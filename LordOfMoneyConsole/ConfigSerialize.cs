using System;
using System.Collections.Generic;
using System.Text;

namespace LordOfMoneyConsole
{
    class ConfigSerialize
    {
        public string Type { set; get; }
        public string Path { set; get; }
        public bool Active { set; get; }

        public ConfigSerialize() { }
    }
}
