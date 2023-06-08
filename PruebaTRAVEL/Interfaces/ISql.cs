using PruebaTRAVEL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTRAVEL.Interfaces
{
    public interface ISql
    {

        Task<bool> DeleteGeneral(ModelGeneral generalRomove);
        Task<ModelGeneralList> GetAll();
        Task<bool> SavedUpdateGeneral(ModelGeneral generalSave);
    }
}
