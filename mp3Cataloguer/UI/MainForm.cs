using System;
using System.Windows.Forms;

using mp3Cataloguer.Logic;

namespace mp3Cataloguer.UI
{
    public delegate void MyDelegate(string data);

    public partial class MainForm : Form
    {
        private MFLogic logic;

        public Control.ControlCollection TabControls
        {
            get => tabControl.Controls;
        }

        public int SelectedTabIndex
        {
            get => tabControl.SelectedIndex;
        }

        public MainForm()
        {
            InitializeComponent();

            logic = new MFLogic(this);
        }

        public void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.OpenFile();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logic.WriteData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            logic.ReadData();
        }

        private void AddOrRenamePage_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Text == "Add" || (sender as ToolStripMenuItem).Text == "Add page")
            {
                logic.AddPage();
            }
            else
            {
                logic.RenamePage();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            logic.RemoveClickedTab();
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.OpenFolder();
        }

        private void RemovePageToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            logic.RemoveSelectedTab();
        }

        private void toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            logic.Search(toolStripTextBox.Text);
        }
    }
}
