using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var numbers = input.Split(' ').Select(x => int.Parse(x)).ToArray();

        Parser parser = new Parser();
        int[] A;
        int[] B;
        parser.ParseA(input, out A);
        parser.ParseB(input, out B);

        foreach (var item in B)
        {
            //Если B[k] = 0, ничего не делать;
            if (item == 0)
            {
            }
            //Если B[k]< 0 и последовательность A имеет недостаточно элементов, операции должны остановиться и выводить номер окончания -1.
            else if (item < 0 && item * -1 > A.Length)
            {
                Console.Write("-1");
                return;
                //goto Found;
            }
            //Если B[k]> 0, прибавьте число B[k] к концу последовательности A B[k] раз;
            else if (item > 0)
            {
                AddItemToArray(ref A, item);
            }
            //Если B[k]< 0, удалите последний | Б[к] | числа из последовательности А;
            else if (item < 0)
            {
                RemoveLastItemToArray(ref A, item * -1);
            }
        }
        PrintArray(ref A);
    }

    static void RemoveLastItemToArray(ref int[] A, int n)
    {
        int NewN = A.Length - n;
        int[] newA = new int[NewN];

        for (int i = 0; i < NewN; i++)
        {
            newA[i] = A[i];
        }
        A = newA;
    }
    static void AddItemToArray(ref int[] A, int value)
    {
        int[] newA = new int[A.Length + value];
        int ALength = A.Length;
        int newALength = newA.Length;
        for (int i = 0; i < ALength; i++)
        {
            newA[i] = A[i];
        }
        for (int i = ALength; i < newALength; i++)
        {
            newA[i] = value;
        }
        A = newA;
    }
    static void PrintArray(ref int[] A)
    {
        foreach (var item in A)
        {
            Console.Write(item + " ");
        }
        Console.Write("-1");
    }
    class Parser
    {
        private String[] Separator = new String[] { "-1" };

        public void ParseA(string input, out int[] A)
        {
            var employeesInput = input.Split(Separator, StringSplitOptions.None)[0].Trim();
            A = employeesInput.Split(' ').Select(x => int.Parse(x)).ToArray();
        }
        public void ParseB(string input, out int[] B)
        {
            var employeesInput = input.Split(Separator, StringSplitOptions.None)[1].Trim();
            try
            {
                B = employeesInput.Split(' ').Select(x => int.Parse(x)).ToArray();
            }
            catch (Exception)
            {
                B = new int[1] { 0 };
            }
        }
    }
}