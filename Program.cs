using System;
using System;
using Microsoft.Win32;

namespace MyWinTweaker
{
    public class RegTweak
    {
        public string Name;
        public string Sub_Key_Path;
        public string Value_Name;
    }
    internal class Program
    {
        static int GetTweakState(RegTweak tweak)
        {
            using(RegistryKey key = Registry.CurrentUser.OpenSubKey(tweak.Sub_Key_Path , false))
            {
                if(key == null)
                {
                    Console.WriteLine("[ERROR]Registry branch not found (read , GetTweakState)");
                    return 1;
                }

                int currentValue = (int)key.GetValue(tweak.Value_Name, 1);
                return currentValue;
            }
        }

        static void ApplyTweak(RegTweak tweak , int newValue)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(tweak.Sub_Key_Path, true))
            {
                if(key == null)
                {
                    Console.WriteLine("[ERROR]Registry branch not found (write , ApplyTweak)");
                    return;
                }

            }
        }

        static void Main(string[] args)
        {
        }
    }
}
