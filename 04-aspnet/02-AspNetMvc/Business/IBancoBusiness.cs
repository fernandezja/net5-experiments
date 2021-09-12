using _02_AspNetMvc.Entities;
using System.Collections.Generic;

namespace _02_AspNetMvc.Business
{
    public interface IBancoBusiness
    {
        IEnumerable<Banco> GetAll();
        Banco Get(int bancoId);
        bool Delete(int bancoId);
    }
}