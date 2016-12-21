using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using System.Net.Http;

namespace GuranRateHost
{
    public class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:8080/";

            using (WebApp.Start<StartUp>(url: baseAddress))
            {
                Console.Write("Service Listening at : " + baseAddress);
                System.Threading.Thread.Sleep(-1);
                
            }
        }
    }
}
