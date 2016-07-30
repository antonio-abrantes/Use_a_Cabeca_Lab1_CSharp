using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1
{
    class Bet
    {
        public int Amount;
        public int Corredor;
        public Guy Bettor;
        public string GetDescription()
        {          
            if(Amount >= 5)
            {
                return Bettor.Name +" apostou R$ "+Amount+" no Corredor "+ Corredor;
            }
            else
            {
                return Bettor.Name + " não apostou!";
            }
        }

        public int PayOut(int Winner)
        {
            if(Corredor == Winner)
            {
                return Bettor.Cash += Amount * 2;
            }
            else
            {
                return Bettor.Cash;
            }
            
        }
    }
}
