using ManageCondo.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ManageCondo.Repository.Interfaces;

namespace DAL
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ManageCondoContext _dbContext;

        public UnitRepository(ManageCondoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return _dbContext.Units.Where(u => u.IsActive == true).Include(u => u.Property).ToList();
        }

        public void AddUnit(Unit unit)
        {
            unit.IsActive = true;
            _dbContext.Units.Add(unit);
            _dbContext.SaveChanges();
        }

        public void UpdateUnit(Unit unit)
        {
            Unit unitData = _dbContext.Units.Where(p => p.ID == unit.ID).FirstOrDefault();
            unitData.Name = unit.Name;
            unitData.Description = unit.Description;
            unitData.FobKey = unit.FobKey;
            unitData.isRentedOut = unit.isRentedOut;
            unitData.Level = unit.Level;
            unitData.Status = unit.Status;
            unitData.PropertyID = unit.PropertyID;
            _dbContext.SaveChanges();
        }

        public Unit GetUnitDetails(int unitID)
        {
            return _dbContext.Units.Where(p => p.ID == unitID).Include(u => u.Property).FirstOrDefault();
        }

        public void DeleteUnit(int unitID)
        {
            Unit unit =  _dbContext.Units.Where(p => p.ID == unitID).Include(u => u.Property).FirstOrDefault();
            unit.IsActive = false;
            _dbContext.SaveChanges();
        }

        public List<Unit> GetUnitsByPropertyID(int propertyID)
        {
            List<Unit> units = _dbContext.Units.Where(p => p.IsActive && p.PropertyID == propertyID).ToList();
            return units;
        }

    }
}
