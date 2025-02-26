using System;
using System.Collections.Generic;

class PrimeNumberFinder
{
    static void Main()
    {
        // 获取用户输入
        int lower = GetValidInput("请输入下限：");
        int upper = GetValidInput("请输入上限：");

        // 确保上下限顺序正确
        if (lower > upper)
        {
            int temp = lower;
            lower = upper;
            upper = temp;
        }

        // 查找素数
        List<int> primes = FindPrimesInRange(lower, upper);

        // 输出结果
        PrintPrimes(primes, lower, upper);
    }

    // 获取有效整数输入
    static int GetValidInput(string prompt)
    {
        int number;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("输入无效，请重新输入整数：");
        }
        return number;
    }

    // 判断是否为素数
    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // 查找范围内的素数
    static List<int> FindPrimesInRange(int start, int end)
    {
        List<int> primes = new List<int>();
        for (int num = start; num <= end; num++)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
        }
        return primes;
    }

    // 格式化输出素数
    static void PrintPrimes(List<int> primes, int lower, int upper)
    {
        if (primes.Count == 0)
        {
            Console.WriteLine($"在 {lower} 到 {upper} 之间没有找到素数");
            return;
        }

        Console.WriteLine($"\n在 {lower} 到 {upper} 之间的素数：");
        for (int i = 0; i < primes.Count; i++)
        {
            Console.Write($"{primes[i],-5}");  // 每个数字占5位左对齐

            // 每10个换行
            if ((i + 1) % 10 == 0)
            {
                Console.WriteLine();
            }
        }

        // 确保最后有换行
        if (primes.Count % 10 != 0)
        {
            Console.WriteLine();
        }
    }
}