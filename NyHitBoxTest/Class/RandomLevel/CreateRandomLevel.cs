using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyHitBoxTest.Class.RandomLevel
{
    class CreateRandomLevel
    {
        private int _mapWidth;
        private int _mapHeight;
        private int _maximumBoxes;
        private int _totalSpace;
        private int _boxSquare;
        private int _totalNrBoxes;
        private int _preferedNumberBoxes;
        private int _preferedPreFabs;
        private List<Point> _takenPoints = new List<Point>();

        public CreateRandomLevel(int mapWidth, int mapHeight, int level)
        {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
            _totalSpace = mapHeight * mapWidth;
            _boxSquare = 40 * 40;
            _totalNrBoxes = _totalSpace / _boxSquare;
            _preferedNumberBoxes = _totalNrBoxes / 10+level*5;
            _preferedPreFabs = _preferedNumberBoxes / 3;
            
        }
        public void createLevel()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var randomPosY = rnd.Next(0, _mapHeight);
                var randomPosX = rnd.Next(0, _mapWidth);
                Point choosenPoint = new Point();
                choosenPoint.X = randomPosX;
                choosenPoint.Y = randomPosY;
               //bool existY = _takenPoints.Any(x => x.Y < choosenPoint.Y-40 && x.Y > choosenPoint.Y+40);
               //bool existX = _takenPoints.Any(x => x.X < choosenPoint.X - 40 && x.X > choosenPoint.X + 40);
               
                   //_takenPoints.Add(choosenPoint);
                   createGround(randomPosX, randomPosY);
               } //createWall(randomPosX+40,randomPosY-40);
            }


        public void createGround(int posX,int posY)
        {
            for (int i = 0; i < 10; i++)
            {
                bool existY = _takenPoints.Any(point => point.Y+40 < posY && point.Y-40 > posY);
                bool existX = _takenPoints.Any(point => point.X-40 > posX && point.X+40 < posX);
                if (!existY && !existX)
                {
                    Ground ground = new Ground(posX + i * 40, posY);
                    Point anotherGroundPoint = new Point(posX + i * 40, posY);
                    _takenPoints.Add(anotherGroundPoint);
                    Form1.CollisionSet._collidables.Add(ground);
                }
            }
        }
        public void createWall(int x, int y)
        {
            for (int i = 0; i < 3; i++)
            {
                Ground ground = new Ground(x , y +i * 40);
                Form1.CollisionSet._collidables.Add(ground);
            }
        }
    }
}

//for (int i = 0; i < _preferedNumberBoxes; i++)
//{
//Ground ground = new Ground(100 + i * 45, 200);
//Form1.CollisionSet._collidables.Add(ground);
//}
