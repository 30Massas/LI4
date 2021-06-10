using System;
namespace WorldWideBasketball.Models
{
    public class Jogo : IEquatable<Jogo>, IComparable<Jogo>
    {
        public Jogo(int id, string data, string hora, string resultado, int equipa_casa_id, int equipa_vis_id)
        {
            this.Id = id;
            this.Data = data;
            this.Hora = hora;
            this.Resultado = resultado;
            this.Equipa_Casa = equipa_casa_id;
            this.Equipa_Vis = equipa_vis_id;
        }

        public int Id { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Resultado { get; set; }
        public int Equipa_Casa { get; set; }
        public int Equipa_Vis { get; set; }

        public bool Equals(Jogo other)
        {
            return (this.Id == other.Id);
        }

        public int CompareTo(Jogo comparePart)
        {
            if (comparePart == null) return 1;
            if (this.Data.CompareTo(comparePart.Data) == 0)
            {
                if (this.Hora.CompareTo(comparePart.Hora) == 0)
                {
                    return this.Id.CompareTo(comparePart.Id);
                }
                else
                    return this.Hora.CompareTo(comparePart.Hora);
            }
            else
                return this.Data.CompareTo(comparePart.Data);
        }

    }
}
