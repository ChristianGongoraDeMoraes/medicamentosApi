using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.dto.medicamentodto;
using medicamentosApi.src.model;

namespace medicamentosApi.src.interfaces
{
    public interface IMedicamentoRepository
    {
        Task<List<Medicamento>> getAllMedicamentos();
        Task<Medicamento?> saveMedicamento(MedicamentoRequestDto req, string idAppUser);
    }
}