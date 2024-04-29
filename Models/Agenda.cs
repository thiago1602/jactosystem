
using Nancy.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agendamentos_jacto.Models
{

    [Table("Agenda")]
    public class Agenda
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Local")]
        [DisplayName("Local")]
        [Required(ErrorMessage = "Obrigatório")]
        public string Local { get; set; }

        [Column("Cep")]
        [DisplayName("Cep")]
        [Required(ErrorMessage = "Obrigatório")]
        public string Cep { get; set; }

        [Column("Endereco")]
        [DisplayName("Endereco")]
        [Required(ErrorMessage = "Obrigatório")]
        public string Endereco { get; set; }

        [Column("Bairro")]
        [DisplayName("Bairro")]
        [Required(ErrorMessage = "Obrigatório")]
        public string Bairro { get; set; }

        [Column("Cidade")]
        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Obrigatório")]
        public string Cidade { get; set; }

        [Column("Estado")]
        [DisplayName("Estado")]
        [Required(ErrorMessage = "Obrigatório")]
        public string Estado { get; set; }

        [Column("Detalhes")]
        [DisplayName("Detalhes")]
        public string Detalhes { get; set; }

        [Column("Feito")]
        [DisplayName("Concluído")]
        public bool Feito { get; set; }

        [Column("CriadoEm")]
        [DisplayName("Dia e Horário da Visita")]
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        [Column("FinalizacaoEstimada")]
        [DisplayName("Término estimado da Visita")]
        public DateTime FinalizacaoEstimada { get; set; } = DateTime.Now;

        [Column("FinalizadoEm")]
        [DisplayName("Término da Visita")]
        public DateTime FinalizadoEm { get; set; } = DateTime.Now;

        [Column("User")]
        [DisplayName("Tecnico")]
        public string User { get; set; }

       
    }
    


}
