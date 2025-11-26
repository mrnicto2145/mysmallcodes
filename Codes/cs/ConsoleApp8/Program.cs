using System;
using System.Diagnostics;

namespace Hello;

class Program
{
    static void Main()
    {
        var d = new SpecificSet([5, 3, 2, 8, 6, 4]);
        d.Add(5);
        Console.WriteLine(d.FindNext(50));
        d.Add(7);
        d.Add(0);
        d.Add(100);
        Console.WriteLine(d.FindNext(50));
        for (var i = 0; i< d.arr.Length; i++)
        {
            Console.Write(d.arr[i]);
            Console.Write(" ");
        }
        Console.WriteLine();
    }

    public static int SBinSearch(int[] array, int find, int left, int right)
    {
        var middle = left + (right - left) / 2;
        if (array[middle] == find || middle == left || middle == right) return middle;
        if (array[middle] > find)
        {
            return SBinSearch(array, find, left, middle);
        }
        return SBinSearch(array, find, middle, right);
    }

    public static int[] BubbleSort(int[] array)
    {
        var sarray = new int[array.Length];
        Array.Copy(array,sarray, array.Length);
        for (int i = 0; i< array.Length; i++)
        {
            for (int j = 0; j < array.Length-1; j++)
            {
                if (sarray[j] > sarray[j + 1])
                {
                    var t = sarray[j];
                    sarray[j] = sarray[j+1];
                    sarray[j+1] = t;
                }
            }
        }
        return sarray;
    }
}

class SpecificSet
{
    public int[] arr;

    public SpecificSet(int[] array)
    {
        arr = Program.BubbleSort(array);        
    }

    public int FindNext(int x)
    {
        var i = Program.SBinSearch(arr, x, 0, arr.Length);
        if (arr[i] <= x) i++;
        if (i >= arr.Length)
        {
            return -1;
        }
        return arr[i];
    }

    public void Add(int x)
    {
        var i = Program.SBinSearch(arr, x, 0, arr.Length);
        if (arr[i] == x) return;
        if (arr[i] < x) i++;
        var narr = new int[arr.Length + 1];
        for (int j = 0; j < i; j++)
        {
            if (j == arr.Length) break;
            narr[j] = arr[j];
        }
        narr[i] = x;
        for (int j = i + 1; j < arr.Length + 1; j++)
        {
            narr[j] = arr[j-1];
        }
        arr = narr;
    }
}
