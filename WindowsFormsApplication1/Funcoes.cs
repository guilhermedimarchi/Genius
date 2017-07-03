using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paint;
using System.Collections;
namespace WindowsFormsApplication1
{
    class Funcoes
    {

        private int passos;

        public int Passos
        {
            get { return passos; }
            set { passos = value; }
        }


        public Funcoes()
        {
            passos = 0;

        }
        public void DelimitaRegiao(int x, int y, Bitmap b, char nivel)
        {
            int meiox = x / 2, meioy = y / 2;
            int cor = 100;

            int pix = Colorir(1, 1, Color.FromArgb(255, 255, 255), b); ;

            Color C0 = Color.FromArgb(0, 0, 0);
            for (int i = 0; i <= meioy; i++)
            {
                b.SetPixel(meiox, i + meioy - 1, C0);
                b.SetPixel(meiox, -i + meioy, C0);
            }

            for (int j = 0; j <= meiox; j++)
            {
                b.SetPixel(j + meiox - 1, meioy, C0);
                b.SetPixel(-j + meiox, meioy, C0);
            }
            if (nivel == 'f')
            {
                Colorir(meiox + 1, meioy - 1, Color.FromArgb(0, cor, 0), b);
                Colorir(meiox + 1, meioy + 1, Color.FromArgb(cor, 0, 0), b);
                Colorir(meiox - 1, meioy + 1, Color.FromArgb(cor, cor, 0), b);
                Colorir(meiox - 1, meioy - 1, Color.FromArgb(0, 0, cor), b);
            }
            else if(nivel=='m')
            {
                Random r = new Random();

                int[] lista = { 1, 2, 3, 4 };
                //EMBARALHAR AS CORES SEM REPETIR!
                for (int i = 0; i < 4; i++)
                {
                    int a = r.Next(4);
                    int temp = lista[i];
                    lista[i] = lista[a];
                    lista[a] = temp;
                }
                
                    if(lista[0]==1)
                        Colorir(meiox + 1, meioy - 1, Color.FromArgb(0, cor, 0), b);
                    else if(lista[0]==2)
                        Colorir(meiox + 1, meioy + 1, Color.FromArgb(0, cor, 0), b);
                    else if(lista[0]==3)
                        Colorir(meiox - 1, meioy + 1, Color.FromArgb(0, cor, 0), b);
                    else
                        Colorir(meiox - 1, meioy - 1, Color.FromArgb(0, cor, 0), b);

                    if (lista[1] == 1)
                        Colorir(meiox + 1, meioy - 1, Color.FromArgb(cor, 0, 0), b);
                    else if (lista[1] == 2)
                        Colorir(meiox + 1, meioy + 1, Color.FromArgb(cor, 0, 0), b);
                    else if (lista[1] == 3)
                        Colorir(meiox - 1, meioy + 1, Color.FromArgb(cor, 0, 0), b);
                    else
                        Colorir(meiox - 1, meioy - 1, Color.FromArgb(cor, 0, 0), b);

                    if (lista[2] == 1)
                        Colorir(meiox + 1, meioy - 1, Color.FromArgb(cor, cor, 0), b);
                    else if (lista[2] == 2)
                        Colorir(meiox + 1, meioy + 1, Color.FromArgb(cor, cor, 0), b);
                    else if (lista[2] == 3)
                        Colorir(meiox - 1, meioy + 1, Color.FromArgb(cor, cor, 0), b);
                    else
                        Colorir(meiox - 1, meioy - 1, Color.FromArgb(cor, cor, 0), b);

                    if (lista[3] == 1)
                        Colorir(meiox + 1, meioy - 1, Color.FromArgb(0, 0, cor), b);
                    else if (lista[3] == 2)
                        Colorir(meiox + 1, meioy + 1, Color.FromArgb(0, 0, cor), b);
                    else if (lista[3] == 3)
                        Colorir(meiox - 1, meioy + 1, Color.FromArgb(0, 0, cor), b);
                    else
                        Colorir(meiox - 1, meioy - 1, Color.FromArgb(0, 0, cor), b);
            }



        }

