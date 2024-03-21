using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lmitp
{
    public partial class reportsform : Form
    {
        public reportsform()
        {
            InitializeComponent();
        }
        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground(); // Draw the background color

            ListBox listBox = sender as ListBox;
            string itemText = listBox.Items[e.Index].ToString();
            string[] columns = itemText.Split('\t'); // Assuming tab-separated columns

            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;

                // Draw each column
                for (int i = 0; i < columns.Length; i++)
                {
                    Rectangle rect = new Rectangle(e.Bounds.Left, e.Bounds.Top + i * (e.Bounds.Height / columns.Length), e.Bounds.Width, e.Bounds.Height / columns.Length);
                    e.Graphics.DrawString(columns[i], listBox.Font, Brushes.Black, rect, sf);

                    // Draw vertical grid lines
                    e.Graphics.DrawLine(Pens.Gray, rect.Right, rect.Top, rect.Right, rect.Bottom);
                }

                // Draw horizontal grid lines
                e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }

            e.DrawFocusRectangle(); // Draw the focus rectangle
        }
        private void reportsform_Load(object sender, EventArgs e)
        {

        }
    }
}
