using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorAplikacji
{
   
        static class Program
        {
            /// <summary>
            /// G³ówny punkt wejœcia dla aplikacji.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (StreamReader sr = File.OpenText(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName))
                {
                    string s = "";
                    bool user_content = false;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s == "<<<<<<<<<<<<<<<<<<<<USERDATA>>>>>>>>>>>>>>>>>>>>")
                            user_content = true;

                        if (user_content)
                            break;
                    }

                    if (user_content)
                    {
                    GeneratedData generatedData = new GeneratedData();
                    generatedData.CompanyName = "Nazwa";
                    using (Stream stream = new MemoryStream())
                    {
                        byte[] data = System.Text.Encoding.UTF8.GetBytes(sr.ReadToEnd().Trim());
                        stream.Write(data, 0, data.Length);
                        stream.Position = 0;
                        DataContractSerializer deserializer = new DataContractSerializer(typeof(GeneratedData));
                        generatedData = (GeneratedData)deserializer.ReadObject(stream);

                    }


                    Application.Run(new AplikacjaWynikowa(generatedData));
                        return;
                    }

                }


                Application.Run(new Generator());
            }
        }
}

