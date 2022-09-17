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
    public partial class frmDateTime : Form
    {
        public frmDateTime()
        {
            InitializeComponent();
        }

        public DateTime _time;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _time = dateTimePicker1.Value;
            this.Hide();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
