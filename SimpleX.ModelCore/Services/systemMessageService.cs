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
using SimpleX.ModelCore.Message;

namespace SimpleX.ModelCore.Services
{

    public class systemMessageService : IDisposable
    {
        private Context context;
        private Repository<SimpleX.Model.systemMessageCore> repositorymessage;

        public systemMessageService()
        {
            context = new Context();
            repositorymessage = new Repository<SimpleX.Model.systemMessageCore>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<systemMessageCore> Listar()
        {
            return repositorymessage.ObterTodos().ToList();
        }

        public systemMessageCore Consultar(Guid id)
        {
            return repositorymessage.Obter(id);
        }

        public Result Salvar(systemMessageCore message)
        {
            Result retorno = new Result();

            try
            {
                if (message.ID == Guid.Empty)
                {
                    message.ID = Guid.NewGuid();
                    repositorymessage.Adicionar(message);
                }
                else
                {
                    repositorymessage.Alterar(message);
                }

                context.SaveChanges();

                systemMessage systemMessageCore = new systemMessage();

                string description = systemMessageCore.BuscarSystemMessageByExternalNumber("0001");

                if (description != "")
                {
                    retorno.Ok(description);
                }
                else
                {
                    retorno.Ok("Registro salvo com sucesso.");
                }
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }

            return retorno;
        }

        public List<systemMessageCore> Filtrar(Expression<Func<systemMessageCore, bool>> filtro, Expression<Func<systemMessageCore, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositorymessage.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir");
                return retorno;
            }
            try
            {
                repositorymessage.Remover(id);
                context.SaveChanges();
                retorno.Ok("Registro removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir " + erro.Message);
            }
            return retorno;
        }

        public List<systemMessageCore> Filtrar(systemMessageCore message)
        {
            return repositorymessage.ObterPorFiltros(b => (
                (message.ID == Guid.Empty || b.ID == message.ID) &&
                (message.internalNumber == null || b.internalNumber == message.internalNumber) &&
                (message.externalNumber == null || b.externalNumber == message.externalNumber) &&
                (message.type == null || b.type == message.type) &&
                (message.description == null || b.description.ToUpper().Contains(message.description))
                )).ToList();
        }

    }
}
