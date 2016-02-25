using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainWpfApplication.Core;
using MainWpfApplication.ViewModel;

namespace MainWpfApplication.DL
{
    public class DBTableManager
    {
        static private Dictionary<string, DBTableManager> _tableManagers = new Dictionary<string, DBTableManager>();
        static private SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TCSystemBDConnectionString"].ConnectionString);

        static public DBTableManager GetTableManager(string tableName)
        {
            DBTableManager tm = null;
            try { tm = _tableManagers[tableName]; }
            catch
            {
                try
                {
                    tm = new DBTableManager(tableName);
                    _tableManagers.Add(tableName, tm);
                }
                catch (Exception exception)
                {
                    Log.Instance.Error("DBTableManager", exception.Message);
                }
            }
            return tm;
        }
        
        static public void RemoveTableManager(string tableName)
        {
            try { _tableManagers.Remove(tableName); }
            catch (Exception exception) { Log.Instance.Error("DBTableManager", exception.Message); }
        }

        /***********************************************************************************************/

        private SqlDataAdapter _da;
        private DataTable _dt;
        private SqlCommand _cmd;

        public DataTable Table => _dt;

        public DBTableManager(string tableName)
        {
            try
            {
                _dt = new DataTable();
                _dt.TableName = tableName;
                _cmd = new SqlCommand("SELECT * FROM ["+Table.TableName+"]");
                _da = new SqlDataAdapter(_cmd.CommandText, _connection);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_da);
                _da.UpdateCommand = commandBuilder.GetUpdateCommand();
                _da.InsertCommand = commandBuilder.GetInsertCommand();
                _da.DeleteCommand = commandBuilder.GetDeleteCommand();

                _da.Fill(_dt);
            }
            catch (Exception exception)
            {
                Log.Instance.Error("DBTableManager", exception.Message);
            }
        }

        internal int DoQuery(string query)
        {
            _cmd.CommandText = "Select * from [TCSystemBD].[dbo].["+
                                Table.TableName + "] "+((query == "") ? "" : " where " + query);
            try
            {
                //_dt.Clear();
                DataTable temp = new DataTable();
                _da.Fill(temp);
                foreach (DataRow row in temp.Rows)
                {
                    if (!_dt.Rows.Contains(row[0]))
                    {
                        _dt.Rows.Add(row);
                    }
                }
                return 0;
            }
            catch 
            {
                //MessageBox.Show("Відбувся запит до таблиці " + Table.TableName + ((query == null) ? "" : " where ") + query + Environment.NewLine + "Таблицю не знайдено!!!", "Помилка БД...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        //отримати ідентифікатори об’єктів з БД, що задовольняють запиту
        //public DataRowCollection GetIds(string query)
        //{
        //    _cmd.CommandText = "select ID from Voll_" + Table.TableName + ((query == null) ? "" : " where " + query);
        //    try
        //    {
        //        _da.Fill(_temp);
        //        return _temp.Rows;
        //    }
        //    catch { MessageBox.Show("Відбувся запит до таблиці SB_" + Table.TableName + ((query == null) ? "" : " where ") + query + Environment.NewLine + "Таблицю не знайдено!!!", "Помилка БД...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //    return null;
        //}

        public int Update(DataRow dr) { return _da.Update(new DataRow[] { dr }); }

        public int Update(DataRow[] drs) { return _da.Update(drs); }
    }

}
