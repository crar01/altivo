using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altivo.Forms
{
    public class Theme
    {
        static Color Background = Color.FromArgb(30, 30, 30);

        public static void Load(Form form)
        {
            form.BackColor = Background;
            form.ForeColor = Color.WhiteSmoke;
        }
    }
}
