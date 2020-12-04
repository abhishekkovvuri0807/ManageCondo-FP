using ManageCondo.DomainModels;
using ManageCondo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagaCondo.Business
{
    public class UnitBusiness
    {
        private readonly IUnitRepository _unitRepository;
        public UnitBusiness(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            IEnumerable<Unit> units = _unitRepository.GetAllUnits();
            return units;
        }

        public void AddUnit(Unit unit)
        {
            _unitRepository.AddUnit(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            _unitRepository.UpdateUnit(unit);
        }

        public Unit GetUnitDetails(int unitID)
        {
            return _unitRepository.GetUnitDetails(unitID);
        }

        public void DeleteUnit(Unit unit)
        {
            _unitRepository.DeleteUnit(unit);
        }
    }

}