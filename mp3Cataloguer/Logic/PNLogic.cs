using mp3Cataloguer.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace mp3Cataloguer.Logic
{
    public class PNLogic
    {
        private PageName pn;
        private MyDelegate d;


        public PNLogic(PageName pn, MyDelegate sender)
        {
            this.pn = pn;
            pn.Logic = this;
            d = sender;
        }

        private bool CheckText(string text)
        {
            string pattern = "\\W";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(text) || text.Length < 1)
            {
                return false;
            }
            return true;
        }

        public bool CheckInputText(string text)
        {
            if (CheckText(text))
            {
                d(text);
                return true;
            }
            else
            {
                MessageBox.Show("Invalid input", "Page name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        } 

    }
}
