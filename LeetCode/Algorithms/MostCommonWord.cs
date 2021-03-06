﻿using LeetCode.Utils;
using System;
using System.Collections.Generic;

namespace LeetCode.Algorithms
{
    public class MostCommonWord
    {
        /* LeetCode #819. Most Common Word
         * Given a paragraph and a list of banned words, return the most frequent word that
         * is not in the list of banned words.  It is guaranteed there is at least one
         * word that isn't banned, and that the answer is unique.
         * Words in the list of banned words are given in lowercase, and free of punctuation.
         * Words in the paragraph are not case sensitive.  The answer is in lowercase.*/
        public static void RunCode()
        {
            string paragraph = @"
                Now is the winter of our discontent
                Made glorious summer by this sun of York;
                And all the clouds that lour'd upon our house
                In the deep bosom of the ocean buried.
                Now are our brows bound with victorious wreaths;
                Our bruised arms hung up for monuments;";
            string[] banned = new string[] { "this", "that", "these", "those", "the", "a" };
            Console.WriteLine($"    MostCommonWord: {GetMostCommonWord(paragraph, banned)}");
        }

        static string GetMostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> bannedWords = new HashSet<string>();
            foreach (string word in banned)
            {
                bannedWords.Add(word);
            }

            HashMap<string, int> counts = new HashMap<string, int>();
            foreach (string word in paragraph.Replace("[^a-zA-Z]", "").Split(" "))
            {
                if (!bannedWords.Contains(word))
                {
                    counts.Put(word, counts.GetOrDefault(word, 0) + 1);
                }
            }

            string result = "";
            foreach (string key in counts.Keys())
            {
                if (result.Equals("") || counts.GetOrDefault(key, 0) > counts.GetOrDefault(result, 0))
                {
                    result = key;
                }
            }

            return result;
        }
    }
}
