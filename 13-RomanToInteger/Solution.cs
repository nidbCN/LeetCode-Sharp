﻿using System;
using System.Collections.Generic;

namespace RomanToInteger
{
    public class Solution
    {
        private readonly Dictionary<string, int> romanDict = new()
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 },
            { "IV", 4 },
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 },
        };

        private bool TryParse(char ch, out int num)
            => TryParse(ch.ToString(), out num);

        private bool TryParse(char ch1, char ch2, out int num)
            => TryParse(new string(new char[] { ch1, ch2 }), out num);

        private bool TryParse(string s, out int num)
            => romanDict.TryGetValue(s, out num);

        public int RomanToInt(string s)
        {
            if (s is null) throw new ArgumentNullException(nameof(s));
            if (s == string.Empty) return 0;

            var result = 0;
            var prevChar = s[0];

            for (var i = 1; i < s.Length; i++)
            {
                var romanChar = s[i];
                if (!TryParse(prevChar, romanChar, out var charResult))
                {
                    if (!TryParse(romanChar, out var romanCharResult))
                    {
                        throw new ArgumentException($"Unknow char {romanChar}");
                    }
                    else
                    {
                        result += romanCharResult;
                    }
                }
                else
                {
                    result += charResult;
                }
            }

            return result;
        }
    }
}
