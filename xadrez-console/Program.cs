using tabuleiro;
using xadrez_console;
using xadrez;
using xadrez_console.xadrez;

namespace xadres_console
{
    class Program
    {
        static void Main(string[] args) 
        {
            try
            {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.PartidaTerminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = partida.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        Console.WriteLine(origem);
                        Console.WriteLine(partida.Tabuleiro.GetPeca(origem));

                        bool[,] posicoesPossiveis = partida.Tabuleiro.GetPeca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine("Turno " + partida.Turno);
                        Console.WriteLine("Aguardando Jogada: " + partida.JogadorAtual);
                        Console.WriteLine();

                        Console.Write("Destino: ");
                        Posicao destino = partida.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);
                        Console.WriteLine();
                        Console.WriteLine(destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }


            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}