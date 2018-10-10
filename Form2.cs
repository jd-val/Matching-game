using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MatchingGameJdvallance
{
    public partial class Form2 : Form
    {
        
        private ClsDeck ObjDeck = new ClsDeck();
        private PictureBox[] BottomArray = new PictureBox[16];
        private PictureBox[] TopArray = new PictureBox[16];
        public Form2()
        {
            InitializeComponent();
            BuildBottomPics();
            BuildTopPics();
        }
        int tDeals = 0;
        int tClicks = 0;
        int mCount = 0;
        int index1;
        int index2;

        private void BuildTopPics()
        {
            int j = 0;
            for (int i = 0; i < 4; i++)
            {
                TopArray[i] = new PictureBox();
                TopArray[i].Left = j * 150;
                TopArray[i].Top = 10;
                TopArray[i].Width = 100;
                TopArray[i].Height = 150;
                TopArray[i].Tag = i;
                TopArray[i].Click += new System.EventHandler(this.TopArray_Click);
                this.Controls.Add(TopArray[i]);
                j++;
            }
            j = 0;
            for (int i = 4; i < 8; i++)
            {
                TopArray[i] = new PictureBox();
                TopArray[i].Left = j * 150;
                TopArray[i].Top = 170;
                TopArray[i].Width = 100;
                TopArray[i].Height = 150;
                TopArray[i].Tag = i;
                TopArray[i].Click += new System.EventHandler(this.TopArray_Click);
                this.Controls.Add(TopArray[i]);
                j++;
            }
            j = 0;
            for (int i = 8; i < 12; i++)
            {
                TopArray[i] = new PictureBox();
                TopArray[i].Left = j * 150;
                TopArray[i].Top = 340;
                TopArray[i].Width = 100;
                TopArray[i].Height = 150;
                TopArray[i].Tag = i;
                TopArray[i].Click += new System.EventHandler(this.TopArray_Click);
                this.Controls.Add(TopArray[i]);
                j++;
            }
            j = 0;
            for (int i = 12; i < 16; i++)
            {
                TopArray[i] = new PictureBox();
                TopArray[i].Left = j * 150;
                TopArray[i].Top = 510;
                TopArray[i].Width = 100;
                TopArray[i].Height = 150;
                TopArray[i].Tag = i;
                TopArray[i].Click += new System.EventHandler(this.TopArray_Click);
                this.Controls.Add(TopArray[i]);
                j++;
            }

        }
        private void BuildBottomPics()
        {
            int j = 0;
            for (int i = 0; i < 4; i++)
            {
                BottomArray[i] = new PictureBox();
                BottomArray[i].Left = j * 150;
                BottomArray[i].Top = 10;
                BottomArray[i].Width = 100;
                BottomArray[i].Height = 150;
                BottomArray[i].Tag = i;
                this.Controls.Add(BottomArray[i]);
                j++;
            }
            j = 0;
            for (int i = 4; i < 8; i++)
            {
                BottomArray[i] = new PictureBox();
                BottomArray[i].Left = j * 150;
                BottomArray[i].Top = 170;
                BottomArray[i].Width = 100;
                BottomArray[i].Height = 150;
                BottomArray[i].Tag = i;
                this.Controls.Add(BottomArray[i]);
                j++;
            }
            j = 0;
            for (int i = 8; i < 12; i++)
            {
                BottomArray[i] = new PictureBox();
                BottomArray[i].Left = j * 150;
                BottomArray[i].Top = 340;
                BottomArray[i].Width = 100;
                BottomArray[i].Height = 150;
                BottomArray[i].Tag = i;
                this.Controls.Add(BottomArray[i]);
                j++;
            }
            j = 0;
            for (int i = 12; i < 16; i++)
            {
                BottomArray[i] = new PictureBox();
                BottomArray[i].Left = j * 150;
                BottomArray[i].Top = 510;
                BottomArray[i].Width = 100;
                BottomArray[i].Height = 150;
                BottomArray[i].Tag = i;
                this.Controls.Add(BottomArray[i]);
                j++;
            }
        }



        int cCount = 0;
        int tCount = 0;

        private void TopArray_Click(object sender, EventArgs e)
        {
            PictureBox alias;
            alias = (PictureBox)sender;
            alias.Visible = false;
            cCount++;
            tClicks++;
            tCount++;
            if (cCount == 1)
            {
                index1 = (int)alias.Tag;
            }
            else
            {
                index2 = (int)alias.Tag;
                cCount = 0;
                timer1.Enabled = true;
                if (ObjDeck.CheckHandForMatch(index1, index2) == true)
                {
                    mCount++;
                }
            }
            if (mCount < 8)
            {
                button1.Enabled = false;
            }
            if (mCount >= 8)
            {
                button1.Enabled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                ObjDeck.FetchHandFromDeck();
            }
            ObjDeck.ShuffleHand();
            BuildTopPics();
            for (int i = 0; i < 16; i++)
            {
                ObjDeck.DealFromHand(i);
                BottomArray[i].Image = Image.FromFile(ObjDeck.Card);
                TopArray[i].Image = Image.FromFile("koontzsmall.jpg");
                TopArray[i].BringToFront();
            }
            mCount = 0;
            tDeals++;
            if (tDeals == 3)
            {
                button1.Enabled = false;
                button3.Visible = true;
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tCount == 2)
            {
                if(ObjDeck.CheckHandForMatch(index1, index2) == true)
                {
                    TopArray[index1].Visible = false;
                    TopArray[index2].Visible = false;
                }
                else
                {
                    int milSec = 1000;
                    Task.Delay(milSec).Wait();
                    TopArray[index1].Visible = true;
                    TopArray[index2].Visible = true;
                }
                timer1.Enabled = false;
                tCount = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }
    }
}
