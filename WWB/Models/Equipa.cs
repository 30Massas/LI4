using System;
namespace WorldWideBasketball.Models
{
    public class Equipa : IEquatable<Equipa>, IComparable<Equipa>
    {
        public Equipa(int id, string name, string localizacao, int liga_id)
        {
            this.Id = id;
            this.Name = name;
            this.Localizacao = localizacao;
            this.Liga_ID = liga_id;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Localizacao { get; set; }

        public int Liga_ID { get; set; }

        public int CompareTo(Equipa comparePart)
        {
            if (comparePart == null) return 1;
            if (this.Name.CompareTo(comparePart.Name) == 0)
            {
                return this.Id.CompareTo(comparePart.Id);

            }
            else
                return this.Name.CompareTo(comparePart.Name);
        }

        public bool Equals(Equipa other)
        {
            return (this.Id == other.Id);
        }
    }
}
