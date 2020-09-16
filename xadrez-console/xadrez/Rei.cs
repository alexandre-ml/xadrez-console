using System;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca 
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : 
            base(tabuleiro, cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.AtualizaPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //ne
            pos.AtualizaPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //direita
            pos.AtualizaPosicao(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //se
            pos.AtualizaPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //baixo
            pos.AtualizaPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //so
            pos.AtualizaPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //esquerda
            pos.AtualizaPosicao(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //no
            pos.AtualizaPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && MovimentoValido(pos))
                mat[pos.Linha, pos.Coluna] = true;

            return mat;
        }
    }
}
