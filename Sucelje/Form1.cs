using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PotapanjeBrodova;
using IspisFlote;
using System.Threading;


namespace Sucelje
{
    public partial class Form1 : Form
    {
        int index = 0;
        int val = 0;
        int od_x = 0;
        int od_y = 0;
        int manji_x = 0;
        int manji_y = 0;
        int drugi_x = 0;
        int drugi_y = 0;
        int dulj_br_iter = 0;
        int [] duljina_brodova = {5,4,4,3,3,3,2,2,2,2,0};
        string prvo_polje = "";
        bool tvoj_red = false;
        int brojNašihBrodova = 0;
        int brojBrodovaUFloti = 0;
        char[] alpha = "ABCDEFGHIJ".ToCharArray();
        Razarač r;
        Brodograditelj b;
        Flota f;

        public List<moji_brodovi> brodovi = new List<moji_brodovi>();
        public List<Polja> polja = new List<Polja>();
        public List<Rectangle> rectangles = new List<Rectangle>();
        public List<Rectangle> gadanje = new List<Rectangle>();



        public Form1()
        {          

            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            inicijaliziraj_listu_polja(ref polja);

            r = new Razarač(10, 10, duljina_brodova);
            int[] duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            b = new Brodograditelj(10, 10, duljineBrodova);
            f = b.SložiFlotu();



            brojNašihBrodova = duljineBrodova.Length;
            brojBrodovaUFloti = duljineBrodova.Length;

            ti_score.Text = "Ti: " + brojNašihBrodova;
            on_score.Text = "On: " + brojBrodovaUFloti;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawGrid(sender, e);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            drawGrid(sender, e);
        }

        private void drawGrid(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int numOfCells = 10;
            int cellSize = 30;
            Pen p = new Pen(Color.Black);

            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }

        }

