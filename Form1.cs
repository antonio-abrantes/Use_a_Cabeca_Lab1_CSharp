using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio1
{
    public partial class Form1 : Form
    {
        Guy[] jogador = new Guy[3];        
        Corredor[] corredor = new Corredor[4];
        public Form1()
        {
            InitializeComponent();

            corredor[0] = new Corredor();
            corredor[0].NumCorredor = 1;
            corredor[0].Vencedor = 0;
            corredor[0].MyPictureBox = corredor1;

            corredor[1] = new Corredor();
            corredor[1].NumCorredor = 2;
            corredor[1].Vencedor = 0;
            corredor[1].MyPictureBox = corredor2;

            corredor[2] = new Corredor();
            corredor[2].NumCorredor = 3;
            corredor[2].Vencedor = 0;
            corredor[2].MyPictureBox = corredor3;

            corredor[3] = new Corredor();
            corredor[3].NumCorredor = 4;
            corredor[3].Vencedor = 0;
            corredor[3].MyPictureBox = corredor4;


            jogador[0] = new Guy();
            jogador[0].Name = rbJoao.Text;
            jogador[0].Cash = 50;
            jogador[0].MyRadioButton = rbJoao;
            jogador[0].MyTexBox = textBox1;
            jogador[0].MyLabel = lbJogador;
            jogador[0].PlaceBet(0, 0);
            jogador[0].JaApostou = false;

            jogador[1] = new Guy();
            jogador[1].Name = rbBeto.Text;
            jogador[1].Cash = 50;
            jogador[1].MyRadioButton = rbBeto;
            jogador[1].MyTexBox = textBox2;
            jogador[1].MyLabel = lbJogador;
            jogador[1].PlaceBet(0, 0);
            jogador[1].JaApostou = false;

            jogador[2] = new Guy();
            jogador[2].Name = rbAlfredo.Text;
            jogador[2].Cash = 50;
            jogador[2].MyRadioButton = rbAlfredo;
            jogador[2].MyTexBox = textBox3;
            jogador[2].MyLabel = lbJogador;
            jogador[2].PlaceBet(0, 0);
            jogador[2].JaApostou = false;
        }

        private void rbJoao_CheckedChanged(object sender, EventArgs e)
        {

            jogador[0].UpdateLabels();
        }

        private void rbBeto_CheckedChanged(object sender, EventArgs e)
        {

            jogador[1].UpdateLabels();
        }

        private void rbAlfredo_CheckedChanged(object sender, EventArgs e)
        {

            jogador[2].UpdateLabels();
        }

        private void btnAposta_Click(object sender, EventArgs e)
        {

            if (rbJoao.Checked == true)
            {
                if(jogador[0].JaApostou == false)
                {
                    jogador[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                }
                else
                {
                    MessageBox.Show("Aposta fechada para "+ jogador[0].Name, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (rbBeto.Checked == true)
            {
                if(jogador[1].JaApostou == false)
                {
                    jogador[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                }
                else
                {
                    MessageBox.Show("Aposta fechada para "+ jogador[1].Name, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (rbAlfredo.Checked == true)
            {
                if(jogador[2].JaApostou == false)
                {
                    jogador[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                }
                else
                {
                    MessageBox.Show("Aposta fechada para "+ jogador[2].Name, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAposta.Enabled = false;
            btnCorram.Enabled = false;
            int i = 0;
            while (corredor[0].Rum() == false && corredor[1].Rum() == false && corredor[2].Rum() == false && corredor[3].Rum() == false)
            {

                for (int j = 0; j < 4; j++)
                {
                    corredor[j].Rum();                                        
                }
                
                i++;
            }

            //int quantvencedor = 0;
            for (int j = 0; j < 4; j++)
            {
                if (corredor[j].Vencedor != 0)
                {
                    MessageBox.Show("Corredor " + corredor[j].Vencedor+ " venceu!!");
                    for(i = 0; i < 3; i++)
                    {
                        //MessageBox.Show("Teste");
                        jogador[i].Collect(corredor[j].Vencedor);
                        jogador[i].UpdateLabels();
                    }
                }
            }

            for(i = 0; i < 4; i++)
            {
                corredor[i].TakeStartPosition();
                //corredor[i].NumCorredor = i+1;
                corredor[i].Vencedor = 0;
            }

            btnAposta.Enabled = true;
            btnCorram.Enabled = true;
        }
    }
}
