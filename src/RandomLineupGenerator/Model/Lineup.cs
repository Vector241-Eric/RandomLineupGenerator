using System;
using System.Collections.Generic;

namespace RandomLineupGenerator.Model
{
    public class Lineup
    {
        public DateTime Date { get; set; }
        public int Index { get; set; }
        public List<string> BattingOrder { get; set; }
        public bool HasBattingOrder => BattingOrder != null && BattingOrder.Count > 0;

        public Lineup Add(string player)
        {
            if (BattingOrder == null)
                BattingOrder = new List<string>();
            BattingOrder.Add(player);
            return this;
        }

        protected bool Equals(Lineup other)
        {
            return Date.Equals(other.Date) && Index == other.Index;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Lineup) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Date.GetHashCode()*397) ^ Index;
            }
        }
    }
}