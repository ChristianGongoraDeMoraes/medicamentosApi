using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.dto.medicamentodto;
using medicamentosApi.src.Extentions;
using medicamentosApi.src.interfaces;
using medicamentosApi.src.mapper;
using medicamentosApi.src.model;
using medicamentosApi.src.repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace medicamentosApi.src.controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly UserManager<AppUser> _userManager;
        public MedicamentoController(IMedicamentoRepository medicamentoRepository, UserManager<AppUser> userManager)
        {
            _medicamentoRepository = medicamentoRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicamentoResponseDto>>> getAllMedicamentos()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null) return BadRequest("User Invalido");

            List<Medicamento> medicamentos = await _medicamentoRepository.getAllMedicamentosByUser(appUser);

            var medicamentosResponse = medicamentos.Select(x => x.MedicamentoToResponse());

            return Ok(medicamentosResponse);
        }

        [HttpPost]
        public async Task<ActionResult<MedicamentoResponseDto>> saveMedicamento([FromBody] MedicamentoRequestDto req)
        {
            if (!ModelState.IsValid) return BadRequest();

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null) return BadRequest("User Invalido");

            var medicamento = await _medicamentoRepository.saveMedicamento(req, appUser.Id);
            if (medicamento == null) return BadRequest("Medicamento Invalido");

            return Ok(medicamento.MedicamentoToResponse());
        }
        
        
    }
}