using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyHitBoxTest.Class
{
    public class Collision : Tuple<Collidable, Collidable>
    {
        public bool AreEqual => Item1 == Item2;
        public bool IsCollision
        {
            get { return true; }

        }

        public Collision(Collidable a, Collidable b) : base(a, b)
        {

        }
    }
}
