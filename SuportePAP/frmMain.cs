using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuportePAP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            frmPainelprinc frm = new frmPainelprinc();
            frm.TopLevel = false;
            panelmdi.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        //Mover Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            frmlogin log = new frmlogin();
            log.Show();
        }

        private void btt_VerPost_Click(object sender, EventArgs e)
        {
            foreach (Form form in panelmdi.Controls.OfType<Form>())
            {
                form.Close(); 
            }
            Form1 frm = new Form1();
            frm.TopLevel = false;
            panelmdi.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btt_Remover_uti_Click(object sender, EventArgs e)
        {
            foreach (Form form in panelmdi.Controls.OfType<Form>())
            {
                form.Close(); 
            }
            frmRemoverUti frm = new frmRemoverUti();
            frm.TopLevel = false;
            panelmdi.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void panelmdi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btt_Suporte_Click(object sender, EventArgs e)
        {
            foreach (Form form in panelmdi.Controls.OfType<Form>())
            {
                form.Close(); 
            }

            frmSuporte frm = new frmSuporte();
            frm.TopLevel = false;
            panelmdi.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btt_Princ_Click(object sender, EventArgs e)
        {
            foreach (Form form in panelmdi.Controls.OfType<Form>())
            {
                form.Close(); 
            }

            frmPainelprinc frm = new frmPainelprinc(); 
            frm.TopLevel = false;
            panelmdi.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
    }
}
