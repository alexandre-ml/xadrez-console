namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Tabuleiro Tabuleiro { get; protected set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.Posicao = null;
            this.Tabuleiro = tabuleiro;
            this.Cor = cor;
            this.QtdMovimentos = 0;
        }

        public void IncrementaMovimento()
        {
            QtdMovimentos++;
        }

        protected bool MovimentoValido(Posicao pos)
        {
            Peca p = Tabuleiro.GetPeca(pos);

            return p == null || p.Cor != Cor;
        }

        public bool ExisteMovimento()
        {
            bool[,] mat = MovimentosPossiveis();

            for(int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for(int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j])
                        return true;
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();

    }   
}
