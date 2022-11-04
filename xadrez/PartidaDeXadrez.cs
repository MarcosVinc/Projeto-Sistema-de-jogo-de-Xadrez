using System;
using Tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleirox tab { get; private set; }
        public int turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() 
        {
            tab = new Tabuleirox(8, 8);
            turno = 1;
            JogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();

            colocarPecas();
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = tab.retirarPeca(origem);
            p.IncrementarQuantidadeDeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }


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

        public HashSet<Peca> pecasEmJogo(Cor cor) 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


        public void realizaJogada(Posicao origem, Posicao destino) 
        {
            ExecutaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos) 
        {
            if (tab.peca(pos) == null) 
            {
                throw new TabuleiroExeption("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual !=  tab.peca(pos).cor) 
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
            if (!tab.peca(origem).podeMover(destino))
            {

                throw new TabuleiroExeption("Posição de destinho invalida!");

            }
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
            colocarNovaPeca('c', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('c', 2,new Torre(Cor.Branca, tab));
            colocarNovaPeca('d', 2, new Torre(Cor.Branca, tab));
            colocarNovaPeca('e', 2, new Torre(Cor.Branca, tab));
            colocarNovaPeca('e', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('d', 1, new Rei(Cor.Branca, tab));

            // Peça Preta
            colocarNovaPeca('c', 7, new Torre(Cor.Preta, tab));
            colocarNovaPeca('c', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('d', 7, new Torre(Cor.Preta, tab));
            colocarNovaPeca('e', 7, new Torre(Cor.Preta, tab));
            colocarNovaPeca('e', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('d', 8, new Rei(Cor.Preta, tab));


        }

    }
}
