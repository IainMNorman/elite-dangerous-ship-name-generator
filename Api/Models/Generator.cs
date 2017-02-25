using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public sealed class Generator
    {
        private static volatile Generator instance;
        private static object syncRoot = new Object();

        private List<Word> Words;
        private List<Word> SaneWords;
        private Random random = new Random();

        private Generator()
        {
            Words = new List<Word>();
            SaneWords = new List<Word>();
            Setup();
        }

        public static Generator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Generator();
                    }
                }

                return instance;
            }
        }

        private void Setup()
        {
            var lines = File.ReadLines(HttpContext.Current.Server.MapPath("~/mobyposf.txt"));

            foreach (var line in lines)
            {
                var split = line.Split('\t');
                Words.Add(new Word { Phrase = split[0], Parts = split[1], Frequency = int.Parse(split[2]) });
            }
        }


        public List<string> GetNames(List<string> patterns, int limit, bool alliterate = false, int count = 1)
        {
            SaneWords = Words.Where(w => w.Frequency >= limit).ToList();
            var names = new List<string>();

            for (int i = 0; i < count; i++)
            {
                names.Add(GetName(patterns.OrderBy(o => Guid.NewGuid()).First(), limit, alliterate));
            }

            return names;
        }

        private string GetName(string pattern, int limit, bool alliterate = false)
        {
            var parts = pattern.Split(' ');
            var nameParts = new string[parts.Length];
            var count = 0;
            var firstLetter = "";
            if (alliterate)
            {
                int num = random.Next(0, 26);
                firstLetter = ((char)('a' + num)).ToString();
            }

            foreach (var part in parts)
            {
                if (part.Length == 1)
                {
                    nameParts[count] = GetRandomWord(part, limit, alliterate, firstLetter);
                }
                else if (part.Contains("&"))
                {
                    var subparts = part.Split('&');
                    nameParts[count] = GetRandomWordAnd(subparts.ToList(), limit, alliterate, firstLetter);
                }
                else if (part.Contains("|"))
                {
                    var subparts = part.Split('|');
                    nameParts[count] = GetRandomWordOr(subparts.ToList(), limit, alliterate, firstLetter);
                }
                else if (part.Contains("["))
                {
                    nameParts[count] = part.Substring(1, part.Length - 2);
                }
                count++;
            }
            var name = "";
            foreach (var n in nameParts)
            {
                name += System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(n) + " ";
            }

            return name.Substring(0, name.Length -1);
        }

        private string GetRandomWord(string part, int limit, bool alliterate = false, string firstLetter = "a")
        {
            if (part == "T") return "The";

            IEnumerable<Word> possibleWords;

            if (alliterate)
            {
                possibleWords = SaneWords.Where(w => 
                    w.Parts.Contains(part) 
                    && w.Frequency >= limit 
                    && w.Phrase.ToLower().StartsWith(firstLetter)
                    );
            }
            else
            {
                possibleWords = SaneWords.Where(w => w.Parts.Contains(part) && w.Frequency >= limit);
            }

            if (!possibleWords.Any()) return "";
            return possibleWords.OrderBy(o => Guid.NewGuid()).First().Phrase;
        }

        private string GetRandomWordAnd(List<string> parts, int limit, bool alliterate = false, string firstLetter = "a")
        {
            IEnumerable<Word> possibleWords;

            if (alliterate)
            {
                possibleWords = SaneWords.Where(w =>
                    parts.All(a => w.Parts.Contains(a)
                    && w.Frequency >= limit
                    && w.Phrase.ToLower().StartsWith(firstLetter))
                    );
            }
            else
            {
                possibleWords = SaneWords.Where(w => parts.All(a => w.Parts.Contains(a) && w.Frequency >= limit));
            }



            if (!possibleWords.Any()) return "";
            return possibleWords.ElementAt(random.Next(0, possibleWords.Count())).Phrase;
        }

        private string GetRandomWordOr(List<string> parts, int limit, bool alliterate = false, string firstLetter = "a")
        {
            IEnumerable<Word> possibleWords;
            if (alliterate)
            {
                possibleWords = SaneWords.Where(w =>
                    parts.Any(a => w.Parts.Contains(a)
                    && w.Frequency >= limit
                    && w.Phrase.ToLower().StartsWith(firstLetter))
                    );
            }
            else
            {
                possibleWords = SaneWords.Where(w => parts.Any(a => w.Parts.Contains(a) && w.Frequency >= limit));
            }

            if (!possibleWords.Any()) return "";
            return possibleWords.ElementAt(random.Next(0, possibleWords.Count())).Phrase;
        }
    }
}