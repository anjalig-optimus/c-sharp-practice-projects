using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    //METHOD OVERRIDING 
    class Class1
    {
        //Virtual Function (Overridable Method)
        public virtual void Show()
        {
            //Parent Class Logic Same for All Child Classes
            Console.WriteLine("Parent Class Show Method");
        }
    }
    class Class2 : Class1
    {
        //Overriding Method
        public override void Show()
        {
            //Child Class Reimplementing the Logic
            Console.WriteLine("Child Class Show Method");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Class1 obj1 = new Class2();
            obj1.Show(); //Resolve at Runtime

            Console.ReadKey();
        }
        //static void Main(string[] args)
        //{
        //    int x = 10;
        //    Program obj= new Program();
        //    Program obj2 = new Program(x);

        //}
        //public Program() {
        //    Console.WriteLine("HI");
        //}
        //private Program(int x)
        //{  
        //    Console.WriteLine(x);
        //}
    }
}

