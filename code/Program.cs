using System;
using System.Configuration;
using ASCII_EBCDIC_Converter;

namespace ASCII_EBCIDIC_Converter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Process();
        }

        private static void Process()
        {
            #region banner
            Console.WriteLine("\n=====================================================================");
            Console.WriteLine("aec.exe - Simple ASCII / EBCDIC Convertor Util");
            Console.WriteLine("Uses the application config file for values so make sure it's there.");
            Console.WriteLine("Comments/Questions - adnan.masood@owasp.org");
            Console.WriteLine("=====================================================================\n");
            #endregion

            try
            {
                string inFile;
                string outFile;
                string convertTo;
                bool cRLF;
                int bytesToSkipForCRLF;
                string codePage;

                GetConfigValues(out inFile, out outFile, out convertTo, out cRLF, out bytesToSkipForCRLF, out codePage);
                Convertor.Convert(inFile, convertTo, outFile, cRLF, bytesToSkipForCRLF, codePage);
                Console.WriteLine("\nOutput file written: " + outFile);
                Console.WriteLine("\nAll Done. Bye now.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOops, something broke!");
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n");
                Environment.Exit(-1);
            }
        }

        private static void GetConfigValues(out string inFile, out string outFile, out string convertTo, out bool cRLF,
            out int bytesToSkipForCRLF, out string codePage)
        {
            inFile = ConfigurationManager.AppSettings["sourcefilename"];
            outFile = ConfigurationManager.AppSettings["outputfilename"];
            convertTo = ConfigurationManager.AppSettings["convertto"];
            cRLF = bool.Parse(ConfigurationManager.AppSettings["crlf"]);
            bytesToSkipForCRLF = int.Parse(ConfigurationManager.AppSettings["skipbytesforcrlf"]);
            codePage = ConfigurationManager.AppSettings["codepage"];
        }
    }
}