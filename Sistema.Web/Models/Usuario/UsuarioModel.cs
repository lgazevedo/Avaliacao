using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sistema.Web.Extensions;

namespace Sistema.Web.Models.Usuario
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [Range(1, 130)]
        public byte Idade { get; set; }
        [StringLength(50)]
        public string Endereco { get; set; }
    }
}