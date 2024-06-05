using System.Collections.Generic;

namespace MySQL_Prototype.DB
{
    public interface IDatabaseReader
    {
        List<string[]> ReadData(string query);
    }
}
