using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Accounting
{
    internal class People
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public People(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public People(string name) 
        {
            Name = name;
        }

        public People() { }
    }
}
