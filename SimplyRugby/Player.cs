using System;

namespace SimplyRugby
{
    class Player
    {
        // A template Object for the Player's Details
        public string name { get; set; }

        public DateTime dob { get; set; }

        public string email { get; set; }

        public int phoneNo { get; set; }

        public int sru { get; set; }

        public string squad { get; set; }

        // A template for the Player's Skills, start with 0 then the Coach can change these
        public DateTime lastChanged { get; set; }

        public int standard { get; set; }

        public int spin { get; set; }

        public int pop { get; set; }

        public int front { get; set; }

        public int rear { get; set; }

        public int side { get; set; }

        public int scrabble { get; set; }

        public int drop { get; set; }

        public int punt { get; set; }

        public int grubber { get; set; }

        public int goal { get; set; }

        // A template for the Player's Skills Comments
        public string passingComments { get; set; }

        public string tacklingComments { get; set; }

        public string kickingComments { get; set; }

    }
}
