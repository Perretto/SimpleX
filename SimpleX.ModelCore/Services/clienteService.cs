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

    public class clienteService : IDisposable
    {
        private Context context;
        private Repository<cliente> repositoryCliente;

        public clienteService()
        {
            context = new Context();
            repositoryCliente = new Repository<cliente>(context);
        }
        
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
        
        public List<cliente> Listar()
        {
            return repositoryCliente.ObterTodos().ToList();
        }
        
        public cliente Consultar(Guid id)
        {
            return repositoryCliente.Obter(id);
        }
        
        public Result Salvar(cliente cliente)
        {
            Result retorno = new Result();
            
            try
            {
                if (cliente.ID == Guid.Empty)
                {
                    cliente.ID = Guid.NewGuid();
                    repositoryCliente.Adicionar(cliente);
                }
                else
                {
                    repositoryCliente.Alterar(cliente);
                }

                context.SaveChanges();

                systemMessageCore systemMessageCore = new systemMessageCore();

                string description = systemMessageCore.BuscarSystemMessageByExternalNumber("0001");

                if (description != "")
                {
                    retorno.Ok(description);
                }
                else
                {
                    retorno.Ok("Cadastro realizado com sucesso.");
                }
                                
                retorno.Sucesso = true;
            }
            catch (Exception erro)
            {
                retorno.Sucesso = false;
                retorno.Erro(erro.InnerException.Message);
            }

            return retorno;
        }

        public List<cliente> Filtrar(Expression<Func<cliente, bool>> filtro, Expression<Func<cliente, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryCliente.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o cliente");
                return retorno;
            }
            try
            {
                repositoryCliente.Remover(id);
                context.SaveChanges();
                retorno.Ok("Cliente removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o cliente " + erro.Message);
            }
            return retorno;
        }

        public List<cliente> Filtrar(cliente cliente)
        {
            return repositoryCliente.ObterPorFiltros(b => (
                (cliente.ID == Guid.Empty || b.ID == cliente.ID) &&
                (cliente.razaoSocial == null || b.razaoSocial.ToUpper().Contains(cliente.razaoSocial)) &&
                (cliente.nomeFantasia == null || b.nomeFantasia.ToUpper().Contains(cliente.nomeFantasia)) &&
                (cliente.codigo == null || b.codigo == cliente.codigo) &&
                (cliente.CNPJ == null || b.CNPJ.ToUpper().Contains(cliente.CNPJ)) &&
                (cliente.CPF == null || b.CPF.ToUpper().Contains(cliente.CPF)) &&
                (cliente.RG == null || b.RG.ToUpper().Contains(cliente.RG)) &&
                (cliente.IE == null || b.IE.ToUpper().Contains(cliente.IE)) &&
                (cliente.IM == null || b.IM.ToUpper().Contains(cliente.IM)) &&
                (cliente.suframa == null || b.suframa.ToUpper().Contains(cliente.suframa)) &&
                (cliente.CNAEID == Guid.Empty || b.CNAEID == cliente.CNAEID) &&
                (cliente.empresaID == Guid.Empty || b.empresaID == cliente.empresaID)
                )).ToList();
        }

    }
}
