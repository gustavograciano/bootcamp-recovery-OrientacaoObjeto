using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTeste.Pages
{
    public class Index2Model : PageModel
    {
        public string Message { get; private set; }
        public void OnGet()
        {
            Message = "Horario do Servidor e: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
