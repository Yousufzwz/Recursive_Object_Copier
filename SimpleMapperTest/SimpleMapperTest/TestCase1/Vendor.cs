using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapperTest.TestCase1
{
    public class Vendor
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public bool Enlisted { get; set; }

        public int GetRatingScore()
        {
            throw new NotImplementedException();
        }
    }
}
