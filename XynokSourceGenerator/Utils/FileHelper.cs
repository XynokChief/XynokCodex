using System;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace XynokSourceGenerator.Utils
{
    public class FileHelper
    {
        public static string GetEmbededResource(string path)
        {
            using var stream = typeof(FileHelper).Assembly.GetManifestResourceStream(path);
            if (stream == null)
            {
                return ($"Resource not found: {path}");
            }

            using var streamReader = new StreamReader(stream);

            return streamReader.ReadToEnd();
        }

        public static string GetCurrentProjectDirectory(EnumDeclarationSyntax syntax)
        {
            var filePath = syntax.SyntaxTree.FilePath;
            var dirPath = filePath.Replace("Assets", "@");
            var localPath = dirPath.Split('@')[0];
            return localPath.Replace("\\", "/");
        }


        public static void WriteFile(string path, string content, string fileName = ".txt")
        {
            string pathAndFileName = path + fileName;
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(pathAndFileName))
                {
                    string fileContent = File.ReadAllText(pathAndFileName);

                    if (fileContent == content) return;

                    File.Delete(pathAndFileName);
                }

                // Create a new file     
                using FileStream fs = File.Create(pathAndFileName);
                // Add some text to file    
                Byte[] bytes = new UTF8Encoding(true).GetBytes(content);
                fs.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}