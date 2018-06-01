using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class pluginsClass
    {

    }

    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        bool Load(string application);
    }

    public class MyPlugin : IPlugin
    {
        public string Name { get { return "MyPlugin"; } }

        public string Description { get { return "my sample plugin"; } }

        public bool Load(string application)
        {
            return true;
        }
    }
}
