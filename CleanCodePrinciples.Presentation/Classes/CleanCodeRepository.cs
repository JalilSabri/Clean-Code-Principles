using System.Linq;
using System.Linq.Expressions;

namespace CleanCodePrinciples.Presentation.Classes
{

    public class CleanCodeRepository<DemoType> : Interfaces.ICleanCodeRepository<DemoType>
    {
        IList<DemoType> _lstData;

        public CleanCodeRepository()
        {
            _lstData = typeof(DemoType).Name switch
            {
                "String" => (IList<DemoType>)new List<string>() { "C#", "is a",  "BackEnd", "Language", "Development" },
                "CleanCodeRecordTemplate" => (IList<DemoType>)new List<CleanCodeRecordTemplate>() {
                    new CleanCodeRecordTemplate(11,"Traditional"),
                    new CleanCodeRecordTemplate(22,"Clean"),
                    new CleanCodeRecordTemplate(33,"Onion"),
                    new CleanCodeRecordTemplate(44,"MicroService")
                    },
                _ => throw new Exception("Data type is not supported")
            };
        }

        public IEnumerable<DemoType> GetAll()
        {
            return _lstData.AsEnumerable();
        }

        public DemoType? GetFirst(Func<DemoType, bool>? where)
        {
            return _lstData.FirstOrDefault(where);
        }

        public IEnumerable<DemoType> GetList(Expression<Func<DemoType, bool>>? where = null)
        {
            IQueryable<DemoType> query = (from l in _lstData select l).AsQueryable();

            if (where != null)
            {
                query = (IQueryable<DemoType>)query.Where(where);
            }

            return query.ToList();
        }

        public IEnumerable<DemoType> GetWithExpressions(Expression<Func<DemoType, bool>>? where = null, Func<IQueryable<DemoType>, IOrderedQueryable<DemoType>> orderBy = null)
        {
            IQueryable<DemoType> query = (from l in _lstData select l).AsQueryable();

            if (where != null)
            {
                query = (IQueryable<DemoType>)query.Where(where);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Add(DemoType entity)
        {
            _lstData.Add(entity);
            int count = _lstData.Count();
        }

        public void Update(DemoType oldEntity,DemoType newEntity)
        {
            int index = _lstData.IndexOf(oldEntity);
             _lstData[index] = newEntity;
        }

        public void Delete(DemoType entity)
        {
            _lstData.Remove(entity);
        }

        public void Delete(Expression<Func<DemoType, bool>> where)
        {
            IEnumerable<DemoType> lstEntities = GetList(where);
            foreach (DemoType ent in lstEntities)
                _lstData.Remove(ent);
        }
        
    }

}
