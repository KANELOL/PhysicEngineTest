using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace NyHitBoxTest.Class
{
    class Jump
    {
        public DispatcherTimer _jumpTime = new DispatcherTimer();
        public int _jumpPower { get; set; }

        public int _jumpZero;

        public int _jumpSpeed;
        //public Label _timerLabel = new Label();

        public bool _TimerRunning;
        //private int _jumpSpeed;

        public Jump()
        {
            _jumpTime.Interval = TimeSpan.FromMilliseconds(20);

        }

        //public void Jumping()
        //{
        //    //if (!_TimerRunning)
        //    {
        //        _jumpTime.Start();
        //        //_TimerRunning = true;
        //        //_jumpTime.Tick += JumpingTimer_Tick;
        //    }

        }

        //private void JumpingTimer_Tick(object sender, EventArgs e)
        //{
        //    if (_jumpZero <= _jumpPower)
        //    {
        //        _jumpZero++;
        //    }

        //    //_jumping = false;
        //    //_jumpZero = 0;
        //    _jumpTime.Stop();
        //    _TimerRunning = false;
        //}
    }
