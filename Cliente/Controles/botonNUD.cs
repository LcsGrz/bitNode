using System;
using System.Windows.Forms;

namespace Cliente.Controles
{
    public partial class botonNUD : UserControl
    {
        private int valorActual = 0;
        private int UltimoApretado = 0;

        public event EventHandler CambioDeValor;

        public int valor
        {
            get { return valorActual; }
            set {
                valorActual = value;
                mtbNumero.Text = value.ToString();
            }
        }
        public int UpDown { get; set; } = 5;
        public int maxValor { get; set; } = 9999;
        public int minValor { get; set; } = 0;

        public botonNUD()
        {
            InitializeComponent();
        }

        private void UP_DOWN(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32((sender as Control).Tag);
            if ((valorActual >= maxValor && tag == 1) || (valorActual <= minValor && tag == 2)) {
                mtbNumero.Text = (valorActual += (tag == 1) ? maxValor : minValor).ToString();
                return;
            }
            mtbNumero.Text = (valorActual += (tag == 1) ? UpDown : -UpDown).ToString();
            if (CambioDeValor != null)
                CambioDeValor.Invoke(this, e);
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            if ((valorActual >= maxValor && UltimoApretado == 1) || (valorActual <= minValor && UltimoApretado == 2))
            {
                mtbNumero.Text = (valorActual += (UltimoApretado == 1) ? maxValor : minValor).ToString();
                tmrTimer.Stop();
                return;
            }
            mtbNumero.Text = (valorActual += (UltimoApretado == 1) ? UpDown : -UpDown).ToString();
        }

        private void EmpezarContador(object sender, MouseEventArgs e)
        {
            UltimoApretado = Convert.ToInt32((sender as Control).Tag);
            tmrTimer.Start();
        }

        private void TerminarContador(object sender, MouseEventArgs e)
        {
            tmrTimer.Stop();
            if (CambioDeValor != null)
                CambioDeValor.Invoke(this, e);
        }

        private void BorrarMTB(object sender, EventArgs e)
        {
            mtbNumero.Clear();
        }

        private void mtbNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                valorActual = Convert.ToInt32(mtbNumero.Text);
                if (CambioDeValor != null)
                    CambioDeValor.Invoke(this, e);
                pbFondo.Focus();
            }
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back);
        }
    }
}
