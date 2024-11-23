using Altivo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altivo.Forms
{
    public partial class FrmConcentrationRate : Form
    {
        public ConcentrationLevel concentrationLevel { get; set; }

        public FrmConcentrationRate()
        {
            InitializeComponent();
            Theme.Load(this);
        }

        private void FrmConcentrationRate_Load(object sender, EventArgs e)
        {
            concentrationLevel = ConcentrationLevel.None;
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            concentrationLevel = ConcentrationLevel.None;
            Close();
        }

        private void btnLow_Click(object sender, EventArgs e)
        {
            concentrationLevel = ConcentrationLevel.Low;
            Close();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            concentrationLevel = ConcentrationLevel.Medium;
            Close();
        }

        private void btnHigh_Click(object sender, EventArgs e)
        {
            concentrationLevel = ConcentrationLevel.High;
            Close();
        }

        private void btnExtreme_Click(object sender, EventArgs e)
        {
            concentrationLevel = ConcentrationLevel.Extreme;
            Close();
        }
    }
}
