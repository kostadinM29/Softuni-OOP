using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer
    {
        ICollection<Repair> Repairs { get; }
    }
}