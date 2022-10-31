using System;
using Tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {

        public Torre(Cor cor, Tabuleirox tab) : base(cor, tab) { }

        public override string ToString()
        {
            return "T";
        }
    }
}
