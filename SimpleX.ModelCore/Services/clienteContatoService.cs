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

    public class clienteContatoService : IDisposable
    {
        private Context context;
        private Repository<clienteContato> repositoryclienteContato;

        public clienteContatoService()
        {
            context = new Context();
            repositoryclienteContato = new Repository<clienteContato>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<clienteContato> Listar()
        {
            return repositoryclienteContato.ObterTodos().ToList();
        }

        public clienteContato Consultar(Guid id)
        {
            return repositoryclienteContato.Obter(id);
        }

        public Result Salvar(clienteContato clienteContato)
        {
            Result retorno = new Result();

            try
            {
                if (clienteContato.ID == null)
                {
                    repositoryclienteContato.Adicionar(clienteContato);
                }
                else
                {
                    repositoryclienteContato.Alterar(clienteContato);
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

        public List<clienteContato> Filtrar(Expression<Func<clienteContato, bool>> filtro, Expression<Func<clienteContato, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryclienteContato.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o Contato");
                return retorno;
            }
            try
            {
                repositoryclienteContato.Remover(id);
                context.SaveChanges();
                retorno.Ok("Contato removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o Contato " + erro.Message);
            }
            return retorno;
        }

        public List<clienteContato> Filtrar(clienteContato clienteContato)
        {
            return repositoryclienteContato.ObterPorFiltros(b => (
                (clienteContato.ID == Guid.Empty || b.ID == clienteContato.ID) &&
                (clienteContato.nomeContato == null || b.nomeContato.ToUpper().Contains(clienteContato.nomeContato)) &&
                (clienteContato.telefoneContato == null || b.telefoneContato.ToUpper().Contains(clienteContato.telefoneContato)) &&
                (clienteContato.emailContato == null || b.emailContato.ToUpper().Contains(clienteContato.emailContato)) &&
                (clienteContato.clienteID == Guid.Empty || b.clienteID == clienteContato.clienteID) &&
                (clienteContato.empresaID == Guid.Empty || b.empresaID == clienteContato.empresaID)
                )).ToList();
        }

    }
}
