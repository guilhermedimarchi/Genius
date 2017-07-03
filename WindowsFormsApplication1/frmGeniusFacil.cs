using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paint;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class frmGeniusFacil : Form
    {
        Funcoes f = new Funcoes();
        Fila passos = new Fila(200);
        int pontos = 0;

        Bitmap b = new Bitmap(500, 500);
        int count = 0;
        public frmGeniusFacil()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Inicia o Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Altura e largura da imagem
            int Width = pbImagem.Width;
            int Heigth = pbImagem.Height;

            //Chama a função para formar a imagem 
            f.DelimitaRegiao(Width, Heigth, b,'f');

            //Atualiza a Imagem.
            pbImagem.Image = b;
            pbImagem.Refresh();
            
            //Dispara o timer que controla a coloração e seleção das cores
            tmrDispara.Enabled = true;
        }

        private void pbImagem_MouseDown(object sender, MouseEventArgs e)
        {
            

            //Ao clicar, altera a cor do quadrado clicado          
            Color Caux = b.GetPixel(e.X, e.Y);
            if (Caux.Name != "ff000000")
            {
                f.Colorir(e.X, e.Y, Color.FromArgb(((int)(Caux.R * 2)), ((int)(Caux.G * 2)), ((int)(Caux.B * 2))), b);
                pbImagem.Image = b;
                pbImagem.Refresh();

                if (count < f.Passos)
                {
                    Point p = new Point(e.X, e.Y);

                    Color CorClicada = f.CorEmUmPonto(p, b);
                    Point p1 = (Point)passos.Remove();
                    Color C1 = f.CorEmUmPonto(p1, b);

                    if (!f.MesmaCor(CorClicada, C1))
                    {
                        MessageBox.Show("VOCE PERDEU! SUA PONTUAÇAO: "+pontos+" pontos!!");

                    }
                    else
                    {
                        pontos++;
                        f.tocaSom(Caux);
                    }
                    passos.Insert(p1);
                    count++;


                   
                }
            }
        }

        private void tmrDispara_Tick(object sender, EventArgs e)
        {
            Point p = new Point();
            if (count < f.Passos)
            {
        
                p = (Point)passos.Remove();

  
                passos.Insert(p);
                count++;

            }
            else if (count == f.Passos)
            {
                p = f.EscolheRegiao(new Point(b.Width / 2, b.Height / 2));
                passos.Insert(p);         
                f.Passos++;
                count = 0;
                tmrDispara.Enabled = false;
            }

            Color Caux = b.GetPixel(p.X, p.Y);
            f.Colorir(p.X, p.Y, Color.FromArgb(((int)(Caux.R * 2)), ((int)(Caux.G * 2)), ((int)(Caux.B * 2))), b);
            pbImagem.Image = b;
            pbImagem.Refresh();

            Thread.Sleep(250);
            Caux = b.GetPixel(p.X, p.Y);
            f.Colorir(p.X, p.Y, Color.FromArgb(((int)(Caux.R / 2)), ((int)(Caux.G / 2)), ((int)(Caux.B / 2))), b);

            Caux = b.GetPixel(p.X, p.Y);         
            f.tocaSom(Caux);

            pbImagem.Image = b;
            pbImagem.Refresh();


        }

        private void pbImagem_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(100);
            Color Caux = b.GetPixel(e.X, e.Y);
            f.Colorir(e.X, e.Y, Color.FromArgb(((int)(Caux.R / 2)), ((int)(Caux.G / 2)), ((int)(Caux.B / 2))), b);
            pbImagem.Image = b;
            pbImagem.Refresh();

            if (count == f.Passos)
            {
                Thread.Sleep(200);
                tmrDispara.Enabled = true;
                count = 0;
            }
        }

        private void pbImagem_Click(object sender, EventArgs e)
        {

        }
    }
}
