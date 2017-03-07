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

        public void add(SQLItem item)
        {
            items.Add(item);
        }

        public int getCount()
        {
            return items.Count;
        }

        public SQLItem getItem(int pos)
        {
            return items.ElementAt(pos);
        }

        public List<string> getItemsAsString()
        {
            List<string> list = new List<string>();
            foreach (SQLItem item in items)
            {
                list.Add(item.getValue());
            }
            return list;
        }

        public string getItem(string columnName)
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
    }
}
