using System;
using Tabuleiro;


namespace xadrez
{
    class Rei : Peca
    {
        public Rei( Cor cor, Tabuleirox tab) : base(cor, tab) { }

        public override string ToString()
        {
            return "R";
        }
    }
}
