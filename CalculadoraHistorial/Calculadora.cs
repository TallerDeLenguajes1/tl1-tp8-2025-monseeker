namespace CalculadoraHistorial;

public class Operacion{ 
    private double resultadoAnterior; // Almacena el resultado previo al cálculo actual 
    private double nuevoValor; //El valor con el que se opera sobre el resultadoAnterior 
    private TipoOperacion operacion;// El tipo de operación realizada 
    
    public double Resultado
    {
        /* Lógica para calcular o devolver el resultado */
        get
        {
            double resultado = 0;
            switch (operacion)
            {
                case TipoOperacion.Suma: resultado = resultadoAnterior + nuevoValor; break;
                case TipoOperacion.Resta: resultado = resultadoAnterior - nuevoValor; break;
                case TipoOperacion.Multiplicacion: resultado = resultadoAnterior * nuevoValor; break;
                case TipoOperacion.Division:
                if(nuevoValor != 0){
                    resultado = resultadoAnterior / nuevoValor;
                } else {
                    resultado = resultadoAnterior;
                }
                break;
                case TipoOperacion.Limpiar: resultado = 0; break;
            }
            return resultado;
        }
    } 

    public double ResultadoAnterior => resultadoAnterior;
    // Propiedad pública para acceder al nuevo valor utilizado en la operación 
    public double NuevoValor{ 
        get {return nuevoValor;} 
    } 

    // Constructor u otros métodos necesarios para inicializar y gestionar la operación 
    public Operacion(double anterior, double nuevo, TipoOperacion tipo){
        resultadoAnterior = anterior;
        nuevoValor = nuevo;
        operacion = tipo;
    } 
}

public enum TipoOperacion{ 
Suma, 
Resta, 
Multiplicacion, 
Division, 
Limpiar  // Representa la acción de borrar el resultado actual o el historial 
} 

public class Calculadora{
    private List<Operacion> historial = new List<Operacion>();
    private double valorActual;

    public void RealizarOperacion(double nuevo, TipoOperacion tipo){
        Operacion nueva = new Operacion(valorActual, nuevo, tipo);
        valorActual = nueva.Resultado;
        historial.Add(nueva);
    }

    public void MostrarHistorial(){
        Console.WriteLine("\nHistorial:");
        foreach (Operacion op in historial)
        {
            Console.WriteLine(op.ResultadoAnterior);
        }
    }

    public void Limpiar(){
        valorActual = 0;
        historial.Clear();
    }

    public double ValorActual => valorActual;
}