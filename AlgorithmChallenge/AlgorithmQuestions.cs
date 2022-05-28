using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmChallenge
{
    public static class AlgorithmQuestions
    {

    //    Digital Cypher assigns to each letter of the alphabet unique number.For example:
    //     a  b  c  d  e  f  g  h  i  j  k  l  m
    //     1  2  3  4  5  6  7  8  9  10 11 12 13
    //     n o  p  q  r  s  t  u  v  w   x  y z
    //    14 15 16 17 18 19 20 21 22 23 24 25 26

    //   Instead of letters in encrypted word we write the corresponding number, eg.The word scout:
    //      s   c  o   u   t
    //      19  3  15  21  20

    //  Then we add to each obtained digit consecutive digits from the key.For example.In case of key equal to 1939 :
    //      s   c  o  u   t
    //      19  3 15  21  20
    //    + 1  9  3   9   1
    //      ---------------
    //      20 12 18 30 21

    //       m  a  s  t  e  r  p  i   e  c  e
    //       13  1 19 20  5 18 16  9  5  3  5
    //     + 1  9  3  9  1  9  3  9  1   9  3
    //      -----------------------------------
    //       14 10 22 29  6 27 19 18  6  12 8


    //      Task
    //Write a function that accepts str string and key number and returns an array of integers representing encoded str.

    //Input / Output
    //The str input string consists of lowercase characters only.
    //The key input number is a positive integer.
    //Example:
    //      Encode("scout",1939);  ==>  [ 20, 12, 18, 30, 21]
    //      Encode("masterpiece",1939);  ==>  [ 14, 10, 22, 29, 6, 27, 19, 18, 6, 12, 8]
        
        public static int[] Encode(string str, int n)
        {
            int[] result = new int[str.Length]; // where to keep our result;
            var key = n.ToString(); // convert the number to string so you can index them
            for (int i = 0; i < str.Length; i++)
            {
                var letterNumber = (int)str[i] - 96; // casting the stri[i] into int will make you get its ASCII value. Then when you substract its ASCII value from 96, you get the Digital Cypher of the letter.
                var numberKey = key[i % key.Length] - 48;
                result[i] = letterNumber + numberKey;
            }
            return result;
        }

        //Write a method, that will get an integer array as parameter and will process every number from this array.

        //Return a new array with processing every number of the input-array like this:

        //If the number has an integer square root, take this, otherwise square the number.

        //Example
        //[4, 3, 9, 7, 2, 1] -> [2,9,3,49,4,1]
        //Notes
        //The input array will always contain only positive numbers, and will never be empty or null.

        public static int[] SquareOrSquareRoot(int[] array)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                var number = array[i];
                if (Math.Sqrt(number) == (int)Math.Sqrt(number))
                {
                    result.Add((int)Math.Sqrt(number));
                }
                else
                {
                    result.Add((int)Math.Pow(number, 2));
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// alternative solution
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] SquareOrSquareRoot2(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                var number = array[i];
                if (Math.Sqrt(number) == (int)Math.Sqrt(number))
                {
                    result[i] = (int)Math.Sqrt(number);
                }
                else
                {
                    result[i] = (int)(Math.Pow(number, 2));
                }
            }
            return result;
        }

        //Write a function that takes in a string of one or more words, and returns the same string, but with all five or more letter words reversed(Just like the name of this Kata).
        //Strings passed in will consist of only letters and spaces.Spaces will be included only when more than one word is present.
        //Examples:
        //spinWords( "Hey fellow warriors" ) => returns "Hey wollef sroirraw".
        //spinWords( "This is a test") => returns "This is a test"
        //spinWords( "This is another test" ) => returns "This is rehtona test"
        public static string SpinWords(string sentence)
        {
            string result = "";
            var array = sentence.Split(' ');
            foreach (var item in array)
            {
                if (item.Length <= 4)
                {
                    result += item;
                    result += " ";
                }
                else
                {
                    for (int i = item.Length - 1; i >= 0; i--)
                    {
                        result += item[i];
                    }
                    result += " ";
                }
            }
            return result.Trim();
        }


        //A palindrome is a word, phrase, number, or other sequence of characters which reads the same backward or forward.
        //This includes capital letters, punctuation, and word dividers.
        //Implement a function that checks if something is a palindrome. If the input is a number, convert it to string first.


        public static bool IsPalindrome(object line)
        {
            var initial = line.ToString().ToLower();
            var final = "";
            for (int i = initial.Length - 1; i >= 0; i--)
            {
                final += initial[i];
            }

            return final == initial;
        }

        /// <summary>
        /// Alternative solutions
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool IsPalindrome2(object line)
        {
            var initial = line.ToString().ToLower();
            var final = "";
            for (int i = initial.Length - 1; i >= 0; i--)
            {
                final += initial[i];
            }

            if (final == initial)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
