using System;
using tabuleiro;
using xadrez_console;
using xadrez;

namespace xadres_console{
    class Program
    {
        static void Main(string[] args) 
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(0, 3));
            tab.ColocarPeca(new Rei(tab, Cor.Preto), new Posicao(3, 4));
            Tela.ImprimirTabuleiro(tab);
        }
    }
}