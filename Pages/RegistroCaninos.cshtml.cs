using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace Prj_RegistroVeterinaria_002.Pages
{
    public class RegistroCaninosModel : PageModel
    {
        [BindProperty]
        public Mascota registro { get; set; }
        [BindProperty]
        public string result { get; set; }
        private IWebHostEnvironment _environment;
        public RegistroCaninosModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string a = "";
                
                string path = Path.Combine(_environment.ContentRootPath, "Registros");
               
                Mascota.EscribirArchivo(path, registro);
                result = "idMascota: " + registro.Id + " NombreMascota: " + registro.Nombre + "raza: " + registro.Raza + " Genero: " + registro.EsMacho + " Cedula Propietario: " +
                        registro.CcPropietario + " Nombre Propietario. " + registro.NombrePropietario + " Correo Propietario: " + registro.EmailPropietario;
                return RedirectToPage("DetalleRegistro", "RegistroCaninos", new { nombre = registro.Nombre});

            }
            return Page();
        }
    }
}