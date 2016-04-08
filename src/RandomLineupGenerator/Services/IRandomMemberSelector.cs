using System.Collections.Generic;

namespace RandomLineupGenerator.Services
{
    public interface IRandomMemberSelector
    {
        TMember GetFrom<TMember>(IList<TMember> list);
    }
}