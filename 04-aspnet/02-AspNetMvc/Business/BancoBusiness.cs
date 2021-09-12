using _02_AspNetMvc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_AspNetMvc.Business
{
    public class BancoBusiness: IBancoBusiness
    {

        private List<Banco> _bancos;

        public BancoBusiness()
        {
            _bancos = new List<Banco>();
        }

        public IEnumerable<Banco> GetAll()
        {
            if (_bancos.Any())
            {
                return _bancos;
            }

            for (int i = 1; i <= 10; i++)
            {
                _bancos.Add( new Banco()
                {
                    BancoId = i,
                    Nombre = $"Gran Banco Nro. {i}"
                });
            }

            return _bancos;
        }

        public Banco Get(int bancoId) {
            return new Banco()
            {
                BancoId = bancoId,
                Nombre = $"Gran Banco Nro. {bancoId}"
            };
        }


        public bool Delete(int bancoId)
        {
            //TODO: delete
            if (_bancos.Any())
            {
                var bancoParaRemover = from b in _bancos
                                       where b.BancoId == bancoId
                                       select b;

                _bancos.Remove(bancoParaRemover.FirstOrDefault());
            }

            return true;
        }
    }
}
