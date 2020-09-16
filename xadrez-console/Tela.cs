using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirPartida(Partida partida)
        {
            Tela.ImprimirTabuleiro(partida.Tabuleiro);
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("\n\nTurno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
        }

        public static void ImprimirPecasCapturadas(Partida partida)
        {
            Console.WriteLine("\nPeças Capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));

            Console.Write("\nPretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;

        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");

            foreach(Peca x in conjunto)
                Console.Write(x + " ");

            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for(int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                     ImprimirPeca(tabuleiro.GetPeca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool [,] movimentos)
        {
            ConsoleColor fundo = Console.BackgroundColor;
            ConsoleColor aux = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.BackgroundColor = fundo;
                Console.Write(8 - i + " ");                

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    Console.BackgroundColor = fundo;

                    if (movimentos[i, j])
                        Console.BackgroundColor = aux;

                    ImprimirPeca(tabuleiro.GetPeca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");

            Console.BackgroundColor = fundo;
        }

        public static void ImprimirPeca(Peca peca)
        {        
            if (peca == null)
                Console.Write("- ");
            else
            {
                ConsoleColor aux = Console.ForegroundColor;

                if (peca.Cor == Cor.Preta)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(peca);

                Console.Write(" ");

                Console.ForegroundColor = aux;
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine().ToUpper();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }
    }
}
