using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyHitBoxTest.Class
{
    class Ground : Collidable
    {
        public Ground(int x, int y) : base(x, y, 40, 40, 0, 0)
        {
            _tag = "Ground";
        }
    }
}
