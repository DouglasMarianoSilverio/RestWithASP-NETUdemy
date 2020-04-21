using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.Converter
{
    public interface IParser<O,D>
    {
        D Parse(O origin);
        IList<D> ParseList(IList<O> origin);
    }
}
