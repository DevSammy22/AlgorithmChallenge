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

        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static string SpinWords2(string sentence)
        {
            string result = string.Empty;
            string[] newArr = sentence.Split(" ");
            foreach (string item in newArr)
            {
                if (item.Length >= 5)
                {
                    for (int i = item.Length - 1; i >= 0; i--)
                    {
                        result += item[i];
                    }
                    result += " ";
                }
                else
                {
                    result += item + " ";

                }
            }
            return result.Trim();
        }



        //A palindrome is a word, phrase, number, or other sequence of characters which reads the same backward or forward.
        //This includes capital letters, punctuation, and word dividers.
        //Implement a function that checks if something is a palindrome. If the input is a number, convert it to string first.
        //Example:
        //isPalindrome("anna")   ==> true
        //isPalindrome("walter") ==> false
        //isPalindrome(12321)    ==> true
        //isPalindrome(123456)   ==> false

        public static bool IsPalindrome(object line)
        {
            var initial = line.ToString().ToLower(); //.we convert to string because we are not sure if the input is a number or string.
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

        //An anagram is the result of rearranging the letters of a word to produce a new word(see wikipedia).

        //Note: anagrams are case insensitive

        //Complete the function to return true if the two arguments given are anagrams of each other; return false otherwise.

        //Examples
        //"foefet" is an anagram of "toffee"

        //"Buckethead" is an anagram of "DeathCubeK"


        public static bool IsAnagram(string test, string original)
        {
            if (test.Length != original.Length)
            {
                return false;
            }

            char[] testRes = test.ToLower().ToCharArray();
            Array.Sort(testRes);
            char[] originalRes = original.ToLower().ToCharArray();
            Array.Sort(originalRes);
            for (int i = 0; i < testRes.Length; i++)
            {
                if (testRes[i] != originalRes[i])
                {
                    return false;
                }
            }

            return true;
        }

        //Your task is to sum the differences between consecutive pairs in the array in descending order.
        //Example:
        //[2, 1, 10]  -->  9
        //In descending order: [10, 2, 1]

        //Sum: (10 - 2) + (2 - 1) = 8 + 1 = 9

        //If the array is empty or the array has only one element the result should be 0 (Nothing in Haskell, None in Rust).


        public static int SumOfDifferences(int[] arr)
        {
            var sum = 0;
            if (arr == null || arr.Length == 1)
            {
                return sum;
            }
            Array.Sort(arr); // Sort array in ascending order.
            Array.Reverse(arr); // reverse array
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var curr = arr[i] - arr[i + 1];
                sum += curr;
            }
            return sum;
        }

        //Your friend has been out shopping for puppies(what a time to be alive!)... He arrives back with multiple dogs, and you simply do not know how to respond!

        //By repairing the function provided, you will find out exactly how you should respond, depending on the number of dogs he has.
        //The number of dogs will always be a number and there will always be at least 1 dog.
        //Note: The method below is part of the question

        //public static string HowManyDalmatians(int n)
        //{
        //    List<string> dogs = new List<string>()
        //    {
        //        "Hardly any",
        //        "More than a handful!",
        //        "Woah that's a lot of dogs!",
        //        "101 DALMATIONS!!!"
        //    };
        //    string respond = if (number <= 10) then dogs[0] elseif number <= 50 then dogs[1] elseif number = 101 then dogs[3] else dogs[2];
        //    return respond;
        //}

        public static string HowManyDalmatians(int n)
        {
            if (n <= 10)
            {
                return "Hardly any";
            }
            else if (n <= 50)
            {
                return "More than a handful!";
            }
            else if (n == 101)
            {
                return "101 DALMATIONS!!!";
            }
            else
            {
                return "Woah that's a lot of dogs!";
            }
        }

        /// <summary>
        /// Alternative Solutions
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string HowManyDalmatians2(int n)
        {
            if (n <= 10) return "Hardly any";
            if (n <= 50) return "More than a handful!";
            if (n == 101) return "101 DALMATIONS!!!";
            return "Woah that's a lot of dogs!";
        }

        //You are creating a text-based terminal version of your favorite board game.
        //In the board game, each turn has six steps that must happen in this order: roll the dice, move, combat, get coins, buy more health, and print status.
        //You are using a library that already has the functions below.Create a function named main that calls the functions in the proper order.
        //- `Combat`
        //- `BuyHealth`
        //- `GetCoins`
        //- `PrintStatus`
        //- `RollDice`
        //- `Move`
        /// <summary>
        /// Solution below but commented
        /// </summary>
        //public static int Health = 100;
        //public static int Position = 0;
        //public static int Coins = 0;
        //public static void PlayTurn()
        //{
        //    RollDice();
        //    Move();
        //    Combat();
        //    GetCoins();
        //    BuyHealth();
        //    PrintStatus();

        //}

        //Given a string of words(x), you need to return an array of the words, sorted alphabetically by the final character in each.

        //If two words have the same last letter, they returned array should show them in the order they appeared in the given string.

        //All inputs will be valid.
        public static string[] Last(string x)
        {
            var newArray = x.Split(" ");
            var OrderedArr = newArray.OrderBy(x => x[x.Length - 1]);
            var result = OrderedArr.ToArray();
            return result;
        }

        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string[] Last2(string x)
        {
            string[] newArr = x.Split(" ");
            var orderedArr = newArr.OrderBy(x => x.Last());
            var result = orderedArr.ToArray();
            return result;
        }

        //Complete the function that takes two integers(a, b, where a < b) and return an array of all integers between the input parameters, including them.
        //For example:
        //a = 1
        //b = 4
        //-- > [1, 2, 3, 4]

        public static int[] Between(int a, int b)
        {
            List<int> result = new List<int>();
            for (int i = a; i <= b; i++)
            {
                result.Add(i);
            }
            return result.ToArray();
        }

        /// <summary>
        /// Alternative solutions
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>

        public static int[] Between1(int a, int b)
        {

            List<int> result = new List<int>();
            while (a <= b)
            {
                result.Add(a);
                a++;
            }
            return result.ToArray();
        }

        //Complete the solution so that it splits the string into pairs of two characters.If the string contains an odd number of characters then it should replace the missing second character of the final pair with an underscore ('_').
        //Examples:
        //* 'abc' =>  ['ab', 'c_']
        //* 'abcdef' => ['ab', 'cd', 'ef']
        public static string[] Solution(string str)
        {
            if (str.Length % 2 != 0)
            {
                str += "_";
            }

            List<string> result = new List<string>();
            for (int i = 0; i < str.Length; i += 2)
            {
                char curr = str[i];
                char next = str[i + 1];
                result.Add(curr + "" + next);
            }
            return result.ToArray();
        }

        //Oh no! Ghosts have reportedly swarmed the city.It's your job to get rid of them and save the day!

        //In this kata, strings represent buildings while whitespaces within those strings represent ghosts.

        //So what are you waiting for? Return the building(string) without any ghosts(whitespaces)!

        //Example:
        //ghostBusters("Sky scra per");
        //Should return: "Skyscraper"
        //If the building contains no ghosts, return the string: "You just wanted my autograph didn't you?"
        public static string GhostBusters(string building)
        {
            if (!building.Contains(" "))
            {
                return "You just wanted my autograph didn't you?";
            }
            return building.Replace(" ", "");
        }

        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="building"></param>
        /// <returns></returns>
        public static string GhostBusters1(string building)
        {
            if (!building.Contains(" "))
            {
                return "You just wanted my autograph didn't you?";
            }

            return String.Concat(building.Where(c => !Char.IsWhiteSpace(c)));
        }

        //Write a function that receives two strings and returns n, where n is equal to the number of characters we should shift the first string forward to match the second.
        //The check should be case sensitive.
        //For instance, take the strings "fatigue" and "tiguefa". In this case, the first string has been rotated 5 characters forward to produce the second string, so 5 would be returned.
        //If the second string isn't a valid rotation of the first string, the method returns -1.
        //Examples:
        //"coffee", "eecoff" => 2
        //"eecoff", "coffee" => 4
        //"moose", "Moose" => -1
        //"isn't", "'tisn" => 2
        //"Esham", "Esham" => 0
        //"dog", "god" => -1
        public static int ShiftedDiff(string first, string second)
        {
            if (first.Length - second.Length != 0) // 0r if(first.Length < second.Length)
            {
                return -1;
            }

            string full = second + second;
            int number = full.IndexOf(first);
            return number;

        }

        //Jaden Smith, the son of Will Smith, is the star of films such as The Karate Kid(2010) and After Earth(2013).
        //Jaden is also known for some of his philosophy that he delivers via Twitter.
        //When writing on Twitter, he is known for almost always capitalizing every word.
        //For simplicity, you'll have to capitalize each word, check out how contractions are expected to be in the example below.
        //Your task is to convert strings to how they would be written by Jaden Smith.
        //The strings are actual quotes from Jaden Smith, but they are not capitalized in the same way he originally typed them.
        //Example:
        //Not Jaden-Cased: "How can mirrors be real if our eyes aren't real"
        //Jaden-Cased:     "How Can Mirrors Be Real If Our Eyes Aren't Real"
        public static string ToJadenCase(this string phrase)
        {
            var result = string.Empty;
            var newArr = phrase.Split(' ');
            foreach (var item in newArr)
            {
                var res = item.First().ToString().ToUpper() + item.Substring(1);
                res += " ";
                result += res;

            }
            return result.Trim();
        }
        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string ToJadenCase1(this string phrase)
        {
            string result = string.Empty;
            string[] newArr = phrase.Split(' ');
            foreach (string item in newArr)
            {
                string firstCapital = char.ToUpper(item[0]) + item[1..];  //item[1..] this is called range operator and it is the same thing as item.Substring(1)
                firstCapital += " ";
                result += firstCapital;
            }
            return result.Trim();
        }

        //Return the number(count) of vowels in the given string.
        //We will consider a, e, i, o, u as vowels for this Kata(but not y).
        //The input string will only consist of lower case letters and/or spaces.

        public static int GetVowelCount(string str)
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            var vowelCount = 0;
            str.ToLower();
            str.Trim();
            vowelCount = str.ToLower().Count(x => vowels.Contains(x));
            return vowelCount;
        }
        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetVowelCount1(string str)
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            int vowelCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u')
                {
                    vowelCount++;
                }
            }
            return vowelCount;
        }


        //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        //You may assume that each input would have exactly one solution, and you may not use the same element twice.
        //You can return the answer in any order.

        //Example 1:

        //Input: nums = [2, 7, 11, 15], target = 9
        //Output: [0,1]
        //Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
        //Example 2:

        //Input: nums = [3, 2, 4], target = 6
        //Output: [1,2]
        //Example 3:

        //Input: nums = [3, 3], target = 6
        //Output: [0,1]


        //Constraints:

        //2 <= nums.length <= 104
        //-109 <= nums[i] <= 109
        //-109 <= target <= 109
        //Only one valid answer exists.

        public static int[] NumberSum(int[] numbers, int target)
        {
            List<int> output = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        output.Add(i);
                        output.Add(j);
                    }
                }
            }
            return output.ToArray();
        }

        //Consider the word "abode". We can see that the letter a is in position 1 and b is in position 2.
        //In the alphabet, a and b are also in positions 1 and 2.
        //Notice also that d and e in abode occupy the positions they would occupy in the alphabet, which are positions 4 and 5.
        //Given an array of words, return an array of the number of letters that occupy their positions in the alphabet for each word.
        //For example:
        //solve(["abode", "ABc", "xyzD"]) = [4, 3, 1]
        //See test cases for more examples.
        //Input will consist of alphabet characters, both uppercase and lowercase. No spaces.
        public static List<int> Solve(List<string> arr)
        {
            List<int> result = new List<int>();
            var alp = "abcdefghijklmnopqrstuvwxyz";
            var count = 0;
            foreach (string word in arr)
            {
                var lower = word.ToLower();
                for (int i = 0; i < lower.Length; i++)
                {
                    if ((int)alp[i] == (int)word[i])
                    {
                        count++;
                    }
                }
                result.Add(count);
            }
            return result;
        }

        public static List<int> Solve1(List<string> arr)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            List<int> counters = new List<int>();

            foreach (var word in arr)
            {
                int count = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i].ToString().ToLower() == alphabet[i].ToString())
                        count++;
                }

                counters.Add(count);
            }

            return counters;
        }
        //        var result = new List<int>();

        //            foreach (var word in arr)
        //            {

        //                var lower = word.ToLower();
        //        var count = 0;
        //                for (int i = 0; i<word.Length; i++)
        //                {
        //                  if (lower[i] == alphabet[i]) count++;  
        //                }
        //    result.Add(count);

        //            }

        //return result;


        public static List<int> Solve2(List<string> arr)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int count = 0;
            List<int> result = new List<int>();
            foreach (string item in arr)
            {
                var lowerCase = item.ToLower();
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == alphabet[i])
                    {
                        count++;
                    }
                }
                result.Add(count);
            }

            return result;
        }

     
        //An acronym deliberately formed from a phrase whose initial letters spell out a particular word or words,
        //either to create a memorable name or as a fanciful explanation of a word's origin."Biodiversity Serving Our Nation", or BISON
        //(from https://en.oxforddictionaries.com/definition/backronym)
        //Complete the function to create backronyms. Transform the given string (without spaces) to a backronym,
        //using the preloaded dictionary and return a string of words, separated with a single space(but no trailing spaces).
        //The keys of the preloaded dictionary are uppercase letters A-Z and the values are predetermined words, for example:
        //dict['P'] == "perfect"
        //Examples
        //"dgm" ==> "disturbing gregarious mustache"
        //"lkj" ==> "literal klingon joke"
        public static string MakeBackronym(string s)
        {
            string backronym = String.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                var dict = "disturbing gregarious mustache"; //this is not part of it, I put it there to resolve the error in "dict"
                string word = dict[s.ToUpper()[i]] + " "; // dic is having error becuase it is a foreign function.
                backronym += word;
            }
            return backronym;
        }

        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MakeBackronym2(string s)
        {
            string backronym = String.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                var dict = "disturbing gregarious mustache"; //this is not part of it, I put it there to resolve the error in "dict"
                var upperCase = s.ToUpper()[i];
                string word = dict[upperCase] + " "; // dic is having error becuase it is a foreign function.
                backronym += word;
            }
            return backronym.Trim();
        }

        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MakeBackronym3(string s)
        {
            var dict = "disturbing gregarious mustache"; //this is not part of it, I put it there to resolve the error in "dict"
            string backronym = String.Empty;
            var cap = s.ToUpper();
            for (int i = 0; i < cap.Length; i++)
            {
                string word = dict[cap[i]] + " "; // dic is having error becuase it is a foreign function.
                backronym += word;
            }
            return backronym.Trim();
        }

        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MakeBackronym4(string s)
        {
            var dict = "disturbing gregarious mustache"; //this is not part of it, I put it there to resolve the error in "dict"
            string backronym = String.Empty;
            var cap = s.ToUpper();
            foreach (var letter in cap)
            {
              
                backronym += dict[letter] + " "; //  dic is having error becuase it is a foreign function.
            }
            return backronym.Trim();
        }

        //Covert a number string to a number
        // input: "123", output: 123
        public static int StringToInt(string str)
        {
            int result = 0;
            for (int i = 0;i < str.Length; i++)
            {
                result = result * 10 + ((int)str[i] - 48);
            }
            return result;
        }

        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int StringToInt2(string str)
        {
            int result = 0;
            //var character = str.ToArray(); not neccessary
            foreach(var letter in str)
            {
                result = result * 10 + (int)char.GetNumericValue(letter);
            }
            return (int)result;
        }

        //Complete the solution so that it returns true if the first argument(string) passed in ends with the 2nd argument(also a string).
        //Examples:
        //solution('abc', 'bc') // returns true
        //solution('abc', 'd') // returns false
        public static bool Solution(string str, string ending)
        {
            var result = str.EndsWith(ending);
            if(result)
             return true;
            return false;
        }

        /// <summary>
        /// Alternative
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ending"></param>
        /// <returns></returns>
        public static bool Solution1(string str, string ending)
        {
           return str.EndsWith(ending);

        }
    }
}
    