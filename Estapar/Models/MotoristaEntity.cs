using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace TesteEstapar.Models
{
    public class MotoristaEntity
    {     
        
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string  Dt_Nascminento { get; set; }
    }
}