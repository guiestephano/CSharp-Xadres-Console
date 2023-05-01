using System;
using tabuleiro;
using xadrez_console;
using xadrez;
using xadrez_console.xadrez;

namespace xadres_console{
    class Program
    {
        static void Main(string[] args) 
        {
            try
            {
                /*
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(0, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preto), new Posicao(3, 4));
                tab.ColocarPeca(new Torre(tab, Cor.Branco), new Posicao(4, 3));
                Tela.ImprimirTabuleiro(tab);
                */
                PosicaoXadrez pos = new PosicaoXadrez('c', 7);
                Console.WriteLine(pos);
                Console.WriteLine(pos.ToPosicao());
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}