using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Word
    {
        public Word()
        {

        }

        public string Parts { get; set; }
        public string Phrase { get; set; }
        public int Frequency { get; set; }
    }
}