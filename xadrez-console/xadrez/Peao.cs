using tabuleiro;
using xadrez;

namespace xadrez_console.xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez Partida;

        #region CTOR
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida)
            : base(tab, cor)
        {
            Partida = partida;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return "P";
        }
        #endregion

        #region ExisteInimigo
        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }
        #endregion

        #region Livre
        private bool Livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }
        #endregion

        #region MovimentosPossiveis
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Anda para cima
            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                #region EnPassant
                // Para as peças brancas só acontece na linha 3 da matriz
                if(Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if(Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        matriz[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEnPassant)
                    {
                        matriz[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
                #endregion
            }
            //Anda para baixo
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                #region EnPassant
                // Para as peças pretas só acontece na linha 4 da matriz
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        matriz[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEnPassant)
                    {
                        matriz[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
                #endregion
            }

            return matriz;
        }
        #endregion
    }
}
