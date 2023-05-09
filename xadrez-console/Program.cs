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
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = partida.LerPosicaoXadrez().ToPosicao();
                    Console.WriteLine(origem);
                    Console.WriteLine(partida.Tabuleiro.GetPeca(origem));

                   bool[,] posicoesPossiveis = partida.Tabuleiro.GetPeca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.Write("Destino: ");
                    Posicao destino = partida.LerPosicaoXadrez().ToPosicao();
                    Console.WriteLine();
                    Console.WriteLine(destino);

                    partida.ExecutarMovimento(origem, destino);
                }


            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}