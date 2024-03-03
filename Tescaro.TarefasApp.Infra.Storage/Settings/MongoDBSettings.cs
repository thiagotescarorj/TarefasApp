using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tescaro.TarefasApp.Infra.Storage.Settings
{
    /// <summary>
    /// Classe para capturar as configurações do MongoDB
    /// </summary>
    public class MongoDBSettings
    {
        public string? Host  { get; set; }
        public string? Database { get; set; }
        public bool IsSSL { get; set; }
    }
}
