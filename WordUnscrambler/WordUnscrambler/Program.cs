using System;
using System.Collections.Generic;
using System.Linq;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class Program
    {
            private static readonly FileReader _fileReader = new FileReader();
            private static readonly WordMatcher _wordMatcher = new WordMatcher();

            static void Main(string[] args)
            {
                try
                {
                    bool continueWordUnscramble = true;
                    do
                    {
                        Console.WriteLine(Constants.Constants.OptionsOnHowToEnterScrambledWords);
                        var option = Console.ReadLine() ?? string.Empty;

                        switch (option.ToUpper())
                        {
                            case Constants.Constants.File:
                                Console.Write(Constants.Constants.EnterScrambledWordsViaFile);
                                ExecuteScrambledWordsInFileScenario();
                                break;
                            case Constants.Constants.Manual:
                                Console.Write(Constants.Constants.EnterScrambledWordsManually);
                                ExecuteScrambledWordsManualEntryScenario();
                                break;
                            default:
                                Console.WriteLine(Constants.Constants.EnterScrambledWordsOptionNotRecognized);
                                break;
                        }

                        var continueDecision = string.Empty;
                        do
                        {
                            Console.WriteLine(Constants.Constants.OptionsOnContinuingTheProgram);
                            continueDecision = (Console.ReadLine() ?? string.Empty);

                        } while (
                            !continueDecision.Equals(Constants.Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                            !continueDecision.Equals(Constants.Constants.No, StringComparison.OrdinalIgnoreCase));

                        continueWordUnscramble = continueDecision.Equals(Constants.Constants.Yes, StringComparison.OrdinalIgnoreCase);

                    } while (continueWordUnscramble);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(Constants.Constants.ErrorProgramWillBeTerminated + ex.Message);
                }
            }

            private static void ExecuteScrambledWordsManualEntryScenario()
            {
                var manualInput = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = manualInput.Split(',');
                DisplayMatchedUnscrambledWords(scrambledWords);
            }

            private static void ExecuteScrambledWordsInFileScenario()
            {
                try
                {
                    var filename = Console.ReadLine() ?? string.Empty;
                    string[] scrambledWords = _fileReader.Read(filename);
                    DisplayMatchedUnscrambledWords(scrambledWords);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(Constants.Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
                }
            }

            private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
            {
                string[] wordList = _fileReader.Read(Constants.Constants.WordListFileName);

                List<MatchedWords> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

                if (matchedWords.Any())
                {
                    foreach (var matchedWord in matchedWords)
                    {
                        Console.WriteLine(Constants.Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                    }
                }
                else
                {
                    Console.WriteLine(Constants.Constants.MatchNotFound);
                }
            }
        }
    }
