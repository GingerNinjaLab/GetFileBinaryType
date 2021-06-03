using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GetFileBinaryType
{
    class Program
    {
        public enum BinaryType : uint
        {
            SCS_32BIT_BINARY = 0, // A 32-bit Windows-based application
            SCS_64BIT_BINARY = 6, // A 64-bit Windows-based application.
            SCS_DOS_BINARY = 1, // An MS-DOS – based application
            SCS_OS216_BINARY = 5, // A 16-bit OS/2-based application
            SCS_PIF_BINARY = 3, // A PIF file that executes an MS-DOS – based application
            SCS_POSIX_BINARY = 4, // A POSIX – based application
            SCS_WOW_BINARY = 2 // A 16-bit Windows-based application 
        }

        [DllImport("kernel32.dll")]
        private static extern bool GetBinaryType(string lpApplicationName, out BinaryType lpBinaryType);

        static void Main(string[] args)
        {
            if (args.Length!=1)
            {
                Console.WriteLine("Single argument is required of the path to the binary file");
                return;
            }
            var filePath = args[0];
            if (!System.IO.File.Exists(filePath))
            {
                Console.WriteLine("Path does not exist");
                return;
            }
            BinaryType result;
            var ok = GetBinaryType(filePath, out result);
            if (!ok)
            {
                Console.WriteLine("File");
            }
            else
            {
                switch (result)
                {
                    case BinaryType.SCS_32BIT_BINARY:
                        Console.WriteLine("A 32-bit Windows-based application");
                        break;
                    case BinaryType.SCS_64BIT_BINARY:
                        Console.WriteLine("A 64-bit Windows-based application");
                        break;
                    case BinaryType.SCS_DOS_BINARY:
                        Console.WriteLine("An MS-DOS – based application");
                        break;
                    case BinaryType.SCS_OS216_BINARY:
                        Console.WriteLine("A 16-bit OS/2-based application");
                        break;
                    case BinaryType.SCS_PIF_BINARY:
                        Console.WriteLine("A PIF file that executes an MS-DOS – based application");
                        break;
                    case BinaryType.SCS_POSIX_BINARY:
                        Console.WriteLine("A POSIX – based application");
                        break;
                    case BinaryType.SCS_WOW_BINARY:
                        Console.WriteLine("A 16-bit Windows-based application");
                        break;
                    default:
                        Console.WriteLine("Unknown type");
                        break;
                }

            }
        }
    }
}
