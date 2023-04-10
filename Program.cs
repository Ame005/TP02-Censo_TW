internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<int,Persona> dicPersonas = new Dictionary<int, Persona>();
        int eleccion=0,ingresado=0,modificado=0;
        do{
            eleccion=menuEjercicio();
            switch(eleccion){
                case 1:
                int dni=IngresarInt("Ingrese su DNI");
                if(!dicPersonas.ContainsKey(dni)){
                string ape=IngresarString("Ingrese su apellido");
                string nom= IngresarString("Ingrese su nombre");
                string mail=IngresarEmail("Ingrese su mail");
                DateTime fnac=IngresarDatetime();
                Persona numPersona=new Persona(dni,ape,nom,fnac,mail);
                dicPersonas.Add(dni,numPersona);
                }
                else
                Console.WriteLine("La persona ya existe, si desea modificar los datos, seleccione la opcion de Modificar Datos");
                break;
                case 2:
                verLista(dicPersonas);
                break;
                case 3:
                ingresado=IngresarInt("Ingrese el DNI de la persona deseada");
                buscarPersona(dicPersonas,ingresado);
                break;
                case 4:
                ingresado=IngresarInt("Ingrese el DNI de la persona a la cual se le desea cambiar algún campo");
                do{
                    modificado=menuModificar();
                    switch(modificado){
                    case 1:
                    cambiarApe(dicPersonas,ingresado);
                    break;
                    case 2:
                    cambiarNom(dicPersonas,ingresado);
                    break;
                    case 3:
                    cambiarFnac(dicPersonas,ingresado);
                    break;
                    case 4:
                    cambiarMail(dicPersonas,ingresado);
                    break;
                    case 5:
                    Console.WriteLine("Volviendo al menú principal");
                    break;
                }
                Console.ReadKey();
                }while(modificado!=5);
                break;
            }
            Console.ReadKey();
        }while(eleccion!=5);
    }
    static int menuModificar(){
        int devolver;
        do{
            Console.WriteLine("1- Modificar Apellido");
            Console.WriteLine("2- Modificar Nombre");
            Console.WriteLine("3- Modificar Fecha de Nacimiento");
            Console.WriteLine("4- Modificar Email");
            Console.WriteLine("5- Salir");
            devolver=int.Parse(Console.ReadLine());
        }while(devolver<1||devolver>5);
        return devolver;
    }
    static void cambiarMail(Dictionary<int,Persona> dicPersonas, int ingresado){
        string nuevoMail="";
        if (dicPersonas.ContainsKey(ingresado)){
            nuevoMail=IngresarString("Ingrese el nuevo mail");
            dicPersonas[ingresado].Email=nuevoMail;
        }
        else
        Console.WriteLine("No se encuentra el DNI");
    }
    static void cambiarApe(Dictionary<int,Persona> dicPersonas, int ingresado){
        string nuevoApe;
        if (dicPersonas.ContainsKey(ingresado)){
            nuevoApe=IngresarString("Ingrese el nuebo apellido");
            dicPersonas[ingresado].Apellido=nuevoApe;
        }
        else
        Console.WriteLine("No se encuentra el DNI");
    }
    static void cambiarNom(Dictionary<int,Persona> dicPersonas, int ingresado){
        string nuevoNom;
        if (dicPersonas.ContainsKey(ingresado)){
            nuevoNom=IngresarString("Ingrese el nuevo nombre");
            dicPersonas[ingresado].Nombre=nuevoNom;
        }
        else
        Console.WriteLine("No se encuentra el DNI");
    }
    static void cambiarFnac(Dictionary<int,Persona> dicPersonas, int ingresado){
        DateTime nuevaFecha;
        if (dicPersonas.ContainsKey(ingresado)){
            nuevaFecha=IngresarDatetime();
            dicPersonas[ingresado].FechaNacimiento=nuevaFecha;
        }
        else
        Console.WriteLine("No se encuentra el DNI");
    }
    static void buscarPersona(Dictionary<int,Persona> dicPersonas, int ingresado){
        
        if (dicPersonas.ContainsKey(ingresado)){
            Console.WriteLine(dicPersonas[ingresado].DNI);
            Console.WriteLine(dicPersonas[ingresado].Apellido);
            Console.WriteLine(dicPersonas[ingresado].Nombre);
            Console.WriteLine(dicPersonas[ingresado].FechaNacimiento.ToShortDateString());
            Console.WriteLine(dicPersonas[ingresado].Email);
            Console.WriteLine(dicPersonas[ingresado].ObtenerEdad());
            Console.WriteLine(dicPersonas[ingresado].PuedoVotar());
        }
        else{
            Console.WriteLine("No se encuentra el DNI");
        }
    }
    static void verLista(Dictionary<int,Persona> dicPersonas){
        int cantPersonas=0,personasVotar=0,totalEdades=0;
        double promedioEdadPersonas=0;
        cantPersonas=dicPersonas.Keys.Count;
        if(cantPersonas==0)
        Console.WriteLine("Aún no se han ingresado personas en la lista");
        else{
            foreach (int dni in dicPersonas.Keys){
                if(dicPersonas[dni].PuedoVotar())
                personasVotar++;
                totalEdades+=dicPersonas[dni].ObtenerEdad();
            }
            promedioEdadPersonas=totalEdades/cantPersonas;
            Console.WriteLine("Estadísticas del Censo:");
            Console.WriteLine("Cantidad de Personas: "+cantPersonas);
            Console.WriteLine("Cantidad de Personas habilitadas para votar: "+personasVotar);
            Console.WriteLine("Promedio de Edad: "+promedioEdadPersonas);
        }
    }
    static DateTime IngresarDatetime(){
        DateTime devolver=new DateTime();
        bool valido=false;
        int dia=1, mes=1, anio=1;
        string fecha;
        do{
            anio=IngresarInt("Ingrese su año de nacimiento");
            mes=IngresarInt("Ingrese su mes");
            dia=IngresarInt("Ingese su dia");
            fecha=dia+"/"+mes+"/"+anio; 
            valido=DateTime.TryParse(fecha, out devolver);
        }while(!valido);
        return devolver;
    }
    static string IngresarEmail(string mensaje){
        string devolver;
        bool valido=false;
        do{
            Console.WriteLine(mensaje);
            devolver=Console.ReadLine();
            if(devolver.IndexOf('@')<devolver.LastIndexOf('.'))
            valido=true; 
        }while(!valido);
        return devolver;
    }
    static string IngresarString(string mensaje){
        string devolver;
        Console.WriteLine(mensaje);
        devolver=Console.ReadLine();
        return devolver;
    }
    static int IngresarInt(string mensaje){
        int devolver;
        Console.WriteLine(mensaje);
        devolver=int.Parse(Console.ReadLine());
        return devolver;
    }
    static int menuEjercicio(){
        int devolver;
        do{
            Console.WriteLine("1- Cargar Nueva Persona");
            Console.WriteLine("2- Obtener Estadísticas del Censo");
            Console.WriteLine("3- Buscar Persona");
            Console.WriteLine("4- Modificar Datos de una Persona");
            Console.WriteLine("5- Salir");
            devolver=int.Parse(Console.ReadLine());
        }while(devolver<1||devolver>5);
        return devolver;
    }
}