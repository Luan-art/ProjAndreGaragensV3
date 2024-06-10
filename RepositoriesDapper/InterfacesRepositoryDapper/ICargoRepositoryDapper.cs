﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesDapper
{
    public interface ICargoRepositoryDapper
    {
        public bool InserirCargo(Cargo cargo);

        Cargo GetCargo(int? v);
    }
}
