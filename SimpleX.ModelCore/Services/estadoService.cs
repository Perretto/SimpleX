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
using SimpleX.ModelCore.Contexts;

namespace SimpleX.ModelCore.Services
{

    public class estadoService : IDisposable
    {
        private Context context;
        private Repository<estado> repositoryestado;

        public estadoService()
        {
            context = new Context();
            repositoryestado = new Repository<estado>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<estado> Listar()
        {
            return repositoryestado.ObterTodos().ToList();
        }

        public estado Consultar(Guid id)
        {
            return repositoryestado.Obter(id);
        }

        public Result Salvar(estado estado)
        {
            Result retorno = new Result();

            try
            {
                if (estado.ID == Guid.Empty)
                {
                    estado.ID = Guid.NewGuid();
                    repositoryestado.Adicionar(estado);
                }
                else
                {
                    repositoryestado.Alterar(estado);
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

        public List<estado> Filtrar(Expression<Func<estado, bool>> filtro, Expression<Func<estado, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryestado.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o estado");
                return retorno;
            }
            try
            {
                repositoryestado.Remover(id);
                context.SaveChanges();
                retorno.Ok("Estado removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o estado " + erro.Message);
            }
            return retorno;
        }

        public List<estado> Filtrar(estado estado)
        {
            return repositoryestado.ObterPorFiltros(b => (
                (estado.ID == Guid.Empty || b.ID == estado.ID) &&
                (estado.nome == null || b.nome.ToUpper().Contains(estado.nome)) &&
                (estado.codigo == null || b.codigo.ToUpper().Contains(estado.codigo)) &&
                (estado.empresaID == Guid.Empty || b.empresaID == estado.empresaID)
                )).ToList();
        }

    }
}
