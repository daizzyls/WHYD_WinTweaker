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
                    return 404;
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

                key.SetValue(tweak.Value_Name, newValue, RegistryValueKind.DWord);
                Console.WriteLine($"[SUCCESS] Tweak-{tweak.Name} set to {newValue}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==| Program start |==");

            RegTweak show_file_ext_tweak = new RegTweak();
            show_file_ext_tweak.Name = "";
            show_file_ext_tweak.Sub_Key_Path = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
            show_file_ext_tweak.Value_Name = "HideFileExt";

            int currentState = GetTweakState(show_file_ext_tweak);
            
            if(currentState == 1)
            {
                Console.WriteLine("[STATUS] Extensions are hided");
                Console.WriteLine("[STATUS] Turning ON...");
                ApplyTweak(show_file_ext_tweak, 1);
                Console.WriteLine("[STATUS] Tweak is successfully applied");
            }
            else
            {
                Console.WriteLine("[STATUS] Nothing to set. Already applied");
            }

            int updatedStatus = GetTweakState(show_file_ext_tweak);
            Console.WriteLine($"[STATUS] Finished tweak value - {updatedStatus}");

            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();

        }
    }
}
