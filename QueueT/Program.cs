using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueT
{
    public class MyQueue<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public MyQueue()
        {
            _items = new T[4];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public int Count => _count;//encapsulation enq anum

        public void Enqeue(T value)//avelacnum enq herti verjum
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_tail] = value;
            _tail = (_tail + 1) % _items.Length;//_tail = (3 + 1) % 4 = 4 % 4 = 0 noric darnum e 0
            _count++;
        }

        public T Dequeue()// heracnum ev veradardznum e arajin andamy
        {
            if ( _count == _items.Length)
            {
                Resize();
            }
            T value = _items[_head];
            _items[_head] = default(T);
            _head = (_head + 1) % (_items.Length);
            _count--;
            return value;
        }

        public T Peek()// veradardznum e arajin tary aranc hanelu
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queu is empty");
            }
            return _items[_head];
        }
        public void Resize()
        {
            T[] newarr = new T[4];
            for (int i = 0; i < _count; i++)
            {
                newarr[i] = _items[i];
            }
            _items = newarr;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyQueue<string> queue = new MyQueue<string>();

            queue.Enqeue("Monte");
            queue.Enqeue("Ani");
            queue.Enqeue("Lena");
            queue.Enqeue("Pen");

            Console.WriteLine($"{queue.Peek()}");

            Console.WriteLine($"{queue.Dequeue()}");

            Console.WriteLine($"{queue.Peek()}");

        }
    }
}
