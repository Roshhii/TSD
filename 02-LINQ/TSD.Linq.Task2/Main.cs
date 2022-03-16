using TSD.Linq.Task1.Lib;
using TSD.Linq.Task1.Lib.Model;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class Tasks
{

    public static void Main(string[] args)
    {
        Func<int, bool> leapYear = year => DateTime.IsLeapYear(year);
        Console.WriteLine(2014 + " is a leap year? : " + leapYear(2012));

        GenericList<int> list = new GenericList<int>();
        list.Add(5);
        list.Add(8);
        list.Add(4);
        list.Add(2);
        Console.WriteLine(list.Get(3));
        Console.WriteLine(list.Get(22));
        Console.WriteLine(list.isEmpty());
    }
}

// Declare the generic class.
public class GenericList<T>
{
    private List<T> t;
    public GenericList() {
        this.t = new List<T>();
    }
    public void Add(T input) { 
        Random rng = new Random();
        var random = rng.NextDouble();
        if (random > 0.5) {
            t.Add(input);
        } else {
            t.Insert(0, input);
        }
    }
    public T Get(int index) {
        if (index >= 0 && index < t.Capacity) {
            return t[index];
        } else {
            return default(T);
        }
    }
    public bool isEmpty() { 
        return t.Count == 0;
    }
}
