using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapperTest.TestCase1
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Color> Colors { get; set; }
        public Feedback[] Feedbacks { get; set; }
    }
}
