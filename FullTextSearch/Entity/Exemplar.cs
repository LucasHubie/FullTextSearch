using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullTextSearch.Entity
{
    public class Exemplar
    {
        public int Id { get; set; }
        public int RegistroSistema { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Assunto { get; set; }
        public int Quantidade { get; set; }
        public string Ano { get; set; }
        public string Edicao { get; set; }
        public string Isbn { get; set; }
        public string Issn { get; set; }

        //[Display(Name = "Autor")]
        public string AutorNome { get; set; }
        public string EditoraNome { get; set; }
        public string Material { get; set; }

        //public virtual Autor Autor { get; set; }
        //public virtual Editora Editora { get; set; }
        //public virtual TipoMaterial TipoMaterial { get; set; }
    }
}
