using System;

namespace CentralTelefonica.util


{
    public class OpcionMenuException : Exception
    {
       private string message = "Error, debe de ingresar una opcion válida";
       public override string Message
       {
           get { return message;}
        
       }
       
    }
}