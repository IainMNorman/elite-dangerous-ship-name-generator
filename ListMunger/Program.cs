using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ListMunger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FreqWord> FreqWords = new List<FreqWord>();

            var lines = File.ReadLines(@"C:\Users\IainM\Copy\My Projects\RandomShipNames\WebUI\1_1_all_fullalpha.txt");
            foreach (var line in lines)
            {
                var split = line.Split('\t');

                if (split[1] == "@")
                {
                    FreqWords.Add(new FreqWord { Phrase = HttpUtility.HtmlDecode(split[3]).Replace("_", " "), Frequency = int.Parse(split[4]) });
                }
                else
                {
                    FreqWords.Add(new FreqWord { Phrase = HttpUtility.HtmlDecode(split[1]).Replace("_", " "), Frequency = int.Parse(split[4]) });
                }
            }

            var mobyfile = File.OpenText(@"C:\Users\IainM\Copy\My Projects\RandomShipNames\WebUI\mobypos.txt");
            File.Delete(@"C:\Users\IainM\Copy\My Projects\RandomShipNames\WebUI\mobyposf.txt");
            var newfile = File.CreateText(@"C:\Users\IainM\Copy\My Projects\RandomShipNames\WebUI\mobyposf.txt");
            string mobyLine;
            while ((mobyLine = mobyfile.ReadLine()) != null)
            {
                var split = mobyLine.Split('\t');
                var freqword = FreqWords.FirstOrDefault(x => x.Phrase == split[0]) 
                    ?? new FreqWord { Frequency = 0};
                newfile.WriteLine("{0}\t{1}", mobyLine, freqword.Frequency);
                Console.WriteLine("{0}\t{1}", mobyLine, freqword.Frequency);
            }

            newfile.Close();
            mobyfile.Close();
            
        }


    }

    public class FreqWord
    {
        public string Phrase { get; set; }
        public int Frequency { get; set; }
    }
}
