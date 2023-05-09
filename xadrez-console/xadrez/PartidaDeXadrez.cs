using System.Data;
using tabuleiro;
using xadrez;

namespace xadrez_console.xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set;}
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool PartidaTerminada;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            ColocarPecas();
            PartidaTerminada = false;
        }

        public void ValidarPosicaoOrigem(Posicao origem)
        {
            if(Tabuleiro.GetPeca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if(Tabuleiro.GetPeca(origem).Cor != JogadorAtual)
            {
                throw new TabuleiroException("Peça de origem  escolhida não é sua!");
            }
            if (!Tabuleiro.GetPeca(origem).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possiveis para a peça de origem escolhida");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.GetPeca(origem).PodeMover(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarMovimento();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        private void MudarJogador()
        {
            if(JogadorAtual == Cor.Branco)
            {
                JogadorAtual = Cor.Preto;
            }
            else
            {
                JogadorAtual = Cor.Branco;
            }
        }

        public PosicaoXadrez LerPosicaoXadrez()
        {
            string str = Console.ReadLine();
            char coluna = str[0];
            int linha = int.Parse(str[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 1).ToPosicao());

            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }

}
