using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models
{
    public class BeneficiariosModel
    {
        public long id { get; set; }

        public string nome { get; set; }

        public string cpf { get; set; }

        public int tipo { get; set; }
    }    
}
