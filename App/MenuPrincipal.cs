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
        private const float precioLocal = 1.25f;

        // public List<Llamada> ListaDeLlamadas = new 
        public List<Llamada> ListaDeLlamadas { get; set; } //este es otro tipo de encapsulamiento, por ejemplo yo no voy a validad que este 
                                                           //vacio, que este nula, si no voy a hacer algun tipo de validacion puedo usar esta forma de encapsulamiento
                                                           //al utilizar este tipo de encapsulamiento yo decido si le agrego get y set o solo lo dejo asi: "public List<Llamada>ListaDeLlamadas;" pero por convencion le dejo agregado get y set como esta

        public MenuPrincipal()
        {
            this.ListaDeLlamadas = new List<Llamada>();

        }
        public void MostrarMenu()
        {
            int opcion = 100;

            do
            {

                try
                {

                    // en todas las writeLine que tenemos tendriamos que colocar console. para que funcione pero para
                    // ya no colocarle solo se importa "using static system.console;"
                    //Clear();
                    WriteLine("1. Registrar llamada local");
                    WriteLine("2. Registrar llamada departamental");
                    WriteLine("3. Costo total de las llamadas locales");
                    WriteLine("4. Costo total de las llamadas departamentales");
                    WriteLine("5. Costo total de las llamadas");
                    WriteLine("6. Mostrar Resumen");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese su opcion===");
                    string valor = ReadLine(); //al principio de ReadLine no se coloco console xq tenemos arriba importado "system.Console" 
                                               // opcion = Convert.ToInt16(valor); //estoy utilizando la clase convert utilizando un metodo que tiene llamado ToInt16 la cual recibe un valor string llamado valor
                    if (EsNumero(valor) == true)
                    {
                        opcion = Convert.ToInt16(valor);
                    }

                    if (opcion == 1)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 2)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 3)
                    {
                        MostrarCostoLlamadasLocales();
                    }
                    else if (opcion == 4)
                    {
                        MostrarDetalleLlamadasDepto();

                    }
                    else if (opcion == 6)
                    {
                        MostrarDetalle();

                    }
                }

                catch (OpcionMenuException e)
                {
                    WriteLine(e.Message);

                }

            } while (opcion != 0);

        }
        public Boolean EsNumero(string valor)
        {
            Boolean resultado = false;
            try
            {
                int numero = Convert.ToInt16(valor);
                resultado = true;
            }
            catch (Exception e)
            {
                throw new OpcionMenuException();
            }
            return resultado;
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
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = calcularFranja(DateTime.Now);
            }
            else
            {
                WriteLine("Tipo de llamada no registrado");
            }
            this.ListaDeLlamadas.Add(llamada);
        }
        /* public void MostrarDetalleWhile()
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
             } while (this.ListaDeLlamadas.Count > i);
         }
         public void MostarDetalleFor()
         {
             for (int i = 0; i < this.ListaDeLlamadas.Count; i++)
             {
                 WriteLine(this.ListaDeLlamadas[i]);
             }
         }*/
        public void MostrarDetalle()
        {

            foreach (var llamada in ListaDeLlamadas)
            {
                WriteLine(llamada);
            }
        }

        public void MostrarCostoLlamadasLocales()
        {

            double tiempoLlamada = 0;
            double costoTotal = 0.0;
            foreach (var elemento in ListaDeLlamadas)
            {
                if (elemento.GetType() == typeof(LlamadaLocal))// aqui hago que con GetType me devuelva el tipo de elemento y compare si elemento tiene la instancia de llamada local
                {
                    tiempoLlamada += elemento.Duracion;
                    costoTotal += elemento.CalcularPrecio();
                }

            }
            WriteLine($"Costo minuto: {precioLocal}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamada} ");
            WriteLine($"Costo total: {costoTotal}");

        }
        public void MostrarDetalleLlamadasDepto()
        {
            double tiempoLlamadaFranjaUno = 0;
            double tiempoLlamadaFranjaDos = 0;
            double tiempoLlamadaFranjaTres = 0;
            double costoTotal = 0.0;

            double costoTotalFranjaUno = 0.0;
            double costoTotalFranjaDos = 0.0;
            double costoTotalFranjaTres = 0.0;
            foreach (var elemento in ListaDeLlamadas)
            {
                if (elemento.GetType() == typeof(LlamadaDepartamental))
                {
                    switch (((LlamadaDepartamental)elemento).Franja)
                    {
                        case 0:
                            tiempoLlamadaFranjaUno += elemento.Duracion;
                            costoTotalFranjaUno += elemento.CalcularPrecio();
                            break;

                        case 1:
                            tiempoLlamadaFranjaDos += elemento.Duracion;
                            costoTotalFranjaDos += elemento.CalcularPrecio();
                            break;

                        case 2:
                            tiempoLlamadaFranjaTres += elemento.Duracion;
                            costoTotalFranjaTres += elemento.CalcularPrecio();
                            break;
                    }
                }
            }

            WriteLine($"Franja: 1");
            WriteLine($"Costo minuto: {precioUnoDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaUno}");
            WriteLine($"Costo total: {costoTotalFranjaUno}");

            WriteLine($"Franja: 2");
            WriteLine($"Costo minuto: {precioDosDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaDos}");
            WriteLine($"Costo total: {costoTotalFranjaDos}");

            WriteLine($"Franja: 3");
            WriteLine($"Costo minuto: {precioTresDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaTres}");
            WriteLine($"Costo total: {costoTotalFranjaTres}");
        }
        /*  public int calcularFranja(DateTime fecha)
         {
             int resultado = -1;
             return resultado; //0,1,2
         }*/

        public int calcularFranja(DateTime fecha)
        {
            int franja = 0;
            fecha = DateTime.Now;
            int dia = (int)fecha.DayOfWeek;
            int hora = fecha.Hour;
            int minutos = fecha.Minute;

                if ((hora >= 6 && hora <= 21) && (dia >= 1 && dia <=5))
                {
                        franja = 0;
                }else if (hora >= 22 || hora <= 5 )
                {
                    if(dia >= 1 && dia <= 5)
                    {
                        franja = 1;
                    }else if (dia == 5 || dia == 6 || dia == 0 || dia == 1 )
                    {
                        franja = 2;
                    }
                }
          /*   if (dia >= 1 && dia <= 5)// si dia estan entre lunes a viernes
            {
                if (hora >= 6 && hora <= 21) //si la hora esta entre 6:00 a 21:59
                {
                    franja = 0;
                }
                else if (hora >= 22 || hora <= 5)//si la hora esta entre 22:00 a 5:59
                {
                    franja = 1;
                }
                else if ((hora >= 22 || hora <= 5) && (dia == 5 || dia == 1))//si hora es de 22:00 a 5:59
                {
                    franja = 2;
                }
            }
            else if (dia == 7 || dia == 0)
            {
                franja = 2;
            }   
            return franja;
        }*/
            return franja;
        }
    }
}
