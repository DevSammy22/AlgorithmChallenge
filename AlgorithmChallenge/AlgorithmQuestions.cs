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



        //Complete the function/method so that it returns the url with anything after the anchor (#) removed.
        //Example:
        //"www.codewars.com#about" --> "www.codewars.com"
        //"www.codewars.com?page=1" -->"www.codewars.com?page=1"

        public static string RemoveUrlAnchor(string url)
        {
            int index = url.IndexOf("#");
            if (index == -1)
            {
                return url;
            }
            string result = url.Substring(0, index);
            return result;
        }

        // Usually when you buy something, you're asked whether your credit card number,
        // phone number or answer to your most secret question is still correct.
        // However, since someone could look over your shoulder, you don't want that shown on your screen. Instead, we mask it.
        // Your task is to write a function maskify, which changes all but the last four characters into '#'.
        // "4556364607935616" --> "############5616"
        //  "64607935616" -->      "#######5616"
        //            "1" -->                "1"
        //             "" -->                 ""

        // // "What was the name of your first pet?"

        // "Skippy" --> "##ippy"

        // "Nananananananananananananananana Batman!"
        // -->
        // "####################################man!"

        public static string Maskify(string cc)
        {

            if (cc.Length <= 4 || cc == null) // or if(cc.Length <= 4 || cc == "")
            {
                return cc;
            }

            string masked = new string('#', cc.Length - 4);
            var last = cc.Substring(cc.Length - 4);
            return masked + last;

        }

        //    An isogram is a word that has no repeating letters, consecutive or non-consecutive.
        //    Implement a function that determines whether a string that contains only letters is an isogram.
        //    Assume the empty string is an isogram. Ignore letter case.
        // "Dermatoglyphics" --> true
        // "aba" --> false
        // "moOse" --> false (ignore letter case)

        public static bool IsIsogram(string str)
        {
            if (str == "")
            {
                return true;
            }
            string lower = str.ToLower();
            for (int i = 0; i < lower.Length; i++)
            {
                for (int j = i + 1; j < lower.Length; j++)
                {
                    if (lower[i] == lower[j])
                    {
                        return false;
                    }
                    //return true;
                }
            }
            return true;
        }


        // Given a string made up of letters a, b, and/or c, switch the position
        // of letters a and b (change a to b and vice versa). Leave any incidence of c untouched.
        // Example:
        // 'acb' --> 'bca'
        // 'aabacbaa' --> 'bbabcabb'

        public static string Switcheroo(string x)
        {
            string result = "";
            string lower = x.ToLower();
            for (int i = 0; i < lower.Length; i++)
            {
                var letter = lower[i];
                if (letter == 'a')
                {
                    result += 'b';
                }
                else if (letter == 'b')
                {
                    result += 'a';
                }
                else
                {
                    result += letter;
                    //or result += 'c';
                }
            }
            return result;

        }

        // Deoxyribonucleic acid (DNA) is a chemical found in the nucleus of 
        // cells and carries the "instructions" for the development and functioning of living organisms.
        // If you want to know more: http://en.wikipedia.org/wiki/DNA
        // In DNA strings, symbols "A" and "T" are complements of each other, as "C" and "G". Your function receives one side of the DNA (string, except for Haskell); you need to return the other complementary side. DNA strand is never empty or there is no DNA at all (again, except for Haskell).
        // More similar exercise are found here: http://rosalind.info/problems/list-view/ (source)
        // Example: (input --> output)
        // "ATTGC" --> "TAACG"
        // "GTAT" --> "CATA"
        public static string MakeComplement(string dna)
        {
            string result = "";
            foreach (var item in dna)
            {
                if (item == 'A')
                {
                    result += 'T';
                }
                else if (item == 'T')
                {
                    result += 'A';
                }
                else if (item == 'C')
                {
                    result += 'G';
                }
                else if (item == 'G')
                {
                    result += 'C';
                }
            }
            return result;

        }

        //   In this little assignment you are given a string of space separated numbers, and have to return the highest and lowest number.
        //   Examples
        //   Kata.HighAndLow("1 2 3 4 5");  // return "5 1"
        //   Kata.HighAndLow("1 2 -3 4 5"); // return "5 -3"
        //   Kata.HighAndLow("1 9 3 4 -5"); // return "9 -5"

        public static string HighAndLow(string numbers)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            string[] numSplit = numbers.Split(" ");
            for (int i = 0; i < numSplit.Length; i++)
            {
                var num = int.Parse(numSplit[i]);
                if (num > max)
                {
                    max = num;
                }
                if (num < min)
                {
                    min = num;
                }
            }
            return max + " " + min;
        }

        //   Write a program to determine if a string contains only unique characters.
        //   Return true if it does and false otherwise.
        //   The string may contain any of the 128 ASCII characters.
        //   Characters are case-sensitive, e.g. 'a' and 'A' are considered different characters.

        public static bool HasUniqueChars(string str)
        {
            var lower = str.ToLower();
            for (int i = 0; i < lower.Length; i++)
            {
                for (int j = i + 1; j < lower.Length; j++)
                {
                    if (lower[i] == lower[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //   Enjoying your holiday, you head out on a scuba diving trip!
        //   Disaster!! The boat has caught fire!!
        //   You will be provided a string that lists many boat related items.
        //   If any of these items are "Fire" you must spring into action.
        //   Change any instance of "Fire" into "~~". Then return the string.
        //   Go to work!
        public static string FireFight(string s)
        {
            return s.Replace("Fire", "~~");

        }

        //Alternative

        public static string FireFight2(string s)
        {
            string[] arr = s.Split(" ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "Fire")
                {
                    arr[i] = "~~";
                }
            }
            return string.Join(" ", arr);
        }

        // Given an array of numbers (in string format), you must return a string.
        // The numbers correspond to the letters of the alphabet in reverse order: a=26, z=1 etc.
        // You should also account for '!', '?' and ' ' that are represented by '27', '28' and '29' respectively.
        // All inputs will be valid.

        public static string Switcher(string[] x)
        {
            var result = "";
            var alpha = "-zyxwvutsrqponmlkjihgfedcba!? ";
            for (int i = 0; i < x.Length; i++)
            {
                var num = alpha[int.Parse(x[i])];
                result += num;

            }
            return result;

        }
        //Alternative
        public static string Switcher2(string[] x)
        {
            var result = "";
            var alpha = "zyxwvutsrqponmlkjihgfedcba!? ";
            for (int i = 0; i < x.Length; i++)
            {
                var num = alpha[int.Parse(x[i]) - 1];
                result += num;

            }
            return result;
        }

        //Alternative
        public static string Switcher3(string[] x)
        {
            var result = "";
            var alpha = "-zyxwvutsrqponmlkjihgfedcba!? ";
            foreach (string a in x)
            {
                var res = alpha[int.Parse(a)];
                result += res;
            }
            return result;
        }

        // Your car is old, it breaks easily. The shock absorbers are gone
        // and you think it can handle about 15 more bumps before it dies totally.
        // Unfortunately for you, your drive is very bumpy!
        // Given a string showing either flat road (_) or bumps (n).
        // If you are able to reach home safely by encountering 15 bumps or less, return Woohoo!, otherwise return Car Dead

        public static string Bump(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'n')
                {
                    count++;
                }
            }
            if (count <= 15)
            {
                return "Woohoo!";
            }
            else
            {
                return "Car Dead";
            }
        }

        public static string Gordon(string a)
        {
            List<string> result = new List<string>();
            var cap = a.ToUpper();
            var arr = cap.Split(" ");

            foreach (var word in arr)
            {
                var res = word.Replace("A", "@").Replace("E", "*").Replace("I", "*").Replace("O", "*").Replace("U", "*") + "!!!!";

                result.Add(res);
            }
            return string.Join(" ", result);

        }


        // Given a number, Find if it is Tidy or not .
        // Number passed is always Positive .
        // Return the result as a Boolean

        // Input >> Output Examples
        // tidyNumber (12) ==> return (true)
        // Explanation:
        // The number's digits { 1 , 2 } are in non-Decreasing Order (i.e) 1 <= 2 .

        // tidyNumber (32) ==> return (false)
        // Explanation:
        // The Number's Digits { 3, 2} are not in non-Decreasing Order (i.e) 3 > 2 .

        // tidyNumber (1024) ==> return (false)
        // Explanation:
        // The Number's Digits {1 , 0, 2, 4} are not in non-Decreasing Order as 0 <= 1 .

        // tidyNumber (13579) ==> return (true)
        // Explanation:
        // The number's digits {1 , 3, 5, 7, 9} are in non-Decreasing Order .

        // tidyNumber (2335) ==> return (true)
        // Explanation:
        // The number's digits {2 , 3, 3, 5} are in non-Decreasing Order , Note 3 <= 3

        public static bool TidyNumber(int n)
        {
            var res = n.ToString();
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = i + 1; j < res.Length; j++)
                {
                    if (res[i] > res[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Alternative

        public static bool TidyNumber1(int n)
        {
            //Do Some Magic
            var res = n.ToString();
            for (int i = 0; i < res.Length - 1; i++)
            {

                if (res[i] > res[i + 1])
                {
                    return false;
                }
            }
            return true;

        }


        // Determine the total number of digits in the integer (n>=0) given as input to the function.
        // For example, 9 is a single digit, 66 has 2 digits and 128685 has 6 digits. Be careful to avoid overflows/underflows.
        // All inputs will be valid.

        public static int Digits(ulong n)
        {

            var res = n.ToString();
            int count = 0;
            foreach (var item in res)
            {
                count++;
            }
            return count;
        }

        //Alternative

        public static int Digits1(ulong n)
        {
            var res = n.ToString();
            return res.Length;

        }


        // You are going to be given a word. Your job is to return the middle character of the word. If the word's length is odd, return the middle character. If the word's length is even, return the middle 2 characters.
        // #Examples:
        // Kata.getMiddle("test") should return "es"
        // Kata.getMiddle("testing") should return "t"
        // Kata.getMiddle("middle") should return "dd"
        // Kata.getMiddle("A") should return "A"

        public static string GetMiddle(string s)
        {

            if (s.Length == 1)
            {
                return s;
            }

            if (s.Length % 2 == 0)
            {
                return s.Substring(((s.Length / 2) - 1), 2);
            }
            else
            {
                return s.Substring((s.Length / 2), 1);
            }
        }

        // Given a mixed array of number and string representations of integers,
        // add up the string integers and subtract this from the total of the non-string integers.
        // Return as a number.


        public static int DivCon(Object[] objArray)
        {
            int strings = 0, ints = 0;
            foreach (var item in objArray)
            {
                if (item is string)
                {
                    strings += int.Parse(item.ToString());
                }
                else if (item is int)
                {
                    ints += (int)(item);
                }
            }
            return (ints - strings);
        }

        // This time no story, no theory. The examples below show you how to write function accum:
        // Examples:
        // accum("abcd") -> "A-Bb-Ccc-Dddd"
        // accum("RqaEzty") -> "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy"
        // accum("cwAt") -> "C-Ww-Aaa-Tttt"
        // The parameter of accum is a string which includes only letters from a..z and A..Z.


        public static String Accum(string s)
        {
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (result.Length > 0)
                {
                    result += "-";
                }
                string cap = s.ToUpper();
                result += cap[i];
                for (int j = 0; j < i; j++)
                {
                    string lower = s.ToLower();
                    result += lower[i];

                    //OR result += char.ToLower(cap[i]);
                }
            }
            return result;
        }

        public static String Accum1(string s)
        {
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (result.Length > 0)
                {
                    result += "-";
                }
                result += char.ToUpper(s[i]);
                for (int j = 0; j < i; j++)
                {
                    result += char.ToLower(s[i]);
                }
            }
            return result;
        }

        //Alternative
        public static String Accum2(string s)
        {
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {

                result += char.ToUpper(s[i]);
                for (int j = 0; j < i; j++)
                {
                    result += char.ToLower(s[i]);
                }
                if (i != s.Length - 1)
                {
                    result += "-";
                }
            }
            return result;
        }

        // Suzuki needs help lining up his students!
        // Today Suzuki will be interviewing his students to ensure they are progressing in their training. He decided to schedule the interviews based on the length of the students name in descending order. The students will line up and wait for their turn.
        // You will be given a string of student names. Sort them and return a list of names in descending order.
        // Here is an example input:
        // string = 'Tadashi Takahiro Takao Takashi Takayuki Takehiko Takeo Takeshi Takeshi'
        // Here is an example return from your function:
        //  lst = ['Takehiko',
        //         'Takayuki',
        //         'Takahiro',
        //         'Takeshi',
        //         'Takeshi',
        //         'Takashi',
        //         'Tadashi',
        //         'Takeo',
        //         'Takao']
        // Names of equal length will be returned in reverse alphabetical order (Z->A) such that:
        // string = "xxa xxb xxc xxd xa xb xc xd"
        // Returns
        // ['xxd', 'xxc', 'xxb', 'xxa', 'xd', 'xc', 'xb', 'xa']

        public static String[] LineupStudents(String a)
        {
            string[] names = a.Split(" ");
            Array.Sort(names);
            names = names.OrderBy(x => x.Length).ToArray();
            Array.Reverse(names);
            return names;
        }

        // Given the triangle of consecutive odd numbers:
        //              1
        //           3     5
        //        7     9    11
        //    13    15    17    19
        // 21    23    25    27    29
        // ...
        // Calculate the sum of the numbers in the nth row of this triangle (starting at index 1) e.g.: (Input --> Output)
        // 1 -->  1
        // 2 --> 3 + 5 = 8

        public static long RowSumOddNumbers(long n)
        {
            return (long)Math.Pow(n, 3);
        }

        public static long RowSumOddNumbers1(long n)
        {
            return n * n * n;
        }




        // Given an array/list [] of integers , Construct a product array Of same size Such
        // That prod[i] is equal to The Product of all the elements of Arr[] except Arr[i].
        // Notes
        // Array/list size is at least 2 .
        // Array/list's numbers Will be only Positives
        // Repetition of numbers in the array/list could occur.
        // Input >> Output Examples
        // productArray ({12,20}) ==>  return {20,12}
        // Explanation:
        // The first element in prod [] array 12 is the product of all array's elements except the first element
        // The second element 20 is the product of all array's elements except the second element .
        // productArray ({1,5,2}) ==> return {10,2,5}
        // productArray ({10,3,5,6,2}) return ==> {180,600,360,300,900}

        public static int[] ProductArray(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int product = array[0];
                for (int j = 1; j < array.Length; j++)
                {
                    product *= array[j];
                }
                result[i] = product / array[i];
            }
            return result;
        }


        //Input = 123; Output = 321;
        public static int Number(int value)
        {
            string result = "";
            string res = value.ToString();
            for (int i = res.Length - 1; i >= 0; i--)
            {
                result += res[i];
            }

            return Convert.ToInt32(result);
        }

        //Alternative
        public static int Number2(int value)
        {
            int result = 0;
            while (value != 0)
            {
                int a = value % 10;
                value = value / 10;
                result = result * 10 + a;
            }
            return result;
        }



        // The Stanton measure of an array is computed as follows:
        // count the number of occurences for value 1 in the array.
        // Let this count be n. The Stanton measure is the number of times that n appears in the array.
        // Write a function which takes an integer array and returns its Stanton measure.
        // Examples
        // The Stanton measure of [1, 4, 3, 2, 1, 2, 3, 2] is 3, because 1 occurs 2 times in the array and 2 occurs 3 times.
        // The Stanton measure of [1, 4, 1, 2, 11, 2, 3, 1] is 1, because 1 occurs 3 times in the array and 3 occurs 1 time.

        public static int StantonMeasure(int[] arr)
        {
            //
            int count = 0;
            int counti = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)

                {
                    count++;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == count)
                {
                    counti++;
                }
            }
            return counti;
        }

        // Your team is writing a fancy new text editor
        // and you've been tasked with implementing the line numbering.
        // Write a function which takes a list of strings and returns each line prepended by the correct number.
        // The numbering starts at 1. The format is n: string. Notice the colon and space in between.
        // Examples: (Input --> Output)
        // [] --> []
        // ["a", "b", "c"] --> ["1: a", "2: b", "3: c"]

        public static List<string> Number(List<string> lines)
        {
            //your code goes here
            List<string> result = new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {
                var res = (i + 1) + ": " + lines[i];
                result.Add(res);
            }
            return result;
        }

        public static List<string> Number2(List<string> lines)
        {
            //your code goes here
            List<string> result = new List<string>();
            if (lines.Count == 0)
            {
                return result;
            }

            for (int i = 0; i < lines.Count; i++)
            {
                var res = (i + 1) + ": " + lines[i];
                result.Add(res);
            }

            return result;
        }

        // You will be given an array and a limit value.
        // You must check that all values in the array are below or equal to the limit value.
        // If they are, return true. Else, return false.
        // You can assume all values in the array are numbers.
        public static bool SmallEnough(int[] a, int limit)
        {
            var result = a.All(x => x <= limit);
            return result;

        }

        public static bool SmallEnough1(int[] a, int limit)
        {
            bool result = a.All(x => x <= limit);
            if (result) return true;
            return false;
        }

        public static bool SmallEnough2(int[] a, int limit)
        {
            List<int> result = new List<int>();
            foreach (var item in a)
            {
                if (item <= limit)
                {
                    result.Add(item);
                }
            }

            if (a.Length == result.Count)
            {
                return true;
            }
            return false;
        }



        // Given an array of integers. Find the maximum product obtained from multiplying 2 adjacent numbers in the array.
        // Notes
        // Array/list size is at least 2.
        // Array/list numbers could be a mixture of positives, negatives also zeroes .
        // Input >> Output Examples
        // adjacentElementsProduct([1, 2, 3]); ==> return 6
        // Explanation:
        // The maximum product obtained from multiplying 2 * 3 = 6, and they're adjacent numbers in the array.
        // adjacentElementsProduct([9, 5, 10, 2, 24, -1, -48]); ==> return 50
        // Explanation:
        // Max product obtained from multiplying 5 * 10  =  50 .
        // adjacentElementsProduct([-23, 4, -5, 99, -27, 329, -2, 7, -921])  ==>  return -14
        // Explanation:
        // The maximum product obtained from multiplying -2 * 7 = -14, and they're adjacent numbers in the array.

        public static int AdjacentElementsProduct(int[] array)
        {
            //int[] result = new int[array.Length];
            List<int> result = new List<int>();
            int product = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                product = array[i] * array[i + 1];
                result.Add(product);

            }
            return result.Max();
        }


        // Given an array of ones and zeroes, convert the equivalent binary value to an integer.
        // Eg: [0, 0, 0, 1] is treated as 0001 which is the binary representation of 1.
        // Examples:
        // Testing: [0, 0, 0, 1] ==> 1
        // Testing: [0, 0, 1, 0] ==> 2
        // Testing: [0, 1, 0, 1] ==> 5
        // Testing: [1, 0, 0, 1] ==> 9
        // Testing: [0, 0, 1, 0] ==> 2
        // Testing: [0, 1, 1, 0] ==> 6
        // Testing: [1, 1, 1, 1] ==> 15
        // Testing: [1, 0, 1, 1] ==> 11
        // However, the arrays can have varying lengths, not just limited to 4.

        public static int binaryArrayToNumber(int[] BinaryArray)
        {
            string result = String.Empty;
            foreach (var item in BinaryArray)
            {
                result += item;
                //Or result += item.ToString();
            }

            return Convert.ToInt32(result, 2);
        }


        // Create a function that returns the sum of the two lowest positive
        // numbers given an array of minimum 4 positive integers. No floats or non-positive integers will be passed.
        // For example, when an array is passed like [19, 5, 42, 2, 77], the output should be 7.
        // [10, 343445353, 3453445, 3453545353453] should return 3453455.

        public static int sumTwoSmallestNumbers(int[] numbers)
        {
            Array.Sort(numbers);
            return (numbers[0] + numbers[1]);
        }

        public static int sumTwoSmallestNumbers1(int[] numbers)
        {
            var result = numbers.OrderBy(i => i).ToArray();
            return result[0] + result[1];
        }

        public static int sumTwoSmallestNumbers2(int[] numbers)
        {
            var sorted = numbers.ToList();
            sorted.Sort();
            return (sorted[0] + sorted[1]);
        }

        // Given a list of integers, determine whether the sum of its elements is odd or even.
        // Give your answer as a string matching "odd" or "even".
        // If the input array is empty consider it as: [0] (array with a zero).

        // Examples:
        // Input: [0]
        // Output: "even"

        // Input: [0, 1, 4]
        // Output: "odd"

        // Input: [0, -1, -5]
        // Output: "even"

        public static string OddOrEven(int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            if (sum % 2 == 0)
            {
                return "even";
            }
            return "odd";
        }

        // Create the function consecutive(arr) that takes an array of integers and
        // return the minimum number of integers needed to make the
        // contents of arr consecutive from the lowest number to the highest number.
        // For example:
        // If arr contains [4, 8, 6] then the output should be 2
        // because two numbers need to be added to the array (5 and 7) to make
        // it a consecutive array of numbers from 4 to 8. Numbers in arr will be unique.

        public static int Consecutive(int[] arr)
        {
            if (arr.Length < 2)
                return 0;
            var result = arr.Max() - arr.Min() - arr.Length + 1;
            // Or var result = arr.Max() - arr.Min() + 1 - arr.Length;
            return result;
        }


        // Write a function that can return the smallest value of an array or the index of that value.
        // The function's 2nd parameter will tell whether it should return the value or the index.
        // Assume the first parameter will always be an array filled with at least 1 number and no duplicates.
        // Assume the second parameter will be a string holding one of two values: 'value' and 'index'.

        // min([1,2,3,4,5], 'value') // => 1
        // min([1,2,3,4,5], 'index') // => 0

        public static int FindSmallest(int[] numbers, string toReturn)
        {
            int min = numbers[0];
            int index = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                    index = i;
                }
            }

            if (toReturn == "value")
            {
                return min;
            }
            else
            {
                return index;
            }

        }


        // Given an array/list [] of n integers , find maximum triplet sum in the array Without duplications .
        // Notes :
        // Array/list size is at least 3 .
        // Array/list numbers could be a mixture of positives , negatives and zeros .
        // Repetition of numbers in the array/list could occur , So (duplications are not included when summing).
        // Input >> Output Examples
        // 1- maxTriSum ({3,2,6,8,2,3}) ==> return (17)
        // Explanation:
        // As the triplet that maximize the sum {6,8,3} in order , their sum is (17)
        // Note : duplications are not included when summing , (i.e) the numbers added only once .
        // 2- maxTriSum ({2,1,8,0,6,4,8,6,2,4}) ==> return (18)
        // Explanation:
        // As the triplet that maximize the sum {8, 6, 4} in order , their sum is (18) ,
        // Note : duplications are not included when summing , (i.e) the numbers added only once .
        // 3- maxTriSum ({-7,12,-7,29,-5,0,-7,0,0,29}) ==> return (41)
        // Explanation:
        // As the triplet that maximize the sum {12 , 29 , 0} in order , their sum is (41) ,
        // Note : duplications are not included when summing , (i.e) the numbers added only once .


        public static int MaxTriSum(int[] a)
        {
            List<int> result = new List<int>();
            Array.Sort(a);
            Array.Reverse(a);
            foreach (var item in a)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }
            if (result.Count < 3)
            {
                return 0;
            }
            return result[0] + result[1] + result[2];
        }
    }
}
    