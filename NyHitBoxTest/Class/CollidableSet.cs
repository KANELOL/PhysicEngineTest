using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyHitBoxTest.Class
{
    public class CollidableSet
    {
        public List<Collidable> _collidables;
        public CollidableSet()
        {
            _collidables = new List<Collidable>();
        }

        public List<PictureBox> SpawnAllCollidables()
        {
            List<PictureBox> newList = new List<PictureBox>();
            foreach (var x in _collidables)
            {
                newList.Add(x._hitBox);
            }

            return newList;
        }
        public List<Collision> CheckCollisions()
        {
            var collisions = new List<Collision>();
            var combinationCount = _collidables.Count * _collidables.Count;
            for (var i = 0; i < combinationCount; i++)
            {
                var cIndex1 = i / _collidables.Count;
                var cIndex2 = i % _collidables.Count;
                //UpCheck
                //if (_collidables[cIndex1]._hitBox != _collidables[cIndex2]._hitBox) {
                if(cIndex1!=cIndex2){
                    if (_collidables[cIndex1]._hitBox.Bounds.IntersectsWith(_collidables[cIndex2]._hitBox.Bounds))
                    {

                        {
                            var collision = new Collision(_collidables[cIndex1], _collidables[cIndex2]);

                            collisions.Add(collision);

                        }
                    }
                }
            }

            return collisions;
        }
    }
}
