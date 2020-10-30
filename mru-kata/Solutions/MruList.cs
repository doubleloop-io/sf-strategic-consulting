using System;
using System.Collections.Generic;

namespace MruKata.Solutions
{
    public class MruList
    {
        readonly int capacity;
        readonly List<string> values;

        public MruList(int capacity)
        {
            this.capacity = capacity;
            values = new List<string>(capacity + 1);
        }

        public void Track(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            values.Remove(value);
            values.Insert(0, value);
            if (values.Count > capacity)
                values.RemoveAt(values.Count - 1);
        }

        public IEnumerable<string> Tracked()=>
            new List<string>(values);
    }
}