        public int Colorir(int x, int y, Color C1, Bitmap b)
        {
            int cont = 0;
            Point P0 = new Point(x, y);
            Color C0 = b.GetPixel(P0.X, P0.Y);
            //
            //


            Fila f = new Fila((b.Width + b.Height) * 2);
            if (C0.R == C1.R && C0.G == C1.G && C0.B == C1.B)
                return 0;
            f.Insert(P0);
            while (!f.Empty())
            {
                Point P = (Point)f.Remove();
                Point PN = new Point(P.X, P.Y - 1);
                Point PS = new Point(P.X, P.Y + 1);
                Point PL = new Point(P.X - 1, P.Y);
                Point PO = new Point(P.X + 1, P.Y);
                #region PN
                if (PN.Y >= 0)
                {
                    Color CN = b.GetPixel(PN.X, PN.Y);
                    if (CN.R == C0.R && CN.G == C0.G && CN.B == C0.B)
                    {
                        b.SetPixel(PN.X, PN.Y, C1);
                        f.Insert(PN);
                        cont++;
                    }
                }
                #endregion
                #region PS
                if (PS.Y < b.Height)
                {
                    Color CS = b.GetPixel(PS.X, PS.Y);
                    if (CS.R == C0.R && CS.G == C0.G && CS.B == C0.B)
                    {
                        b.SetPixel(PS.X, PS.Y, C1);
                        f.Insert(PS);
                        cont++;
                    }
                }
                #endregion
                #region PO
                if (PO.X < b.Width)
                {
                    Color CO = b.GetPixel(PO.X, PO.Y);
                    if (CO.R == C0.R && CO.G == C0.G && CO.B == C0.B)
                    {
                        b.SetPixel(PO.X, PO.Y, C1);
                        f.Insert(PO);
                        cont++;
                    }
                }
                #endregion
                if (PL.X >= 0)
                {
                    Color CL = b.GetPixel(PL.X, PL.Y);
                    if (CL.R == C0.R && CL.G == C0.G && CL.B == C0.B)
                    {
                        b.SetPixel(PL.X, PL.Y, C1);
                        f.Insert(PL);
                        cont++;
                    }
                }
            }
            //}           
            /* Dicas: 
             *  - Pode-se colocar na fila x e y. ou pode-se colocar direto um ponto. Pode-se usar a classe Point para isso. 
             *    Ex,: Point p = new Point(x,y)
             *  - Uma variável que armazena cor é do tipo Color. Ex.: Color cor_ponto
             *  - Para pegar uma cor de um ponto do Bitmap use: b.GetPixel(x,y)
             *  - Para gravar uma cor em um ponto do Bitmap use: b.SetPixel(x,y,cor)
             * - Uma cor é igual a outra se seus 3 canais (R, G e B) forem iguais
             * */
            return cont;
        }
        /// <summary>
        /// Retorna a cor de um ponto 
        /// </summary>
        /// <param name="P">Ponto a Ser avaliado</param>
        /// <param name="b">Imagem que será avaliada</param>
        /// <returns>Retorna uma cor </returns>
        public Color CorEmUmPonto(Point P, Bitmap b)
        {
            Color C1 = b.GetPixel(P.X, P.Y);
     
            return C1;

        }
        /// <summary>
        /// Verifica se as cores são identicas
        /// </summary>
        /// <param name="C0">Cor 0</param>
        /// <param name="C1">Cor 1</param>
        /// <returns>True - Mesma Cor, False Cores diferentes.</returns>
        public bool MesmaCor(Color C0, Color C1)
        {

            if (C0.Name == C1.Name)
                return true;
            return false;
        }

        /// <summary>
        /// Determina a próxima regiao a entrar na fila.
        /// </summary>
        /// <param name="Meio"></param>
        /// <returns></returns>
        /// 
        public Point EscolheRegiao(Point Meio)
        {
            //JOSEPHUS
            //MUDAR DE LUGAR AS CORES
            //INVERTER ORDEM DA FILA
            //NIVEIS DIFERENTES


            Random r = new Random();
            Point p = new Point();
            

            int rand = r.Next(0, 4);
            if (rand == 1)
            {
                p = new Point(Meio.X + 1, Meio.Y - 1);
            }
            if (rand == 2)
            {
                p = new Point(Meio.X + 1, Meio.Y + 1);
            }
            if (rand == 3)
            {
                p = new Point(Meio.X - 1, Meio.Y + 1);
            }
            if (rand == 4)
            {
                p = new Point(Meio.X - 1, Meio.Y - 1);
            }

            return p;
        }

        public void tocaSom(Color Caux)
        {
            if (Caux.R == 100 && Caux.G == 100 && Caux.B == 0)
            {
                System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"1.wav");
                startSoundPlayer.Play();
            }
            if (Caux.R == 100 && Caux.G == 0 && Caux.B == 0)
            {
                System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"2.wav");
                startSoundPlayer.Play();
            }
            if (Caux.R == 0 && Caux.G == 100 && Caux.B == 0)
            {
                System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"3.wav");
                startSoundPlayer.Play();
            }
            if (Caux.R == 0 && Caux.G == 0 && Caux.B == 100)
            {
                System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"4.wav");
                startSoundPlayer.Play();
            }
        }
    }
}
