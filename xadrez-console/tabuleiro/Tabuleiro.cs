namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca GetPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca GetPeca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
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

            Pecas[pos.Linha, pos.Coluna] = peca;
            peca.Posicao = pos;
        }

        public Peca RetiraPeca(Posicao pos)
        {
            if (GetPeca(pos) == null)
                return null;

            Peca aux = GetPeca(pos);
            Pecas[pos.Linha, pos.Coluna] = null;

            return aux;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas ||
                pos.Coluna < 0 || pos.Coluna >= Colunas)
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
