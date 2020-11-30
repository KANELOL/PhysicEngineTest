using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace NyHitBoxTest.Class
{
    public class Collidable
    {
        public int _x;
        public int _y;
        public PictureBox _hitBox = new PictureBox();
        public int _width;
        public int _height;
        public int _newtons;
        public int _mass;
        public string _tag;
        public int _speedX;
        public int _speedY;
        public int fineTune = 5;
        public int _gravity;
        public bool _grounded;
        public bool _jumping;
        public int _maxFallSpd;

        public Collidable(int x, int y, int width, int height, int speedX, int mass) {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _mass = mass;
            _newtons = _mass;
            _gravity = 3;
            _maxFallSpd = 4;

           
            _hitBox.Width = _width;
            _hitBox.Height = _height;
            _hitBox.Top = _y;
            _hitBox.Left = _x;
            _speedX = speedX;
            _speedY = 0;
            _hitBox.BackColor = Color.Blue;


        }

        public void spawn()
        {

        }

        public void Move()
        {
           
            //_newtons = _mass + _mass * _speed - _mass;

            if (_tag == "Ground")
            {
                _speedY = 0;
                _speedX = 0;
            }

            //_newtons = _mass+_mass * _speed;
            if (_grounded) _speedY = 0;
            _hitBox.Top += _speedY;
            if (!_grounded && !_jumping)
            {
                if(_speedY < _maxFallSpd)
                _speedY += _gravity;
            }
            //if (!_grounded) _gravity++;
            
            _hitBox.Left += _speedX;
            _grounded = false;

        }

        public bool IsLeft(Collidable x)
        {
            var underXTop = _hitBox.Top + _hitBox.Height > x._hitBox.Top+ x._speedX;
            var overXTopAndHeight = _hitBox.Top < x._hitBox.Top+x._hitBox.Height-fineTune;
            int width = x._hitBox.Width / 2;
            if (_hitBox.Left + _hitBox.Width >= x._hitBox.Left &&
                _hitBox.Left + _hitBox.Width < x._hitBox.Left + width && underXTop && overXTopAndHeight)
            {
                return true;
            }

            return false;
        }


        //Finetune can be changed with _speedX or _speedY so it check from where it traveled.
        public bool IsRight(Collidable x)
        {
            
            var underXTop = _hitBox.Top + _hitBox.Height > x._hitBox.Top+ x._speedX;
            var overXTopAndHeight = _hitBox.Top < x._hitBox.Top + x._hitBox.Height-fineTune;
            int width = x._hitBox.Width / 2;
            if (_hitBox.Left <= x._hitBox.Left+x._hitBox.Width &&
                _hitBox.Left > x._hitBox.Left + width && underXTop && overXTopAndHeight)
            {
                return true;
            }

            return false;
        }
        public bool IsOver(Collidable x)
        {
            var LeftXWidth = _hitBox.Left + _hitBox.Width > x._hitBox.Left+ x._speedY;
            var RightForXAndWidth = _hitBox.Left < x._hitBox.Left + x._hitBox.Width-fineTune;
            int height = x._hitBox.Height / 2;
            if (_hitBox.Top + _hitBox.Height > x._hitBox.Top &&
                _hitBox.Top + _hitBox.Height < x._hitBox.Top + height && LeftXWidth && RightForXAndWidth)
            {
                return true;
            }

            return false;
        }
        public bool IsUnder(Collidable x)
        {
            var LeftXWidth = _hitBox.Left + _hitBox.Width > x._hitBox.Left+x._speedY;
            var RightForXAndWidth = _hitBox.Left < x._hitBox.Left + x._hitBox.Width-fineTune;
            int height = x._hitBox.Height / 2;
            if (_hitBox.Top < x._hitBox.Top + x._hitBox.Height &&
                _hitBox.Top > x._hitBox.Top + height && LeftXWidth && RightForXAndWidth)
            {
                return true;
            }

            return false;
        }

        public void GetFree(Collidable x)
        {


            if (IsLeft(x))
            {

        _hitBox.BackColor = Color.BlueViolet;
            _speedX = -5;
            }
            if (IsRight(x))
            {
                _hitBox.BackColor = Color.GreenYellow;
                _speedX = +5;
            }
            if (IsOver(x))
            {
                _hitBox.BackColor = Color.Blue;
                if(_speedY > 0) _speedY = 0;
                if (_hitBox.Top + _hitBox.Height > x._hitBox.Top && x._tag != "Ground")
                    _hitBox.Top = x._hitBox.Top-_hitBox.Height;
                if (x._tag == "Ground" && !_jumping)
                {
                    _grounded = true;

                }
                
            }
            if (IsUnder(x))
            {
                _hitBox.BackColor = Color.Red;
                _speedY = -_speedY;
            }

            //if (_hitBox.Left > x._hitBox.Left && _hitBox.Top > x._hitBox.Top - x._hitBox.Height / 2)
            //{
            //    _speedX = -_speedX;
            //}

            //if (_hitBox.Top < x._hitBox.Top && _hitBox.Left > x._hitBox.Left - x._hitBox.Width / 2)
            //{

            //    _speedY = -_speedY;
            //}
            //if (_hitBox.Top > x._hitBox.Top && _hitBox.Left < x._hitBox.Left + x._hitBox.Width / 2)
            //{

            //    _speedY = -_speedY;
            //}





            //Vector vector1 = new Vector(_hitBox.Left, _hitBox.Top);
            //Vector vector2 = new Vector(x._hitBox.Left, x._hitBox.Top);
            //Double angleBetween;
            //angleBetween = Vector.AngleBetween(vector1, vector2);
            //Venstre _hitBox.Left < x._hitBox.Left Høyre;
            //Over _hitBox.Top < x.hitBox.Left Under
            //OppHøyre _hitBox.Top < x._hitBox.Top && _hitBox.Left > x._hitBox.Left+x._hitBox.Heigth/2
            //Legg inn object.
            //if (_tag != "Ground")
            //{
            //    if (pos == 0)
            //    {
            //        //_hitBox.Top = x._hitBox.Top + x._hitBox.Height;
            //        _hitBox.Top = 200;
            //        _hitBox.Left = 200;
            //    }

            //    if (pos == 1)
            //    {
            //        //_hitBox.Top = _hitBox.Top = x._hitBox.Top - x._hitBox.Top - x._hitBox.Height;
            //        _speedY = +_speedY;
            //    }

            //    if (pos == 2)
            //    {
            //        _speedX--; /*x._hitBox.Left + x._hitBox.Left - x._hitBox.Height;*/
            //    }

            //    if (pos == 3)
            //    {
            //        _speedX++;
            //    }}
        }

        public void Reverse()
        {
            if (_tag != "Ground")
            {
                _speedY = -_speedY;
            }
        }

        public void getGravity()
        {
            if (_speedY < -10)
            {
                _speedY--;
            }

            _speedY++;
        }
    }

}
