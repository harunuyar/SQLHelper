using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class SQLResult
    {
        private List<SQLEntry> entries;
        private int index;

        public SQLResult()
        {
            entries = new List<SQLEntry>();
            index = 0;
        }

        public SQLResult add(SQLEntry entry)
        {
            entries.Add(entry);
            return this;
        }

        public SQLEntry getEntry(int pos)
        {
            return entries.ElementAt(pos);
        }

        public int getCount()
        {
            return entries.Count;
        }

        public bool hasNext()
        {
            return index < entries.Count;
        }

        public SQLEntry next()
        {
            return entries.ElementAt(index++);
        }

        public void reset()
        {
            index = 0;
        }

        public bool isEmpty()
        {
            return entries.Count == 0;
        }
    }
}
