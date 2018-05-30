using System;

using mp3Cataloguer.Enums;

namespace mp3Cataloguer.Logic
{
    public class MP3File : File
    {

        private Boolean hasID3Tag;
        private String title;
        private String artist;
        private String album;
        private String year;
        private String comment;
        private Byte track;
        private Genres genre;
        private Byte id3Genre;
        private String duration;


        public MP3File() : base()
        {

            this.hasID3Tag = false;
            this.album = String.Empty;
            this.comment = String.Empty;
            this.title = String.Empty;
            this.year = String.Empty;
            this.artist = String.Empty;
            this.id3Genre = 0;
            this.track = 0;
            this.duration = String.Empty;

            this.genre = Genres.None;
        }
        public MP3File(string path) : base(path)
        {
            ID3v1.ReadID3v1(this);
            genre = (Genres)id3Genre;
        }

        public Genres Genre
        {

            get
            {

                return this.genre;
            }
            set
            {

                this.genre = value;
            }
        }
        public String Duration
        {

            get
            {

                return this.duration;
            }
            set
            {

                this.duration = value;
            }
        }
        public Boolean HasID3Tag
        {

            get
            {

                return this.hasID3Tag;
            }
            set
            {

                this.hasID3Tag = value;
            }
        }
        public String Album
        {

            get
            {

                return this.album;
            }
            set
            {

                this.album = value;
            }
        }
        public String Comment
        {

            get
            {

                return this.comment;
            }
            set
            {

                this.comment = value;
            }
        }
        public String Title
        {

            get
            {

                return this.title;
            }
            set
            {

                this.title = value;
            }

        }
        public String Artist
        {

            get
            {

                return this.artist;
            }
            set
            {

                this.artist = value;
            }
        }
        public String Year
        {

            get
            {

                return this.year;
            }
            set
            {

                this.year = value;
            }
        }
        public Byte Id3Genre
        {

            get
            {

                return this.id3Genre;
            }
            set
            {

                this.id3Genre = value;
            }
        }
        public Byte Track
        {

            get
            {

                return this.track;
            }
            set
            {

                this.track = value;
            }
        }
    }
}
