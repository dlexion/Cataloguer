namespace mp3Cataloguer.UI
{
    partial class EditTag
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelArtist = new System.Windows.Forms.Label();
            this.labelAlbum = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelComment = new System.Windows.Forms.Label();
            this.labelTrack = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxArtist = new System.Windows.Forms.TextBox();
            this.textBoxAlbum = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.textBoxTrack = new System.Windows.Forms.TextBox();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.AutoSize = true;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Location = new System.Drawing.Point(511, 312);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(430, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(11, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(90, 23);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name:";
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(11, 94);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(90, 23);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title:";
            // 
            // labelArtist
            // 
            this.labelArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelArtist.Location = new System.Drawing.Point(11, 177);
            this.labelArtist.Name = "labelArtist";
            this.labelArtist.Size = new System.Drawing.Size(90, 23);
            this.labelArtist.TabIndex = 4;
            this.labelArtist.Text = "Artist:";
            // 
            // labelAlbum
            // 
            this.labelAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAlbum.Location = new System.Drawing.Point(11, 260);
            this.labelAlbum.Name = "labelAlbum";
            this.labelAlbum.Size = new System.Drawing.Size(90, 23);
            this.labelAlbum.TabIndex = 5;
            this.labelAlbum.Text = "Album:";
            // 
            // labelYear
            // 
            this.labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYear.Location = new System.Drawing.Point(303, 20);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(90, 23);
            this.labelYear.TabIndex = 6;
            this.labelYear.Text = "Year:";
            // 
            // labelComment
            // 
            this.labelComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelComment.Location = new System.Drawing.Point(303, 94);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(90, 23);
            this.labelComment.TabIndex = 7;
            this.labelComment.Text = "Comment:";
            // 
            // labelTrack
            // 
            this.labelTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTrack.Location = new System.Drawing.Point(303, 177);
            this.labelTrack.Name = "labelTrack";
            this.labelTrack.Size = new System.Drawing.Size(90, 23);
            this.labelTrack.TabIndex = 8;
            this.labelTrack.Text = "Track:";
            // 
            // labelGenre
            // 
            this.labelGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGenre.Location = new System.Drawing.Point(303, 260);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(90, 23);
            this.labelGenre.TabIndex = 9;
            this.labelGenre.Text = "Genre:";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(107, 17);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 26);
            this.textBoxName.TabIndex = 10;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTitle.Location = new System.Drawing.Point(107, 91);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(180, 26);
            this.textBoxTitle.TabIndex = 11;
            // 
            // textBoxArtist
            // 
            this.textBoxArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxArtist.Location = new System.Drawing.Point(107, 174);
            this.textBoxArtist.Name = "textBoxArtist";
            this.textBoxArtist.Size = new System.Drawing.Size(180, 26);
            this.textBoxArtist.TabIndex = 12;
            // 
            // textBoxAlbum
            // 
            this.textBoxAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAlbum.Location = new System.Drawing.Point(107, 257);
            this.textBoxAlbum.Name = "textBoxAlbum";
            this.textBoxAlbum.Size = new System.Drawing.Size(180, 26);
            this.textBoxAlbum.TabIndex = 13;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxYear.Location = new System.Drawing.Point(399, 17);
            this.textBoxYear.MaxLength = 4;
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(180, 26);
            this.textBoxYear.TabIndex = 14;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxComment.Location = new System.Drawing.Point(399, 91);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(180, 26);
            this.textBoxComment.TabIndex = 15;
            // 
            // textBoxTrack
            // 
            this.textBoxTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTrack.Location = new System.Drawing.Point(399, 174);
            this.textBoxTrack.MaxLength = 3;
            this.textBoxTrack.Name = "textBoxTrack";
            this.textBoxTrack.Size = new System.Drawing.Size(180, 26);
            this.textBoxTrack.TabIndex = 16;
            // 
            // textBoxGenre
            // 
            this.textBoxGenre.AutoCompleteCustomSource.AddRange(new string[] {
            "Blues",
            "ClassicRock",
            "Country",
            "Dance",
            "Disco",
            "Funk",
            "Grunge",
            "HipHop",
            "Jazz",
            "Metal",
            "NewAge",
            "Oldies",
            "Other",
            "Pop",
            "RnB",
            "Rap",
            "Reggae",
            "Rock",
            "Techno",
            "Industrial",
            "Alternative",
            "Ska",
            "DeathMetal",
            "Pranks",
            "Soundtrack",
            "EuroTechno",
            "Ambient",
            "TripHop",
            "Vocal",
            "JazzFunk",
            "Fusion",
            "Trance",
            "Classical",
            "Instrumental",
            "Acid",
            "House",
            "Game",
            "SoundClip",
            "Gospel",
            "Noise",
            "AlternRock",
            "Bass",
            "Soul",
            "Punk",
            "Space",
            "Mediative",
            "InstrumentalPop",
            "InstrumentalRock",
            "Ethnic",
            "Gothic",
            "Darkwave",
            "TechnoIndustrial",
            "Electronic",
            "PopFolk",
            "Eurodance",
            "Dream",
            "SouthernRock",
            "Comedy",
            "Cult",
            "Gangsta",
            "Top40",
            "ChristianRap",
            "PopFunk",
            "Jungle",
            "NativeAmerican",
            "Cabaret",
            "NewWave",
            "Psychadelic",
            "Rave",
            "Showtunes",
            "Trailer",
            "LoFi",
            "Trailer",
            "AcidPunk",
            "AcidJazz",
            "Polka",
            "Retro",
            "Musical",
            "RocknRoll",
            "HardRock",
            "None"});
            this.textBoxGenre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxGenre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxGenre.Location = new System.Drawing.Point(399, 257);
            this.textBoxGenre.Name = "textBoxGenre";
            this.textBoxGenre.Size = new System.Drawing.Size(180, 26);
            this.textBoxGenre.TabIndex = 17;
            // 
            // EditTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 354);
            this.Controls.Add(this.textBoxGenre);
            this.Controls.Add(this.textBoxTrack);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.textBoxAlbum);
            this.Controls.Add(this.textBoxArtist);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.labelTrack);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelAlbum);
            this.Controls.Add(this.labelArtist);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "EditTag";
            this.Text = "EditTag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelArtist;
        private System.Windows.Forms.Label labelAlbum;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Label labelTrack;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxArtist;
        private System.Windows.Forms.TextBox textBoxAlbum;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.TextBox textBoxTrack;
        private System.Windows.Forms.TextBox textBoxGenre;
    }
}