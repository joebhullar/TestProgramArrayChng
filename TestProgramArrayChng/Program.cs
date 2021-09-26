using System;
using System.Collections.Generic;

namespace TestProgramArrayChng
{
    class Program
    {
        public static List<double> result = new List<double>();
        public static int[] ListOfNumbers { get; set; }
        public static int n = 0;
        public static int sw = 0;
        public static int maxSw = 1;
        public static int firstElementValue = 1;
        public static int ListOfNumbersLength = 1;
        public static string ArrayChallenge(int[] arr)              //Input:{ 5, 2, 4, 6} Output: {2,3,4}");
        {
            firstElementValue = arr[0]; //VALUE OF SLIDING ARRAY GIVEN, N =5 
            ListOfNumbers = new int[arr.Length - 1]; // ListOfNumbers is the array we are working with { , , }
            ListOfNumbersLength = ListOfNumbers.Length; //ListOfNumbersLength is the Length of the array we are working with. = 3
            if (firstElementValue > ListOfNumbers.Length) // if N size > array we have     
                {
                    maxSw = ListOfNumbersLength; // since sw size N is too big for current list of numbers length... we will start with sw =1
                    sw = 1;
          
                }
            else
                {
                    maxSw = firstElementValue;
                    sw = firstElementValue; // sliding window is first element of array IF the array is long enough.

                int i = 1;
                while (i < maxSw)
                {
                    result.Add(i);
                    i++;
                }

            }
            //Console.WriteLine(maxSw);
            //Console.WriteLine(sw);

            Array.Copy(arr, 1, ListOfNumbers, 0, ListOfNumbersLength);


            var currentWindow = GetSlidingWindow(ListOfNumbers);
            result.Add(GetMedianFromCurrentWindow(currentWindow));
            
            GetNextSlidingWindow();

            return string.Join(",", result.ToArray());
        }

        public static int[] GetSlidingWindow(int[] ListOfNumbers)
        {
            try
            {
                var w = new int[sw];
                Array.Copy(ListOfNumbers, n, w, 0, sw);
                Console.WriteLine("MadeItToGetSlidingwindow");
                Console.WriteLine(sw);
                //if (sw < maxSw) 
                //{ sw++; }
                
                return w;
            }
            catch
            {
                return null;
            }

        }
        public static double GetMedianFromCurrentWindow(int[] window)
        {
            Console.WriteLine("getmedianFromCurrentWindow");
            foreach (var item in window)
            {
                Console.WriteLine(item.ToString());
            }
          

            Array.Sort(window);
            if ((window.Length == maxSw) && ((window.Length % 2) == 0))
            {
                var i1 = window.Length / 2;
                var i2 = i1 + 1;
                return (double)(window[i1 - 1] + window[i2 - 1]) / 2;
            }
            else if ((window.Length == maxSw) && ((window.Length % 2) == 1))
            {
                var i = (window.Length - 1) / 2;
                return window[i];

            }
            else if (window.Length == 1)
            {
                return window[0];
            }
            else
            {
                return (double)(window[0] + window[1]) / 2;
            }
        }
        public static void GetNextSlidingWindow()
        {
            if(sw < maxSw)
            {
                sw++;
            }
            else if (sw == maxSw)
            {
                n++;
            }
            else
            {
                sw = maxSw;
            }
            //n++;
            var currentWindow = GetSlidingWindow(ListOfNumbers);
            if (currentWindow != null)
            {
                result.Add(GetMedianFromCurrentWindow(currentWindow));
                GetNextSlidingWindow();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input[] arr= { 5, 2, 4, 6} Output: {2,3,4}");
            Console.WriteLine("Input[] arr= { 3, 1, 3, 5, 10, 6, 4, 3, 1} Output: {1,2,3,5,6,6,4,3}");
           // Console.WriteLine(ArrayChallenge(new int[] { 3, 1, 3, 5, 10, 6, 4, 3, 1 }));
            Console.WriteLine(ArrayChallenge(new int[] { 5, 2, 4, 6}));
            Console.ReadLine();
        }
    }
}
