using System;
using System.Collections.Generic;

namespace MruKata
{
    public class CappedMruList
    {
        readonly List<string> items;
        readonly int capacity;

        public CappedMruList(int capacity)
        {
            items = new List<string>();
            this.capacity = capacity;
        }

        public void TrackFile(string file)
        {
            if (file == null) throw new ArgumentNullException();
            AddUniqueFile(file);
            RemoveExtraCapacityFiles();
        }

        void RemoveExtraCapacityFiles()
        {
            if (items.Count > capacity)
                items.RemoveAt(capacity - 1);
        }

        void AddUniqueFile(string file)
        {
            if (items.Contains(file))
                items.Remove(file);
            items.Add(file);
        }
    }
}
