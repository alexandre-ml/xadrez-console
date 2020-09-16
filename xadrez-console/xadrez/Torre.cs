using System;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) :
            base(tabuleiro, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            if (Posicao.Linha - 1 > 0)
            {
                pos.AtualizaPosicao(Posicao.Linha - 1, Posicao.Coluna);
                while (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                    if (MovimentoValido(pos) == false)
                        break;

                    pos.Linha--;
                }
            }

            if (Posicao.Coluna + 1 < 8)
            {
                //direita
                pos.AtualizaPosicao(Posicao.Linha, Posicao.Coluna + 1);
                while (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                    if (MovimentoValido(pos) == false)
                        break;

                    pos.Coluna++;
                }
            }

            if (Posicao.Linha + 1 < 8)
            {
                //baixo
                pos.AtualizaPosicao(Posicao.Linha + 1, Posicao.Coluna);
                while (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                    if (MovimentoValido(pos) == false)
                        break;

                    pos.Linha++;
                }
            }

            if (Posicao.Coluna - 1 > 0)
            {
                //esquerda
                pos.AtualizaPosicao(Posicao.Linha, Posicao.Coluna - 1);
                while (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                    if (MovimentoValido(pos) == false)
                        break;

                    pos.Coluna--;
                }
            }
            return mat;
        }
    }
}