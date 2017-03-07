using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class SQLQuery
    {
        public static int SELECT  = 1;
        public static int INSERT  = 2;
        public static int UPDATE  = 3;
        public static int DELETE  = 4;
        public static int COMMAND = 5;
        
        private string table;
        private SQLEntry entry, conditions;
        private string command;

        public SQLQuery(string tableName, SQLEntry sqlEntry, SQLEntry sqlConditions)
        {
            table = tableName;
            entry = sqlEntry;
            conditions = sqlConditions;
            command = null;
        }

        public SQLQuery(string command)
        {
            table = null;
            entry = null;
            conditions = null;
            this.command = command;
        }

        public string getCommand(int type)
        {
            createCommand(type);
            return command;
        }

        public string getCommand()
        {
            return command;
        }

        private void createCommand(int type)
        {
            if (type == SELECT)
            {
                command = "select * from [" + table + "]";
                if (conditions != null)
                {
                    if (conditions.getCount() != 0)
                    {
                        command += " where " + conditions.getItem(0).getColumnName() + "='" + conditions.getItem(0).getValue() + "'";
                        for (int i = 1; i < conditions.getCount(); i++)
                        {
                            command += " AND " + conditions.getItem(i).getColumnName() + "='" + conditions.getItem(i).getValue() + "'";
                        }
                    }
                }
            }
            else if (type == INSERT)
            {
                if (entry.getCount() != 0)
                {
                    command = "insert into [" + table + "](" + entry.getItem(0).getColumnName();
                    string values = "values('" + entry.getItem(0).getValue() + "'";
                    for (int i = 1; i < entry.getCount(); i++)
                    {
                        command += ", " + entry.getItem(i).getColumnName();
                        values += ", '" + entry.getItem(i).getValue() + "'";
                    }
                    values += ")";
                    command += ") " + values;
                }
            }
            else if (type == UPDATE)
            {
                if (entry.getCount() != 0)
                {
                    command = "update [" + table + "] set " + entry.getItem(0).getColumnName() + "='" + entry.getItem(0).getValue() + "'";
                    for (int i = 1; i < entry.getCount(); i++)
                    {
                        command += ", " + entry.getItem(i).getColumnName() + "='" + entry.getItem(i).getValue() + "'";
                    }
                    if (conditions != null)
                    {
                        if (conditions.getCount() != 0)
                        {
                            command += " where " + conditions.getItem(0).getColumnName() + "='" + conditions.getItem(0).getValue() + "'";
                            for (int i = 1; i < conditions.getCount(); i++)
                            {
                                command += " AND " + conditions.getItem(i).getColumnName() + "='" + conditions.getItem(i).getValue() + "'";
                            }
                        }
                    }
                }
            }
            else if (type == DELETE)
            {
                command = "delete from [" + table + "]";
                if (conditions != null)
                {
                    if (conditions.getCount() != 0)
                    {
                        command += "where " + conditions.getItem(0).getColumnName() + " = '" + conditions.getItem(0).getValue() + "'";
                        for (int i = 1; i < conditions.getCount(); i++)
                        {
                            command += " AND " + conditions.getItem(i).getColumnName() + "='" + conditions.getItem(i).getValue() + "'";
                        }
                    }
                }
                 
            }
        }
    }
}
