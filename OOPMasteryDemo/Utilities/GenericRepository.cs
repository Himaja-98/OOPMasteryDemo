using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPMasteryDemo.Utilities
{
    // Simple generic repository showing generics usage
    public class GenericRepository<T> where T : class
    {
        private readonly List<T> _items = new List<T>();

        public IEnumerable<T> Items => _items;

        public void Add(T item) => _items.Add(item);
        public void AddRange(IEnumerable<T> items) => _items.AddRange(items);
        public void Remove(T item) => _items.Remove(item);
    }
}
