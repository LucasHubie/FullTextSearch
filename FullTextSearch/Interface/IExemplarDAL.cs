using FullTextSearch.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullTextSearch.Interface
{
    public interface IExemplarDAL
    {
        IEnumerable<Exemplar> GetAllExemplar();

        IEnumerable<Exemplar> busca(string busca);
        IEnumerable<Exemplar> FTS(string busca);
    }
}
