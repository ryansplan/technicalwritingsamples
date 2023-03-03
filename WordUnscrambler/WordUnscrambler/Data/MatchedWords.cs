namespace WordUnscrambler.Data
{
    struct MatchedWords
    {
        public string ScrambledWord { get; set; }
        public string UnscrambledWord { get; set; }
        public int Word { get; internal set; }
    }
}
