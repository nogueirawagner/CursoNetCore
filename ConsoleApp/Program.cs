using System;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Bem vindo ao curso C# na 3Way.";
            int idade = 20;
            idade.ContadorConsole(3);
            Console.WriteLine("A quantidade é {0}", s.ContadorPalavras());
        }
    }
}
