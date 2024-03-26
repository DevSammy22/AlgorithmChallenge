using System;

namespace AlgorithmChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var result = AlgorithmQuestions.Encode("scout", 1939);
            //foreach(var i in result)
            //{
            //    Console.WriteLine(i);
            //}

            //var result = AlgorithmQuestions.IsAnagram("value", "lueva");
            //Console.WriteLine(result);
            //AlgorithmQuestions.SumOfDifferences();
            // int[] num = { 2, 7, 11, 15 };
            //var result =  AlgorithmQuestions.NumberSum(num, 17);

            // foreach (var item in result)
            // {
            //     Console.WriteLine(item);
            // }
            //var result = AlgorithmQuestions.StringToInt2("790");
            //Console.WriteLine(result);
            //var result = AlgorithmQuestions.Solution("end", "yt");
            var result = AlgorithmQuestions.TotalPoints(new[] { "3:1", "2:2", "0:1" });
            Console.WriteLine(result);
        }

    }
}
