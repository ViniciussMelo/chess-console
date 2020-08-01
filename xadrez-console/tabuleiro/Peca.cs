namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tab { get; set; }

        #region CTOR
        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Tab = tab;
            Cor = cor;
            QteMovimentos = 0;
        }
        #endregion

        #region IncrementarQteMovimentos
        public void IncrementarQteMovimentos()
        {
            QteMovimentos++;
        }
        #endregion

        #region DecrementarQteMovimentos
        public void DecrementarQteMovimentos()
        {
            QteMovimentos--;
        }
        #endregion

        #region ExisteMovimentosPossiveis
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] matriz = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (matriz[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #region MovimentosPossiveis
        public bool MovimentosPossiveis(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        #endregion

        #region MovimentosPossiveis
        public abstract bool[,] MovimentosPossiveis();
        #endregion
    }
}
