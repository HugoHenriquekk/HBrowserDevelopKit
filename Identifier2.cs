using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
namespace H_Browser
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//enter key
                browser.LoadUrl(txtUrl.Text);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            browser.Load(txtUrl.Text);
        }
        ChromiumWebBrowser browser;
        

        private void frmMain_Load(object sender, EventArgs e)
        {
            browser = new ChromiumWebBrowser(txtUrl.Text);
            browser.Dock = DockStyle.Fill;
            this.pContainer.Controls.Add(browser);//Add browser to Panel control
            webBrowser1.Navigate(browser.Address.ToString());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (browser.CanGoBack)
                browser.Back();
            else
            { }

        }

        private void btnAvanca_Click(object sender, EventArgs e)
        {
            if (browser.CanGoForward)
                browser.Forward();
            else
            { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            browser.Reload();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

            FrmMenu men = new FrmMenu();
            men.Show();
            
       
           

        }

        private void SegTRM_Tick(object sender, EventArgs e)
        {
            if (txtUrl.Text.Contains("https://"))
            {
                picSeg.Image = Secure.Image;
            
            }
            else
            {
                picSeg.Image = noSecure.Image;
            }
        }
      

        private void txtUrl_Enter(object sender, EventArgs e)
        {
            UrlTRM.Stop();
        }

        private void UrlTRM_Tick(object sender, EventArgs e)
        {
            txtUrl.Text = browser.Address;
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            UrlTRM.Start();
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//enter key
                browser.LoadUrl(txtUrl.Text);
        }

        private void picSeg_Click(object sender, EventArgs e)
        {
            CSSMenu1 CS1 = new CSSMenu1();
            CS1.Show();

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtUrl.Text = webBrowser1.Url.ToString();
        }

        private void btnIA_Click(object sender, EventArgs e)
        {
            InteligenciaArtificial IA = new InteligenciaArtificial();
            IA.Show();
        }
    }
}
