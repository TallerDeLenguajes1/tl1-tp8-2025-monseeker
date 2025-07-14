// See https://aka.ms/new-console-template for more information
using CalculadoraHistorial;

Calculadora calculadora = new Calculadora();

Console.WriteLine("--------CALCULADORA----------");
Console.WriteLine("1. Sumar");
Console.WriteLine("2. Restar");
Console.WriteLine("3. Multiplicar");
Console.WriteLine("4. Dividir");
Console.WriteLine("5. Limpiar\n");

Console.WriteLine("Ingrese el numero de la operación a realizar: ");
string cadena = Console.ReadLine();
if ((int.TryParse(cadena, out int operacionElegidaNum)) && (Enum.IsDefined(typeof(TipoOperacion), operacionElegidaNum-1)))
{
    if ((operacionElegidaNum < 5) && operacionElegidaNum > 0)
    {
        TipoOperacion operacionSeleccionada = (TipoOperacion)(operacionElegidaNum-1);
        Console.Write("\nIngrese el numero a calcular: ");
        cadena = Console.ReadLine();
        Console.Write("\n");
        if (double.TryParse(cadena, out double numeroACalcular))
        {
            calculadora.RealizarOperacion(numeroACalcular, operacionSeleccionada);
        }
    } else if (operacionElegidaNum == 5)
    {
        calculadora.Limpiar();
    }
}