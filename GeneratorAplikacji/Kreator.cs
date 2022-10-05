using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace GeneratorAplikacji
{
    public class Kreator
    {
        internal static void MakeExe(string sourceExe, string destinationExe, GeneratedData generatedData, string dll)
        {
            string path = Path.GetDirectoryName(destinationExe);
            string filename_without_ext = Path.GetFileNameWithoutExtension(destinationExe);
            string directoryPath = path + "\\" + filename_without_ext;
            string filename_with_ext = Path.GetFileName(destinationExe);
          
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            //if (File.Exists(destinationExe))
            //    File.Delete(destinationExe);

            File.Copy(dll, directoryPath + "\\" + "Guna.UI.dll");
            File.Copy(sourceExe, directoryPath + "\\" + filename_with_ext);
       
            using (var sw = File.AppendText(directoryPath + "\\" + filename_with_ext))
            {
                for (var i = 0; i < 20; i++)
                    sw.Write("\n");

                sw.WriteLine("<<<<<<<<<<<<<<<<<<<<USERDATA>>>>>>>>>>>>>>>>>>>>");
                sw.Flush();


                GeneratedData konfiguracja = new GeneratedData();
                var serializer = new DataContractSerializer(typeof(GeneratedData));
                using (var writer = new XmlTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented; 
                    serializer.WriteObject(writer, generatedData);
                    writer.Flush();
                }
            }

           

        }
    }
}
