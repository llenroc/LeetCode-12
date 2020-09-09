﻿using System;
using System.Collections.Generic;

namespace LeetCode.Algorithms
{
    public class MostCommonWord
    {
        // LeetCode #819. Most Common Word
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

            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (string word in paragraph.Replace("[^a-zA-Z]", "").Split(" "))
            {
                if (!bannedWords.Contains(word))
                {
                    //Java: count.put(word, counts.getOrDefault(word, 0) + 1);
                    if (counts.ContainsKey(word))
                    {
                        counts[word] = counts[word] + 1;
                    }
                    else
                    {
                        counts[word] = 1;
                    }
                }
            }

            string result = "";
            foreach (string key in counts.Keys)
            {
                if (result.Equals("") || counts.GetValueOrDefault(key, 0) > counts.GetValueOrDefault(result, 0))
                {
                    result = key;
                }
            }

            return result;
        }
    }
}