using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Regra;
using Persistencia;
using System.Linq.Expressions;

namespace Regra.MantemTroca
{
    public class MantemTroca
    {
        private UnidadeDeTrabalho unidadedetrabalho = new UnidadeDeTrabalho();
       

        public void NovaTroca(Troca troca)
        {
            try
            {
                unidadedetrabalho.TrocaRepositorio.InsereTroca(troca);
                unidadedetrabalho.SalvaAlteracoes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Troca> ObtemTodasTrocas()
        {
            try
            {
                return unidadedetrabalho.TrocaRepositorio.ObtemTodasTrocas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
