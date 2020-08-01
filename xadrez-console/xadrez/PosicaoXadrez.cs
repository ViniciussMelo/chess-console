using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        #region CTOR
        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }
        #endregion

        #region ToPosicao
        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
        #endregion
    }
}
