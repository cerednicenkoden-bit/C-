using System;

namespace Restaurant.Models
{
    public class Drink : MenuItem
    {
        public int VolumeMl { get; private set; }
        public bool IsAlcoholic { get; private set; }

        public Drink(int id, string name, decimal price, string category, int volumeMl, bool isAlcoholic = false)
            : base(id, name, price, category)
        {
            VolumeMl = volumeMl;
            IsAlcoholic = isAlcoholic;
        }

        public override string GetInfo()
        {
            return $"{Name} ({VolumeMl} мл{(IsAlcoholic ? ", алкогольний" : ", безалкогольний")}) - {Price} грн";
        }
    }
}
