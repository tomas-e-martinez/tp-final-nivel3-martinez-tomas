﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Favorito
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Articulo Articulo { get; set; }
    }
}
