namespace tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        #region CTOR
        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        #endregion

        #region DefinirValores
        public void DefinirValores(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return Linha
                + ", "
                + Coluna;
        }
        #endregion
    }
}
