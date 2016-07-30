using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratorio1
{
    class Corredor
    {
        //public int StartPosition;
        //public int RacetrackLength;
        public int NumCorredor;
        public int Vencedor;
        public PictureBox MyPictureBox = null;
        //public int Location = 0;
        public Random MyRandom;
        public bool Rum()
        {            
            MyRandom = new Random();
            Point p = MyPictureBox.Location;
            if(p.X < 650)
            {
                p.X += MyRandom.Next(4);
                MyPictureBox.Location = p;

                for (int i = 0; i < 1000000; i++)
                {
                    //timer
                }
                return false;
            }
            else
            {
                Vencedor = NumCorredor;
                return true;
            }
           
        }

        public void TakeStartPosition()
        {
            Point p = MyPictureBox.Location;
            p.X = 12;
            MyPictureBox.Location = p;
        }
    }
}
