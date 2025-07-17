using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.dto.horariodto;
using medicamentosApi.src.Extentions;
using medicamentosApi.src.interfaces;
using medicamentosApi.src.mapper;
using medicamentosApi.src.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace medicamentosApi.src.controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HorarioController : ControllerBase
    {
        private readonly IHorariosRepository _horarioRepository;
        private readonly UserManager<AppUser> _userManager;
        public HorarioController(IHorariosRepository horariosRepository, UserManager<AppUser> userManager)
        {
            _horarioRepository = horariosRepository;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> saveHorario([FromBody] HorarioRequestDto horarioRequestDto)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null) return BadRequest("User Invalido");

            var res = await _horarioRepository.saveHorario(appUser, horarioRequestDto.nomeMedicamento);
            if (res == null) return BadRequest();

            return Ok(res.HorarioToResponse());
        }

        [HttpGet]
        public async Task<IActionResult> getHorarios([FromQuery] HorarioRequestDto horarioRequestDto)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null) return BadRequest("User Invalido");

            var res = await _horarioRepository.getHorariosByUserMedicamento(appUser, horarioRequestDto.nomeMedicamento);
            if (res == null) return BadRequest();

            return Ok(res.Select(x => x.HorarioToResponse()));

        }
    }
}