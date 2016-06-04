using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SimpleX.ModelCore;
using System.Data.Entity;
using Simplex.Pizzaria.Context;
using Simplex.Pizzaria.Repository;
using Simplex.Pizzaria.Models;
using Simplex.Pizzaria.Service;

namespace Simplex.Pizzaria.Service
{

    public class usuarioService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<usuario> repositoryusuario;

        public usuarioService()
        {
            context = new ContextPizzaria();
            repositoryusuario = new Repository<usuario>(context);
        }

        public List<usuario> Filtrar(usuario usuario)
        {
            return repositoryusuario.ObterPorFiltros(b => (
                (usuario.ID == Guid.Empty || b.ID == usuario.ID) &&
                (usuario.nome == null || b.nome.ToUpper().Contains(usuario.nome)) &&
                (usuario.email == null || b.email.ToUpper().Contains(usuario.email)) &&
                (usuario.senha == null || b.senha.ToUpper().Contains(usuario.senha)) &&
                (usuario.empresaID == Guid.Empty || b.empresaID == usuario.empresaID)
                )).ToList();
        }

    }
}
