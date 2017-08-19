using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenZip;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string extractFrom;
        string extractTo;
        public Form1()
        {
            SevenZip.SevenZipExtractor.SetLibraryPath("7z.dll");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
            OpenFolderBrowser();
            Extract();
        }
        private void Extract()
        {
            using (var file = new SevenZipExtractor(extractFrom))
            {
                file.ExtractArchive(@extractTo);
            }
        }

        public void OpenFileDialog()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы iso, msi|*.iso;*.msi";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                extractFrom = OPF.FileName;
            }
            else OpenFileDialog();
        }

        public void OpenFolderBrowser()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                 extractTo = FBD.SelectedPath;
            }
            else OpenFolderBrowser();
        }
    }
}
