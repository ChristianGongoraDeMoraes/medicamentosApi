using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.DataBase;
using medicamentosApi.src.dto.medicamentodto;
using medicamentosApi.src.interfaces;
using medicamentosApi.src.mapper;
using medicamentosApi.src.model;
using Microsoft.EntityFrameworkCore;

namespace medicamentosApi.src.repository
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly ApplicationDbContext _context;
        public MedicamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool?> deleteMedicamento(AppUser app, string medicamento)
        {
            var res = await _context.Medicamentos.FirstOrDefaultAsync(x => x.AppUser == app && x.Nome == medicamento);
            if (res == null) return null;

            _context.Remove(res);
           await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Medicamento>> getAllMedicamentos()
        {
            return await _context.Medicamentos.Include(x => x.AppUser).ToListAsync();
        }

        public async Task<List<Medicamento>> getAllMedicamentosByUser(AppUser appUser)
        {
            var medicamentos = await _context.Medicamentos
                .Include(x => x.AppUser)
                .Where(x => x.AppUser == appUser)
                .ToListAsync();

            return medicamentos;
        }

        public async Task<Medicamento?> saveMedicamento(MedicamentoRequestDto req, string idAppUser)
        {
            if (await _context.Medicamentos.AnyAsync(x => x.Nome == req.Nome && x.AppUser.Id == idAppUser)) return null;

            Medicamento medicamento = req.RequestToMedicamento();
            AppUser medicamentoUser = await _context.Users.FirstOrDefaultAsync(x => idAppUser == x.Id);
            if (medicamentoUser == null) return null;

            medicamento.IdAppUser = idAppUser;
            medicamento.AppUser = medicamentoUser;

            await _context.AddAsync(medicamento);
            await _context.SaveChangesAsync();

            return medicamento;
        }
        
        
    }
}