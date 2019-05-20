using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Week4.Models
{
    public class Serie
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int SerieID { get; set; }

        [Unique, NotNull]
        public string Title { get; set; }

        public string Description { get; set; }

        [NotNull]
        public int YearStarted { get; set; }

        public int YearEnded { get; set; }

        [NotNull]
        public int NumberOfEpesodes { get; set; }

        [NotNull]
        public int NumberOfSeasons { get; set; }
    }
}
