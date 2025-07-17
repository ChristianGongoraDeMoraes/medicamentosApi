using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace medicamentosApi.src.model
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Dosagem { get; set; } = "";
        public string Instrucoes { get; set; } = "";

        [JsonIgnore]
        public AppUser AppUser { get; set; } = new AppUser();
        public string IdAppUser { get; set; } 
    }
}