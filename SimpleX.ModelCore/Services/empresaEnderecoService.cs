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

    public class empresaEnderecoService : IDisposable
    {
        private Context context;
        private Repository<empresaEndereco> repositoryempresaEndereco;

        public empresaEnderecoService()
        {
            context = new Context();
            repositoryempresaEndereco = new Repository<empresaEndereco>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<empresaEndereco> Listar()
        {
            return repositoryempresaEndereco.ObterTodos().ToList();
        }

        public empresaEndereco Consultar(Guid id)
        {
            return repositoryempresaEndereco.Obter(id);
        }

        public Result Salvar(empresaEndereco empresaEndereco)
        {
            Result retorno = new Result();

            try
            {
                if (empresaEndereco.ID == Guid.Empty)
                {
                    empresaEndereco.ID = Guid.NewGuid();
                    repositoryempresaEndereco.Adicionar(empresaEndereco);
                }
                else
                {
                    repositoryempresaEndereco.Alterar(empresaEndereco);
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

        public List<empresaEndereco> Filtrar(Expression<Func<empresaEndereco, bool>> filtro, Expression<Func<empresaEndereco, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryempresaEndereco.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir a endereço");
                return retorno;
            }
            try
            {
                repositoryempresaEndereco.Remover(id);
                context.SaveChanges();
                retorno.Ok("Endereço removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o endereço " + erro.Message);
            }
            return retorno;
        }

        public List<empresaEndereco> Filtrar(empresaEndereco empresaEndereco)
        {
            return repositoryempresaEndereco.ObterPorFiltros(b => (
                (empresaEndereco.ID == Guid.Empty || b.ID == empresaEndereco.ID) &&
                (empresaEndereco.logradouro == null || b.logradouro.ToUpper().Contains(empresaEndereco.logradouro)) &&
                (empresaEndereco.numero == null || b.numero.ToUpper().Contains(empresaEndereco.numero)) &&
                (empresaEndereco.complemento == null || b.complemento.ToUpper().Contains(empresaEndereco.complemento)) &&
                (empresaEndereco.bairro == null || b.bairro.ToUpper().Contains(empresaEndereco.bairro)) &&
                (empresaEndereco.CEP == null || b.CEP.ToUpper().Contains(empresaEndereco.CEP)) &&
                (empresaEndereco.cidadeID == Guid.Empty || b.cidadeID == empresaEndereco.cidadeID) &&
                (empresaEndereco.estadoID == Guid.Empty || b.estadoID == empresaEndereco.estadoID) &&
                (empresaEndereco.paisID == Guid.Empty || b.paisID == empresaEndereco.paisID) &&
                (empresaEndereco.empresaID == Guid.Empty || b.empresaID == empresaEndereco.empresaID)
                )).ToList();
        }

    }
}
