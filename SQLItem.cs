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
        private string columnName, value;

        public SQLItem(string columnName, string value)
        {
            this.columnName = columnName;
            this.value = value;
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
            return value;
        }
    }
}
