using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SimpleX.ModelCore;
using SimpleX.ModelCore.Repository;
using SimpleX.Model;
using System.Data.Entity;
using SimpleX.Core;
using SimpleX.ModelCore.Contexts;

namespace SimpleX.ModelCore.Services
{

    public class paisService : IDisposable
    {
        private Context context;
        private Repository<pais> repositorypais;

        public paisService()
        {
            context = new Context();
            repositorypais = new Repository<pais>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<pais> Listar()
        {
            return repositorypais.ObterTodos().ToList();
        }

        public pais Consultar(Guid id)
        {
            return repositorypais.Obter(id);
        }

        public Result Salvar(pais pais)
        {
            Result retorno = new Result();

            try
            {
                if (pais.ID == null)
                {
                    repositorypais.Adicionar(pais);
                }
                else
                {
                    repositorypais.Alterar(pais);
                }

                context.SaveChanges();

                retorno.Ok("Cadastro realizado com sucesso.");
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }

            return retorno;
        }

        public List<pais> Filtrar(Expression<Func<pais, bool>> filtro, Expression<Func<pais, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositorypais.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o pais");
                return retorno;
            }
            try
            {
                repositorypais.Remover(id);
                context.SaveChanges();
                retorno.Ok("pais removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o pais " + erro.Message);
            }
            return retorno;
        }

        public List<pais> Filtrar(pais pais)
        {
            return repositorypais.ObterPorFiltros(b => (
                (pais.ID == Guid.Empty || b.ID == pais.ID) &&
                (pais.nome == null || b.nome.ToUpper().Contains(pais.nome)) &&
                (pais.codigo == null || b.codigo.ToUpper().Contains(pais.codigo)) &&
                (pais.empresaID == Guid.Empty || b.empresaID == pais.empresaID)
                )).ToList();
        }

    }
}
