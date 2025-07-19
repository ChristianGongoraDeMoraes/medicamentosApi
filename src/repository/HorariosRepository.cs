using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.DataBase;
using medicamentosApi.src.interfaces;
using medicamentosApi.src.model;
using Microsoft.EntityFrameworkCore;

namespace medicamentosApi.src.repository
{
    public class HorariosRepository : IHorariosRepository
    {
        public readonly ApplicationDbContext _context;
        public HorariosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool?> deleteHorario(AppUser appUser, string medNome, string dateTime)
        {
            var medicamento = await _context.Medicamentos.FirstOrDefaultAsync(x => x.Nome == medNome && x.AppUser == appUser);
            if (medicamento == null) return null;

            var horario = await _context.Horarios.FirstOrDefaultAsync(x => x.appUser == appUser && x.medicamento == medicamento && x.Hora == DateTime.Parse(dateTime));
            if (horario == null) return null;

            _context.Remove(horario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Horario>> getHorariosByUserMedicamento(AppUser appUser, string nomeMedicamento)
        {
            var medicamento = await _context.Medicamentos.FirstOrDefaultAsync(x => x.Nome == nomeMedicamento && x.AppUser == appUser);
            if (medicamento == null) return null;

            return await _context.Horarios.Where(x => x.appUser == appUser && medicamento == x.medicamento).ToListAsync();
        }

        public async Task<List<Horario>> getHorariosByUserName(AppUser appUser)
        {
            return await _context.Horarios.Include(x=> x.medicamento).Where(x => x.appUser == appUser).ToListAsync();
        }

        public async Task<Horario> saveHorario(AppUser appUser, string nomeMedicamento)
        {
            var medicamento = await _context.Medicamentos.FirstOrDefaultAsync(x => x.Nome == nomeMedicamento && x.AppUser == appUser);
            if (medicamento == null) return null;

            Horario horario = new Horario();
            horario.appUser = appUser;
            horario.medicamento = medicamento;

            await _context.Horarios.AddAsync(horario);
            await _context.SaveChangesAsync();
            return horario;
        }

        
    }
}