﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Cliente
{
    public class SocketTCP
    {
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------Atributos y variables
        public static bool PermitirRecibir = true;
        private ManualResetEvent TodoHecho = new ManualResetEvent(false);
        static int port = 666;
        int maxThreadON = 12;
        int Nposicion = 6;
        //-----------------------------------------------
        // ManualResetEvent instances signal completion.  
        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);

        // The response from the remote device.  
        private String response = String.Empty;
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------Metodos
        public void Frenar()
        {
            PermitirRecibir = false;
            allDone.Set();
        }
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------Enviar
        public void EnviarSolicitud(ArchivoSolicitado AS)
        {
            IPEndPoint remoteEP = new IPEndPoint(AS.IPDestino, port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                connectDone.Reset();
                sendDone.Reset();

                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                Send(client, frmCliente.archivosCompartidos[AS.IDPosicion].Ruta, AS.IDPosicion, AS.ParteArchivo);
                sendDone.WaitOne();

                client.Shutdown(SocketShutdown.Send);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("StartClient Error: " + e.ToString());
            }
            Controlador.PermitirEnviarSolicitud.Set();
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                ((Socket)ar.AsyncState).EndConnect(ar);
                connectDone.Set();
            }
            catch (Exception e)
            {
                Controlador.PermitirEnviarSolicitud.Set();
                Console.WriteLine("conecctcallback Error: " + e.ToString());
            }
        }

        private void Send(Socket client, String filename, int id, int Nparte)
        {
            FileStream loadedFile;
            try
            {
                loadedFile = new FileStream(filename, FileMode.Open, FileAccess.Read);

                byte[] byteId = Encoding.ASCII.GetBytes(id.ToString() + "|");//ID                
                byte[] byteParte = Encoding.ASCII.GetBytes(Nparte.ToString() + "|");//Parte


                byte[] byteData = new byte[StateObject.size];

                loadedFile.Position = Nparte * StateObject.size;
                loadedFile.Read(byteData, 0, byteData.Length);

                byte[] bFinal = Encoding.ASCII.GetBytes("<BNF>");

                byte[] sendB = new byte[byteId.Length + byteParte.Length + byteData.Length + bFinal.Length];

                byteId.CopyTo(sendB, 0);
                byteParte.CopyTo(sendB, byteId.Length);
                byteData.CopyTo(sendB, (byteId.Length + byteParte.Length));

                bFinal.CopyTo(sendB, (byteId.Length + byteParte.Length + byteData.Length));//Agrego el punto final del archivo

                client.BeginSend(sendB, 0, sendB.Length, 0, new AsyncCallback(SendCallback), client);
            }
            catch (Exception e)
            {
                Controlador.PermitirEnviarSolicitud.Set();
                Console.WriteLine("Error Send: " + e.Message);
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                ((Socket)ar.AsyncState).EndSend(ar);
                sendDone.Set();
            }
            catch (Exception e)
            {
                Controlador.PermitirEnviarSolicitud.Set();
                Console.WriteLine("Send CallbackEroor: " + e.ToString());
            }
        }
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------Recibir datos
        public ManualResetEvent allDone = new ManualResetEvent(false);

        public void RecibirTCP()
        {
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, port);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(sender);
                listener.Listen(100);

                while (PermitirRecibir)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();
            Socket handler = ((Socket)ar.AsyncState).EndAccept(ar);

            StateObject state = new StateObject { workSocket = handler };
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }
        public void ReadCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {
                string content;
                state.sb.Append(Encoding.ASCII.GetString(
                state.buffer, 0, bytesRead));

                content = state.sb.ToString();
                state.enterita += content;

                if (content.IndexOf("<BNF>") > -1)
                {
                    state.ManejarArchivo(bytesRead);
                }
                else
                {
                    // Not all data received. Get more.  
                    if (state.leerIndices)
                    {
                        string[] spliteo = content.Split('|');
                        state.id = Convert.ToInt32(spliteo[0]);
                        state.parte = Convert.ToInt32(spliteo[1]);
                        state.leerIndices = false;
                    }
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------Clase Auxiliar
        public class StateObject
        {
            // public static int Nid = 1;
            //  public static int Npartes = 6;
            public string enterita = "";

            public static int size = ArchivoNecesitado.TamañoParte;
            public Socket workSocket = null;
            // Size of receive buffer.  
            public int id = 0;
            public long parte = 0;
            public bool leerIndices = true;
            public int byteLeidos = 0;
            public const int BufferSize = 64;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];

            public byte[] datos = new byte[size];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();

            public void ManejarArchivo(int byteRead)
            {
                Console.WriteLine("Enterita: " + enterita);

                Console.WriteLine("ID: " + id);
                Console.WriteLine("Parte: " + parte);
                //Console.WriteLine("Enterita: " + enterita);
                if (Controlador.archivosNecesitados[id].Partes[parte])
                {
                    using (FileStream output = new FileStream(Controlador.archivosNecesitados[id].RutaDesarga, FileMode.Append))
                    {
                        //output.Position = parte * size;
                        //output.Write(buffer, 0, buffer.Length);
                        Console.WriteLine("Escribiendo: ....");
                        Console.WriteLine("Escribido: ....");
                    }
                }
            }
        }
    }
}