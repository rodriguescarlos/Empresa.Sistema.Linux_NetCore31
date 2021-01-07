using System.ComponentModel.DataAnnotations;

namespace Empresa.Sistema.Cadastro.Application.DTOs
{
    public class ParametroSistemaCreateDTO
    {
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descricao é campo obrigatório")]
        [StringLength(255, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Conteudo é campo obrigatório")]
        [StringLength(8000, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Conteudo { get; set; }
    }
}
