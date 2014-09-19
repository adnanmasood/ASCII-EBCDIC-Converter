using System;
using System.IO;
using System.Text;

namespace ASCII_EBCDIC_Converter
{
    internal class Convertor
    {
        public static void Convert(string inFile, string inputType, string outFile, bool crlf, int crlfLength,
            string codepage)
        {
            byte[] fileArray = File.ReadAllBytes(inFile);

            if (inputType.ToLower() == "ebcdic")
                fileArray = ConvertAsciiToEbcdic(fileArray, codepage);
            else if (inputType.ToLower() == "ascii")
                fileArray = ConvertEbcdicToAscii(fileArray, codepage);
            else
                throw new Exception(
                    "Unable to process the conversion type. Please check the converto parameter in the config file.");

            using (var fileStream = new FileStream(outFile, FileMode.Create, FileAccess.Write))
            {
                int byteCount = 0;
                int offset = 0;

                if (crlf)
                {
                    var byteArray = new byte[crlfLength + Encoding.Default.GetBytes(Environment.NewLine).Length];
                    foreach (byte b in fileArray)
                    {
                        byteArray[byteCount++] = b;
                        if (byteCount%3000 == 0)
                        {
                            foreach (byte _byte in Encoding.Default.GetBytes(Environment.NewLine))
                                byteArray[byteCount++] = _byte;
                            fileStream.Write(byteArray, 0, byteArray.Length);
                            offset += byteCount;
                            byteCount = 0;
                        }
                    }
                }
                fileStream.Close();
            }
        }

        #region public static byte[] ConvertAsciiToEbcdic(byte[] asciiData)

        public static byte[] ConvertAsciiToEbcdic(byte[] asciiData, string codepage)
        {
            Encoding ascii = Encoding.ASCII;
            Encoding ebcdic = Encoding.GetEncoding(codepage);
            return Encoding.Convert(ascii, ebcdic, asciiData);
        }

        #endregion

        #region public static byte[] ConvertEbcdicToAscii(byte[] ebcdicData)

        public static byte[] ConvertEbcdicToAscii(byte[] ebcdicData, string codepage)
        {
            Encoding ascii = Encoding.ASCII;
            Encoding ebcdic = Encoding.GetEncoding(codepage);
            return Encoding.Convert(ebcdic, ascii, ebcdicData);
        }

        #endregion
    }
}