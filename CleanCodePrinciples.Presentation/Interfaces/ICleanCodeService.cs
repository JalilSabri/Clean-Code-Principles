using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePrinciples.Presentation.Interfaces
{
    public interface ICleanCodeService<DemoType>
    {
        public IEnumerable<DemoType>? GetAll();

        public DemoType? GetFirst(Func<DemoType, bool>? where);

        public IEnumerable<DemoType> GetList(Expression<Func<DemoType, bool>>? where = null);

        public void Add(DemoType entity);

        public void Update(DemoType oldEntity, DemoType newEntity);

        public void Delete(DemoType entity);

        public void Delete(Expression<Func<DemoType, bool>> where);

    }
}
