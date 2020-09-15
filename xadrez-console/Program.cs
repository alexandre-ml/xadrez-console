using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao p = new Posicao(3, 4);
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            Console.WriteLine("A posição é: " + p);

            Tela.imprimirTabuleiro(tabuleiro);

            //Console.ReadLine
        }
    }
}
