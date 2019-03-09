using System;
using static System.Console;
using CentralTelefonica.Entidades;
using System.Collections.Generic;
using CentralTelefonica.util;

namespace CentralTelefonica.App
{
    public class MenuPrincipal
    {
        //defino mis variables constantes
        private const float precioUnoDepartamental = 0.65f; //se le coloco f xq el compilador no sabe di el valor es un double o float ahora cuando no se que 
                                                            //puede venir un float o un double no se le coloca nada (hago la prueba si le quito f me da error)
        private const float precioDosDepartamental = 0.85f;
        private const float precioTresDepartamental = 0.90f;
        private const float precioLocal = 0.40f;



        // public List<Llamada> ListaDeLlamadas = new 
        public List<Llamada> ListaDeLlamadas { get; set; } //este es otro tipo de encapsulamiento, por ejemplo yo no voy a validad que este 
                                                           //vacio, que este nula, si no voy a hacer algun tipo de validacion puedo usar esta forma de encapsulamiento
                                                           //al utilizar este tipo de encapsulamiento yo decido si le agrego get y set o solo lo dejo asi: "public List<Llamada>ListaDeLlamadas;" pero por convencion le dejo agregado get y set como esta

        public MenuPrincipal()
        {
            ListaDeLlamadas = new List<Llamada>();

        }



        public void MostrarMenu()
        {
            int opcion = 100;

            do
            {

                try{

                // en todas las writeLine que tenemos tendriamos que colocar console. para que funcione pero para
                // ya no colocarle solo se importa "using static system.console;"
                WriteLine("1. Registrar llamada local");
                WriteLine("2. Registrar llamada departamental");
                WriteLine("3. Costo total de las llamadas locales");
                WriteLine("4. Costo total de las llamadas departamentales");
                WriteLine("5. Costo total de las llamadas");
                WriteLine("6. Mostrar Resumen");
                WriteLine("0. Salir");
                WriteLine("Ingrese su opcion===");
                string valor = ReadLine(); //al principio de ReadLine no se coloco console xq tenemos arriba importado "system.Console" 
                opcion = Convert.ToInt16(valor); //estoy utilizando la clase convert utilizando un metodo que tiene llamado ToInt16 la cual recibe un valor string llamado valor
                if (opcion == 1)
                {
                    RegistrarLlamada(opcion);
                }
                else if (opcion == 2){
                    RegistrarLlamada(opcion); 
                }

                else if (opcion == 6)
                {
                    MostrarDetalleForeach();

                }
                }catch (OpcionMenuException e)
                {
                   throw new OpcionMenuException();
                }

            } while (opcion != 0);

        }


        public void RegistrarLlamada(int opcion)
        {
            string numeroOrigen = "";
            string numeroDestino = "";
            string duracion = "";
           // string tipo = "";
            Llamada llamada = null;
            WriteLine("Ingrese el numero de origen");
            numeroOrigen = ReadLine();
            WriteLine("Ingrese el numero de destino");
            numeroDestino = ReadLine();
            WriteLine("Duracion de la llamada");
            duracion = ReadLine();
            if (opcion == 1)
            {
                llamada = new LlamadaLocal(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                /*  llamada.NumeroDestino = numeroDestino;
                 llamada.NumeroOrigen = numeroOrigen;
                 llamada.Duracion = Convert.ToDouble(duracion); */
                ((LlamadaLocal)llamada).Precio = precioLocal; //cast converti llamada de tipo llamada local aqui para poder tener acceso a precioLocal xq la el objeto llamada es de tipo llamada y este mismos no tiene precioLocal
            }
            else if (opcion == 2)
            {
                llamada = new LlamadaDepartamental(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                /*  llamada.NumeroDestino = numeroDestino;
                 llamada.NumeroOrigen = numeroOrigen;
                 llamada.Duracion = Convert.ToDouble(duracion); */
                ((LlamadaDepartamental)llamada).PrecioUno = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = 0;
            }
            else
            {
                WriteLine("Tipo de llamada no registrado");
            }
            this.ListaDeLlamadas.Add(llamada);
        }
        public void MostrarDetalleWhile()
        {
            int i = 0;
            while (this.ListaDeLlamadas.Count > i)
            {
                WriteLine(this.ListaDeLlamadas[i]);
                i = i + 1;


            }
        }
        public void MostrarDetalleDoWhile()
        {
            int i = 0;
            
            do
            {
                WriteLine(this.ListaDeLlamadas[i]);
                i++;
            }while(this.ListaDeLlamadas.Count > i);
        }
        public void MostarDetalleFor()
        {
            for (int i = 0; i < this.ListaDeLlamadas.Count; i++){
            WriteLine(this.ListaDeLlamadas[i]);
            }
        }
        public void MostrarDetalleForeach(){

        foreach (var llamada in ListaDeLlamadas)
        {
            WriteLine(llamada);
        }
        }
    }
}
