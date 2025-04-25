using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerezMaximiliano_MorenoAaron_Projecte.View
{
    public partial class IniciarSessioForm : MaterialForm
    {
        public IniciarSessioForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true; 
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Color mainColor = ColorTranslator.FromHtml("#FFB997");
            Color hoverColor = ColorTranslator.FromHtml("#D57150");
            TextShade textColor = TextShade.BLACK;
            Color formBackColor = Color.White;

            materialSkinManager.ColorScheme = new ColorScheme(mainColor, hoverColor, formBackColor, mainColor, textColor);
        }
        private void IniciarSessioForm_Load(object sender, EventArgs e)
        {

        }
    }
}
