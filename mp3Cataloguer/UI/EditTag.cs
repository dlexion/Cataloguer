using System;
using System.Windows.Forms;

using mp3Cataloguer.Logic;

namespace mp3Cataloguer.UI
{
    public partial class EditTag : Form
    {
        private ETLogic logic;

        public ETLogic Logic { get => logic; set => logic = value; }

        public EditTag()
        {
            InitializeComponent();
        }

        public new string Name
        {
            get
            {

                return textBoxName.Text;
            }
            set
            {

                textBoxName.Text = value;
            }
        }
        public string Title
        {
            get
            {

                return textBoxTitle.Text;
            }
            set
            {

                textBoxTitle.Text = value;
            }
        }
        public string Album
        {
            get
            {

                return textBoxAlbum.Text;
            }
            set
            {

                textBoxAlbum.Text = value;
            }
        }
        public string Artist
        {
            get
            {

                return textBoxArtist.Text;
            }
            set
            {

                textBoxArtist.Text = value;
            }
        }
        public string Year
        {
            get
            {

                return textBoxYear.Text;
            }
            set
            {

                textBoxYear.Text = value;
            }
        }
        public string Comment
        {
            get
            {

                return textBoxComment.Text;
            }
            set
            {

                textBoxComment.Text = value;
            }
        }
        public string Track
        {
            get
            {

                return textBoxTrack.Text;
            }
            set
            {

                textBoxTrack.Text = value;
            }
        }
        public string Genre
        {
            get
            {
                string text = textBoxGenre.Text;
                Char.ToUpper(text[0]);
                return text;
            }
            set
            {
                textBoxGenre.Text = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (logic.ChangeTag())
            {
                Close();
            }
        }
    }
}
