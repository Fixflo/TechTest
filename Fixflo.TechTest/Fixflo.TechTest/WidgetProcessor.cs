using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// put usings in here which are not needed

namespace Fixflo.TechTest
{
    /// <summary>
    /// myt class called wisget
    /// </summary>
    internal class Widget
    {
        public Widget()
        {
        }

        public void Go(Settings settings)
        {
            var ProcessorOld = new ProcessorOld();
            ProcessorOld.Print("I am a processor called ProcessorOld");
            var t1 = ProcessorOld.GetValue(new CostClc(), settings.Cost, settings.Units, out string comment);
            ProcessorOld.Print(t1.ToString());
            ProcessorOld.Print(comment);

            var ProcessorNew = new ProcessorNew();
            ProcessorNew.Print("I am a processor called ProcessorNew");
            var t2 = ProcessorNew.GetValue(new CostClc(), settings.Cost, settings.Units, out string comment2);
            ProcessorNew.Print(t2.ToString());
            ProcessorNew.Print(comment2);

            var fib = new ProcessorFibonacci();
            fib.Print("I am a processor called fib");
            var fibVal = ProcessorNew.GetValue(new CostClc(), settings.Cost, settings.Units, out string commentfib);
            fib.Print(t2.ToString());
            ProcessorNew.Print(comment2);
        }
    }

    public class Settings
    {
        public int Cost { get; set; }

        public int Units { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public interface IProcessor
    {
        void Print(string message);

        int GetValue(CostClc clc, int c, int u, out string c2);
    }

    public class ProcessorNew : IProcessor
    {
        #region methods

        public void Print(string message)
        {
            //// write the message out here
            Console.WriteLine(message);
        }

        public int GetValue(CostClc clc, int c, int u, out string c2)
        {
            c2 = "Comment 1";

            var ret = 0;
            for (int i = 0; i < u; i++)
            {
                var magicNumber = GetMagicNumber();
                ret = ret + magicNumber;
            }

            return clc.RunCtsInt(c, ret);
        }

        // for the purposes of this testm this method must remain as is. Pretend that this is a long running DB call. 
        // It does always return the name number under all conditions. You can assume this to be true always.
        private int GetMagicNumber()
        {
            return 6;
        }

        #endregion
    }

    public class ProcessorOld : IProcessor
    {
        #region methods

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        #endregion 

        private void RunAnotherThing()
        {
            Console.WriteLine("I am another method to run");
        }

        public int GetValue(CostClc clc, int c, int u, out string c2) { c2 = "comment2"; return clc.RunCtsInt(c, 10); }
    }

    public class ProcessorFibonacci : IProcessor
    {
        #region methods

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        #endregion 

        private void RunAnotherThing()
        {
            Console.WriteLine("I am another method to run");
        }

        public int GetValue(CostClc clc, int c, int u, out string c2)
        {
            c2 = "fiboacci";

            // Write this!!!
            return 0;
        }
    }

    public class CostClc
    {
        public int RunCtsInt(int intValue, int intOtherVal)
        {
            return intValue * intOtherVal;
        }
    }
}
