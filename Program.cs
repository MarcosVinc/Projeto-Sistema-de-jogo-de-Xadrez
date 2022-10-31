
using System;
using Tabuleiro;

namespace ProjetoXadrex
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleirox tab = new Tabuleirox(8,8);
            Tela.imprimirTabuleiro(tab);
            Console.WriteLine();
          
        }
    }
}
