using System;
using Utils;
// current utils: C:\Users\Michael\source\repos\Utils\Utils\bin\Debug\netcoreapp2.2
// email sarah hilby about Anna's soccer
// order mud boots
namespace ChaseHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            ChaseProcessor cp = new ChaseProcessor(@"c:\m\chase.csv");
             
            cp.loadData();
        }
    }
}