        private void inicijaliziraj_listu_polja(ref List<Polja> po) 
        {
            char sl = 'A';

            int i = 1;

            for (int x = 30; x <= 300; x += 30) 
            {
                i = 1;
                for (int y = 30; y <= 300; y += 30) 
                {
                    Polja p = new Polja();
                    p.naziv = sl+"-"+i;
                    p.x = x;
                    p.y = y;
                    ++i;
                    po.Add(p);
                }

                ++sl;
            }

            label_dogadanja.Text = "Postavi brod veličine "+duljina_brodova[dulj_br_iter];
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
           // int korx = e.X;
           // int kory = e.Y;
            if (duljina_brodova[dulj_br_iter] != 0)
            {
                foreach (Polja p in polja)
                {
                    int x = p.x - e.X;
                    int y = p.y - e.Y;


                    if (x < 30 && x > 0 && y < 30 && y > 0)
                    {

                        if (String.Compare(prvo_polje, "", false) != 0)
                        {
                            if (manji_x == p.x && manji_y == p.y) 
                            {
                                MessageBox.Show("Klikni na polje u kojem smjeru želiš postaviti brod!");
                                return;
                            }
                            moji_brodovi m_b = new moji_brodovi();
                            m_b.pocetno_polje = prvo_polje;
                            //m_b.sva_polja.Add(prvo_polje);
                            m_b.dulj = duljina_brodova[dulj_br_iter];
                            index = char.ToUpper(prvo_polje[0]) - 64;
                            val = (int)Char.GetNumericValue(prvo_polje[2]);

                            drugi_x = p.x;
                            drugi_y = p.y;

                            if (od_x != p.x && od_y != p.y) 
                            {
                                MessageBox.Show("Brodovi se ne mogu postaviti dijagonalno! Izaberite nova polja!");
                                oznaci_odznaci(od_x, od_y, false);
                                prvo_polje = "";
                                return;
                            }

                            if (manji_x > p.x)
                            {
                                m_b.smj = smjer.left;
                                drugi_x = manji_x - 30 * duljina_brodova[dulj_br_iter] + 30;

                            }
                            else if (manji_x < p.x)
                            {
                                m_b.smj = smjer.right;

                            }
                            else if (manji_y > p.y)
                            {
                                m_b.smj = smjer.up;
                                drugi_y = manji_y - 30 * duljina_brodova[dulj_br_iter] + 30;


                            }
                            else if (manji_y < p.y)
                            {
                                m_b.smj = smjer.down;

                            }


                            if (drugi_x < manji_x)
                            {
                                manji_x = drugi_x;
                                manji_y = drugi_y;
                            }
                            else if (drugi_y < manji_y)
                            {
                                manji_x = drugi_x;
                                manji_y = drugi_y;
                            }




                            if (draw_ship(m_b))
                            {
                                brodovi.Add(m_b);
                                prvo_polje = "";
                                if (duljina_brodova[dulj_br_iter] != 0)
                                    label_dogadanja.Text = "Postavi brod veličine " + duljina_brodova[dulj_br_iter];
                                else
                                {
                                    label_dogadanja.Text = "Igra Počinje!";

                                    protivnik_igra();
                                }
                            }
                            else
                            {
                                oznaci_odznaci(od_x, od_y, false);
                                prvo_polje = "";
                            }
                            return;
                        }
                        //MessageBox.Show(p.naziv);
                        prvo_polje = p.naziv;
                        manji_x = p.x;
                        manji_y = p.y;

                        od_x = p.x;
                        od_y = p.y;

                        oznaci_odznaci(p.x, p.y, true);
                    }
                }
            }
            else 
            {
                MessageBox.Show("Gotovo je postavljanje brodova! Sada gađaj protivničke brodove!");
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (duljina_brodova[dulj_br_iter] == 0 && tvoj_red)
            {
                foreach (Polja p in polja)
                {
                    int x = p.x - e.X;
                    int y = p.y - e.Y;

                    if (x < 30 && x > 0 && y < 30 && y > 0)
                    {
                        // MessageBox.Show(p.naziv);

                        gadanje_protivnickih_brodova(p.x, p.y);
                    }
                }
            }
            else if (duljina_brodova[dulj_br_iter] != 0)
            {
                MessageBox.Show("Prvo postavi sve brodove na svojem polju, zatim gađaj protivničke brodove!");
            }
            else 
            {
                MessageBox.Show("Pričekaj svoj red!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private bool draw_ship(moji_brodovi m_b) 
        {
            Graphics g = pictureBox1.CreateGraphics();
            Rectangle rect = new Rectangle(0,0,0,0);
            Rectangle provjera = new Rectangle(0, 0, 0, 0);

            if (m_b.smj == smjer.down || m_b.smj == smjer.up)
            {
                if (m_b.smj == smjer.down && 30 * duljina_brodova[dulj_br_iter] + manji_y - 30 > 300 || m_b.smj == smjer.up && manji_y - 30 < 0) 
                {
                    MessageBox.Show("Brod izlazi izvan dopuštenih granica! Izaberite nova polja!");
                    return false;
                }



                int duljina = duljina_brodova[dulj_br_iter];

                if(m_b.smj == smjer.up)
                    for (int i = val; duljina > 0; --i)
                    {
                        m_b.sva_polja.Add(prvo_polje[0] + "-" + i);
                        --duljina;
                    }
                else if(m_b.smj == smjer.down)
                    for (int i = val; duljina > 0; ++i)
                    {
                        m_b.sva_polja.Add(prvo_polje[0] + "-" + i);
                        --duljina;
                    }



                rect = new Rectangle(manji_x - 30, manji_y - 30, 30, 30 * duljina_brodova[dulj_br_iter]);
                provjera = new Rectangle(manji_x - 60, manji_y - 60, 90, 30 * duljina_brodova[dulj_br_iter] + 60);
            }
            else if (m_b.smj == smjer.right || m_b.smj == smjer.left)
            {
                if (m_b.smj == smjer.right && 30 * duljina_brodova[dulj_br_iter] + manji_x - 30  > 300 || m_b.smj == smjer.left && manji_x - 30  < 0)
                {
                    MessageBox.Show("Brod izlazi izvan dopuštenih granica! Izaberite nova polja!");
                    return false;
                }




                if(m_b.smj == smjer.left)
                    for (int i = duljina_brodova[dulj_br_iter]; i > 0; --i)
                    {
                        m_b.sva_polja.Add(alpha[index - i] + "-" + prvo_polje[2]);
                    }
                else if(m_b.smj == smjer.right)
                    for (int i = 0; i < duljina_brodova[dulj_br_iter]; ++i)
                    {
                        m_b.sva_polja.Add(alpha[index + i - 1] + "-" + prvo_polje[2]);
                    }



                rect = new Rectangle(manji_x - 30, manji_y - 30, 30 * duljina_brodova[dulj_br_iter], 30);
                provjera = new Rectangle(manji_x - 60, manji_y - 60, 30 * duljina_brodova[dulj_br_iter] + 60 , 90);
            }
                
            foreach (Rectangle rec in rectangles)
            {
                if (rec.IntersectsWith(provjera)) 
                {
                    MessageBox.Show("Brodovi se ne smiju preklapati i moraju jednim poljem biti razmaknuti! Izaberite nova polja!");
                    return false;
                }

            }

            rectangles.Add(rect);
            SolidBrush myBrush = new SolidBrush(Color.Gray);

            g.FillRectangle(myBrush, rect);
            ++dulj_br_iter;

            return true;
        }

        private bool gadanje_protivnickih_brodova(int x, int y) 
        {

            
            String polje = koordinate_u_polje(x, y);
            Graphics g = pictureBox2.CreateGraphics();
            Rectangle rect = new Rectangle(x-30, y-30, 30, 30);
            SolidBrush myBrush;
            int stupac = char.ToUpper(polje[0]) - 65;
            int redak = (int)Char.GetNumericValue(polje[2]) - 1;

            if (polje.Length == 4)
                redak = 9;

            foreach (Rectangle rec in gadanje)
            {
                if (rec.IntersectsWith(rect)) 
                {
                    MessageBox.Show("Polje je već gađano! Birajte novo polje za gađanje!");
                    return false;
                }
            }

            var gađanje = f.GađajPolje(redak, stupac);
            

            if (gađanje == RezultatGađanja.Pogodak || gađanje == RezultatGađanja.Potopljen)
            {
                myBrush = new SolidBrush(Color.Red);
                label_dogadanja.Text = "Protivnički Brod je pogođen!";
            }
            else
            {
                myBrush = new SolidBrush(Color.YellowGreen);
                label_dogadanja.Text = "Promašio si!";
            }

            g.FillRectangle(myBrush, rect);

            if (gađanje == RezultatGađanja.Potopljen)
            {
                --brojBrodovaUFloti;
                label_dogadanja.Text = "POTOPLJEN je protivnički brod!";
                MessageBox.Show("POTPOLJEN JE PROTIVNIČKI BROD!");
                on_score.Text = "On: " + brojBrodovaUFloti;
            }




            gadanje.Add(rect);
                
            provjera_igre();
            //label_dogadanja.Text = "Protivnik gađa!";
            tvoj_red = false;
            
            protivnik_igra();
            return true;
        }


        private string koordinate_u_polje(int x, int y)
        {
            string naz= "";

            foreach (Polja po in polja) 
            {
                if (po.x == x && po.y == y)
                    naz = po.naziv;
            }

            return naz;
        }


        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void oznaci_odznaci(int x, int y, bool ind) 
        {
            Graphics g = pictureBox1.CreateGraphics();
            Rectangle rect = new Rectangle(x-25, y-25, 20, 20);
            SolidBrush myBrush;

            if (ind)
                myBrush = new SolidBrush(Color.Green);
            else
                myBrush = new SolidBrush(Color.DodgerBlue);

            g.FillRectangle(myBrush, rect);

        }

        public void provjera_igre() 
        {
            if (brojNašihBrodova <= 0)
            {
                MessageBox.Show("GAME OVER!!! YOU SUCK!!!");
                restart();
            }
            else if (brojBrodovaUFloti <= 0)
            {
                MessageBox.Show("WOOHOOO VICTORY!!!");
                restart();
            }
        }

        public void restart() 
        {
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

            r = new Razarač(10, 10, duljina_brodova);
            int[] duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            b = new Brodograditelj(10, 10, duljineBrodova);
            f = b.SložiFlotu();

            brojNašihBrodova = duljineBrodova.Length;
            brojBrodovaUFloti = duljineBrodova.Length;

            ti_score.Text = "Ti: " + brojNašihBrodova;
            on_score.Text = "On: " + brojBrodovaUFloti;

            brodovi.Clear();
            gadanje.Clear();
            rectangles.Clear();

            dulj_br_iter = 0;

            label_dogadanja.Text = "Postavi brod veličine " + duljina_brodova[dulj_br_iter];
        }

        public void protivnik_igra()
        {

            PoljeZaBrod p = r.Gađaj();

            RezultatGađanja rez = provjera_gadanja(p.ToString());
            r.ZabilježiRezultat(rez);
            if (rez == RezultatGađanja.Potopljen)
            {
                --brojNašihBrodova;
                ti_score.Text = "Ti: " + brojNašihBrodova;
            }
            //if (rez == RezultatGađanja.Pogodak)
            //    label_dogadanja.Text = "Tvoj Brod je pogođen! Tvoj red!";
            //else if(rez == RezultatGađanja.Potopljen)
            //    label_dogadanja.Text = "Tvoj Brod je potopljen! Tvoj red!";
            //else if (rez == RezultatGađanja.Promašaj)
            //    label_dogadanja.Text = "Protivnik je promašio! Tvoj red!";

            provjera_igre();

            tvoj_red = true;
        }

        private RezultatGađanja provjera_gadanja(string polje)
        {
            int[] coor = polje_u_koordinate(polje);

            Graphics g = pictureBox1.CreateGraphics();
            Rectangle rect = new Rectangle(coor[0]-30, coor[1]-30, 30, 30);

            bool pogodak = false;

            foreach (moji_brodovi mb in brodovi) 
            {
                foreach (string po in mb.sva_polja) 
                {
                    if (polje.CompareTo(po) == 0) 
                    {
                        g.FillRectangle(new SolidBrush(Color.Red), rect); 
                        --mb.dulj;
                        if (mb.dulj <= 0)
                            return RezultatGađanja.Potopljen;
                        else
                            return RezultatGađanja.Pogodak;
                    }
                }
            }

            g.FillRectangle(new SolidBrush(Color.Green), rect);

            return RezultatGađanja.Promašaj;
        }

        private int[] polje_u_koordinate(string p) 
        {
            int[] coor = { 0, 0 };

            foreach (Polja po in polja) 
            {
                if (po.naziv.CompareTo(p) == 0) 
                {
                    coor[0] = po.x;
                    coor[1] = po.y;
                }
            }

            return coor;
        }
    }  
}
