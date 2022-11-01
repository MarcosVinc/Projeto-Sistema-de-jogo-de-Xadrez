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
        public Peca peca(Posicao pos) 
        {

            return pecas[pos.Linha, pos.Coluna];        
        }

        public void colocarPeca(Peca p, Posicao pos) 
        {
            if (existePeca(pos))
            {
                throw new TabuleiroExeption("Ja existe uma peça nessa posição");
            }
            else 
            {
                pecas[pos.Linha, pos.Coluna] = p;
                p.posicao = pos;
            }

        
        }
        public Peca retirarPeca(Posicao pos) 
        {
            if (peca(pos) == null) 
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool existePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }
        public bool posicaoValida(Posicao pos) 
        {
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas) 
            {
                return false;
            
            }
            return true;
        }
        public void ValidarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos)) 
            {
                throw new TabuleiroExeption("Posição inválida!");
            }

        }
       
    }
}
 