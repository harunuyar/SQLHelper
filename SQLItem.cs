using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class SQLItem
    {
        public static string EQUAL = "=";
        public static string GREATER = ">";
        public static string LESS = "<";
        public static string NOT_EQUAL = "!=";

        private string columnName, value, operand;

        public SQLItem(string columnName, string value)
        {
            this.columnName = columnName;
            this.value = value;
            this.operand = EQUAL;
        }

        public SQLItem(string columnName, string value, string operand)
        {
            this.columnName = columnName;
            this.value = value;
            this.operand = operand;
        }

        public void setColumnName(string columnName)
        {
            this.columnName = columnName;
        }

        public void setValue(string value)
        {
            this.value = value;
        }

        public string getColumnName()
        {
            return columnName;
        }

        public string getValue()
        {
            return value==null ? "null" : value;
        }

        override public string ToString()
        {
            string val;
            if (value == null)
            {
                val = "null";
            }
            else
            {
                val = "'" + value + "'";
            }
            return "'" + columnName + "'" + operand + val;
        }

        public override bool Equals(object obj)
        {
            if (obj is SQLItem)
            {
                SQLItem i = (SQLItem)obj;
                return getColumnName() == i.getColumnName() && getValue() == i.getValue();
            }
            return false;
        }
    }
}
