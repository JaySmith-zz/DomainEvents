using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEvents.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.Initialize();

            var application = ObjectFactory.GetInstance<DemoApplication>();
            application.Run();

            Console.Read();
        }
    }
}
