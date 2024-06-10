﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public interface IPixRepositoryADO
    {
        bool InserirPix(Pix pix);
        Pix GetPix(string id);
    }
}