﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace CatalogoAPI.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [JsonIgnore]
        public ICollection<Produto> Produtos { get; set; } = new Collection<Produto>();
    }
}
