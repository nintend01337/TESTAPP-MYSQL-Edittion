using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Prototype.DB
{
    public interface IDbConnector
    {
        void OpenConnection();
        void CloseConnection();
    }
}
