using xadrez;
using System;
using Tabuleiro;

namespace ProjetoXadrex
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Tabuleirox tab = new Tabuleirox(8, 8);
                tab.colocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0));
                tab.colocarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 3));
                tab.colocarPeca(new Rei(Cor.Branca, tab), new Posicao(0, 02));

                Tela.imprimirTabuleiro(tab);
            }
            catch (TabuleiroExeption tabex) 
            {
                Console.WriteLine(tabex.Message);
            }
            Console.ReadLine();
            

            
          
        }
    }
}
