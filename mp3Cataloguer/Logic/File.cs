using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace mp3Cataloguer.Logic
{
    public class File
    {
        private String name;
        private String path;

        public File()
        {
            this.name = String.Empty;
            this.path = String.Empty;
        }

        public File(string path)
        {
            this.name = path.Substring(path.LastIndexOf('\\') + 1, (path.LastIndexOf('.') - path.LastIndexOf('\\')) - 1);
            this.path = path;
        }

        public void Move()
        {
            try
            {
                if (!(System.IO.File.Exists(path.Substring(0, path.LastIndexOf('\\')) + name + ".mp3")))
                {
                    string newFile = path.Substring(0, path.LastIndexOf('\\')+1) + name + ".mp3";
                    System.IO.File.Move(path, newFile);
                    path = newFile;
                }
                else
                {
                    this.name = path.Substring(path.LastIndexOf('\\') + 1, (path.LastIndexOf('.') - path.LastIndexOf('\\')) - 1);
                    MessageBox.Show("Such file already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }

        [XmlAttribute]
        public String Name
        {

            get
            {

                return this.name;
            }
            set
            {

                this.name = value;
            }
        }

        [XmlElement]
        public String Path
        {
            get
            {

                return this.path;
            }
            set
            {

                this.path = value;
            }
        }

    }
}
