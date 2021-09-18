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
            
            int idxWithMaxLen = 1;
            int rightBoundary = 2;
            int centerPtr = 1;
            
            void Expand(int center)
            {
                bool BothSidesWithinWorkingSet(int i) => center - i >= 0 && center + i < workingSet.Length;
                
                int left = center - 1;
                int right = center + 1;
                
                for (int i = 1; BothSidesWithinWorkingSet(i); i++)
                {
                    left = center - i;
                    right = center + i;
                    
                    if (workingSet[left] == workingSet[right])
                    {
                        lengths[center] = i;
                    }
                    else
                    {
                        break;
                    }
                }
                
                rightBoundary = right;
                centerPtr = center;
                idxWithMaxLen = lengths[idxWithMaxLen] < lengths[center] ? center : idxWithMaxLen;
            }

            for (int i = 2; i < workingSet.Length; i++)
            {
                if (i < rightBoundary)
                {
                    int mirror = 2 * centerPtr - i;
                    int idx = rightBoundary - i;
                    lengths[i] = Math.Min(idx, mirror);
                }
                
                Expand(i);
            }

            int palindromeLen = lengths[idxWithMaxLen];
            int palindromeStart = (idxWithMaxLen - palindromeLen) / 2 ;
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