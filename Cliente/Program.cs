using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Cliente
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length == 1)
            {
                if (!Directory.Exists(Configuracion.bitNode))
                    Directory.CreateDirectory(Configuracion.bitNode);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmSplash());
                Application.Run(new frmCliente());
            }
            else
                new frmMensaje(Idioma.StringResources.mensajebitNodeActivo).ShowDialog();
        }
    }
}