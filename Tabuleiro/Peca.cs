
namespace Tabuleiro
{
     abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get;  protected set; }
        public Tabuleirox tab { get;  protected set; }

        public Peca(Tabuleirox tab, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.qteMovimentos = 0;
            this.tab = tab;
        }
        public void IncrementarQuantidadeDeMovimentos() 
        {
            qteMovimentos++;
        }
        public void DecrementarQuantidadeDeMovimentos()
        {
            qteMovimentos--;
        }
        public bool existeMovimentosPossiveis() 
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++) 
            {
                for (int j = 0; j < tab.colunas; j++) 
                {
                    if (mat[i, j] == true) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool movimentoPossivel(Posicao pos) 
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis(); 

    }
}
