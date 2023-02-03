using System.Linq.Expressions;

namespace CleanCodePrinciples.Presentation.Interfaces
{
    public interface ICleanCodeRepository<DemoType>
    {

        public IEnumerable<DemoType> GetAll();

        public DemoType GetFirst(Func<DemoType, bool>? where);

        public IEnumerable<DemoType> GetList(Expression<Func<DemoType, bool>>? where = null);

        public IEnumerable<DemoType> GetWithExpressions(Expression<Func<DemoType, bool>>? where = null, Func<IQueryable<DemoType>, IOrderedQueryable<DemoType>> orderBy = null);

        public void Add(DemoType entity);

        public void Update(DemoType oldEntity, DemoType newEntity);

        public void Delete(DemoType entity);

        public void Delete(Expression<Func<DemoType, bool>> where);

        // and some other methods ... which is presented in other post: "Single-Core-Repository-Architecture"
    }
}
