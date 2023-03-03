using System;
using System.Collections.Generic;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    class WordMatcher
    {
        public List<MatchedWords> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWords>();

            foreach (var scrambledWord in scrambledWords) 
            {
                foreach (var unscrambledWord in wordList)
                {
                    if (scrambledWord.Equals(unscrambledWord, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWords(scrambledWord, unscrambledWord));
                    }
                    else 
                    { 
                    var scrambledWordArray = scrambledWord.ToCharArray();
                    var wordArray = unscrambledWord.ToCharArray();
                        
                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                    var sortedScrambledWord = new string(scrambledWordArray);
                    var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase)) 
                        {
                            matchedWords.Add(BuildMatchedWords(scrambledWord, unscrambledWord));
                        }

                    }
                }
            }

            return matchedWords; 
        }

        private MatchedWords BuildMatchedWords(string scrambledWords, string unScrambledWords) 
        {
            MatchedWords matchedWords = new MatchedWords
            {
                ScrambledWord = scrambledWords,
                UnscrambledWord = unScrambledWords
            };
            
            return matchedWords;
        }
    }
}
