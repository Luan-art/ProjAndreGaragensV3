﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface IFuncionarioRepository
    {
        bool InjetarFuncionario(Funcionario funcionario);
        Funcionario GetFuncionario(string documento);
    }
}
