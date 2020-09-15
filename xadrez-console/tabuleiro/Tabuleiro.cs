namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca GetPeca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca GetPeca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidaPosicao(pos);

            return GetPeca(pos) != null;
        }

        public void PosicionarPeca(Peca peca, Posicao pos)
        {
            if (ExistePeca(pos)) 
                throw new TabuleiroException("Já Existe uma peça na posição!");

            pecas[pos.Linha, pos.Coluna] = peca;
            peca.posicao = pos;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha > Linhas ||
                pos.Coluna < 0 || pos.Coluna > Colunas)
                return false;
            
            return true;
        }

        void ValidaPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
                throw new TabuleiroException("Posição Inválida!");
        }
    }
}
