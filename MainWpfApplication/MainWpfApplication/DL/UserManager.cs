using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.Model;

namespace MainWpfApplication.DL
{
    public class UserManager
    {
        private DataSet _dataSet = new DataSet();
        private SqlDataAdapter _userAdapter;

        public User GetUserInfo(string login, string password)
        {
            _dataSet.Clear();
            GetUserDataAdapter().Fill(_dataSet, "User");

            foreach (DataRow row in _dataSet.Tables["User"].Rows)
            {
                if (row["Login"].Equals(login) && row["Password"].Equals(password))
                {
                    /*User user = new User(login, password);
                    if (row["Trainer"] != null)
                    {
                        //user.Trainer = (new TrainerManager()).GetTrainer(row["Trainer"].ToString());
                    }
                    return user;*/
                }
            }

            return null;
        }

        //true == unique
        public bool CheckUserLogin(string login)
        {
            GetUserDataAdapter().Fill(_dataSet, "User");

            foreach (DataRow row in    _dataSet.Tables["User"].Rows)
            {
                if (row["Login"].Equals(login))
                    return false;
            }

            return true;
        }

        public void Save(User user)
        {
            /*if (user.Trainer != null)
            {
                TrainerManager trainerManager = new TrainerManager();
                trainerManager.Save(user.Trainer);
                _dataSet.Tables["User"].Rows.Add(null, user.Login, user.Password, null, user.Trainer.Id);
            }
            else if (user.Client != null)
            {
                ClientManager clientManager = new ClientManager();
                clientManager.Save(user.Client);
                _dataSet.Tables["User"].Rows.Add(null, user.Login, user.Password, user.Client.Id, null);
            }
            
            GetUserDataAdapter().Update(_dataSet, "User");*/
        }

        private SqlDataAdapter GetUserDataAdapter()
        {
            if (_userAdapter == null)
            {
                string connectionString = GetConnectionString();
                SqlConnection connection = new SqlConnection(connectionString);

                string selectProductSQL = "SELECT * FROM [User]";
                
                _userAdapter = new SqlDataAdapter(selectProductSQL, connection);

                CreateUpdateCommand(_userAdapter);
            }
            return _userAdapter;
        }

        private string GetConnectionString()
        {
            //return @"Data Source=ANDREY-PC\SQLEXPRESS;Initial Catalog=TCSystemBD;Integrated Security=True";
            return ConfigurationManager.ConnectionStrings["TCSystemBDConnectionString"].ConnectionString;
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
