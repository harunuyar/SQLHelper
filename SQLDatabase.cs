using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLHelper
{
    public class SQLDatabase
    {
        private SqlConnection connection;
        private SqlCommand command;

        private bool connected;

        public SQLDatabase(string connectionString)
        {
            connected = false;
            Task task = new Task(new Action(() => initialize(connectionString)));
            task.Start();
        }

        private void initialize(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
            connected = true;
        }

        public bool isConnected()
        {
            return connected;
        }

        public void connect(string connectionString)
        {
            connected = false;
            Task task = new Task(new Action(() => initialize(connectionString)));
            task.Start();
        }

        public bool execute(string komutString)
        {
            if (!connected)
                throw new Exception("Henüz veritabanı bağlantısı sağlanamadı.");
            try
            {
                connection.Open();
                command.CommandText = komutString;
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }
        }

        public bool execute(SQLQuery query)
        {
            try
            {
                return execute(query.getCommand());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool insert(SQLQuery query)
        {
            try
            {
                return execute(query.getCommand(SQLQuery.INSERT));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool update(SQLQuery query)
        {
            try
            {
                return execute(query.getCommand(SQLQuery.UPDATE));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool delete(SQLQuery query)
        {
            try
            {
                return execute(query.getCommand(SQLQuery.DELETE));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SQLResult select(SQLQuery query)
        {
            if (!connected)
                throw new Exception("Henüz veritabanı bağlantısı sağlanamadı.");

            SQLResult result = new SQLResult();

            try
            {
                connection.Open();
                command.CommandText = query.getCommand(SQLQuery.SELECT);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SQLEntry entry = new SQLEntry();
                    for (int i = 0; i < reader.FieldCount; i++) {
                        entry.add(new SQLItem(reader.GetName(i), reader.GetSqlValue(i).ToString()));
                    }
                    result.add(entry);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }

            return result;
        }

        public bool exists(SQLQuery query)
        {
            if (!connected)
                throw new Exception("Henüz veritabanı bağlantısı sağlanamadı.");

            try
            {
                connection.Open();
                command.CommandText = query.getCommand(SQLQuery.SELECT);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
                
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }
        }
    }
}
