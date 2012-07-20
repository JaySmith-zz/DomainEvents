using DomainEvents.Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEvents.Example
{
    public class DemoApplication
    {
        public void Run()
        {
            var person = new Person("Kristina", "Parker");
            
            // Change Last Name
            person.LastName = "Smith";
        }
    }
}
