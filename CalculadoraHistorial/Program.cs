// See https://aka.ms/new-console-template for more information
using CalculadoraHistorial;

Calculadora calculadora = new Calculadora();
bool repetirOperacion = false;
do
{

    Console.WriteLine("--------CALCULADORA----------");
    Console.WriteLine("1. Sumar");
    Console.WriteLine("2. Restar");
    Console.WriteLine("3. Multiplicar");
    Console.WriteLine("4. Dividir");
    Console.WriteLine("5. Limpiar");
    Console.WriteLine("6. Mostrar Historial\n");

    Console.WriteLine("Ingrese el numero de la operación a realizar: ");
    string cadena = Console.ReadLine();
    if ((int.TryParse(cadena, out int operacionElegidaNum)) && ((Enum.IsDefined(typeof(TipoOperacion), operacionElegidaNum-1)) || operacionElegidaNum==6))
    {
        if (operacionElegidaNum < 5)
        {
            TipoOperacion operacionSeleccionada = (TipoOperacion)(operacionElegidaNum-1);
            Console.Write("\nIngrese el numero a calcular: ");
            cadena = Console.ReadLine();
            Console.Write("\n");
            if (double.TryParse(cadena, out double numeroACalcular))
            {
                calculadora.RealizarOperacion(numeroACalcular, operacionSeleccionada);
                Console.WriteLine($"Resultado: {calculadora.ValorActual}\n");
            }
        } else if (operacionElegidaNum == 5)
        {
            calculadora.Limpiar();
            Console.WriteLine("Historial y resultado limpiados.\n");

        } else if (operacionElegidaNum == 6)
        {
            calculadora.MostrarHistorial();
        } else {
            Console.WriteLine("Ingrese un numero valido. \n");
        }
    } else {
        Console.WriteLine("Ingrese un numero valido. \n");
    }

    bool numeroValido = false;
    do
    {
        Console.WriteLine("Desea realizar otra operacion?");
        Console.WriteLine("1. Si \t2. No");
        cadena = Console.ReadLine();
        if (int.TryParse(cadena, out int desicion))
        {
            if (desicion == 2)
            {
                repetirOperacion = false;
                numeroValido = true;
            } else if (desicion == 1)
            {
                repetirOperacion = true;   
                numeroValido = true;
            } else
            {
                Console.WriteLine("Ingrese un numero valido. \n");
                numeroValido = false;
            }
        }
    } while (!numeroValido);
} while (repetirOperacion);