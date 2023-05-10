using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DA
{
    public interface ICRUD
    {
        void Create();

        void Read();

        void Update();

        void Delete();

        void InitialiseProgram();

        string GetRecord();

        void UpdatePlayerIDValue();

        string GetSetConnectionString(string connString);

        void SetSQLConnection(SqlConnection connection);
    }
}
