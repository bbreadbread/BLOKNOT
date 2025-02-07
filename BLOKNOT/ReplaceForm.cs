using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLOKNOT
{
    public partial class ReplaceForm : Form
    {
        public string SearchText { get; private set; }
        public string ReplaceText { get; private set; }

        public ReplaceForm()
        {
            InitializeComponent();
        }

        private void btnReplace_Click_1(object sender, EventArgs e)
        {
            SearchText = txtSearch.Text;
            ReplaceText = txtReplace.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
