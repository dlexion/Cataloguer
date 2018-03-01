using System;
using System.IO;
using System.Text;

namespace mp3Cataloguer.Logic
{
    static class ID3v1
    {
        const string header = "TAG";

        public static void ReadID3v1(MP3File file)
        {
            // Read the 128 byte ID3 tag into a byte array
            byte[] buffer = new byte[128];

            using (FileStream fstream = new FileStream(file.Path, FileMode.Open, FileAccess.Read))
            {

                fstream.Seek(-128, SeekOrigin.End);
                fstream.Read(buffer, 0, 128);
            }

            // Convert the Byte Array to a String
            String id3Tag = Encoding.GetEncoding(1251).GetString(buffer);

            // If there is an attched ID3 v1.x TAG then read it 
            if (id3Tag.Substring(0, 3) == header)
            {
                file.Title = id3Tag.Substring(3, 30).Trim('\0', ' ');
                file.Artist = id3Tag.Substring(33, 30).Trim('\0', ' ');
                file.Album = id3Tag.Substring(63, 30).Trim('\0', ' ');
                file.Year = id3Tag.Substring(93, 4).Trim('\0', ' ');
                file.Comment = id3Tag.Substring(97, 28).Trim('\0', ' ');

                if (id3Tag[125] == 0)
                    file.Track = buffer[126];
                else
                    file.Track = 0;

                file.Id3Genre = buffer[127];

                file.HasID3Tag = true;
            }
            else
            {
                file.HasID3Tag = false;
            }
        }

        public static void WriteID3v1(MP3File file)
        {
            // Ensure all properties are correct size
            if (file.Title.Length > 30) file.Title = file.Title.Substring(0, 30);
            if (file.Artist.Length > 30) file.Artist = file.Artist.Substring(0, 30);
            if (file.Album.Length > 30) file.Album = file.Album.Substring(0, 30);
            if (file.Year.Length > 4) file.Year = file.Year.Substring(0, 4);
            if (file.Comment.Length > 28) file.Comment = file.Comment.Substring(0, 28);

            // Build a new ID3 Tag (128 Bytes)
            byte[] id3 = new byte[128];
            for (int i = 0; i < id3.Length; i++)
            {
                id3[i] = 0;
            }// Initialise array to nulls

            // Convert the Byte Array to a String
            Encoding instEncoding = new ASCIIEncoding();
            // Copy "TAG" to Array
            byte[] buffer = instEncoding.GetBytes(header);
            Array.Copy(buffer, 0, id3, 0, buffer.Length);
            buffer = instEncoding.GetBytes(file.Title);
            Array.Copy(buffer, 0, id3, 3, buffer.Length);
            buffer = instEncoding.GetBytes(file.Artist);
            Array.Copy(buffer, 0, id3, 33, buffer.Length);
            buffer = instEncoding.GetBytes(file.Album);
            Array.Copy(buffer, 0, id3, 63, buffer.Length);
            buffer = instEncoding.GetBytes(file.Year);
            Array.Copy(buffer, 0, id3, 93, buffer.Length);
            buffer = instEncoding.GetBytes(file.Comment);
            Array.Copy(buffer, 0, id3, 97, buffer.Length);
            id3[126] = file.Track;
            id3[127] = file.Id3Genre;

            // Ssve to disk: Replace the final 128 Bytes with our new ID3v1 tag

            using (FileStream fstream = new FileStream(file.Path, FileMode.Open, FileAccess.Write))
            {

                if (file.HasID3Tag)
                    fstream.Seek(-128, SeekOrigin.End);
                else
                    fstream.Seek(0, SeekOrigin.End);
                fstream.Write(id3, 0, 128);
            }
            file.HasID3Tag = true;
        }

    }
}
