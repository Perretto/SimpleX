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

    public class fornecedorService : IDisposable
    {
        private Context context;
        private Repository<fornecedor> repositoryfornecedor;

        public fornecedorService()
        {
            context = new Context();
            repositoryfornecedor = new Repository<fornecedor>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<fornecedor> Listar()
        {
            return repositoryfornecedor.ObterTodos().ToList();
        }

        public fornecedor Consultar(Guid id)
        {
            return repositoryfornecedor.Obter(id);
        }

        public Result Salvar(fornecedor fornecedor)
        {
            Result retorno = new Result();

            try
            {
                if (fornecedor.ID == null)
                {
                    repositoryfornecedor.Adicionar(fornecedor);
                }
                else
                {
                    repositoryfornecedor.Alterar(fornecedor);
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

        public List<fornecedor> Filtrar(Expression<Func<fornecedor, bool>> filtro, Expression<Func<fornecedor, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryfornecedor.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o fornecedor");
                return retorno;
            }
            try
            {
                repositoryfornecedor.Remover(id);
                context.SaveChanges();
                retorno.Ok("fornecedor removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o fornecedor " + erro.Message);
            }
            return retorno;
        }

        public List<fornecedor> Filtrar(fornecedor fornecedor)
        {
            return repositoryfornecedor.ObterPorFiltros(b => (
                (fornecedor.ID == Guid.Empty || b.ID == fornecedor.ID) &&
                (fornecedor.codigo == null || b.codigo.ToUpper().Contains(fornecedor.codigo)) &&
                (fornecedor.razaoSocial == null || b.razaoSocial.ToUpper().Contains(fornecedor.razaoSocial)) &&
                (fornecedor.nomeFantasia == null || b.nomeFantasia.ToUpper().Contains(fornecedor.nomeFantasia)) &&
                (fornecedor.CNPJ == null || b.CNPJ.ToUpper().Contains(fornecedor.CNPJ)) &&
                (fornecedor.CPF == null || b.CPF.ToUpper().Contains(fornecedor.CPF)) &&
                (fornecedor.RG == null || b.RG.ToUpper().Contains(fornecedor.RG)) &&
                (fornecedor.IE == null || b.IE.ToUpper().Contains(fornecedor.IE)) &&
                (fornecedor.IM == null || b.IM.ToUpper().Contains(fornecedor.IM)) &&
                (fornecedor.CNAEID == Guid.Empty || b.CNAEID == fornecedor.CNAEID) &&
                (fornecedor.empresaID == Guid.Empty || b.empresaID == fornecedor.empresaID)
                )).ToList();
        }

    }
}
