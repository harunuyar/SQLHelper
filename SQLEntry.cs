using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class SQLEntry
    {
        private List<SQLItem> items;

        public SQLEntry()
        {
            items = new List<SQLItem>();
        }

        public SQLEntry add(SQLItem item)
        {
            items.Add(item);
            return this;
        }

        public SQLEntry add(string columnName, string value)
        {
            items.Add(new SQLItem(columnName, value));
            return this;
        }

        public SQLEntry add(string columnName, string value, string operand)
        {
            items.Add(new SQLItem(columnName, value, operand));
            return this;
        }

        public int getCount()
        {
            return items.Count;
        }

        public SQLItem getItem(int index)
        {
            return items.ElementAt(index);
        }

        public SQLItem getItem(string columnName)
        {
            foreach (SQLItem item in items)
            {
                if (item.getColumnName() == columnName)
                {
                    return item;
                }
            }
            return null;
        }

        public List<string> getItemsAsStringList()
        {
            List<string> list = new List<string>();
            foreach (SQLItem item in items)
            {
                list.Add(item.getValue());
            }
            return list;
        }

        public string getValue(string columnName)
        {
            foreach(SQLItem item in items)
            {
                if (item.getColumnName() == columnName)
                {
                    return item.getValue();
                }
            }
            return null;
        }

        public string getValue(int index)
        {
            return items.ElementAt(index).getValue();
        }

        public override bool Equals(object obj)
        {
            if (obj is SQLEntry)
            {
                SQLEntry e = (SQLEntry)obj;
                if (getCount() != e.getCount())
                    return false;
                for (int i = 0; i < getCount(); i++)
                {
                    if (!getItem(i).Equals(e.getItem(i)))
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
