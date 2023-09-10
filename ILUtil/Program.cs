
using System.Runtime.InteropServices;

namespace CILVerify
{
    internal class Program
    {
        [DllImport("ilasm-lib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "execute", CharSet = CharSet.Unicode)]
        static extern int ILAsm_execute(int argc, string[] argv);

        static string[] ArgsFrom(int start, string[] args)
        {
            string[] actual = new string[args.Length - start];

            for (int i = 0; i < actual.Length; i++)
            {
                actual[i] = args[i + start];
            }

            return actual;
        }

        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Usage: il <asm | verify> [args]");
                return;
            }

            switch(args[0])
            {
                case "asm": ILAsm_execute(args.Length, args);
                    return;

                case "verify": ILVerify.ILVerify.Execute(ArgsFrom(1, args));
                    return;
            }

            Console.WriteLine("Usage: il <asm | verify> [args]");
        }
    }
}
