using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prj_RegistroVeterinaria_002.Pages
{
    public class Mascota
    {
        [Display(Name = "Identificacion de Mascota"),Required, MaxLength(6)]
        public string Id { get; set; }
        [Display(Name = "Nombre de Mascota"),Required,MaxLength(20)]
        public string Nombre { get; set; }
        [Display(Name = "Raza de Mascota"),Required,MaxLength(20)]
        public string Raza { get; set; }
        [Display(Name = "Edad"),Required,Range(1,15)]
        public int Edad { get; set; }
        [Display(Name = "Canino Macho"),Required]
        public bool EsMacho { get; set; }
        [Display(Name = "Cedula de Propietario"),Required, ]
        public string CcPropietario { get; set; }
        [Display(Name = "Nombre de Propietario"), Required]
        public string NombrePropietario { get; set; }
        [Display(Name = "Email del Propietario"), EmailAddress(ErrorMessage ="EL correo que digito no es valido")]
        public string EmailPropietario { get; set; }
        public override string ToString()
        {
            return Id + "&&" + Nombre + "&&" + Raza + "&&" + Edad + "&&" + EsMacho + "&&" + CcPropietario + "&&" + NombrePropietario + "&&" + EmailPropietario;
        }
        
        public static void EscribirArchivo(string ruta, Mascota mascota)
        {
            ruta += "\\RegistroMascota.txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(ruta, true))
            {
                file.WriteLine(mascota);
            }
        }
    }
}
