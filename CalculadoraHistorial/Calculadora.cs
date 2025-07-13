namespace EspacioCalculadora
{
    public enum TipoOperacion{ 
        Suma, 
        Resta, 
        Multiplicacion, 
        Division, 
        Limpiar  // Representa la acción de borrar el resultado actual o el historial 
    } 

    public class Operacion
    {
        private double resultadoAnterior; // Almacena el resultado previo al cálculo actual 
        private double nuevoValor; //El valor con el que se opera sobre el resultadoAnterior 
        private TipoOperacion operacion;// El tipo de operación realizada 

        
        public void Operacion(double resultadoanterior, double nuevovalor, TipoOperacion tipo){
            resultadoAnterior = resultadoanterior;
            nuevoValor = nuevovalor;
            operacion = tipo;
        }
        
        /* Lógica para calcular o devolver el resultado */
        public double Resultado()
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
                case TipoOperacion.Limpiar: resultado = 0;
            }
            return resultado;
        }

        // Propiedad pública para acceder al nuevo valor utilizado en la operación 
        public double NuevoValor
        {
            get {return nuevoValor;}
        }
    }
}