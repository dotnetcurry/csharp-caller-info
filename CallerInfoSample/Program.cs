using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CallerInfoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            LoopInfinitely();
        }

        private static void LoopInfinitely()
        {
            while (true)
            {
                ConsoleKeyInfo keyCode = Console.ReadKey();
                Console.WriteLine(keyCode.Key.ToString());
                if (keyCode.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    if (keyCode.Key >= ConsoleKey.F1 && 
                        keyCode.Key <= ConsoleKey.F10)
                    {
                        Logger.Instance.Warning(new
                            ApplicationException("Warning: You pressed keycode *" +
                            keyCode.Key.ToString() + "* Exception"));
                    }
                    else if (keyCode.Key >= ConsoleKey.D0 && 
                        keyCode.Key <= ConsoleKey.D9)
                    {
                        Logger.Instance.Debug(new
                            ApplicationException("Debug: You pressed keycode *" +
                            keyCode.Key.ToString() + "* Exception"));
                    }
                    else
                    {                        
                        LogError(keyCode);
                    }
                }
            }
        }

        private static void LogError(ConsoleKeyInfo keyCode)
        {
            Logger.Instance.Error(new
                           ApplicationException("ERROR: You pressed keycode *" +
                           keyCode.Key.ToString() + "* Exception"));
        }
    }
}
