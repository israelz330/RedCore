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

using System;
using System.IO.Ports;

namespace RedCore
{
    public class VerificarPuertos
    {
        #region PROPIEDADES Y CAMPOS
        public SerialPort tty0USB { get; }
        public SerialPort tty1USB { get; private set; }
        private string port_tty0USB { get; }
        private string port_tty1USB { get; }
        private int baudRate_tty0USB { get; }
        private int baudRate_tty1USB { get; }
        private Parity parity_tty0USB { get; }
        private Parity parity_tty1USB { get; }
        private int bits_tty0USB { get; }
        private int bits_tty1USB { get; }
        private StopBits stopBits_tty0USB { get; }
        private StopBits stopBits_tty1USB { get; }
        int countChecker = 0;
        #endregion
        public VerificarPuertos()
        {
            #region PARAMETROS TTY
            port_tty0USB = "/dev/ttyUSB0";
            port_tty1USB = "/dev/ttyUSB1";
            baudRate_tty0USB = 9600;
            baudRate_tty1USB = 1200;
            parity_tty0USB = Parity.None;
            parity_tty1USB = Parity.Even;
            bits_tty0USB = 8;
            bits_tty1USB = 7;
            stopBits_tty0USB = StopBits.One;
            stopBits_tty1USB = StopBits.One;
            #endregion

            //Inicializa puertos ttyUSB0 y ttyuSB1
            tty0USB = new SerialPort(portName: port_tty0USB,
                                     baudRate: baudRate_tty0USB,
                                     parity: parity_tty0USB,
                                     dataBits: bits_tty0USB,
                                     stopBits: stopBits_tty0USB);

            tty1USB = new SerialPort(portName: port_tty1USB,
                                     baudRate: baudRate_tty0USB,
                                     parity: parity_tty0USB,
                                     dataBits: bits_tty0USB,
                                     stopBits: stopBits_tty0USB);
        }

        //Revisa si ambos convertidores USB-Serial ya estan conectados en la Rasperry
        public bool ambosPuertos()
        {
            try
            {
               tty0USB.Open(); 
               Console.ForegroundColor = ConsoleColor.Green;
               System.Console.WriteLine("Puerto tty0USB encontrado (Red Lion)");
               Console.ResetColor();
               countChecker++;
            }
            catch (System.Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Puerto tty0USB (Red Lion) no encontrado");
                Console.ResetColor();
            }

            try
            {
                tty1USB.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Puerto tty1USB encontrado (PC Inspección)");
                Console.ResetColor();
                countChecker++;
            }
            catch (System.Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Puerto tty1USB (PC Inspección) no encontrado");
                Console.ResetColor();

            }
            if (countChecker == 2)
            {
                return true;
            }
            
            else return false;

        }
    }
}
