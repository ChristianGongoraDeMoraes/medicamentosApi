using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace medicamentosApi.src.model
{
    public class Horario
    {
        public int Id { get; set; }
        public DateTime Hora { get; set; } = DateTime.Now;
        [JsonIgnore]
        public AppUser appUser { get; set; }
        public Medicamento medicamento{ get; set; }
    }
}