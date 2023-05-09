
namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca GetPeca(int linha, int couluna)
        {
            return Pecas[linha, couluna];
        }

        public Peca GetPeca(Posicao posicao)
        {

         
            return Pecas[posicao.Linha, posicao.Coluna];

        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return GetPeca(posicao) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (!ExistePeca(pos))
            {
                Pecas[pos.Linha, pos.Coluna] = p;
                p.Posicao = pos;
            }
            else
            {
                throw new TabuleiroException("Ja existe uma peça na posição: " + pos);
            }
            
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if(GetPeca(pos) == null)
            {
                return null;
            }
            else
            {
                Peca aux = GetPeca(pos);
                aux.Posicao = null;
                Pecas[pos.Linha, pos.Coluna] = null;
                return aux;
            }

        }

        public bool PosicaoValida(Posicao posicao)
        {
            if(posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição invalida!");
            }
        }
    }
}
