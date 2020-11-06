using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILeutenantGeneral
    {
        ICollection<Private> Privates { get; }
    }
}