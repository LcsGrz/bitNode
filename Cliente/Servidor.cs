﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;

namespace Cliente
{
    class Servidor
    {
        //----------------------------------------------------------------------------------------------Variables y atributos
        SocketUDP SUDP = new SocketUDP();
        Ping pingSender = new Ping();
        public static List<IPAddress> IPSVecinas = new List<IPAddress>();
        Thread EscucharUDP;
        private static System.Timers.Timer temporizador;
        //----------------------------------------------------------------------------------------------Funciones
        //-----------------------------------------------Server
        public void IniciarEjecuciones()
        {
            EscucharUDP = new Thread(() => { SUDP.RecibirUDP(); });
            EscucharUDP.Start();
            temporizador = new System.Timers.Timer(60000) { AutoReset = true, Enabled = true };
            temporizador.Elapsed += bitNodersVivos;
            temporizador.Start();
        }
        public void AgregarIP(IPAddress ip)
        {
            if (!IPSVecinas.Exists(x => x.Equals(ip)))
                IPSVecinas.Add(ip);
        }
        private void bitNodersVivos(Object source, ElapsedEventArgs e)
        {
            for (int i = 0; i < IPSVecinas.Count; i++)
            {
                if (pingSender.Send(IPSVecinas[i]).Status != IPStatus.Success)
                {
                    IPSVecinas.RemoveAt(i);
                }
            }
        }
        public void FrenarEjecuciones()
        {
            SUDP.FrenarEscucha();
            temporizador.Stop();
            temporizador.Dispose();
        }
        //-----------------------------------------------UDP
        public void EnviarUDP(IPAddress ip, string msj)
        {
            SUDP.EnviarMSJ_UDP(ip, msj);
        }
        public void SolicitarArchivosCompartidos()
        {

        }
        //-----------------------------------------------TCP
    }
}