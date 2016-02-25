using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.Model;

namespace MainWpfApplication.DL
{
    public class ClientManager
    {
        private DataSet _dataSet = new DataSet();
        private SqlDataAdapter _trainerAdapter;

        public void Save(Client client)
        {
            GetTrainerDataAdapter().Fill(_dataSet, "Client");
            //_dataSet.Tables["Client"].Rows.Add(null, client.Name, client.Surname, client.PatronymicName, client.Gender.ToString(), client.Address, client.PhoneNumber, client.Age, client.Insurance);

            GetTrainerDataAdapter().Update(_dataSet, "Client");

            _dataSet.Clear();
            GetTrainerDataAdapter().Fill(_dataSet, "Client");
            foreach (DataRow row in _dataSet.Tables["Client"].Rows)
            {
                /*if (client.Name.Equals(row["Name"]) && client.Surname.Equals(row["Surname"]) && client.PatronymicName.Equals(row["Patronymicname"]))
                {
                    client.Id = Int32.Parse(row["Id"].ToString());
                }*/
            }
        }

        private SqlDataAdapter GetTrainerDataAdapter()
        {
            if (_trainerAdapter == null)
            {
                string connectionString = GetConnectionString();
                SqlConnection connection = new SqlConnection(connectionString);

                string selectProductSQL = "SELECT * FROM [Client]";

                _trainerAdapter = new SqlDataAdapter(selectProductSQL, connection);

                CreateUpdateCommand(_trainerAdapter);
            }
            return _trainerAdapter;
        }

        private string GetConnectionString()
        {
            return @"Data Source=ANDREY-PC\SQLEXPRESS;Initial Catalog=TCSystemBD;Integrated Security=True";
        }

        private void CreateUpdateCommand(SqlDataAdapter adapter)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter.InsertCommand = commandBuilder.GetInsertCommand();
            adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
        }
    }
}
