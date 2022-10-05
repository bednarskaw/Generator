using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorAplikacji
{
    public class Table
    {
        public string Name { get; set; }

        public List<Tuple<string, string>> item = new List<Tuple<string, string>>();

    }
}
