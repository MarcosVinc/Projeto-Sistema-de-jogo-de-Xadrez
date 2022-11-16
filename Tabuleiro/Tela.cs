using System;
using Tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace Tabuleiro
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida) 
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("TURNO: " + partida.turno);
            if (!partida.terminada) 
            {
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else 
            {
                Console.WriteLine("XEQUEMATE !");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }

            

        }
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida) 
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            imprirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;

        }
        public static void imprirConjunto(HashSet<Peca> conjunto) 
        {
            Console.Write("[");
            foreach (Peca x in conjunto) 
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }
        public static void imprimirTabuleiro(Tabuleirox tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write( 8 - i + " ");

                for (int j = 0; j < tab.colunas; j++) 
                {                 
                     Tela.imprimirPeca(tab.peca(i,j));                                 
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void imprimirTabuleiro(Tabuleirox tab, bool[,] posPosiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posPosiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else 
                    { 
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Tela.imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }
        public static PosicaoXadrez lerPosicaoXadrez() 
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);

        
        }
        public static void imprimirPeca(Peca peca) 
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;

                }
                Console.Write(" ");
            }
        }
    }
}
