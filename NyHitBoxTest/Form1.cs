using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;
using NyHitBoxTest.Class;
using NyHitBoxTest.Class.LineFolder;
using NyHitBoxTest.Class.RandomLevel;
using Line = NyHitBoxTest.Class.Line;

namespace NyHitBoxTest
{
    public partial class Form1 : Form
    {
       public static CollidableSet CollisionSet = new CollidableSet();
        Player player = new Player(0, 0, 20, 20, 0, 0);
        public static Form1 form1;


        // Cache font instead of recreating font objects each time we paint.
        
        public Form1()
        {
            form1 = this;
            LoadGame();
            InitializeComponent();
        }

        private void LoadGame()
        {
            CreateRandomLevel newLevel = new CreateRandomLevel(ClientSize.Width,ClientSize.Height,10);
            newLevel.createLevel();

            //for (int i = 0; i < 10; i++)
            //{
            //    Ground ground = new Ground(100+i*45, 50);
            //    CollisionSet._collidables.Add(ground);
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    Ground ground = new Ground(100 + i * 45, 200);
            //    CollisionSet._collidables.Add(ground);
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    Collidable x = new Collidable(0, 500 - 40 * i, 40, 40,  1, 1+i);
            //    CollisionSet._collidables.Add(x);

            //}
           
            CollisionSet._collidables.Add(player);



            List<PictureBox> newList = CollisionSet.SpawnAllCollidables();
            foreach (var x in newList)
            {
                Controls.Add(x);
            }
        }


        
        /// <summary>
        /// ///////////////////////////
        /// </summary>
        private void gameEngineTimer_Tick(object sender, EventArgs e)
        {
            foreach (var x in CollisionSet._collidables)
            {
                x.Move();
                if (x._hitBox.Top > ClientSize.Height)
                {
                    x._hitBox.Top = 0;
                }
                if (x._hitBox.Top < 0)
                {
                    x._hitBox.Top = ClientSize.Height;
                }
                if (x._hitBox.Left < 0)
                {
                    x._hitBox.Left = ClientSize.Width;
                }
                if (x._hitBox.Left > ClientSize.Width)
                {
                    x._hitBox.Left = 0;
                }
                player.PlayerMove();
                
            }

            var checkCollisions = CollisionSet.CheckCollisions();
            foreach (var x in checkCollisions)
            {
                label1.Text = x.ToString();
                x.Item2.GetFree(x.Item1);
                //if (x.Item1._hitBox.Top == x.Item2._hitBox.Top-x.Item2._height)
                //Checking Y-axis and over and under.
              //if  (x.Item2._hitBox.Top > x.Item1._hitBox.Top)
              //{
              //    x.Item2._speedY = -x.Item2._speedY /*+ x.Item1._mass*/;
              //    x.Item2.GetFree(x.Item1,0);
              //  }
              //  if (x.Item2._hitBox.Top < x.Item1._hitBox.Top)
              //  {
              //      x.Item2._speedY = -x.Item2._speedY;
              //      x.Item2.GetFree(x.Item1, 1);
              //  }
              //  //Checking x-axis left and right
              //  if (x.Item2._hitBox.Left > x.Item1._hitBox.Left)
              //  {
              //      x.Item2._speedX = +x.Item2._speedX;
              //      x.Item2.GetFree(x.Item1, 2); ;
              //  }
              //  if (x.Item2._hitBox.Left < x.Item1._hitBox.Left)
              //  {
              //      x.Item2._speedX = -x.Item2._speedX;
              //      x.Item2.GetFree(x.Item1, 3); ;
              //  }



                //if (x.Item1._hitBox.Top < x.Item2._hitBox.Top) x.Item1._speed -= x.Item2._speed + x.Item2._mass;

            }
        }
    }
}
