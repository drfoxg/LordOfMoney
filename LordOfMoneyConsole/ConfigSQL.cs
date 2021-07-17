using System;
using System.Collections.Generic;
using System.Text;

namespace LordOfMoneyConsole
{
    class ConfigSQL
    {
        public string Type { set; get; }
        public string Path { set; get; }
        public string Driver { set; get; }
        public bool Active { set; get; }

        public ConfigSQL() { }
    }
}
