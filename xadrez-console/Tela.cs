using tabuleiro;
namespace xadrez_console
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for(int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    
                    if(tabuleiro.GetPeca(i,j) == null)
                    {
                        Console.Write("_ ");
                    }
                    else
                    {
                        Console.Write(tabuleiro.GetPeca(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
    }
}
