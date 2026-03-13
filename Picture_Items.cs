using System;
using System.Collections.Generic;
using System.Text;

namespace Match_picture
{
    public class Picture_items
    {
        // ID της εικόνας (π.χ. 1,2,3...)
        public int Id { get; set; }

        // Το αρχείο εικόνας (π.χ. "1.png")
        public string ImagePath { get; set; }

        // Αν έχει ήδη βρεθεί το ζευγάρι
        public bool IsMatched { get; set; }

        // Αν είναι προσωρινά ανοιχτή
        public bool IsRevealed { get; set; }

        public Picture_items(int id, string path)
        {
            Id = id;
            ImagePath = path;
            IsMatched = false;
            IsRevealed = false;
        }
    }

}
