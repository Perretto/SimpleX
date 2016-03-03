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

    public class clienteEnderecoService : IDisposable
    {
        private Context context;
        private Repository<clienteEndereco> repositoryclienteEndereco;

        public clienteEnderecoService()
        {
            context = new Context();
            repositoryclienteEndereco = new Repository<clienteEndereco>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<clienteEndereco> Listar()
        {
            return repositoryclienteEndereco.ObterTodos().ToList();
        }

        public clienteEndereco Consultar(Guid id)
        {
            return repositoryclienteEndereco.Obter(id);
        }

        public Result Salvar(clienteEndereco clienteEndereco)
        {
            Result retorno = new Result();

            try
            {
                if (clienteEndereco.ID == Guid.Empty)
                {
                    clienteEndereco.ID = Guid.NewGuid();
                    repositoryclienteEndereco.Adicionar(clienteEndereco);
                }
                else
                {
                    repositoryclienteEndereco.Alterar(clienteEndereco);
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

        public List<clienteEndereco> Filtrar(Expression<Func<clienteEndereco, bool>> filtro, Expression<Func<clienteEndereco, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryclienteEndereco.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o endereço");
                return retorno;
            }
            try
            {
                repositoryclienteEndereco.Remover(id);
                context.SaveChanges();
                retorno.Ok("Endereço removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o endereço " + erro.Message);
            }
            return retorno;
        }

        public List<clienteEndereco> Filtrar(clienteEndereco clienteEndereco)
        {
            return repositoryclienteEndereco.ObterPorFiltros(b => (
                (clienteEndereco.ID == Guid.Empty || b.ID == clienteEndereco.ID) &&
                (clienteEndereco.logradouro == null || b.logradouro.ToUpper().Contains(clienteEndereco.logradouro)) &&
                (clienteEndereco.numero == null || b.numero.ToUpper().Contains(clienteEndereco.numero)) &&
                (clienteEndereco.complemento == null || b.complemento.ToUpper().Contains(clienteEndereco.complemento)) &&
                (clienteEndereco.bairro == null || b.bairro.ToUpper().Contains(clienteEndereco.bairro)) &&
                (clienteEndereco.CEP == null || b.CEP.ToUpper().Contains(clienteEndereco.CEP)) &&
                (clienteEndereco.cidadeID == Guid.Empty || b.cidadeID == clienteEndereco.cidadeID) &&
                (clienteEndereco.estadoID == Guid.Empty || b.estadoID == clienteEndereco.estadoID) &&
                (clienteEndereco.paisID == Guid.Empty || b.paisID == clienteEndereco.paisID) &&
                (clienteEndereco.empresaID == Guid.Empty || b.empresaID == clienteEndereco.empresaID) &&
                (clienteEndereco.clienteID == Guid.Empty || b.clienteID == clienteEndereco.clienteID)

                )).ToList();
        }

    }
}
