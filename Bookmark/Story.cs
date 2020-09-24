using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Bookmark
{
    public class Story
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Finished { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public float? Rating { get; set; }
        public string LeftOff { get; set; }
        public string Notes { get; set; }
        public int IsFinished { get; set; }




    }
}
