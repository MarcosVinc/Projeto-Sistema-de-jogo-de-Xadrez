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

                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.Write("Origem: ");
                    Posicao origem  = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.ExecutaMovimento(origem, destino);


                }
                
            }
            catch (TabuleiroExeption tabex) 
            {
                Console.WriteLine(tabex.Message);
            }
            Console.ReadLine();
            

            
          
        }
    }
}
