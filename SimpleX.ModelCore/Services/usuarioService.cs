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

    public class usuarioService : IDisposable
    {
        private Context context;
        private Repository<usuario> repositoryusuario;

        public usuarioService()
        {
            context = new Context();
            repositoryusuario = new Repository<usuario>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<usuario> Listar()
        {
            return repositoryusuario.ObterTodos().ToList();
        }

        public usuario Consultar(Guid id)
        {
            return repositoryusuario.Obter(id);
        }

        public Result Salvar(usuario usuario)
        {
            Result retorno = new Result();

            try
            {
                if (usuario.ID == null)
                {
                    repositoryusuario.Adicionar(usuario);
                }
                else
                {
                    repositoryusuario.Alterar(usuario);
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

        public List<usuario> Filtrar(Expression<Func<usuario, bool>> filtro, Expression<Func<usuario, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryusuario.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o usuario");
                return retorno;
            }
            try
            {
                repositoryusuario.Remover(id);
                context.SaveChanges();
                retorno.Ok("usuario removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o usuario " + erro.Message);
            }
            return retorno;
        }

        public List<usuario> Filtrar(usuario usuario)
        {
            return repositoryusuario.ObterPorFiltros(b => (
                (usuario.ID == Guid.Empty || b.ID == usuario.ID) &&
                (usuario.nome == null || b.nome.ToUpper().Contains(usuario.nome)) &&
                (usuario.login == null || b.login.ToUpper().Contains(usuario.login)) &&
                (usuario.senha == null || b.senha.ToUpper().Contains(usuario.senha)) &&
                (usuario.empresaID == Guid.Empty || b.empresaID == usuario.empresaID)
                )).ToList();
        }

    }
}
