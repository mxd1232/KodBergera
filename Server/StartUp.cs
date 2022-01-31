using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class StartUp : Form
    {
        List<Server> servers = new List<Server>();
        public StartUp()
        {
            InitializeComponent();
        }

        private void StartUp_Load(object sender, EventArgs e)
        {
           
        }

        private void startProgram_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++)
            {
                servers.Add(new Server(i));
                servers[i - 1].Show();
            }
        }
    }
}
