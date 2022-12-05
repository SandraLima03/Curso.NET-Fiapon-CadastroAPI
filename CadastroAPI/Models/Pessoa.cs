using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CadastroAPI.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public String NomePessoa { get; set; }
        public String EnderecoPessoa { get; set; }
    }
}
