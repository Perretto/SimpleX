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

    public class fornecedorEnderecoService : IDisposable
    {
        private Context context;
        private Repository<fornecedorEndereco> repositoryfornecedorEndereco;

        public fornecedorEnderecoService()
        {
            context = new Context();
            repositoryfornecedorEndereco = new Repository<fornecedorEndereco>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<fornecedorEndereco> Listar()
        {
            return repositoryfornecedorEndereco.ObterTodos().ToList();
        }

        public fornecedorEndereco Consultar(Guid id)
        {
            return repositoryfornecedorEndereco.Obter(id);
        }

        public Result Salvar(fornecedorEndereco fornecedorEndereco)
        {
            Result retorno = new Result();

            try
            {
                if (fornecedorEndereco.ID == null)
                {
                    repositoryfornecedorEndereco.Adicionar(fornecedorEndereco);
                }
                else
                {
                    repositoryfornecedorEndereco.Alterar(fornecedorEndereco);
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

        public List<fornecedorEndereco> Filtrar(Expression<Func<fornecedorEndereco, bool>> filtro, Expression<Func<fornecedorEndereco, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryfornecedorEndereco.Filtrar(filtro, campo, ordenacao).ToList();
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
                repositoryfornecedorEndereco.Remover(id);
                context.SaveChanges();
                retorno.Ok("Endereço removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o endereço " + erro.Message);
            }
            return retorno;
        }

        public List<fornecedorEndereco> Filtrar(fornecedorEndereco fornecedorEndereco)
        {
            return repositoryfornecedorEndereco.ObterPorFiltros(b => (
                (fornecedorEndereco.ID == Guid.Empty || b.ID == fornecedorEndereco.ID) &&
                (fornecedorEndereco.logradouro == null || b.logradouro.ToUpper().Contains(fornecedorEndereco.logradouro)) &&
                (fornecedorEndereco.numero == null || b.numero.ToUpper().Contains(fornecedorEndereco.numero)) &&
                (fornecedorEndereco.complemento == null || b.complemento.ToUpper().Contains(fornecedorEndereco.complemento)) &&
                (fornecedorEndereco.bairro == null || b.bairro.ToUpper().Contains(fornecedorEndereco.bairro)) &&
                (fornecedorEndereco.CEP == null || b.CEP.ToUpper().Contains(fornecedorEndereco.CEP)) &&
                
                (fornecedorEndereco.cidadeID == Guid.Empty || b.cidadeID == fornecedorEndereco.cidadeID) &&
                (fornecedorEndereco.estadoID == Guid.Empty || b.estadoID == fornecedorEndereco.estadoID) &&
                (fornecedorEndereco.paisID == Guid.Empty || b.paisID == fornecedorEndereco.paisID) &&
                (fornecedorEndereco.fornecedorID == Guid.Empty || b.fornecedorID == fornecedorEndereco.fornecedorID) &&
                (fornecedorEndereco.empresaID == Guid.Empty || b.empresaID == fornecedorEndereco.empresaID)

                )).ToList();
        }

    }
}
