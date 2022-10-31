using xadrez;
using System;
using Tabuleiro;

namespace ProjetoXadrex
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleirox tab = new Tabuleirox(8,8);

            tab.colocarPeca(new Torre ( Cor.Laranja, tab) , new Posicao(0, 0));
            tab.colocarPeca( new Rei(Cor.Branca, tab) , new Posicao(1, 3));
            tab.colocarPeca(new Rei(Cor.Branca, tab) , new Posicao(2, 4));
            Tela.imprimirTabuleiro(tab);
            Console.WriteLine();
          
        }
    }
}
