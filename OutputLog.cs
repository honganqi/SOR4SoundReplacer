using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOR4SoundReplacer
{
    public partial class OutputLog : Form
    {
        MainWindow _mainwindow;
        public OutputLog(MainWindow mainwindow)
        {
            InitializeComponent();
            _mainwindow = mainwindow;

        }

        private void ChatLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _mainwindow.btnToggleCommandLog.Text = "Show Output Log";
            this.Hide();
        }
    }
}
