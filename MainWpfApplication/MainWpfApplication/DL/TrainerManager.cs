using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainWpfApplication.Model;

namespace MainWpfApplication.DL
{
    public class TrainerManager
    {
        private DataSet _dataSet = new DataSet();
        private SqlDataAdapter _trainerAdapter;
        //Data Mapper
        //Active record
        //ORM

        /*
            Perseon => Entity
            Person Mapper => BaseMapper--->|
        */

        public Trainer GetTrainer(string id)
        {
            _dataSet.Clear();
            //_dataSet.Tables["Trainer"].PrimaryKey = _dataSet.Tables["Trainer"].Columns[0];
            GetTrainerDataAdapter().Fill(_dataSet, "Trainer");

            foreach (DataRow row in _dataSet.Tables["Trainer"].Rows)
            {
                if (row["Id"].Equals(id))
                {
                    /*GenderType gender;
                    if(row[])
                    return new Trainer(row["Name"].ToString(), row["Surname"].ToString(), row["Patronymicname"].ToString(), row[""].ToString(), row[""].ToString(),
                                        row[""].ToString(), row[""].ToString(), row[""].ToString());*/
                }
            }
            return null;
        }

        /*public void Save(Trainer trainer)
        {
            GetTrainerDataAdapter().Fill(_dataSet, "Trainer");
            _dataSet.Tables["Trainer"].Rows.Add(null, trainer.Name, trainer.Surname, trainer.PatronymicName, trainer.Gender.ToString(), trainer.Address, trainer.PhoneNumber, trainer.Age, trainer.Expirience);

            GetTrainerDataAdapter().Update(_dataSet, "Trainer");

            _dataSet.Clear();
            GetTrainerDataAdapter().Fill(_dataSet, "Trainer");
            foreach (DataRow row in _dataSet.Tables["Trainer"].Rows)
            {
                if (trainer.Name.Equals(row["Name"]) && trainer.Surname.Equals(row["Surname"]) && trainer.PatronymicName.Equals(row["Patronymicname"]))
                {
                    trainer.Id = Int32.Parse(row["Id"].ToString());
                    //MessageBox.Show(row["Id"].ToString() + " " + row["Name"]);
                }
            }
        }*/

        private SqlDataAdapter GetTrainerDataAdapter()
        {
            if (_trainerAdapter == null)
            {
                string connectionString = GetConnectionString();
                SqlConnection connection = new SqlConnection(connectionString);

                string selectProductSQL = "SELECT * FROM [Trainer]";

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
