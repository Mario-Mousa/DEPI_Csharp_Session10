using System;
using System.Collections;
using System.Collections.Generic;

namespace Session10
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("==== Session 10: Choose a question (1-6), or 0 to exit ====");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: Question1(); break;
                    case 2: Question2(); break;
                    case 3: Question3(); break;
                    case 4: Question4(); break;
                    case 5: Question5(); break;
                    case 6: Question6(); break;
                    case 0: Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice."); break;
                }

            } while (choice != 0);
        }

        #region Question 1 - Optimized Bubble Sort
        static void OptimizedBubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                // Shrinks the comparison range each pass: the last i elements
                // are already sorted into place, so there's no need to recheck them.
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                // Optimization: if no swap happened in this whole pass, the array
                // is already sorted, so we can stop early instead of doing all n passes.
                // This turns the BEST case from O(n^2) into O(n) for an already-sorted array.
                if (!swapped)
                    break;
            }
        }

        static void Question1()
        {
            int[] arr = { 5, 1, 4, 2, 8, 0, 2 };

            Console.WriteLine("Before: " + string.Join(", ", arr));
            OptimizedBubbleSort(arr);
            Console.WriteLine("After: " + string.Join(", ", arr));
        }
        #endregion

        #region Question 2 - Range<T>
        static void Question2()
        {
            Range<int> intRange = new Range<int>(10, 50);

            Console.WriteLine("IsInRange(30) = " + intRange.IsInRange(30));   // true
            Console.WriteLine("IsInRange(5) = " + intRange.IsInRange(5));     // false
            Console.WriteLine("Length() = " + intRange.Length());             // 40
        }
        #endregion

        #region Question 3 - Reverse ArrayList in place
        static void ReverseArrayListInPlace(ArrayList list)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left < right)
            {
                object temp = list[left];
                list[left] = list[right];
                list[right] = temp;

                left++;
                right--;
            }
        }

        static void Question3()
        {
            ArrayList list = new ArrayList { 1, 2, 3, 4, 5 };

            Console.WriteLine("Before: " + string.Join(", ", list.ToArray()));
            ReverseArrayListInPlace(list);
            Console.WriteLine("After: " + string.Join(", ", list.ToArray()));
        }
        #endregion

        #region Question 4 - Get even numbers from a list
        static List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> evens = new List<int>();

            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                    evens.Add(num);
            }

            return evens;
        }

        static void Question4()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evens = GetEvenNumbers(numbers);

            Console.WriteLine("Even numbers: " + string.Join(", ", evens));
        }
        #endregion

        #region Question 5 - FixedSizeList<T>
        static void Question5()
        {
            FixedSizeList<string> list = new FixedSizeList<string>(3);

            list.Add("Ahmed");
            list.Add("Sara");
            list.Add("Omar");

            Console.WriteLine("Get(1) = " + list.Get(1));

            try
            {
                list.Add("Mona"); // should throw: list is full
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                Console.WriteLine(list.Get(10)); // should throw: invalid index
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        #endregion

        #region Question 6 - First non-repeated character
        static int FirstNonRepeatedCharIndex(string text)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (charCount[text[i]] == 1)
                    return i;
            }

            return -1;
        }

        static void Question6()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            int index = FirstNonRepeatedCharIndex(text);
            Console.WriteLine("First non-repeated character index: " + index);
        }
        #endregion
    }
}