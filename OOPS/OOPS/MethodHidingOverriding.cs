using System;
namespace OOPS

{
    public class Parent
    {
        public virtual void Show()
        {
            Console.WriteLine("Parent Class Show Method");
        }
        public virtual void Display()
        {
            Console.WriteLine("Parent Class Display Method");
        }
    }
    public class Child : Parent
    {
        //Method Overriding
        public override void Show()
        {
            Console.WriteLine("Child Class Show Method");
        }

        //Method Hiding/Shadowing
        public new void Display()
        {
            Console.WriteLine("Child Class Display Method");
        }
    }
    class MethodHidingOverriding
       {
        static void Main3()
        {
            Parent obj = new Child();
            obj.Show();
            obj.Display();

            Console.ReadKey();
        }
    }
}
