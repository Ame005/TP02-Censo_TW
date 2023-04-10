internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<int,Persona> dicPersonas = new Dictionary<int, Persona>();
        int eleccion=0,ingresado=0;
        do{
            eleccion=menuEjercicio();
            switch(eleccion){
                case 1:
                int dni=IngresarInt("Ingrese su DNI");
                string ape=IngresarString("Ingrese su apellido");
                string nom= IngresarString("Ingrese su nombre");
                string mail=IngresarString("Ingrese su mail");
                DateTime fnac=IngresarDatetime();
                Persona numPersona=new Persona(dni,ape,nom,fnac,mail);
                dicPersonas.Add(dni,numPersona);
                break;
                case 2:
                verLista(dicPersonas);
                break;
                case 3:
                ingresado=IngresarInt("Ingrese el DNI de la persona deseada");
                buscarPersona(dicPersonas,ingresado);
                break;
                case 4:
                ingresado=IngresarInt("Ingrese el DNI de la persona a la cual se le desea cambiar el email");
                cambiarMail(dicPersonas,ingresado);
                break;
            }
            Console.ReadKey();
        }while(eleccion!=5);
    }
    static void cambiarMail(Dictionary<int,Persona> dicPersonas, int ingresado){
        string nuevoMail="";
        if (dicPersonas.ContainsKey(ingresado)){
            Console.WriteLine("Ingrese el nuevo email");
            nuevoMail=Console.ReadLine();
            dicPersonas[ingresado].Email=nuevoMail;
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
            Console.WriteLine("4- Modificar Mail de una Persona");
            Console.WriteLine("5- Salir");
            devolver=int.Parse(Console.ReadLine());
        }while(devolver<1||devolver>5);
        return devolver;
    }
}