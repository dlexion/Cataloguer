using System;
using System.Windows.Forms;

using mp3Cataloguer.Logic;

namespace mp3Cataloguer.UI
{
    public partial class PageName : Form
    {
        private PNLogic logic;


        public PNLogic Logic { get => logic; set => logic = value; }

        public PageName()
        {
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string text = textBox.Text.Trim();
            if (logic.CheckInputText(text))
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                textBox.Text = String.Empty;
                textBox.Focus();
            }
        }

        

    }
}
