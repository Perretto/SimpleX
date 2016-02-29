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

    public class empresaService : IDisposable
    {
        private Context context;
        private Repository<empresa> repositoryEmpresa;

        public empresaService()
        {
            context = new Context();
            repositoryEmpresa = new Repository<empresa>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<empresa> Listar()
        {
            return repositoryEmpresa.ObterTodos().ToList();
        }

        public empresa Consultar(Guid id)
        {
            return repositoryEmpresa.Obter(id);
        }

        public Result Salvar(empresa empresa)
        {
            Result retorno = new Result();

            try
            {
                if (empresa.ID == null)
                {
                    repositoryEmpresa.Adicionar(empresa);
                }
                else
                {
                    repositoryEmpresa.Alterar(empresa);
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

        public List<empresa> Filtrar(Expression<Func<empresa, bool>> filtro, Expression<Func<empresa, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryEmpresa.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir a empresa");
                return retorno;
            }
            try
            {
                repositoryEmpresa.Remover(id);
                context.SaveChanges();
                retorno.Ok("Empresa removida com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir a empresa " + erro.Message);
            }
            return retorno;
        }

        public List<empresa> Filtrar(empresa empresa)
        {
            return repositoryEmpresa.ObterPorFiltros(b => (
                (empresa.ID == Guid.Empty || b.ID == empresa.ID) &&
                (empresa.razaoSocial == null || b.razaoSocial.ToUpper().Contains(empresa.razaoSocial)) &&
                (empresa.nomeFantasia == null || b.nomeFantasia.ToUpper().Contains(empresa.nomeFantasia)) &&
                (empresa.CNPJ == null || b.CNPJ.ToUpper().Contains(empresa.CNPJ)) &&
                (empresa.CPF == null || b.CPF.ToUpper().Contains(empresa.CPF)) &&
                (empresa.RG == null || b.RG.ToUpper().Contains(empresa.RG)) &&
                (empresa.IE == null || b.IE.ToUpper().Contains(empresa.IE)) &&
                (empresa.IM == null || b.IM.ToUpper().Contains(empresa.IM)) &&
                (empresa.CNAEID == Guid.Empty || b.CNAEID == empresa.CNAEID)
                )).ToList();
        }

    }
}
