using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.model;

namespace medicamentosApi.src.interfaces
{
    public interface IHorariosRepository
    {
        Task<Horario> saveHorario(AppUser appUser, string nomeMedicamento);
        Task<List<Horario>> getHorariosByUserMedicamento(AppUser appUser, string nomeMedicamento);
    }
}