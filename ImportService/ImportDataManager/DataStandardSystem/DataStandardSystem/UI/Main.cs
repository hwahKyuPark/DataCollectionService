using DataStandardSystem.Config;
using DataStandardSystem.SystemManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStandardSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigManager configManager = new ConfigManager();
            DataStandardManger dataStandardManager = new DataStandardManger();

            dataStandardManager.RunCollectionImportData();
        }
    }
}
