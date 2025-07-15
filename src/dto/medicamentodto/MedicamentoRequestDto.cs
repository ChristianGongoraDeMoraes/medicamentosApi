using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.model;

namespace medicamentosApi.src.dto.medicamentodto
{
    public class MedicamentoRequestDto
    {
        [Required]
        public string Nome { get; set; } = "";
        public string Dosagem { get; set; } = "";
        public string Instrucoes { get; set; } = "";
    }
}