using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;

using mp3Cataloguer.UI;

namespace mp3Cataloguer.Logic
{
    public class MyListView : ListView
    {
        public MyListView()
        {
            this.DoubleBuffered = true;
        }
    }

    public class Page : TabPage, IXmlSerializable
    {
        private SortedDictionary<string, MP3File> files;
        private ListView listView;
        private ListViewColumnSorter lvwColumnSorter;
        private DataView dv;
        private DataTable dt;

        public string TabName { get => Text; }

        public Page() : this("default")
        {

        }

        public Page(string name)
        {
            this.Text = name;

            files = new SortedDictionary<string, MP3File>();
            lvwColumnSorter = new ListViewColumnSorter();

            listView = new MyListView();
            CreateListView();
            this.Controls.Add(listView);

            dt = new DataTable();
            CreateDataTable();
            dv = new DataView(dt);
        }

        private void CreateDataTable()
        {
            dt.Columns.Add("Name");
            dt.Columns.Add("Path");
            dt.Columns.Add("Title");
            dt.Columns.Add("Artist");
            dt.Columns.Add("Album");
            dt.Columns.Add("Year");
            dt.Columns.Add("Comment");
            dt.Columns.Add("Track");
            dt.Columns.Add("Genre");
            dt.Columns.Add("Duration");
        }

        private void CreateListView()
        {
            listView.ListViewItemSorter = lvwColumnSorter;
            listView.View = View.Details;
            listView.Dock = System.Windows.Forms.DockStyle.Fill;
            listView.Location = new System.Drawing.Point(0, 0);
            listView.Margin = new System.Windows.Forms.Padding(0);
            listView.Size = (this.Size);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.FullRowSelect = true;
            listView.Sorting = SortOrder.Ascending;
            listView.ColumnClick += ListView_ColumnClick;
            listView.ShowItemToolTips = true;
            listView.DoubleClick += Edit_Click;

            listView.Columns.Add("Name", 150);
            listView.Columns.Add("Path", 150);
            listView.Columns.Add("Title", 100);
            listView.Columns.Add("Artist", 90);
            listView.Columns.Add("Album", 90);
            listView.Columns.Add("Year", 40);
            listView.Columns.Add("Comment", 90);
            listView.Columns.Add("Track", 40);
            listView.Columns.Add("Genre", 90);
            listView.Columns.Add("Duration", 60);

            ToolStripMenuItem edit = new ToolStripMenuItem();
            edit.Name = "editToolStripMenuItem";
            edit.Size = new System.Drawing.Size(117, 22);
            edit.Text = "Edit";
            edit.Click += Edit_Click;

            ToolStripMenuItem remove = new ToolStripMenuItem();
            remove.Name = "removeToolStripMenuItem";
            remove.Size = new System.Drawing.Size(117, 22);
            remove.Text = "Remove";
            remove.Click += Remove_Click;

            ToolStripMenuItem open = new ToolStripMenuItem();
            open.Name = "openToolStripMenuItem";
            open.Size = new System.Drawing.Size(117, 22);
            open.Text = "Open";
            open.Click += Open_Click;

            ToolStripMenuItem clear = new ToolStripMenuItem();
            clear.Name = "clearToolStripMenuItem";
            clear.Size = new System.Drawing.Size(117, 22);
            clear.Text = "Clear";
            clear.Click += Clear_Click;

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                open,
                edit,
                remove,
                clear
            });
            contextMenu.Size = new System.Drawing.Size(118, 70);

            listView.ContextMenuStrip = contextMenu;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                EditTag editTag = new EditTag();
                ETLogic logic = new ETLogic(editTag, files[listView.FocusedItem.Text]);
                editTag.ShowDialog();
                DrawTable();
            }
            catch
            {
                ShowError("Choose any items");
            }
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;

            }

            // Perform the sort with these new sort options.
            this.listView.Sort();

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            files.Clear();
            DrawTable();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(files[listView.FocusedItem.Text].Path);
            }
            catch
            {
                ShowError("Choose any items");
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection items = this.listView.SelectedItems;

                if (items.Count == 0)
                {
                    ShowError("Choose any items");

                }
                else
                {
                    listView.BeginUpdate();
                    foreach (ListViewItem item in items)
                    {
                        files.Remove(item.Text);
                        item.Remove();
                        
                    }
                    listView.EndUpdate();

                    DrawTable();
                }
            }
            catch
            {
                ShowError("Choose any items");
            }
        }

        public void Add(MP3File file)
        {
            if (!files.ContainsKey(file.Name))
            {
                files.Add(file.Name, file);
                DrawTable(file);
            }
        }

        private void DrawTable()
        {
            listView.Items.Clear();
            dt.Clear();
            foreach (var file in files)
            {
                DrawTable(file.Value);
            }
        }

        private void DrawTable(MP3File file)
        {
            var item = new ListViewItem(new[]
            { file.Name, file.Path, file.Title, file.Artist,
                file.Album, file.Year, file.Comment, file.Track.ToString(),
                file.Genre.ToString(), file.Duration });

            item.ToolTipText = item.Text;
            listView.Items.Add(item);

            dt.Rows.Add(file.Name, file.Path, file.Title, file.Artist,
                file.Album, file.Year, file.Comment, file.Track.ToString(),
                file.Genre.ToString(), file.Duration);
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(List<MP3File>));
            //bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            //if (wasEmpty)
            //   return;

            this.Text = (string)keySerializer.Deserialize(reader);
            List<MP3File> list = (List<MP3File>)valueSerializer.Deserialize(reader);

            reader.ReadEndElement();
            foreach (var l in list)
            {
                files.Add(l.Name, l);
            }
            DrawTable();

        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(List<MP3File>));

            keySerializer.Serialize(writer, this.Text);
            List<MP3File> list = new List<MP3File>();

            foreach (var pair in files)
            {
                list.Add(pair.Value);
            }

            valueSerializer.Serialize(writer, list);
        }

        public void Rename(string newName)
        {
            this.Text = newName;
        }

        private void SearchForResults()
        {
            listView.Items.Clear();
            foreach (DataRow row in dv.ToTable().Rows)
            {
                listView.Items.Add(new ListViewItem(new String[] {
                    row[0].ToString(), row[1].ToString(), row[2].ToString(),
                    row[3].ToString(), row[4].ToString(), row[5].ToString(),
                    row[6].ToString(), row[7].ToString(), row[8].ToString(),
                    row[9].ToString(), }));
            }
        }

        public void StartSearching(string str)
        {
            dv.RowFilter = string.Format(
                "Name like '%{0}%' " +
                "Or Genre like '%{0}%'" +
                "Or Title like '%{0}%'" +
                "Or Artist like '%{0}%'" +
                "Or Album like '%{0}%'" +
                "Or Year like '%{0}%'", str);

            SearchForResults();
        }

        private void ShowError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
