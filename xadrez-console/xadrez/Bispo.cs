using System;
using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca peca = Tabuleiro.GetPeca(pos);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Diagonal Esquerda cima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            //Diagonal Direita cima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            //Diagonal Esquerda baixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            //Diagonal Direita baixo
            pos.DefinirValores(Posicao.Linha +1, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }
            return mat;
        }
    }
}
