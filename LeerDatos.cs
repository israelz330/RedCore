/*
#Autor: Israel Zapata
#Fecha: 08/Mayo/2020
#Versión: 0.0.1
#Descripción: Lectura de los datos del RedLion a travez del puerto serial ttyUSB0 y transformación
#             de los datos usando expresiones regulares para que el software de la PC de inspección
#             pueda leerlos a travez del pierto serial ttyUSB1 con un scan de 300ms y este se conecta
#             q la PC de calidad a travez del puerto serial COM1 (SOLO funciona si es COM1)
#v0.0.1 - 08/Mayo/2020 - Creación del programa

#********************CONFIGURACIÓN REDLION***********************
#Baudrate: 9600
#Paridad: NONE
#Bits: 8
#Auto: NO (Para evitar que el RedLion mande datos sin que se le pidan)
#SOLO mandar la cuenta a la salida serial del canal A o B
#Salida de datos: RS232
#****************************************************************
#********************CONFIGURACIÓN RASPBERRY*********************
#os: Raspbian
#Serial Ports: ttyUSB0 & ttyUSB1
#HDMI: No
#Ethernet: No
#Detectar puerto tty: pi$: dmesg | grep tty
#Enlistar puertos: python -m serial.tools.list_ports
#Autorun: sudo nano /etc/rc.local -> python3 regEx.py
#****************************************************************
*/
using System.Threading;
using System;

namespace RedCore
{
    public class LeerDatos
    {
        public string Datos { get; set; }
        public string NuevosDatos {get; set;}
        ConvertirDatos Convertir = new ConvertirDatos();
        protected static int origRow;
        protected static int origCol;
        public LeerDatos()
        {
           System.Console.WriteLine("Verificando puertos...");
        }

        public void adquisicion()
        {
            VerificarPuertos verificar = new VerificarPuertos();

            if(verificar.ambosPuertos() == true)
            {
                System.Console.WriteLine("Puertos OK...");
                System.Console.WriteLine("Adquiriendo datos...");
                Thread.Sleep(1000);

                while(true)
                {
                    verificar.tty0USB.Write("TA*");
                    Datos = verificar.tty0USB.ReadLine();
                    NuevosDatos =  Convertir.aDurant(Datos);
                    System.Console.WriteLine(NuevosDatos);
                    Thread.Sleep(500);
                }
            }

            else 
            {
                System.Console.WriteLine("Por favor primero conecta ambos puertos y luego reinicia la Raspberry Pi con CTRL + ALT + SUPR");
                Thread.Sleep(3000);
            }
        }
    }
}
