using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteEstapar.Models
{
    public class ResponsavelEntity
    {
        [Key]
        public int Id { get; set; }

        public string Responsavel { get; set; }

        public string Carro { get; set; }

        public int IdMotorista { get; set; }

    }
}