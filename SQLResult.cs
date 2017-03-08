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

        public SQLResult(SQLResult r)
        {
            entries = new List<SQLEntry>(r.asList());
            index = 0;
        }

        public SQLResult(List<SQLEntry> list)
        {
            entries = new List<SQLEntry>(list);
            index = 0;
        }

        public SQLResult add(SQLEntry entry)
        {
            entries.Add(entry);
            return this;
        }

        public SQLResult add(List<SQLEntry> list)
        {
            entries.AddRange(list);
            return this;
        }

        public SQLResult add(SQLResult r)
        {
            entries.AddRange(r.asList());
            return this;
        }

        public SQLResult addIfNotExists(SQLEntry entry)
        {
            if (!entries.Contains<SQLEntry>(entry))
            {
                entries.Add(entry);
            }
            return this;
        }

        public SQLResult addIfNotExists(SQLResult r)
        {
            List<SQLEntry> list = r.asList();
            foreach (SQLEntry e in list)
            {
                if (!entries.Contains<SQLEntry>(e))
                {
                    entries.Add(e);
                }
            }
            return this;
        }

        public SQLResult addIfNotExists(List<SQLEntry> list)
        {
            foreach (SQLEntry e in list)
            {
                if (!entries.Contains<SQLEntry>(e))
                {
                    entries.Add(e);
                }
            }
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

        public List<SQLEntry> asList()
        {
            return entries;
        }

        public static SQLResult combine(SQLResult r1, SQLResult r2)
        {
            SQLResult result = new SQLResult(r1);
            result.addIfNotExists(r2);
            return result;
        }
    }
}
