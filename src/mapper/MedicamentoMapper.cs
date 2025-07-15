using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.dto.medicamentodto;
using medicamentosApi.src.model;

namespace medicamentosApi.src.mapper
{
    public static class MedicamentoMapper
    {
        public static Medicamento RequestToMedicamento(this MedicamentoRequestDto req)
        {
            return new Medicamento
            {
                Nome = req.Nome,
                Dosagem = req.Dosagem,
                Instrucoes = req.Instrucoes
            };
        }

        public static MedicamentoResponseDto MedicamentoToResponse(this Medicamento req)
        {
            return new MedicamentoResponseDto
            {
                Nome = req.Nome,
                Dosagem = req.Dosagem,
                Instrucoes = req.Instrucoes
            };
        }
    }
}