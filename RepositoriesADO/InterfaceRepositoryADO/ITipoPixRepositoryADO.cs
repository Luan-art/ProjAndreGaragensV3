﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public interface ITipoPixRepositoryADO
    {
        bool InserirTipoPix(TipoPix tiposPix);
        TipoPix GetTipoPix(int id);
    }
}