using System;
using System.IO;
using UglyToad.PdfPig;

class Program
{
    const string Version = "PdfTextDump v1.0";

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine(Version);
            Console.WriteLine("Usage: PdfTextDump.exe <file.pdf>");
            Environment.Exit(0);
        }

        string path = args[0];
        if (!File.Exists(path))
        {
            Console.Error.WriteLine("Error: File not found.");
            Environment.Exit(1);
        }

        try
        {
            using var document = PdfDocument.Open(path);
            foreach (var page in document.GetPages())
            {
                Console.WriteLine(page.Text);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error reading PDF: {ex.Message}");
            Environment.Exit(1);
        }
    }
}
