namespace SimplyRugby
{
    class Player
    {
        // A template Object for the Player's Details
        public string name { get; set; }

        public int age { get; set; }

        public string squad { get; set; }

        // A template for the Player's Skills, start with 0 then the Coach can change these
        public int tackling { get; set; }

        public int passing { get; set; }

        public int running { get; set; }

        public int throwing { get; set; }

        public string comments { get; set; }
    }
}
