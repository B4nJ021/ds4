using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.Repositories
{
    public interface ICalculoRepository
    {
        List<CalculoModel> GetTodosLosCalculos();
        List<CalculoModel> GetSumas();
        List<CalculoModel> GetRestas();
        List<CalculoModel> GetMultiplicaciones();
        List<CalculoModel> GetDivisiones();
    }
}