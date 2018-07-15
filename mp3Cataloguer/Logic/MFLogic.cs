using System.Collections.Generic;
using System.Linq;

using mp3Cataloguer.UI;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace mp3Cataloguer.Logic
{
    public class MFLogic
    {
        private MainForm mForm;
        private List<Page> pages = new List<Page>();

        public MFLogic(MainForm mainForm)
        {
            mForm = mainForm;

        }

        private int ClickedTabIndex()
        {
            int coordinateRelativeToMenu = Cursor.Position.X - mForm.cmsTabControl.Left; //distance relative to the start of the context menu
            int x = Cursor.Position.X - mForm.tabControl.Location.X - mForm.tabControl.Margin.Horizontal - mForm.Location.X - coordinateRelativeToMenu;
            // distance from window 
            //+ indent tabcontrol from the beginning of the window + coordinateRelativeToMenu

            int size = mForm.tabControl.ItemSize.Width;
            int index = x / size;
            return index;
        }

        private void Add(string name)
        {
            mForm.TabControls.Add(new Page(name));
        }

        private void Add()
        {
            mForm.TabControls.Add(new Page());
        }

        public void OpenFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.SelectedPath = @"C:\";
            fbd.Description = "Choose the directory with mp3 files.";

            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                List<string> list = Directory.GetFiles(path, "*.mp3").ToList();
                foreach (var file in list)
                {
                    MP3File mP3File = new MP3File(file);
                    (mForm.TabControls[mForm.SelectedTabIndex] as Page).Add(mP3File);
                }
            }
        }

        public void WriteData()
        {
            for (int i = 0; i < mForm.TabControls.Count; ++i)
            {
                pages.Add(mForm.TabControls[i] as Page);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Page>));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, pages);
            string xml = stringWriter.ToString();
            System.IO.File.WriteAllText("data.xml", xml);
        }

        public void ReadData()
        {
            if (System.IO.File.Exists("data.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Page>));
                string xml = System.IO.File.ReadAllText("data.xml");
                var stringReader = new StringReader(xml);
                List<Page> p = (List<Page>)xmlSerializer.Deserialize(stringReader);
                mForm.TabControls.Clear();
                foreach (var page in p)
                {
                    mForm.TabControls.Add(page);
                }
            }
            else
            {
                mForm.TabControls.Clear();
                mForm.TabControls.Add(new Page());
            }
        }

        public void AddPage()
        {
            PageName pageName = new PageName();
            PNLogic logic = new PNLogic(pageName, new MyDelegate(Add));
            pageName.ShowDialog();
        }

        public void RenamePage()
        {
            PageName pageName = new PageName();
            PNLogic logic = new PNLogic(pageName, (mForm.TabControls[ClickedTabIndex()] as Page).Rename);
            pageName.ShowDialog();
        }

        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "music files (*.mp3)|*.mp3";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                MP3File f = new MP3File(filename);
                (mForm.TabControls[mForm.SelectedTabIndex] as Page).Add(f);
            }
        }

        public void RemoveClickedTab()
        {
            int index = ClickedTabIndex();
            RemoveAt(index);
        }

        public void RemoveSelectedTab()
        {
            RemoveAt(mForm.SelectedTabIndex);
        }

        private void RemoveAt(int index)
        {
            try
            {
                mForm.TabControls.RemoveAt(index);
            }
            catch { }

            if (mForm.TabControls.Count == 0)
            {
                mForm.TabControls.Add(new Page());
            }
        }

        public void Search(string str)
        {

            (mForm.TabControls[mForm.SelectedTabIndex] as Page).StartSearching(str);
        }

        public void Backup()
        {
            try
            {
                GoogleDrive.Upload("data.xml");
                MessageBox.Show("Done");
            }
            catch
            { 

            }
        }

        public void Restore()
        {
            try
            {
                GoogleDrive.Download("data.xml");
            }
            catch { }
        }

        public void LogOut()
        {
            try
            {
                GoogleDrive.LogOut();
            }
            catch { }
        }
    }
}
