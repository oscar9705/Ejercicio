using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prj_RegistroVeterinaria_002.Pages
{
    public class DetalleRegistroModel : PageModel
    {
        [BindProperty]
        public Mascota regist { get; set; }

        [BindProperty]
        public string url { get; set; }

        private IWebHostEnvironment _enviroment;
        public DetalleRegistroModel(IWebHostEnvironment environment)
        {
            _enviroment = environment;
        }
        private Mascota ObtenerRegistroMascota()
        {
            Mascota reg = new Mascota();
            var lista = System.IO.File.ReadAllLines(Path.Combine(_enviroment.ContentRootPath, "Registros") + "\\RegistroMascota.txt");
            foreach (string str in lista)
            {
                if (str.Split("&&").Length == 8)
                {
                    reg.Id = str.Split("&&")[0];
                    reg.Nombre = str.Split("&&")[1];
                    reg.Raza = str.Split("&&")[2];
                    reg.Edad = int.Parse(str.Split("&&")[3]);
                    reg.EsMacho = bool.Parse(str.Split("&&")[4]);
                    reg.CcPropietario = str.Split("&&")[5];
                    reg.NombrePropietario = str.Split("&&")[6];
                    reg.EmailPropietario = str.Split("&&")[7];

                    if (reg.EsMacho)
                    {
                        url = "https://previews.123rf.com/images/cole123rf/cole123rf1105/cole123rf110500031/9515567-perro-de-negocios-bulldog-ingl%C3%A9s-masculino-con-corbata-y-gafas-sentado-al-lado-de-malet%C3%ADn.jpg";
                    }
                    else
                    {
                        url = "https://comps.canstockphoto.es/perro-hembra-almacen-de-im%C3%A1genes_csp18897754.jpg";
                    }
                }

            }

            return reg;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("RegistroCaninos");
        }
        public void OnGetRegistroCaninos()
        {
            regist = ObtenerRegistroMascota();
        }
        [BindProperty(Name = "nombre",SupportsGet =true)]
        public String nombreMascota { get; set; }
    }
}