using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(new Book());

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());

            var number = new Nullable<int>(5);
            Console.WriteLine("has value ?" + number.HasValue);
            Console.WriteLine("value: " + number.GetValueOrDefault());
        }
    }

    public class GenericList<T>
    {
        public void Add(T value)
        {

        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {

        }
    }

    public class Utilities<T> where T : IComparable, new()
    {
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething(T Value)
        {
            var obj = new T();
        }
    }

    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CaculateDiscount(TProduct product)
        {
            return product.Price;
        }
    }

    public class Product
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class Book : Product
    {
        public string Isbn { get; set; }
    }

    public class Nullable<T> where T : struct
    {
        private object _value;

        public Nullable(T value)
        {
            _value = value;
        }
        public bool HasValue
        {
            get { return _value != null; }
        }
        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T)_value;
            return default(T);
        }
    }
}
