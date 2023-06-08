using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTRAVEL.Model
{

    public class autores
    {
        [Key]
        public int id { get; set; } =0;
        public string nombre { get; set; }
        public string apellido { get; set; }
    }


    public class Libros
    {
        [Key]
        public int IBN { get; set; }=0;
        public int esditoriales_id { get; set; }=0;
        public string titulo { get; set; }
        public string sinopsis { get; set; }
        public string n_paginas { get; set; }
    }

    public class autores_has_libros
    {
        [Key]
        public int autores_id { get; set; }=0;
       
        public int libros_ISBN { get; set; }=0;
    }

    public class editoriales
    {
        [Key]
        public int id { get; set; }=0;
        public string nombre { get; set; }
        public string sede { get; set; }

    }

    public class ModelGeneral
    {

        public autores Autor { get; set; }
        public autores_has_libros Autor_has_libros { get; set; }
        public Libros Libros { get; set; }
        public editoriales Editoriales { get; set; }
    }

    public class ModelGeneralList
    {
        public List<autores> Autor { get; set; }
        public List<autores_has_libros> Autor_has_libros { get; set; }
        public List<Libros> Libros { get; set; }
        public List<editoriales> Editoriales { get; set; }
    }
}
