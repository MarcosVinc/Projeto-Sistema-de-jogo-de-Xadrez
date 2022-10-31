namespace Tabuleiro
{
    class Tabuleirox
    {
        private Peca[,] pecas;
        public int linhas { get; set; }
        public int colunas { get; set; }

        public Tabuleirox(int linhas, int colunas) 
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        public Peca peca(int linha, int coluna) 
        {
            return pecas[linha, coluna];
        }
       
    }
}
 