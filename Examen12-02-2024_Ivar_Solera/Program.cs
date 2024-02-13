using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static int[] numeroFactura = new int[15];
    static string[] numeroPlaca = new string[15];
    static string[] fecha = new string[15];
    static int[] tipoVehiculo = new int[15];
    static int[] numeroCaseta = new int[15];
    static double[] montoPagar = new double[15];
    static double[] pagaCon = new double[15];
    static double[] vuelto = new double[15];
    static int cantidadVehiculos = 0;

    static void Main()
    {
        int opcion;

        do
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // para que me pueda mostrar el signo de colones
            Console.ForegroundColor = ConsoleColor.Green; // para que me tire las letras en color
            Console.WriteLine("Menú Principal del Sistema **** PEAJES IDSO CR ****");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White; // para que me tire las letras en color
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Paso Vehicular");
            Console.WriteLine("3. Consulta de vehículos por Número de Placa");
            Console.WriteLine("4. Modificar Datos Vehículos por Número de Placa");
            Console.WriteLine("5. Reporte Todos los Datos de los vectores");
            Console.WriteLine("6. Salir");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Green; // para que me tire las letras en color
            Console.Write("Ingrese la opción deseada: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        InicializarVectores();
                        break;
                        
                    case 2:
                        IngresarPasoVehicular();
                        break;
                    case 3:
                        ConsultaPorNumeroPlaca();
                        break;
                    case 4:
                        ModificarDatosPorNumeroPlaca();
                        break;
                    case 5:
                        ReporteTodosLosDatos();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        break;
                        // Agregar un retraso de 3 segundos antes de salir
                        Thread.Sleep(3000);
                      
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                Console.ReadKey(); // para que se limpie la pantalla
            }

        } while (opcion != 6);
    }

    static void InicializarVectores() // primera función
    {
        for (int i = 0; i < 15; i++)
        {
            numeroFactura[i] = 0;
            numeroPlaca[i] = "";
            fecha[i] = "";
            tipoVehiculo[i] = 0;
            numeroCaseta[i] = 0;
            montoPagar[i] = 0.0;
            pagaCon[i] = 0.0;
            vuelto[i] = 0.0;
        }

        cantidadVehiculos = 0;

        Console.WriteLine("Vectores inicializados correctamente.");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
    }

    static void IngresarPasoVehicular() // funcion para ingresar los datos del carro
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Ingrese los datos del paso vehicular:");

        if (cantidadVehiculos < 15)
        {
            Console.Write("Número de factura: ");
            numeroFactura[cantidadVehiculos] = int.Parse(Console.ReadLine());

            Console.Write("Número de placa: ");
            numeroPlaca[cantidadVehiculos] = Console.ReadLine();
            // se le pone para condicionar la fecha y no acepte otros formatos
            Console.Write("Fecha (formato DD/MM/AAAA): ");
            string formatoFecha = "dd/MM/yyyy";
            DateTime fechaIngresada;

            while (!DateTime.TryParseExact(Console.ReadLine(), formatoFecha, null, System.Globalization.DateTimeStyles.None, out fechaIngresada))
            {
                Console.Write($"Formato de fecha incorrecto. Por favor, ingrese la fecha en formato {formatoFecha}: ");
            }

            fecha[cantidadVehiculos] = fechaIngresada.ToString(formatoFecha);
            // se da formato para que acepte la hora solo en ese formato.
            Console.Write("Hora (formato HH:MM): ");
            string formatoHora = "HH:mm";
            DateTime horaIngresada;

            while (!DateTime.TryParseExact(Console.ReadLine(), formatoHora, null, System.Globalization.DateTimeStyles.None, out horaIngresada))
            {
                Console.Write($"Formato de hora incorrecto. Por favor, ingrese la hora en formato {formatoHora}: ");
            }

            
            Console.Write("Tipo de vehículo (1=Moto, 2=Vehículo Liviano, 3=Camión o Pesado, 4=Autobús): ");
            tipoVehiculo[cantidadVehiculos] = int.Parse(Console.ReadLine());

            if (tipoVehiculo[cantidadVehiculos] >= 1 && tipoVehiculo[cantidadVehiculos] <= 4)
            {
                double precio;
                switch (tipoVehiculo[cantidadVehiculos])
                {
                    case 1:
                        precio = 500;
                        break;
                    case 2:
                        precio = 700;
                        break;
                    case 3:
                        precio = 2700;
                        break;
                    case 4:
                        precio = 3700;
                        break;
                    default:
                        precio = 0; // En caso de tipo de vehículo no reconocido
                        break;
                }

                Console.WriteLine($"Monto a pagar: {precio:C}");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.Write("¿Desea continuar? (S/N): ");
                string respuesta = Console.ReadLine();

                if (respuesta.ToUpper() == "S")
                {
                    Console.Write($"Número de caseta (1, 2, 3): ");
                    numeroCaseta[cantidadVehiculos] = int.Parse(Console.ReadLine());

                    montoPagar[cantidadVehiculos] = precio;

                    Console.Write("Paga con: ");
                    pagaCon[cantidadVehiculos] = double.Parse(Console.ReadLine());

                    vuelto[cantidadVehiculos] = pagaCon[cantidadVehiculos] - montoPagar[cantidadVehiculos];

                    cantidadVehiculos++;

                    Console.WriteLine("Paso vehicular registrado exitosamente.");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("Operación cancelada por el usuario.");
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.WriteLine("Tipo de vehículo no válido. Ingrese un valor entre 1 y 4.");
                Console.WriteLine(" ");
            }
        }
        else
        {
            Console.WriteLine("Se ha alcanzado el límite de registros. No es posible ingresar más pasos vehiculares.");
            Console.WriteLine(" ");
        }
        Console.WriteLine(" ");
    }

    static void ConsultaPorNumeroPlaca()
    {
        Console.Write("Ingrese el número de placa a consultar: ");
        string placaConsulta = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < cantidadVehiculos; i++)
        {
            if (numeroPlaca[i] == placaConsulta)
            {
                MostrarDatosVehiculo(i);
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron datos para el número de placa ingresado.");
        }
    }

    static void ModificarDatosPorNumeroPlaca()
    {
        Console.Write("Ingrese el número de placa del vehículo a modificar: ");
        string numeroPlacaBuscar = Console.ReadLine();

        int indiceModificar = -1;

        for (int i = 0; i < cantidadVehiculos; i++)
        {
            if (numeroPlaca[i] == numeroPlacaBuscar)
            {
                indiceModificar = i;
                break;
            }
        }

        if (indiceModificar != -1)
        {
            MostrarDatosVehiculo(indiceModificar);

            Console.WriteLine("\nMenú de Modificación:");
            Console.WriteLine("1. Modificar Número de Factura");
            Console.WriteLine("2. Modificar Fecha");
            Console.WriteLine("3. Modificar Tipo de Vehículo");
            Console.WriteLine("4. Modificar Número de Caseta");
            Console.WriteLine("5. Modificar Monto a Pagar");
            Console.WriteLine("6. Modificar Paga Con");
            Console.WriteLine("7. Regresar al Menú Principal");

            Console.Write("Ingrese la opción deseada: ");
            if (int.TryParse(Console.ReadLine(), out int opcionModificar))
            {
                switch (opcionModificar)
                {
                    case 1:
                        Console.Write("Nuevo número de factura: ");
                        numeroFactura[indiceModificar] = int.Parse(Console.ReadLine());
                        Console.WriteLine("Número de factura modificado exitosamente.");
                        break;
                    case 2:
                        Console.Write("Nueva fecha (formato DD/MM/AAAA): ");
                        string formatoFecha = "dd/MM/yyyy";
                        DateTime nuevaFecha;
                        while (!DateTime.TryParseExact(Console.ReadLine(), formatoFecha, null, System.Globalization.DateTimeStyles.None, out nuevaFecha))
                        {
                            Console.Write($"Formato de fecha incorrecto. Por favor, ingrese la fecha en formato {formatoFecha}: ");
                        }
                        fecha[indiceModificar] = nuevaFecha.ToString(formatoFecha);
                        Console.WriteLine("Fecha modificada exitosamente.");
                        break;
                    case 3:
                        Console.Write("Nuevo tipo de vehículo (1=Moto, 2=Vehículo Liviano, 3=Camión o Pesado, 4=Autobús): ");
                        tipoVehiculo[indiceModificar] = int.Parse(Console.ReadLine());
                        // Puedes implementar la lógica para recalcular el monto a pagar según la tabla de precios
                        Console.WriteLine("Tipo de vehículo modificado exitosamente.");
                        break;
                    case 4:
                        Console.Write("Nuevo número de caseta (1, 2, 3): ");
                        numeroCaseta[indiceModificar] = int.Parse(Console.ReadLine());
                        Console.WriteLine("Número de caseta modificado exitosamente.");
                        break;
                    case 5:
                        Console.Write("Nuevo monto a pagar: ");
                        double nuevoMontoPagar = double.Parse(Console.ReadLine());
                        montoPagar[indiceModificar] = nuevoMontoPagar;
                        // Actualizar el vuelto después de modificar el monto a pagar
                        vuelto[indiceModificar] = pagaCon[indiceModificar] - nuevoMontoPagar;
                        Console.WriteLine("Monto a pagar modificado exitosamente.");
                        break;
                    case 6:
                        Console.Write("Nuevo paga con: ");
                        pagaCon[indiceModificar] = double.Parse(Console.ReadLine());
                        // Puedes implementar la lógica para recalcular el vuelto
                        Console.WriteLine("Paga con modificado exitosamente.");
                        break;
                    case 7:
                        Console.WriteLine("Regresando al menú principal.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron datos para el número de placa ingresado.");
        }
    }

    static void ReporteTodosLosDatos()
    {
        Console.WriteLine("Título del Reporte");
        Console.WriteLine("=============================================================================");
        Console.WriteLine("N factura\tPlaca\t\t\ttipo de vehículo\tcaseta\tmonto Pagar\tpaga con\tvuelto");
        Console.WriteLine("=============================================================================");

        for (int i = 0; i < cantidadVehiculos; i++)
        {
            Console.WriteLine($"{numeroFactura[i]}\t\t{numeroPlaca[i]}\t\t{tipoVehiculo[i]}\t\t{numeroCaseta[i]}\t\t{montoPagar[i]}\t\t{pagaCon[i]}\t\t{vuelto[i]}");
        }

        Console.WriteLine("=============================================================================");
        Console.WriteLine($"Cantidad de vehículos: {cantidadVehiculos}\t\ttotal: {CalcularTotalMonto()}");
        Console.WriteLine("=============================================================================");
        Console.WriteLine("<<<Pulse tecla para regresar >>>");
        Console.ReadKey();
    }

    static void MostrarDatosVehiculo(int indice)
    {
        Console.WriteLine("Datos del vehículo:");
        Console.WriteLine($"Número de factura: {numeroFactura[indice]}");
        Console.WriteLine($"Número de placa: {numeroPlaca[indice]}");
        Console.WriteLine($"Fecha: {fecha[indice]}");
        Console.WriteLine($"Tipo de vehículo: {tipoVehiculo[indice]}");
        Console.WriteLine($"Número de caseta: {numeroCaseta[indice]}");
        Console.WriteLine($"Monto a pagar: {montoPagar[indice]}");
        Console.WriteLine($"Paga con: {pagaCon[indice]}");
        Console.WriteLine($"Vuelto: {vuelto[indice]}");
    }

    static double CalcularTotalMonto()
    {
        double total = 0;

        for (int i = 0; i < cantidadVehiculos; i++)
        {
            total += montoPagar[i];
        }

        return total;
    }
}

