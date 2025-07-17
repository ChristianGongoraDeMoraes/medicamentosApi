using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.dto.horariodto;
using medicamentosApi.src.model;

namespace medicamentosApi.src.mapper
{
    public static class MapperHorario
    {
         public static HorarioResponseDto HorarioToResponse(this Horario req)
        {
            return new HorarioResponseDto
            {
                Hora = req.Hora,
                medicamento = req.medicamento.MedicamentoToResponse()
            };
        }
    }
}