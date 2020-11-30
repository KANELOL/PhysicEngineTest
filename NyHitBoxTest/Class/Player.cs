using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using NyHitBoxTest.Class.LineFolder;

namespace NyHitBoxTest.Class
{
    class Player : Collidable
    {
        public int _playerSpd;
        public bool _moving;
        public int _playerJump;
        private Jump _jump;
        private bool _drawn;

        public Player(int x, int y, int width, int height, int speed, int mass) : base(x, y, width, height, speed, mass)
        {
            _jump = new Jump();
            _hitBox.BackColor = Color.BlueViolet;
            _playerSpd = 4;
            _jump._jumpPower = 20;
            _jump._jumpSpeed = 1;
            _gravity = 5;
            _drawn = false;

        }

        public void PlayerMove()
        {
            _moving = false;
            
            _jump._jumpTime.Tick += _jumpTime_Tick;
            _jump._jumpTime.Start();
            if (!_moving)
            {
                _speedX = 0;
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                _moving = true;
                _speedX = -_playerSpd;
            }

            if (Keyboard.IsKeyDown(Key.D))
            {
                _moving = true;
                _speedX = _playerSpd;
            }

            if (Keyboard.IsKeyDown(Key.W))
            {
                _moving = true;
                _speedY = -_playerSpd;
            }

            if (Keyboard.IsKeyDown(Key.S))
            {
                _moving = true;
                _speedY = _playerSpd;
            }

            if (Keyboard.IsKeyDown(Key.Space) && _grounded)
            {
                _moving = true;
                //_grounded = false;
                
                if (!_jumping)
                {
                    _jumping = true;
                    //_jump._TimerRunning = true;
                    //_jump._jumpTime.Start();
                }
                
            }
            if (!Keyboard.IsKeyDown(Key.Space))
            {
                //_moving = true;
                //_grounded = false;
                //_jump._jumpTime.Start();
                //_gravity = 0;
                //_jump._jumpTime.Tick += _jumpTime_Tick;
            }



        }

        private void _jumpTime_Tick(object sender, EventArgs e)
        {
            if (_jumping && _jump._jumpZero < _jump._jumpPower)
            {
                _speedY -= _jump._jumpSpeed;
                _jump._jumpZero++;
                
            }

            if (_jump._jumpZero >= _jump._jumpPower)
            {
                //_jump._jumpTime.Stop();
                _jump._jumpZero = 0;
                _jump._TimerRunning = false;
                //_gravity = 8;
                _jumping = false;
            }
        }
    }
}
