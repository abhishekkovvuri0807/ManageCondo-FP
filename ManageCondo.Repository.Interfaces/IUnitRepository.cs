using ManageCondo.DomainModels;
using System.Collections.Generic;

namespace ManageCondo.Repository.Interfaces
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> GetAllUnits();
        void AddUnit(Unit unit);

        void UpdateUnit(Unit unit);

        Unit GetUnitDetails(int unitID);

        void DeleteUnit(Unit unit);
    }
}
