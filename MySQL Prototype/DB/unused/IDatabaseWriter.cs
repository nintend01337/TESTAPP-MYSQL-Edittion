using System.Collections.Generic;

namespace MySQL_Prototype.DB
{
    public interface IDatabaseWriter
    {
        void WriteData(string query, Dictionary<string, object> parameters);
    }
}
