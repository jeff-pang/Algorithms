using System;
using System.Text;
using System.Transactions;

namespace Manacher
{
    public class Answer
    {
        public string FindPalindrome(string s)
        {
            char[] workingSet = InitializePaddedChars(s);

            var lengths = new int[s.Length * 2 + 1];
            lengths[1] = 1;
            
            int maxPos = 1;
            int boundary = 2;
            int center = 1;
            
            void Expand(int middle)
            {
                bool BothSidesWithinWorkingSet(int i) => middle - i >= 0 && middle + i < workingSet.Length;
                
                int left = middle - 1;
                int right = middle + 1;
                
                for (int i = 1; BothSidesWithinWorkingSet(i); i++)
                {
                    left = middle - i;
                    right = middle + i;
                    
                    if (workingSet[left] == workingSet[right])
                    {
                        lengths[middle] = i;
                    }
                    else
                    {
                        break;
                    }
                }
                
                boundary = right;
                center = middle;
                maxPos = lengths[maxPos] < lengths[middle] ? middle : maxPos;
            }

            for (int i = 2; i < workingSet.Length; i++)
            {
                if (i < boundary)
                {
                    int mirror = 2 * center - i;
                    int idx = boundary - i;
                    lengths[i] = Math.Min(idx, mirror);
                }
                
                Expand(i);
            }

            int palindromeLen = lengths[maxPos];
            int palindromeStart = (maxPos - palindromeLen) / 2 ;
            return s.Substring(palindromeStart, palindromeLen);
        }
        
        private char[] InitializePaddedChars(string s)
        {
            char[] chars = new char[s.Length * 2 + 1];
            chars[^1] = '|';
            for (int i = 0; i < s.Length; i++)
            {
                var evenPosition = i * 2;
                var oddPosition = evenPosition + 1;
                chars[evenPosition] = '|';
                chars[oddPosition] = s[i];
            }

            return chars;
        }
    }
}