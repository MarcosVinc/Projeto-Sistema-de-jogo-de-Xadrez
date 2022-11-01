
namespace Tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get;  protected set; }
        public Tabuleirox tab { get;  protected set; }

        public Peca( Cor cor, Tabuleirox tab)
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
    }
}
