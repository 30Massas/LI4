using System;
using System.Collections.Generic;

namespace WorldWideBasketball.Models
{
    public class Liga : IEquatable<Liga>, IComparable<Liga>
    {
        public Liga(int id, string nome, string localizacao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Localizacao = localizacao;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Localizacao { get; set; }

        public List<Equipa> Equipas { get; set; }

        public Dictionary<int, List<Jogo>> JogosEquipa { get; set; }

        public string getString()
        {
            return this.Id + ": " + this.Nome + ", " + this.Localizacao;
        }

        public int CompareTo(Liga comparePart)
        {
            if (comparePart == null) return 1;
            if (this.Nome.CompareTo(comparePart.Nome) == 0)
            {
                return this.Id.CompareTo(comparePart.Id);

            }
            else
                return this.Nome.CompareTo(comparePart.Nome);
        }

        public bool Equals(Liga other)
        {
            return (this.Id == other.Id);
        }
    }
}
