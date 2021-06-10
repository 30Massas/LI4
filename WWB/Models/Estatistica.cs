using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldWideBasketball.Models
{
    public class Estatistica
    {
        public Estatistica(int p_f, int p_c, int v, int d, int c, int diff, int id_e)
        {
            this.Pontos_a_favor = p_f;
            this.Pontos_contra = p_c;
            this.Vitorias = v;
            this.Derrotas = d;
            this.Classificacao = c;
            this.DiffPontos = diff;
            this.Id_equipa = id_e;
        }

        public int Pontos_a_favor { get; set; }
        public int Pontos_contra { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Classificacao { get; set; }
        public int DiffPontos { get; set; }
        public int Id_equipa { get; set; }
    }
}
