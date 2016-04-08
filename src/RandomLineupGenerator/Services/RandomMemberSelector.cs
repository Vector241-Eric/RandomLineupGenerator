using System;
using System.Collections.Generic;

namespace RandomLineupGenerator.Services
{
    public class RandomMemberSelector : IRandomMemberSelector
    {
        private readonly Random _random = new Random();

        public TMember GetFrom<TMember>(IList<TMember> list)
        {
            var index = _random.Next(list.Count);
            var value = list[index];
            list.RemoveAt(index);

            return value;
        }
    }
}