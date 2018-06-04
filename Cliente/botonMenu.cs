using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class botonMenu : UserControl
    {
        //----------------------------------------------------------------------------------------------Variables
        //----------------------------------------------------------------------------------------------Constructor
        public botonMenu()
        {
            InitializeComponent();
        }
        //----------------------------------------------------------------------------------------------Propiedades
        public string setTexto
        {
            get { return lblNombre.Text; }
            set { lblNombre.Text = value; }
        }
        public Image setIcono
        {
            get { return pbIcono.Image; }
            set { pbIcono.Image = value; }
        }
        //----------------------------------------------------------------------------------------------Funciones
        public void Activo() {
            this.BackColor = Color.FromArgb(255, 1, 9, 17);
            pnlRojo.BackColor = Color.FromArgb(255, 255, 42, 42);
        }

        public void Default()
        {
            this.BackColor = Color.FromArgb(255, 7, 17, 27);
            pnlRojo.BackColor = Color.FromArgb(255, 7, 17, 27);
        }

        public void Fuente(Font f)
        {
            lblNombre.Font = f;
        }
    }
}

/*
 verifiicar si puedo pasar metodo anonimo y que todos los componentes se hagan cargo del click de eso, y modifique el form

    pasar el form por contructor o lo que sea, y crear el click dentro de la clase

    probar poner el click directo, y ver si anda, capaz ni tengo que pasar el form

    ver si realmente es util, si no borrar todo a la mierdaaaa
     
     */
