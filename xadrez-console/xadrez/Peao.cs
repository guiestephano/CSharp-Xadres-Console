using System;
using tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool TemInimigo(Posicao pos)
        {
            Peca peca = Tabuleiro.GetPeca(pos);
            return peca != null && peca.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tabuleiro.GetPeca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);
            if(Cor == Cor.Branco)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if(Tabuleiro.PosicaoValida(pos) && Livre(pos) && QntMovimentos == 0) 
                {
                    mat[pos.Linha, pos.Coluna] = true; 
                }

                pos.DefinirValores(Posicao.Linha - 1, pos.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && TemInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && TemInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QntMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, pos.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && TemInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && TemInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }

            return mat;
        }
    }
}
