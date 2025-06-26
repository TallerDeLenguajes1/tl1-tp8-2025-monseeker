// See https://aka.ms/new-console-template for more information
using distribuidora;

List<Tarea> TareasPendientes = new List<Tarea>();
List<Tarea> TareasRealizadas = new List<Tarea>();

Random random = new Random();
string[] descripciones = {"Enviar correo", "Actualizar informacion", "Completar datos", "Compartir archivo", "Comprar repuestos"};
for (int i = 0; i < random.Next(3, 11); i++)
{
    int duracion = random.Next(10, 101);
    string descripcion = descripciones[random.Next(0,5)];
    Tarea nueva = new Tarea(i, descripcion, duracion);
    TareasPendientes.Add(nueva);
}

bool otraEleccion = false;
do
{
    bool datoValido = false;
    Console.WriteLine("-------------------------MENU--------------------------");
    Console.WriteLine("1. Presione 1 si desea marcar una tarea como realizada.");
    Console.WriteLine("2. Presione 2 si desea buscar un tarea por descripcion.");
    Console.WriteLine("3. Presione 3 si desea ver un listado de todas las tareas.\n");
    do
    {
        Console.Write("ELECCION: ");
        string cadena1 = Console.ReadLine();
        if (int.TryParse(cadena1, out int EleccionMenu))
        {
        switch (EleccionMenu)
        {
            case 1:
                datoValido = true;
                PasarTareaARealizada(TareasPendientes);
            break;
            case 2:
                datoValido = true;
                BuscarPorDescripcion(TareasPendientes);
            break;
            case 3:
                datoValido = true;
                MostrarTodasTareas(TareasPendientes, TareasRealizadas);
            break;
            default:
                Console.WriteLine("Ingrese un numero valido.\n");
            break;
        }   
        } else {
            Console.WriteLine("ingrese un numero.\n");
        }
        
    } while (!datoValido);
    Console.WriteLine("Desea seleccionar otra opcion?\n1.Si\t0.No");
    Console.Write("Eleccion: ");
    string cadena = Console.ReadLine();
    Console.WriteLine("\n");
    if (int.TryParse(cadena, out int repetir))
    {
        if (repetir == 1)
        {
            otraEleccion = true;
        } else if(repetir == 0){
            otraEleccion = false;
        } else {
            Console.WriteLine("Ingrese un numero vallido.\n");
            break;
        }
    } else {
        Console.WriteLine("Ingrese un numero.\n");
    }
} while (otraEleccion);








void PasarTareaARealizada(List<Tarea> TareasPendientes){
    Console.WriteLine("\n----------------TAREAS PENDIENTES-----------------");
    foreach (Tarea pendiente in TareasPendientes)
    {
        pendiente.MostrarTareas();
    }
    Console.WriteLine("\n");
    Console.WriteLine("Ingrese el ID de la tarea realizada.");
    Console.Write("ID: ");
    string cadena = Console.ReadLine();
    Console.WriteLine("\n");
    if (int.TryParse(cadena, out int id))
    {
        Tarea tareaSeleccionada = null;
        foreach (Tarea pendiente in TareasPendientes)
        {
            if (pendiente.TareaID == id)
            {
                pendiente.MostrarTareas();
                Console.WriteLine("\n");
                tareaSeleccionada = pendiente;
                break;
            }
        }
        if (tareaSeleccionada != null)
        {
            TareasRealizadas.Add(tareaSeleccionada);
            TareasPendientes.Remove(tareaSeleccionada);
        } else {
            Console.WriteLine($"No se encontro ninguna tarea de ID {id}.\n");
        }
    } else {
        Console.WriteLine("Ingrese un numero.\n");
    }
}
       


void BuscarPorDescripcion(List<Tarea> TareasPendientes){
    Console.Write("\nIngrese descripcion a buscar: ");
    string DescripcionABuscar = Console.ReadLine();
    bool coincidencias = false;
    foreach (Tarea pendiente in TareasPendientes)
    {
        if (pendiente.Descripcion.ToLower().Contains(DescripcionABuscar.ToLower()))
        {
            pendiente.MostrarTareas();
            coincidencias = true;
        }
    }
    Console.WriteLine("\n");
    if (!coincidencias)
    {
        Console.WriteLine("No se encontro ninguna tarea que coincida con la descripcion.\n");
    }
}

void MostrarTodasTareas(List<Tarea> TareasPendientes, List<Tarea> TareasRealizadas){
    bool contador = false;
    Console.WriteLine("\n\n----------------TAREAS PENDIENTES-----------------");
    Console.WriteLine($"{"ID",-5} | {"Descripción",-30} | {"Duración",-10}");
    Console.WriteLine(new string('-', 50));

    foreach (Tarea pendiente in TareasPendientes)
    {
        pendiente.MostrarTareas();
        contador = true;
    }
    if(!contador) Console.WriteLine("No existen tareas pendientes.\n");

    contador = false;
    Console.WriteLine("\n\n----------------TAREAS REALIZADAS-----------------");
    Console.WriteLine($"{"ID",-5} | {"Descripción",-30} | {"Duración",-10}");
    Console.WriteLine(new string('-', 50));
    foreach (Tarea realizada in TareasRealizadas)
    {
        realizada.MostrarTareas();
        contador = true;
    }

    if(!contador) Console.WriteLine("No existen tareas realizadas.\n");
}