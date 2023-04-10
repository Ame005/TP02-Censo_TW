class Persona{
    public int DNI{get;set;}
    public string Apellido{get;set;}
    public string Nombre{get;set;}
    public DateTime FechaNacimiento{get;set;}
    public string Email{get;set;}

    public Persona(int dni,string ape, string nom, DateTime fnac, string mail){
        DNI=dni;
        Apellido=ape;
        Nombre=nom;
        FechaNacimiento=fnac;
        Email=mail;
    }
    public bool PuedoVotar(){
        bool puedeVotar=false;
        if(ObtenerEdad()>=16)
        puedeVotar=true;
        return puedeVotar;
    }
    public int ObtenerEdad(){
        DateTime today = DateTime.Today;
        int anios=0;
        anios=today.Year-FechaNacimiento.Year;
        if (today.Month<FechaNacimiento.Month)
        anios-=1;
        else if(today.Month==FechaNacimiento.Month){
            if(today.Day<FechaNacimiento.Day)
            anios-=1;
        }
        return anios;
    }
}