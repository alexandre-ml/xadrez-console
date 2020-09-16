using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class Partida
    {
        public Tabuleiro Tabuleiro { get; set; }

        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; set; }

        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public Partida()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void FazMovimento(Posicao origem, Posicao dest)
        {
            Peca p = Tabuleiro.RetiraPeca(origem);
            p.IncrementaMovimento();

            Peca pecaCapturada = Tabuleiro.RetiraPeca(dest);
            Tabuleiro.PosicionarPeca(p, dest);

            if (pecaCapturada != null)
                Capturadas.Add(pecaCapturada);
        }

        public void FazJogada(Posicao origem, Posicao dest)
        {
            FazMovimento(origem, dest);
            Turno++;
            AlteraJogador();
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tabuleiro.GetPeca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição escolhida!");

            if (Tabuleiro.GetPeca(pos).ExisteMovimento() == false)
                throw new TabuleiroException("Não há movimentos possíveis!");

            if (JogadorAtual != Tabuleiro.GetPeca(pos).Cor)
                throw new TabuleiroException("A peça de origem não é sua!");
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao dest)
        {
            if (Tabuleiro.GetPeca(origem).PodeMoverPara(dest) == false)
                throw new TabuleiroException("Posição de destino inválida!");
        }

        private void AlteraJogador()
        {
            if (JogadorAtual == Cor.Branca)
                JogadorAtual = Cor.Preta;
            else
                JogadorAtual = Cor.Branca;
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in Capturadas)
                if (x.Cor == cor)
                    aux.Add(x);

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in Capturadas)
                if (x.Cor == cor)
                    aux.Add(x);

            aux.ExceptWith(PecasCapturadas(cor));

            return aux;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.PosicionarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('C', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('C', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('D', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('E', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('E', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('D', 1, new Rei(Tabuleiro, Cor.Branca));

            ColocarNovaPeca('C', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('C', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('D', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('E', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('E', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('D', 8, new Rei(Tabuleiro, Cor.Preta));
        }
    }
}
