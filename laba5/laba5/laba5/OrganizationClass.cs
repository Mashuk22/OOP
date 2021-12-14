using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5
{
    public partial class Organization
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
