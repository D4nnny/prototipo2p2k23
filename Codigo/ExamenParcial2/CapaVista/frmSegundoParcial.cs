﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;
namespace CapaVista
{
    public partial class frmSegundoParcial : Form
    {
        Controlador cn = new Controlador();
        public frmSegundoParcial()
        {
            InitializeComponent();
        }
        public void llenarse(string tabla, string campo1, string campo2)
        {

            string tbl = tabla;
            string cmp1 = campo1;
            string cmp2 = campo2;
          

           
           cmb_tabla.ValueMember = "numero";
            cmb_tabla.DisplayMember = "nombre";

            string[] items = cn.items(tabla, campo1, campo2);



            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        cmb_tabla.Items.Add(items[i]);
                    }
                }

            }

            var dt2 = cn.enviar(tabla, campo1, campo2);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {

                coleccion.Add(Convert.ToString(row[campo1]) + "-" + Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + "-" + Convert.ToString(row[campo1]));


            }

            cmb_tabla.AutoCompleteCustomSource = coleccion;
            cmb_tabla.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_tabla.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            


            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
