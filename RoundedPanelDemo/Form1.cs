using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoundedPanelDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "RoundedShadowPanel Demo";
            this.Size = new Size(600, 400);
            this.BackColor = Color.WhiteSmoke;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoScroll = true,
                Padding = new Padding(20),
                BackColor = Color.FromArgb(100, 247, 249, 251)
            };

            var panel = new RoundedShadowPanel
            {
                CornerRadius = 20,
                ShadowSize = 12,
                ShadowColor = Color.FromArgb(60, 0, 0, 0),
                FillColor = Color.White,
                InnerPadding = new Padding(20)
            };

            var label = new Label
            {
                Text = "이것은 RoundedShadowPanel 내부입니다.",
                Font = new Font("Segoe UI", 12),
                AutoSize = true
            };

            panel.Controls.Add(label);
            layout.Controls.Add(panel);
            this.Controls.Add(layout);
        }
    }
}
