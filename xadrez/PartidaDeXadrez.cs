using System;
using Tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public Tabuleirox tab { get; private set; }
        public int turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        public bool xeque { get; private set; }

        //Construtor 
        public PartidaDeXadrez()
        {
            tab = new Tabuleirox(8, 8);
            turno = 1;
            JogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            xeque = false;

            colocarPecas();
        }
        //
        #region Movimentos
        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.IncrementarQuantidadeDeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;


        }
        public bool testeXequeMate(Cor cor)
        {

            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();

                for (int i = 0; i < tab.linhas; i = i + 1)
                {
                    for (int k = 0; k < tab.colunas; k++)
                    {
                        if (mat[i, k])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, k);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }

                        }
                    }
                }

            }
            return true;

        }
        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroExeption("Não tem rei na cor " + cor + " no tabuleiro!");

            }
            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.Linha, R.posicao.Coluna])
                {
                    return true;
                }

            }
            return false;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.DecrementarQuantidadeDeMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (estaEmXeque(JogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroExeption("Você não pode se colocar em xeque!");
            }
            if (estaEmXeque(adversaria(JogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (testeXequeMate(adversaria(JogadorAtual)))
            {
                terminada = true;
            }
            else 
            {
                turno++;
                mudaJogador();
            }
        }

        #endregion
        //
        #region Peças e Jogador
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private void mudaJogador()
        {

            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else { JogadorAtual = Cor.Branca; }
        }
        private void colocarPecas()
        {
            // Peça BRANCA
            colocarNovaPeca('a', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('b', 1, new Cavalo(Cor.Branca, tab));
            colocarNovaPeca('c', 1, new Bispo(Cor.Branca, tab));
            colocarNovaPeca('d', 1, new Dama(Cor.Branca, tab));
            colocarNovaPeca('e', 1, new Rei(Cor.Branca, tab));
            colocarNovaPeca('f', 1, new Bispo(Cor.Branca, tab));
            colocarNovaPeca('g', 1, new Cavalo(Cor.Branca, tab));
            colocarNovaPeca('h', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('a', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('b', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('c', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('d', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('e', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('f', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('g', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('h', 2, new Peao(Cor.Branca, tab));


            // Peça Preta
            colocarNovaPeca('a', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('b', 8, new Cavalo(Cor.Preta, tab));
            colocarNovaPeca('c', 8, new Bispo(Cor.Preta, tab));
            colocarNovaPeca('d', 8, new Dama(Cor.Preta, tab));
            colocarNovaPeca('e', 8, new Rei(Cor.Preta, tab));
            colocarNovaPeca('f', 8, new Bispo(Cor.Preta, tab));
            colocarNovaPeca('g', 8, new Cavalo(Cor.Preta, tab));
            colocarNovaPeca('h', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('a', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('b', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('c', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('d', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('e', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('f', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('g', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('h', 7, new Peao(Cor.Preta, tab));


        }
        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }


            }

            return null;
        }
        #endregion
        //
        #region Validação
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroExeption("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroExeption("A peça de origem escolhida não e sua");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroExeption("Não há movimentos possíves para a peça de origem escolhida");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {

                throw new TabuleiroExeption("Posição de destinho invalida!");

            }
        }

        #endregion

    }
}
