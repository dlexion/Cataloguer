using System;

using mp3Cataloguer.UI;
using mp3Cataloguer.Enums;
using System.Windows.Forms;

namespace mp3Cataloguer.Logic
{
    public class ETLogic
    {
        private EditTag editTag;
        private MP3File file;

        public ETLogic(EditTag editTag, MP3File file)
        {
            this.editTag = editTag;
            this.file = file;
            editTag.Logic = this;
            Initialize();
        }

        private void Initialize()
        {
            editTag.Name = file.Name;
            editTag.Title = file.Title;
            editTag.Album = file.Album;
            editTag.Artist = file.Artist;
            editTag.Year = file.Year;
            editTag.Comment = file.Comment;
            editTag.Track = file.Track.ToString();
            editTag.Genre = file.Genre.ToString();
        }

        public bool ChangeTag()
        {
            if (Check())
            {
                file.Name = editTag.Name;
                file.Title = editTag.Title;
                file.Album = editTag.Album;
                file.Artist = editTag.Artist;
                file.Year = editTag.Year;
                file.Comment = editTag.Comment;
                file.Track = Convert.ToByte(editTag.Track);
                file.Genre = (Genres)Enum.Parse(typeof(Genres), editTag.Genre);

                ID3v1.WriteID3v1(file);
                file.Move();
                
                return true;
            }
            else
            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool Check()
        {
            if (Int32.TryParse(editTag.Year, out int temp))
            {
                if (!(temp >= 1800 && temp <= DateTime.Now.Year))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (Int32.TryParse(editTag.Track, out temp))
            {
                if (!(temp >= 0 && temp <= 255))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (!(Enum.TryParse(editTag.Genre, true, out Genres parse)))
            {
                return false;
            }

            return true;
        }
    }
}
