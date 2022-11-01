using System;
using Tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleirox tab { get; private set; }
        private int turno;
        private Cor JogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez() 
        {
            tab = new Tabuleirox(8, 8);
            turno = 1;
            JogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = tab.retirarPeca(origem);
            p.IncrementarQuantidadeDeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);


        }

        private void colocarPecas() 
        {
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('d', 1).toPosicao());
            //
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(Cor.Branca, tab), new PosicaoXadrez('d', 8).toPosicao());

        }

    }
}
