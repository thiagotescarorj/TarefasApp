using Tescaro.TarefasApp.Application.Enumerators;

namespace Tescaro.TarefasApp.Application.DTOs
{
    public class TarefaDTO
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataHora { get; set; }
        public string? Descricao { get; set; }
        public Prioridade? Prioridade { get; set; }

    }

    

}
