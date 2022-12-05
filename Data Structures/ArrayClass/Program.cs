using System;

namespace DataStructures
{
    public class Array
    {
        
        public int Count 
        {
            get;
            private set;
        }

        private int LastIndex
        {
            get
            {
                return this.Count - 1;
            }
        }

        private int activeIndex;
        private int[] numbers;
        
        public Array(int Lenght)
        {
            Count = Lenght;
            numbers = new int[Count];
            activeIndex = 0;
        }

        public void Insert(int number)
        {
            if(activeIndex <= LastIndex)
            {
                numbers[activeIndex++] = number;
            }
            else
            {
                int[] oldNumbers = numbers;
                numbers = new int[++Count];

                for(int i = 0; i < activeIndex; i++)
                {
                    numbers[i] = oldNumbers[i];
                }

                numbers[activeIndex++] = number; 
            }

        }
        public void RemoveAt(int index)
        {
            if(index > LastIndex || index < 0)
            {
                throw new Exception("Out of Range");
            }

            int[] oldNumbers = numbers;
            numbers = new int[--Count];

            for(int i = 0; i < index; i++)
            {
                numbers[i] = oldNumbers[i];
            }
            for(int i = index; i < Count; i++)
            {
                numbers[i] = oldNumbers[i + 1];
            }
        }
        public int IndexOf(int number)
        {
            for(int i = 0; i < Count; i++)
            {
                if(numbers[i] == number)
                    return i;
            }
            return -1;
        }
        public int this[int key]
        {
            get
            {
                return numbers[key];
            }
        }
        public void Print()
        {
            Console.Write("[");
            for(int i = 0; i < Count; i++)
            {
                Console.Write(numbers[i]);
                if(i != Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]");
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = new Array(3);
            arr.Insert(1);
            arr.Insert(3);
            arr.Insert(4);
            arr.Insert(5);
            arr.RemoveAt(0);
            arr.Print();
            Console.WriteLine("\narr[2]:" + arr[2]);
            Console.WriteLine("count: " + arr.Count);
            Console.WriteLine("index of 5:" + arr.IndexOf(5));
            Console.ReadLine();
        }
    }
}