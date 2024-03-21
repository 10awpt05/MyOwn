using lmitp.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lmitp
{
    public partial class Form3 : Form
    {
        addForm addform = new addForm();
        Form2 form2 = new Form2();

        public Form3()
        {
            InitializeComponent();
            // LoadFormData();
            // addform.DataSelected += Addform_DataSelected;
            form2.DataChanged += Form2_DataChanged;
            textBox1.TextChanged += TextBox_TextChanged;
            label3.TextChanged += TextBox_TextChanged;
            
        }
        private void Form2_DataChanged(object sender, EventArgs e)
        {
            // Update salesDataGrid when data in Form2 changes
            LoadFormData();
        }
        private void LoadFormData()
        {

            salesDataGrid.Rows.Clear();

            foreach (string[] data in GlobalData.Form3Data)
            {
                salesDataGrid.Rows.Add(data);
            }


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (string item in SaleListData.ListBoxData)
            {
                listBox1.Items.Add(item);
            }
            LoadFormData();
            
            //   foreach (string[] data in GlobalData.Form2Data)
            //  {
            //     salesDataGrid.Rows.Add(data);
            //  }
        }
        private void Addform_DataSelected(object sender, DataSelectedEventArgs e)
        {
            // Add the selected data to the DataGridView
            //    salesDataGrid.Rows.Add(e.Data);
        }

        private void salesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex == salesDataGrid.Columns["Column4"].Index)
            {
                DataGridViewRow selectedRow = salesDataGrid.Rows[e.RowIndex];

                listBox1.Items.Clear(); // Clear existing items in the ListBox

                // Assuming Column5 is the correct column index
                string cellName = selectedRow.Cells["Column2"].Value.ToString();
                string cellQuan = selectedRow.Cells["Column5"].Value.ToString();
                string cellPrize = selectedRow.Cells["Column3"].Value.ToString();

                label2.Text = cellName;
                textBox1.Text = cellQuan.Split(' ')[0];
                comboBox1.Text = cellQuan.Split(' ')[1];
                label3.Text = cellPrize;

                
                

                




            }



        }




        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //--------------------OK Button-----------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {

            

            int selectedIndex = salesDataGrid.CurrentRow.Index;
            if (selectedIndex >= 0 && selectedIndex < GlobalData.Form3Data.Count)
            {

                

                string quant0 = (string)salesDataGrid.CurrentRow.Cells["Column5"].Value;
                string[] quant001 = quant0.Split(' ');
                int currentQuantity = Convert.ToInt32(quant001[0]);
                int quantityToAdd = Convert.ToInt32(textBox1.Text);
                
                if (currentQuantity >= 0 && currentQuantity > quantityToAdd)
                {
                    GlobalData.Form3Data[selectedIndex][2] = (currentQuantity - quantityToAdd).ToString();

                 
                    LoadFormData1();

                    string add = label2.Text + " -- " + textBox1.Text + " " + comboBox1.Text + "   =   " + "P" + label8.Text;
                    listBox1.Items.Add(add);
                    SaleListData.ListBoxData.Add(add);
                    listBox1.Refresh();

                }
                else
                {
                    
                    MessageBox.Show("Invalid Quantity", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
                /*
                string cellQuan = selectedIndex.Cells["Column5"].Value.ToString();
                int quanti = cellQuan[0];

                if (quanti < 0)
                {

                    int quant1 = Convert.ToInt32(textBox1.Text);
                    int result1 = quanti - quant1;
                    selectedRow.Cells["Column5"].Value = result1;
                }

                salesDataGrid.Rows[selectedIndex].Cells["Column5"].Value = result.ToString();
                */
            }
            
        
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int quantity))
            {
                // Parse the prize from the panel
                if (int.TryParse(label3.Text, out int prize))
                {
                    // Calculate the total prize
                    int totalPrize = quantity * prize;

                    // Update the total prize label
                    label8.Text = totalPrize.ToString();
                }
            }
        }
        private void LoadFormData1()
        {
            // Clear existing rows
            salesDataGrid.Rows.Clear();

            // Add rows from GlobalData.Form3Data to saleDataGrid
            foreach (string[] data in GlobalData.Form3Data)
            {
                // Add a new row to the saleDataGrid
                int rowIndex = salesDataGrid.Rows.Add(data);

                // Update the quantity column in the newly added row
                salesDataGrid.Rows[rowIndex].Cells["Column5"].Value = data[2];
            }
        }



    }
}

