using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.Migrations;
using medicamentosApi.src.dto.medicamentodto;

namespace medicamentosApi.src.dto.horariodto
{
    public class HorarioResponseDto
    {
        [Required]
        public DateTime Hora { get; set; }

        public MedicamentoResponseDto medicamento { get; set; }
    }
}