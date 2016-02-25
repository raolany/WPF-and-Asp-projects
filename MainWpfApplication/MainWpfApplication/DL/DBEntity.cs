using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.Core;
using MainWpfApplication.ViewModel;

namespace MainWpfApplication.DL
{
    public class DBEntity<T> where T : class
    {
        static DBTableManager tm;

        static DBEntity() { tm = DBTableManager.GetTableManager(typeof(T).Name); }

        static public T[] AllItems { get { return GetByQuery(""); } }

        static public T GetByID(Guid id)
        {
            try
            {
                return
                    (T)
                        Activator.CreateInstance(typeof (T),
                            new object[] {tm.Table.Select("ID = '" + id + "'")[0]});
            }
            catch (Exception exception)
            {
                Log.Instance.Error("DBEntity", exception.Message);
                return null;
            }
        }

        static public T[] GetByQuery(string query)
        {
            List<T> res = new List<T>();
            List<DataRow> ldrs = new List<DataRow>();

            tm.DoQuery("");
            ldrs.AddRange(tm.Table.Select(query));

            foreach (DataRow dr in ldrs)
                res.Add((T)Activator.CreateInstance(typeof(T), new object[] { dr }));
            return res.ToArray();
        }

        /***********************************************/

        protected DataRow _row;
        private bool _isNew = false;

        public DBEntity()
        {
            _row = tm.Table.NewRow();
            _row["Id"] = Guid.NewGuid();
            _isNew = true;
        }

        public DBEntity(DataRow dr)
        {
            _row = dr;
            _isNew = false;
        }

        public Guid Id => new Guid(_row["Id"].ToString());

        public bool IsNew => _isNew;

        public void Save()
        {
            if (IsNew)
            {
                _isNew = false;
                tm.Table.Rows.Add(_row);
            }
            tm.Update(_row);
        }

        public void Delete()
        {
            _row.Delete();
            tm.Update(_row);
        }
    }
}
