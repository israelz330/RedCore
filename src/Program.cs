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
#PortDET puerto tty: pi$: dmesg | grep tty
#Portlist puertos: python -m serial.tools.list_ports
#Autorun: sudo nano /etc/rc.local -> python3 regEx.py
#Autostart: sudo nano /home/pi/.bashrc
#           echo Running at boot
#           sudo python /home/..../program.py
#****************************************************************
#****************************************************************
*******************CONFIGURACIÓN .NET CORE***********************
#CLI: dotnet publish -r linux-arm
#RPi: chmod 760 ./RedCore (ó 755)
#RPi: ./RedCore
#****************************************************************
*/

namespace RedCore
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            //Inicializa el programa
            var iniciar = new Inicializar();
        }
    }
}
