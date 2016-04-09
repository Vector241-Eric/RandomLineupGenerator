using System.Collections.Generic;
using RandomLineupGenerator.Services;

namespace UnitTests._Stubs.Services
{
    public class AlwaysSelectFirstMember : IRandomMemberSelector
    {
        public TMember GetFrom<TMember>(IList<TMember> list)
        {
            var member = list[0];
            list.RemoveAt(0);
            return member;
        }
    }
}