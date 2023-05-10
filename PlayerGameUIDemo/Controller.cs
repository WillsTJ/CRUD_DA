using CRUD_DA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// These namespaces are needed for SQL conections.
using System.Configuration;
using System.Data.SqlClient;


// Reference the CRUD API.

namespace PlayerGameUIDemo
{
    internal class Controller
    {
        public Controller()
        {
            
        }


        public string GetRecordData(ICRUD apiReference)
        {
            apiReference.InitialiseProgram();
            apiReference.GetSetConnectionString(String.Empty); // Update this function in the API-- it doesn't need an overload.
            apiReference.SetSQLConnection(new SqlConnection());
            apiReference.Read();

            return apiReference.GetRecord();
        }
    }
}

