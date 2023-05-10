using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;

// These namespaces are needed for SQL conections.
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CRUD_DA
{
    public class CRUD : ICRUD
    {
        // Table and row names.
        // These strings can be used to identify the target table and columns
        // where we want to retrieve records.
        string playerProfileTable = "PlayerProfileTable";
        string playerIDColumn = "PlayerId";
        string playerUsernameColumn = "PlayerUsername";
        string playerEmailColumn = "PlayerEmail";
        string playerIsPremiumTierColumn = "IsPremiumTier";
        string playerPasswordColumn = "PlayerPassword";

        // Members may not need to be static when the API is being used from a discrete front/program.
        // This member may be static, if calling it in a static context within the API.
        static SqlConnection sqlConnection;
        string connectionString;

        // Hold arbitrary record values in a List<>.
        List<string> PlayerProfileTabeRecords = new List<string>();

        // Record variables. May need public implementations to update these values 
        // from UI-level. These are not used yet, in this demo project.
        int playerIDRecord;
        string playerUsernameRecord;
        string playerEmailRecord;
        bool playerTierRecord;
        string playerPasswrodRecord;

        [STAThread]
        static void Main()
        {

        }

        /// <summary>
        /// Place some empty slots in a List<>.
        /// The List<> can be used to store retrieved record data.
        /// </summary>
        public void InitialiseProgram()
        {
            // Create empty slots in the Player List<>.
            // These slots are to store the records from the SQL DB table.
            PlayerProfileTabeRecords.Add(string.Empty);
            PlayerProfileTabeRecords.Add(string.Empty);
            PlayerProfileTabeRecords.Add(string.Empty);
            PlayerProfileTabeRecords.Add(string.Empty);
            PlayerProfileTabeRecords.Add(string.Empty);
        }

        /// <summary>
        /// Establishes an SQL connection.
        /// </summary>
        /// <param name="connection"></param>
        public void SetSQLConnection(SqlConnection connection)
        {
            sqlConnection = connection;
        }

        /// <summary>
        /// Returns the first entry in the List<> holding arbitrary record data retrieved.
        /// </summary>
        /// <returns></returns>
        public string GetRecord()
        {
            return PlayerProfileTabeRecords[0];
        }

        /// <summary>
        /// Returns the conenction string name, which can be used to find the connection string for the target SQL database.
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public string GetSetConnectionString(string connString)
        {
            // Depending on the application, the connection string can be passed, or baked into the API.
            return this.connectionString = ConfigurationManager.ConnectionStrings["PlayerGameUIDemo.Properties.Settings.PlayerProfilesConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Retrieve data from an SQL database.
        /// </summary>
        public void Read()
        {
            // Hard-code a primary key for now, just to retrevie the specific record.
            object key = 12;

            using (sqlConnection = new SqlConnection(this.connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PlayerProfileTable", sqlConnection)) // USE REFERENCED STORED PROCEDURES DEFINED IN THE SQL DB!! USING DIRECT T-SQL REFERENCES HERE IS VERY RISKY FOR SECURITY!!
                {
                    DataTable playerTable = new DataTable();
                    adapter.Fill(playerTable);

                    // Set the primary key we want to target.
                    DataColumn[] keyColumns = new DataColumn[1];
                    keyColumns[0] = playerTable.Columns[0];
                    playerTable.PrimaryKey = keyColumns;

                    PlayerProfileTabeRecords[0] = playerTable.Rows.Find(key)[1].ToString();// .CreateDataReader()[0].ToString();
                }
            }
        }

        // Implementations not set yet. //

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }   

        private void CreateRoutine(object query)
        {
            throw new NotImplementedException();

            query = "INSERT INTO <" + playerProfileTable + "> (, " + playerIDColumn + ", " + playerUsernameColumn + ", " + playerEmailColumn + ", " + playerIsPremiumTierColumn + ", " + playerPasswordColumn + ") " +
            "VALUES (" + playerIDRecord + ", " + playerUsernameRecord + ", " + playerEmailRecord + ", " + playerTierRecord + ", " + playerPasswrodRecord + ")";
        }

        private void InsertRecordToPlayerIDRow()
        {
            throw new NotImplementedException();

            object query = "INSERT INTO <" + playerProfileTable + "> (, " + playerIDColumn + ")" +
            "VALUES (" + playerIDRecord + ")";
        }

        public void UpdatePlayerIDValue()
        {
            throw new NotImplementedException();
        }
    }
}
