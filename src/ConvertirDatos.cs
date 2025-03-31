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

using System.Text.RegularExpressions;

namespace RedCore
{
    public class ConvertirDatos
    {
        public Regex RoyalFlush = new Regex("[ ]{3}CTA[ ]{5}[0-9]{4}[.]{1}[0-9]{2}");
        public Regex FullHouse = new Regex("[ ]{3}CTA[ ]{6}[0-9]{3}[.]{1}[0-9]{2}");
        public Regex Flush = new Regex("[ ]{3}CTA[ ]{7}[0-9]{2}[.]{1}[0-9]{2}");
        public Regex OnePair = new Regex("[ ]{3}CTA[ ]{8}[0-9]{1}[.]{1}[0-9]{2}");

        public string aDurant(string datos)
        {

            if (RoyalFlush.IsMatch(datos))
            {
              return Regex.Replace(datos, "[ ]{3}CTA[ ]{5}", "CNT 00");
                
            }
            else if (FullHouse.IsMatch(datos))
            {
              return Regex.Replace(datos, "[ ]{3}CTA[ ]{6}", "CNT 000");

            }
            else if (Flush.IsMatch(datos))
            {
               return Regex.Replace(datos, "[ ]{3}CTA[ ]{7}", "CNT 0000");

            }
            else if (OnePair.IsMatch(datos))
            {
                return Regex.Replace(datos, "[ ]{3}CTA[ ]{8}", "CNT 00000");
            }
            else
            {
                return "";
            }
        }

    }
}
