using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace imageDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Datalist (Seperate With '/' and Change Spaces to Something Like '_' to Prevent any Search Problems)");
            String DATA = Console.ReadLine();
            String[] ARRAY = DATA.Split("/");

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Checking And Installing Requirements...");
            Console.WriteLine(runCommand());

            String tmp = "";
            foreach (String a in ARRAY)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(a + ": Started Working and Waiting for Downloading Files");
                File.AppendAllText("log.txt", a + ": Started Working and Waiting for Downloading Files" + Environment.NewLine);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                tmp = runCommand(a);
                Console.WriteLine(a + " : " + tmp);
                File.AppendAllText("log.txt", a + " : " + tmp + Environment.NewLine);
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(a + ": Finished Downloading And Putting Files in Correct Place");
                File.AppendAllText("log.txt", a + ": Finished Downloading And Putting Files in Correct Place" + Environment.NewLine);
                Console.ResetColor();
                string createText = a;
                File.WriteAllText("lastCommand.txt", createText);
                Thread.Sleep(500);
            }
        }

        static string runCommand(String FlowerName)
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\windows\system32\cmd.exe",
                    Arguments = @"/c python flickr_scraper.py --search " + FlowerName + " --n 130 --download",
                    UseShellExecute = false,

                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();

            string result = proc.StandardOutput.ReadToEnd();
            string[] ARR = result.Split("\n");
            try
            {
                return ARR[ARR.Length - 4];
            }
            catch
            {
                return "No Pictures Found For This Phrase";
            }
        }
        static string runCommand()
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\windows\system32\cmd.exe",
                    Arguments = @"/c pip install flickrapi",
                    UseShellExecute = false,

                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();

            string result = proc.StandardOutput.ReadToEnd();
            return result;
        }
        static string runCommandM()
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\windows\system32\cmd.exe",
                    Arguments = @"/c pip install xattr && curl -O https://raw.githubusercontent.com/munki/macadmin-scripts/main/installinstallmacos.py",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();

            string result = proc.StandardOutput.ReadToEnd();
            return result;
        }
        static string runCommandC()
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\windows\system32\cmd.exe",
                    Arguments = @"/c python installinstallmacos.py --raw--seedprogram DeveloperSeed",
                    UseShellExecute = false,
                    
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();

            string result = proc.StandardOutput.ReadToEnd();
            return result;
        }
    }
}
