using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models.Enums
{
    public enum SaleStatus : int
    {
        Pendente = 0,
        Faturado = 1,
        Cancelado = 2,
    }
}
