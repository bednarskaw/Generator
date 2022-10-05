using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GeneratorAplikacji
{
    [DataContract]
    public class GeneratedData
    {
        public GeneratedData()
        {
            sqlCommands = new List<Tuple<string, string>>();
        }

        [DataMember]
        public string ConnectionString { get; set; }

        [DataMember]
        public string CompanyName { get; set; }


        [DataMember]
        public List<Tuple<string, string>> sqlCommands { get; set; }

    }
}