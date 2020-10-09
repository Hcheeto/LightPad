using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Notepad : Form
    {

        int count = 0;
        string strNotes;
        const string NOTES = "file.txt";

        public Notepad()
        {

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(3222, 0);

            InitializeComponent();

            count = 0;

            StreamReader notes;

            notes = File.OpenText("file.txt");

            while (notes.EndOfStream == false)
            {

                strNotes = notes.ReadLine();
                txtNotes.Text += strNotes;

            }

            notes.Close();

            System.IO.File.WriteAllText("file.txt", string.Empty); //Clear File here
            

        }

        private void Notepad_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (count < 1)
            {

                StreamWriter outputInfo;

                outputInfo = File.AppendText("file.txt");
                outputInfo.Write(txtNotes.Text);

                count++;

                outputInfo.Close();

            }

        }
    }

}
