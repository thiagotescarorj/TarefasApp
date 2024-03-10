using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tescaro.TarefasApp.Infra.Messages.Settings
{
    public class RabbitMQSettings
    {
        public string? URL { get; set; }
        public string? Queue { get; set; }
    }
}
