using System;

namespace CentralTelefonica.util


{
    public class OpcionMenuException : Exception
    {
       private string message = "Error, debe de ingresar un numero no un caracter";
       public override string Message
       {
           get { return message;}
        
       }
       
    }
}