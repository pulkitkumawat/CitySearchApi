//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ConsoleApp1
//{
//    public class TestClass<T>
//    {
//        T[] obj = new T[5];
//        int count = 0;

//        public void Add(T obj)
//        {
//            if (count < 5)
//            {
//                this.obj[count] = obj;
//                count++;
//            }
//        }
//        public T this[int index]
//        {
//            get { return obj[index]; }
//            set { obj[index] = value; }
//        }
//    }

//    public class sort
//    {
//        public static string Dir = "asc";
//        public static string Field = "name";
//    }

//    public class delExample
//    {


//        public static void m1()
//        {
//            Console.WriteLine("m1");
//        }
//        public static void m2()
//        {
//            Console.WriteLine("m2");
//        }
//        public void m3()
//        {
//            Console.WriteLine("m3");
//        }
//    }
//    class Class1
//    {
//        public delegate void delmethod();
//        static void Main(string[] args)
//        {
//            TestClass<int> obj = new TestClass<int>();

//            obj.Add(1);
//            obj.Add(2);
//            obj.Add(3);
//            obj.Add(4);
//            obj.Add(5);
//            obj.Add(6);

//            for (int i = 0; i < 5; i++)
//            {
//                Console.WriteLine(obj[i]);
//            }

//            string orderBy = string.Empty;


//            orderBy = string.IsNullOrEmpty(orderBy) ? sort.Dir == "desc" ? sort.Field + ' ' + sort.Dir : sort.Field : sort.Dir == "desc" ? orderBy + ", " + sort.Field + ' ' + sort.Dir : orderBy + ", " + sort.Field;

//            Console.WriteLine(orderBy);

//            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };

//            Queue<int> q = new Queue<int>(arr);

//            q.Enqueue(5);
//            q.Enqueue(4);
//            q.Enqueue(3);
//            q.Enqueue(2);
//            q.Enqueue(1);
//            q.Dequeue();

//            foreach (var item in q)
//            {
//                //Console.WriteLine(q.Peek());
//                Console.WriteLine(item);
//            }

//            delmethod del1 = delExample.m1;
//            delmethod del2 = new delmethod(delExample.m2);

//            delExample obj2 = new delExample();
//            del2 += obj2.m3;


//            del1();
//            del2();

//            Console.ReadKey();
//        }
//    }
//}
