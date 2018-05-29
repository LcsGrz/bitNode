using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace Cliente
{
    class Configuracion
    {
        //bitNode
        public static string bitNode = Environment.ExpandEnvironmentVariables("%AppData%") + "\\bitNode";
        public static string bnConfiguracion = bitNode + @"\Configuracion.json";
        public static string userRoot = Environment.GetEnvironmentVariable("USERPROFILE");
        public static Random r = new Random();
        //General
        public bool latino = true;
        public bool iniciarConWindows = false;
        public bool minimizarBandeja = false;
        public string nombre;
        //Interfaz
        public bool MenuSlideDeluxe = true;
        public bool BotonSlideDeluxe = true;
        public bool InicioFadeDeluxe = true;
        public bool temaOscuro = true;
        //Transferencias
        public static int FinalizoDescarga = 0;
        public int limiteDesacargas = 3;
        public int limiteSubida = 0;
        public int limiteBajada = 0;
        public string rutaDescarga = Path.Combine(userRoot, "Downloads");
        //Tema
        public Color colorFondo = Color.FromArgb(255, 7, 17, 27);
        public Color colorVistaFondo = Color.FromArgb(255, 13, 23, 33);
        public Color colorMenu = Color.FromArgb(255, 7, 17, 27);
        public Color colorMenuSeleccion = Color.FromArgb(255, 1, 9, 17);
        public Color colorGeneral = Color.FromArgb(255, 153, 153, 153);
        public Color colorDetalles = Color.FromArgb(255, 255, 42, 42);
        public Color colorPanelesInternosVistas = Color.FromArgb(255, 22, 31, 41);
        public static event EventHandler CambioDeTema;
        //Metodos
        public void Guardar() => File.WriteAllText(bnConfiguracion, JsonConvert.SerializeObject(this));
        public Configuracion Leer()
        {
            if (!File.Exists(bitNode + "\\Newtonsoft_Json.dll"))
                File.WriteAllBytes(Configuracion.bitNode + "\\Newtonsoft_Json.dll", Cliente.Properties.Resources.Newtonsoft_Json);
            if (!File.Exists(bnConfiguracion))
            {
                GenerarNombre();
                Guardar();
                return this;
            }
            return JsonConvert.DeserializeObject<Configuracion>(File.ReadAllText(bnConfiguracion));
        }
        public static PrivateFontCollection Tipografia()
        {
            if (!File.Exists(bitNode + "\\Roboto_Light.ttf"))
                File.WriteAllBytes(Configuracion.bitNode + "\\Roboto_Light.ttf", Cliente.Properties.Resources.Roboto_Light);

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@Environment.ExpandEnvironmentVariables("%AppData%") + "\\bitNode\\Roboto_Light.ttf");
            return pfc;
        }
        public void CambiarTema()
        {
            colorFondo = (temaOscuro) ? Color.FromArgb(255, 7, 17, 27) : Color.FromArgb(255, 102, 102, 102);
            colorVistaFondo = (temaOscuro) ? Color.FromArgb(255, 13, 23, 33) : Color.FromArgb(255, 249, 249, 249);
            colorMenu = (temaOscuro) ? Color.FromArgb(255, 7, 17, 27) : Color.FromArgb(255, 230, 230, 230);
            colorMenuSeleccion = (temaOscuro) ? Color.FromArgb(255, 1, 9, 17) : Color.FromArgb(255, 183, 183, 183);
            colorGeneral = (temaOscuro) ? Color.FromArgb(255, 153, 153, 153) : Color.FromArgb(255, 255, 42, 42);
            colorPanelesInternosVistas = (temaOscuro) ? Color.FromArgb(255, 22, 31, 41) : Color.FromArgb(255, 230, 230, 230);
            Guardar();
            CambioDeTema?.Invoke(this, null);
        }
        private void GenerarNombre() //Genera nombre aleatorio a la maquina
        {
            string ABC = "Q W E R T Y U I O P A S D F G H J K L Ñ Z X C V B N M";
            nombre = ABC.Split(' ')[r.Next(0, 27)] + ABC.Split(' ')[r.Next(0, 27)] + ABC.Split(' ')[r.Next(0, 27)] + r.Next(100, 999).ToString();
        }
    }
}