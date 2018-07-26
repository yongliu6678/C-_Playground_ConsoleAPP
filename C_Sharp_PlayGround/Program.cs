using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_PlayGround
{
    public class BaseClass { public string name = "baseClass"; }
    public class ChildrenClass : BaseClass { public string cName = "children"; }
    class Program
    {
       





        //The extern modifier is used to declare a method that is implemented externally.
        //A common use of the extern modifier is with the DllImport attribute when you are using Interop services to call into unmanaged code.
        //In this case, the method must also be declared as static, as shown in the following example:

        //Example 1. 
        //    In this example, the program receives a string from the user and displays it inside a message box.
        //    The program uses the MessageBox method imported from the User32.dll library.

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);


        static void Main(string[] args)
        {

            // how to get an instance's class name
            ChildrenClass cd = new ChildrenClass();
            BaseClass bc = cd;
            string className = bc.GetType().Name;






            //Example 1. 
            //    In this example, the program receives a string from the user and displays it inside a message box.
            //    The program uses the MessageBox method imported from the User32.dll library.
            string myString;
            Console.Write("Enter your message: ");
            myString = Console.ReadLine();
            var x = MessageBox((IntPtr)0, myString, "My Message Box", 0);


            // passed by refference behaviour
            TestRef t = new TestRef();
            t.Something = "Foo";
            t.n = 10;
            Console.WriteLine("--------------------- has ref keyword -------------------------");
            DoSomething(ref t);
            Console.WriteLine("after funtion DoSomething(ref TestRef t): " + t.ToString());
            //output
            //--------------------- has ref keyword -------------------------
            //In funtion DoSomething(ref TestRef t): Not just a changed t, but a completely different TestRef object,10000000
            //after funtion DoSomething(ref TestRef t): Not just a changed t, but a completely different TestRef object,10000000


            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("--------------------- no ref keyword --------------------------");

            t.Something = "Foo";
            t.n = 10;
            DoSomething(t);
            Console.WriteLine("after funtion DoSomething(TestRef t): " + t.ToString());
            // output
            //-------------------- - no ref keyword --------------------------
            //in funciton DoSomething(TestRef t): Not just a changed t, but a completely different TestRef object,10000000
            //after funtion DoSomething(TestRef t): Foo,10



            Console.ReadKey();
        }

        static void DoSomething(ref TestRef t)
        {
            t = new TestRef();
            t.Something = "Not just a changed t, but a completely different TestRef object";
            t.n = 10000000;
            Console.WriteLine("In funtion DoSomething(ref TestRef t): " + t.ToString());
        }

        static void DoSomething(TestRef t)
        {
            t = new TestRef();
            t.Something = "Not just a changed t, but a completely different TestRef object";
            t.n = 10000000;
            Console.WriteLine("in funciton DoSomething(TestRef t): " + t.ToString());
        }
    }

    public class TestRef
    {
        public String Something;
        public int n;

        public String ToString()
        {
            return Something + "," + n;
        }
    }
}
