using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dosya_Duzenleme.Presentation
{
    public partial class frmAçıklama : Form
    {
        public frmAçıklama()
        {
            InitializeComponent();
        }

        public string _açıklama = string.Empty;

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _açıklama = richTextBox1.Text;
            this.Hide();
        }
    }
}
