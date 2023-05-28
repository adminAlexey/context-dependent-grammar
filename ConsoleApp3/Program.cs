using Microsoft.VisualBasic;
using System;

class Program
{
    public static bool regularLeft(string arr)
    {
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == '=')
                index = i + 1;
        string rightSide = arr[index..];
        if (char.IsUpper(rightSide[0]) && rightSide.Length > 1)
        {
            return true;
        }
        return false;
    }
    public static bool regularRight(string arr)
    {
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == '=')
                index = i + 1;
        string rightSide = arr[index..];
        if (char.IsUpper(arr[^1]) && rightSide.Length > 1)
        {
            return true;
        }
        return false;
    }
    public static bool kS(string arr)
    {
        int index = 0;
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == '=')
                index = i;
        string leftSide = arr[..(index-1)];
        for (int i = 0; i < leftSide.Length; i++)
        {
            if (char.IsUpper(leftSide[i]))
                count++;
        }
        if (count == leftSide.Length)
        {
            return true;
        }
        return false;
    }
    public static bool kZ(string arr)
    {
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == '=')
                index = i + 1;
        string rightSide = arr[index..];
        string leftSide = arr[..(index - 1)];
        if (leftSide[0] == rightSide[0] && leftSide[^1] == rightSide[^1] && rightSide.Length > 2 && leftSide.Length > 2)
        {
            return true;
        }
        return false;
    }

    public static void Main()
    {
        Console.WriteLine("L(G) = {a^n * b^m * c^k | n, m ,k > 0}");
        string str1 = "S=a";
        string str2 = "A=ab";
        string str3 = "B=cAb";
        Console.WriteLine("\n" + str1 + "\n" + str2 + "\n" + str3 + "\n");

        
        if (regularLeft(str1) && regularLeft(str2) && regularLeft(str3))
            Console.WriteLine("Регулярная левая грамматика типа 3");
        else if (regularRight(str1) && regularRight(str2) && regularRight(str3))
            Console.WriteLine("Регулярная правая грамматика типа 3");
        else if (kS(str1) && kS(str2) && kS(str3))
            Console.WriteLine("Контекстно свободная грамматика типа 2");
        else if (kZ(str1) && kZ(str2) && kZ(str3))
            Console.WriteLine("Контекстно зависимая грамматика типа 1");
        else
            Console.WriteLine("Грамматика типа 0");
    }
}