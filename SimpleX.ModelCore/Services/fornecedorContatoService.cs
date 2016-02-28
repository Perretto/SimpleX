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

    public class fornecedorContatoService : IDisposable
    {
        private Context context;
        private Repository<fornecedorContato> repositoryfornecedorContato;

        public fornecedorContatoService()
        {
            context = new Context();
            repositoryfornecedorContato = new Repository<fornecedorContato>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<fornecedorContato> Listar()
        {
            return repositoryfornecedorContato.ObterTodos().ToList();
        }

        public fornecedorContato Consultar(Guid id)
        {
            return repositoryfornecedorContato.Obter(id);
        }

        public Result Salvar(fornecedorContato fornecedorContato)
        {
            Result retorno = new Result();

            try
            {
                if (fornecedorContato.ID == null)
                {
                    repositoryfornecedorContato.Adicionar(fornecedorContato);
                }
                else
                {
                    repositoryfornecedorContato.Alterar(fornecedorContato);
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

        public List<fornecedorContato> Filtrar(Expression<Func<fornecedorContato, bool>> filtro, Expression<Func<fornecedorContato, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryfornecedorContato.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o contato");
                return retorno;
            }
            try
            {
                repositoryfornecedorContato.Remover(id);
                context.SaveChanges();
                retorno.Ok("Contato removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o contato " + erro.Message);
            }
            return retorno;
        }

        public List<fornecedorContato> Filtrar(fornecedorContato fornecedorContato)
        {
            return repositoryfornecedorContato.ObterPorFiltros(b => (
                (fornecedorContato.ID == Guid.Empty || b.ID == fornecedorContato.ID) &&
                (fornecedorContato.nomeContato == null || b.nomeContato.ToUpper().Contains(fornecedorContato.nomeContato)) &&
                (fornecedorContato.telefoneContato == null || b.telefoneContato.ToUpper().Contains(fornecedorContato.telefoneContato)) &&
                (fornecedorContato.emailContato == null || b.emailContato.ToUpper().Contains(fornecedorContato.emailContato)) &&
                (fornecedorContato.fornecedorID == Guid.Empty || b.fornecedorID == fornecedorContato.fornecedorID) &&
                (fornecedorContato.empresaID == Guid.Empty || b.empresaID == fornecedorContato.empresaID)
                )).ToList();
        }

    }
}
