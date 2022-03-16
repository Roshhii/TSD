using TSD.Linq.Task1.Lib;
using TSD.Linq.Task1.Lib.Model;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class Tasks
{

    public static void Main(string[] args)
    {
        Top3();
        Earned5Percent();
        Question4();
        Average();
        BestMoments();
        listToXML();
        readXML();
    }

    public static void Top3()
    {
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> listGoldPrices = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();

        IEnumerable<GoldPrice> orderingListGoldPricesDescending =
        from listOrdered in listGoldPrices
        orderby listOrdered.Price descending
        select listOrdered;

        IEnumerable<GoldPrice> orderingListGoldPricesAscendng =
        from listOrdered in listGoldPrices
        orderby listOrdered.Price ascending
        select listOrdered;

        List<GoldPrice> top3highest = orderingListGoldPricesDescending.Take(3).ToList();
        Console.WriteLine("TOP3 highest:");
        Console.WriteLine("1: " + top3highest[0].Price);
        Console.WriteLine("2: " + top3highest[1].Price);
        Console.WriteLine("3: " + top3highest[2].Price);

        Console.WriteLine("-----------------");

        List<GoldPrice> top3lowest = orderingListGoldPricesAscendng.Take(3).ToList();
        Console.WriteLine("TOP3 lowest:");
        Console.WriteLine("1: " + top3lowest[0].Price);
        Console.WriteLine("2: " + top3lowest[1].Price);
        Console.WriteLine("3: " + top3lowest[2].Price);

        Console.WriteLine("-----------------");


        using StreamWriter file = new("C:\\Users\\auffr\\Documents\\semestre_pologne\\tech_soft_dev\\tasks-2-3-4.txt", append: true);
        file.WriteLineAsync("TOP3 highest:" + " 1: " + top3highest[0].Price + "; 2: " + top3highest[1].Price + "; 3: " + top3highest[2].Price).GetAwaiter().GetResult();
        file.WriteLineAsync("------------------------------------------").GetAwaiter().GetResult();

        /* try
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\auffr\\Documents\\semestre_pologne\\tech_soft_dev\\top3.txt");
            sw.WriteLine("TOP3 highest:");
            sw.WriteLine("1: " + top3highest[0].Price);
            sw.WriteLine("2: " + top3highest[1].Price);
            sw.WriteLine("3: " + top3highest[2].Price);
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        } */


    }

    public static void Earned5Percent()
    {
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> listGoldPrices = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 01, 31)).GetAwaiter().GetResult();

        IEnumerable<GoldPrice> earned5percents =
        from listJanuary in listGoldPrices
        where listJanuary.Price / listGoldPrices[0].Price >= 1.05
        select listJanuary;

        List<GoldPrice> dayEarned5 = earned5percents.ToList();

        using StreamWriter file = new("C:\\Users\\auffr\\Documents\\semestre_pologne\\tech_soft_dev\\tasks-2-3-4.txt", append: true);
        file.WriteLineAsync("Day of 5%: " + dayEarned5[0].Date).GetAwaiter().GetResult();
        file.WriteLineAsync("------------------------------------------").GetAwaiter().GetResult();

        Console.WriteLine("Day of 5%:");
        Console.WriteLine("Date: " + dayEarned5[0].Date);

        Console.WriteLine("-----------------");
    }

    public static void Question4()
    {
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> listGoldPrices2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();

        listGoldPrices2019.AddRange(listGoldPrices2020);
        listGoldPrices2019.AddRange(listGoldPrices2021);


        IEnumerable<GoldPrice> prices =
        from listPrices in listGoldPrices2019
        orderby listPrices.Price descending
        select listPrices;

        prices = prices.Skip(10);

        List<GoldPrice> listPricesSorted = prices.Take(3).ToList();

        using StreamWriter file = new("C:\\Users\\auffr\\Documents\\semestre_pologne\\tech_soft_dev\\tasks-2-3-4.txt", append: true);
        file.WriteLineAsync("3 days");
        file.WriteLineAsync("Date 1: " + listPricesSorted[0].Date + ", price: " + listPricesSorted[0].Price).GetAwaiter().GetResult();
        file.WriteLineAsync("Date 2: " + listPricesSorted[1].Date + ", price: " + listPricesSorted[1].Price).GetAwaiter().GetResult();
        file.WriteLineAsync("Date 3: " + listPricesSorted[2].Date + ", price: " + listPricesSorted[2].Price).GetAwaiter().GetResult();
        file.WriteLineAsync("------------------------------------------").GetAwaiter().GetResult();

        Console.WriteLine("3 days");
        Console.WriteLine("Date 1: " + listPricesSorted[0].Date + ", price: " + listPricesSorted[0].Price);
        Console.WriteLine("Date 2: " + listPricesSorted[1].Date + ", price: " + listPricesSorted[1].Price);
        Console.WriteLine("Date 3: " + listPricesSorted[2].Date + ", price: " + listPricesSorted[2].Price);

        Console.WriteLine("-----------------");
    }

    public static void Average()
    {
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> listGoldPrices2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();

        IEnumerable<double> prices2019 =
        from listPrices in listGoldPrices2019
        select listPrices.Price;

        double average2019 = prices2019.ToList().Average();

        IEnumerable<double> prices2020 =
        from listPrices in listGoldPrices2020
        select listPrices.Price;

        double average2020 = prices2020.ToList().Average();

        IEnumerable<double> prices2021 =
        from listPrices in listGoldPrices2021
        select listPrices.Price;

        double average2021 = prices2021.ToList().Average();

        using StreamWriter file = new("C:\\Users\\auffr\\Documents\\semestre_pologne\\tech_soft_dev\\tasks-8-9.txt", append: true);
        file.WriteLineAsync("Average 2019: " + average2019).GetAwaiter().GetResult();
        file.WriteLineAsync("Average 2020: " + average2020).GetAwaiter().GetResult();
        file.WriteLineAsync("Average 2021: " + average2021).GetAwaiter().GetResult();
        file.WriteLineAsync("------------------------------------------").GetAwaiter().GetResult();

        Console.WriteLine("Average 2019: " + average2019);
        Console.WriteLine("Average 2020: " + average2020);
        Console.WriteLine("Average 2021: " + average2021);
        Console.WriteLine("-----------------");
    }

    public static void BestMoments()
    {
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> listGoldPrices2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2022 = goldClient.GetGoldPrices(new DateTime(2022, 01, 01), new DateTime(2022, 03, 13)).GetAwaiter().GetResult();

        listGoldPrices2019.AddRange(listGoldPrices2020);
        listGoldPrices2019.AddRange(listGoldPrices2021);
        listGoldPrices2019.AddRange(listGoldPrices2022);


        IEnumerable<GoldPrice> lowestPrices =
        from listPrices in listGoldPrices2019
        orderby listPrices.Price ascending
        select listPrices;

        List<GoldPrice> lowestDay = lowestPrices.Take(1).ToList();
        Console.WriteLine("Best day to buy: " + lowestDay[0].Date);

        IEnumerable<GoldPrice> highestPrices =
        from listPrices in listGoldPrices2019
        orderby listPrices.Price descending
        select listPrices;

        List<GoldPrice> highestDay = highestPrices.Take(1).ToList();
        Console.WriteLine("Best day to sell: " + highestDay[0].Date);

        Console.WriteLine("The return of investment: " + (highestDay[0].Price - lowestDay[0].Price));

        using StreamWriter file = new("C:\\Users\\auffr\\Documents\\semestre_pologne\\tech_soft_dev\\tasks-8-9.txt", append: true);
        file.WriteLineAsync("Best day to buy: " + lowestDay[0].Date).GetAwaiter().GetResult();
        file.WriteLineAsync("Best day to sell: " + highestDay[0].Date).GetAwaiter().GetResult();
        file.WriteLineAsync("The return of investment: " + (highestDay[0].Price - lowestDay[0].Price)).GetAwaiter().GetResult();
        file.WriteLineAsync("------------------------------------------").GetAwaiter().GetResult();
    }

    public static void listToXML()
    {
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> listGoldPrices2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> listGoldPrices2022 = goldClient.GetGoldPrices(new DateTime(2022, 01, 01), new DateTime(2022, 03, 13)).GetAwaiter().GetResult();


        listGoldPrices2019.AddRange(listGoldPrices2020);
        listGoldPrices2019.AddRange(listGoldPrices2021);
        listGoldPrices2019.AddRange(listGoldPrices2022);
        
        XDocument file = new XDocument(new XElement("List_of_prices",
        from prices in listGoldPrices2019
        select new XElement("Gold",
               new XElement("Date", prices.Date),
               new XElement("Price", prices.Price)
        )));

        file.Declaration = new XDeclaration("1.0", "utf-8", "true");
        file.Save("C:\\Users\\auffr\\Documents\\semestre_pologne\\tech_soft_dev\\ListOfPrice.xml");

        Console.WriteLine("XML file created.");
    }

    public static void readXML()
    {
        XDocument file = XDocument.Load("C:\\Users\\auffr\\Documents\\semestre_pologne\\tech_soft_dev\\ListOfPrice.xml");
        printPrices(file);
    }

    public static void printPrices(XDocument file)
    {
        foreach (XElement price in file.Root.Elements())
        {
            Console.WriteLine("Date:" + price.Element("Date").Value);
            Console.WriteLine("Price:" + price.Element("Price").Value);

        }
    }



}