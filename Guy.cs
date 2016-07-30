using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio1
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;
        public TextBox MyTexBox;
        public bool JaApostou;

        public void UpdateLabels()
        {                  
            MyLabel.Text = Name;
            MyRadioButton.Text = Name +" tem R$ " + Cash;
            if(JaApostou == false)
            {
                MyTexBox.Text = Name + " não apostou!";
            }                              
        }

        public void ClearBet()
        {
            MyBet = new Bet();
            MyBet.Amount = 0;
            MyBet.Corredor = 0;
            MyBet.Bettor = null;
            JaApostou = false;
            
        }

        public void PlaceBet(int Amount = 0, int corredor = 0)
        {            
                if (Amount > Cash)
                {
                    MessageBox.Show("Dinheiro insuficiente...", "Atenção!");
                    MyBet = new Bet();
                    MyBet.Bettor = this;
                    MyBet.Amount = 0;
                    MyBet.Corredor = corredor;
                    MyTexBox.Text = MyBet.GetDescription();
                    //return false;
                }
                else
                {
                    Cash -= Amount;
                    MyBet = new Bet();
                    MyBet.Amount = Amount;
                    MyBet.Bettor = this;
                    MyBet.Corredor = corredor;                    
                    UpdateLabels();
                    JaApostou = true;
                    MyTexBox.Text = MyBet.GetDescription();
                //return true;
            }
         }
                       

        public void Collect(int Winner)
        {
            MyBet.Bettor = this;
            MyBet.PayOut(Winner);
            ClearBet();           
        }
    }
}
