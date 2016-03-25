﻿using System;
using System.Net;

namespace apod_api
{
    class Program
    {
        static void Main(string[] args)
        {
            APOD_API apod_api = new APOD_API();
            int action;

            do
            {
                apod_api.sendRequest();
                Console.WriteLine("Title: " + apod_api.apod.title);
                Console.WriteLine("Date: " + apod_api.apod.date.ToShortDateString());
                Console.WriteLine("[1] Standard");
                Console.WriteLine("[2] HD");
                Console.WriteLine("[3] Previous Day");
                Console.WriteLine("[4] Next Day");
                Console.WriteLine("[0] Quit.");
                Console.Write("Enter selection: ");

                action = int.Parse(Console.ReadLine());
                WebClient dl = new WebClient();

                switch (action)
                {
                    case 0:
                        Console.WriteLine("Exiting . . .");
                        break;
                    case 1:
                        Console.WriteLine("Downloading standard photo . . .");
                        dl.DownloadFile(apod_api.apod.url, "apod_" + apod_api.apod.date + ".jpg");
                        Console.WriteLine("Finished downloading.");
                        break;
                    case 2:
                        Console.WriteLine("Downloading hd photo . . .");
                        dl.DownloadFile(apod_api.apod.hdurl, "apod_" + apod_api.apod.date + ".jpg");
                        Console.WriteLine("Finished downloading.");
                        break;
                    case 3:
                        apod_api.setDate(apod_api.apod.date.AddDays(-1));
                        break;
                    case 4:
                        apod_api.setDate(apod_api.apod.date.AddDays(1));
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
            while (action != 0);
        }
    }
}
