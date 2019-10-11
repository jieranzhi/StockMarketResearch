using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareholderResearch.UI
{
    public partial class UI_Option : UserControl
    {
        public string OptionText {
            get => labelOptionText.Text;
            set => labelOptionText.Text = value;
        }

        public Image Icon {
            get => _icon;
            set => _icon = value;
        }

        public Image IconHOver
        {
            get => _iconHOver;
            set => _iconHOver = value;
        }

        public Color BackgroundColor {
            get {
                return _backgroundColor;
            }
            set {
                _backgroundColor = value;
            }
        }

        public Color BackgroundColorHOver
        {
            get {
                return _backgroundColorHOver;
            }
            set {
                _backgroundColorHOver = value;
            }
        }

        public Color OptionTextForecolor
        {
            get
            {
                return _optionTextForecolor;
            }
            set
            {
                _optionTextForecolor = value;
            }
        }

        public Color OptionTextForecolorHOver
        {
            get
            {
                return _optionTextForecolorHOver;
            }
            set
            {
                _optionTextForecolorHOver = value;
            }
        }

        private Color _backgroundColor;
        private Color _backgroundColorHOver;
        private Color _optionTextForecolor;
        private Color _optionTextForecolorHOver;
        private Image _icon;
        private Image _iconHOver;

        public UI_Option()
        {
            InitializeComponent();
        }

        private void UI_Option_Load(object sender, EventArgs e)
        {
            pictureBoxIcon.BackgroundImage = _icon;
            panelClient.BackColor = _backgroundColor;
            labelOptionText.ForeColor = _optionTextForecolor;
        }

        private void UIOption_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxIcon.BackgroundImage = _iconHOver;
            panelClient.BackColor = _backgroundColorHOver;
            labelOptionText.ForeColor = _optionTextForecolorHOver;
        }

        private void UIOption_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxIcon.BackgroundImage = _icon;
            panelClient.BackColor = _backgroundColor;
            labelOptionText.ForeColor = _optionTextForecolor;
        }

    }
}
