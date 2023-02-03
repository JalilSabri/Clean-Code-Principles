using CleanCodePrinciples.Presentation.Interfaces;
using System.Linq.Expressions;

namespace CleanCodePrinciples.Presentation.Classes
{
    public class CleanCodeService<DemoType> : ICleanCodeService<DemoType>, IDisposable
    {
        Interfaces.ICleanCodeRepository<DemoType> _CleanCodeRepository;
        CleanCodeInfra? _CleanCodeInfra;

        public CleanCodeService(ICleanCodeRepository<DemoType> CleanCodeRepository)
        {
            _CleanCodeRepository = CleanCodeRepository;
        }

        CleanCodeInfra CreateCleanCodeInfra(Exception ex)
        {
            _CleanCodeInfra = new CleanCodeInfra(ex);
            return _CleanCodeInfra;
        }

        public virtual void Add(DemoType entity)
        {
            bool CheckAddBusinessRules(DemoType entity)
            {
                //check Rules and error handeling
                return true;
            }

            try
            {
                if (CheckAddBusinessRules(entity))
                    _CleanCodeRepository.Add(entity);
            }
            catch (DataLayerHasException dlEx)
            {
                CreateCleanCodeInfra(dlEx).SendMessage(dlEx.Message);
            }
            catch (Exception ex)
            {
                CreateCleanCodeInfra(ex).DoLog().SendMessage(ex.Message);
            }

        }

        public virtual void Delete(DemoType entity)
        {
            bool CheckPermmission(DemoType entity)
            {
                //check Rules and error handeling
                return true;
            }

            try
            {
                if (CheckPermmission(entity))
                    _CleanCodeRepository.Delete(entity);
            }
            catch (DataLayerHasException dlEx)
            {
                CreateCleanCodeInfra(dlEx).SendMessage(dlEx.Message);
            }
            catch (Exception ex)
            {
                CreateCleanCodeInfra(ex).DoLog().SendMessage(ex.Message);
            }
        }

        public virtual void Delete(Expression<Func<DemoType, bool>> where)
        {
            try
            {
                _CleanCodeRepository.Delete(where);
            }
            catch (DataLayerHasException dlEx)
            {
                CreateCleanCodeInfra(dlEx).SendMessage(dlEx.Message);
            }
            catch (Exception ex)
            {
                CreateCleanCodeInfra(ex).DoLog().SendMessage(ex.Message);
            }
        }

        public virtual void Update(DemoType oldEntity, DemoType newEntity)
        {
            bool CheckUpdateBusinessRules(DemoType newEntity)
            {
                //check Rules and error handeling
                return true;
            }

            try
            {
                if (CheckUpdateBusinessRules(newEntity))
                    _CleanCodeRepository.Update(oldEntity, newEntity);
            }
            catch (DataLayerHasException dlEx)
            {
                CreateCleanCodeInfra(dlEx).SendMessage(dlEx.Message);
            }
            catch (Exception ex)
            {
                CreateCleanCodeInfra(ex).DoLog().SendMessage(ex.Message);
            }
        }

        public virtual IEnumerable<DemoType>? GetAll()
        {
            IEnumerable<DemoType>? getResult = null;
            try
            {
                getResult = _CleanCodeRepository.GetAll();
            }
            catch (DataLayerHasException dlEx)
            {
                CreateCleanCodeInfra(dlEx).SendMessage(dlEx.Message);
            }
            catch (Exception ex)
            {
                CreateCleanCodeInfra(ex).DoLog().SendMessage(ex.Message);
            }
            return getResult;
        }

        public virtual DemoType? GetFirst(Func<DemoType, bool> where)
        {
            DemoType? firstResult = default(DemoType);
            try
            {
                firstResult = _CleanCodeRepository.GetFirst(where);
            }
            catch (DataLayerHasException dlEx)
            {
                CreateCleanCodeInfra(dlEx).SendMessage(dlEx.Message);
            }
            catch (Exception ex)
            {
                CreateCleanCodeInfra(ex).DoLog().SendMessage(ex.Message);
            }
            return firstResult;
        }

        public virtual IEnumerable<DemoType>? GetList(Expression<Func<DemoType, bool>>? where = null)
        {
            IEnumerable<DemoType>? getResult = null;
            try
            {
                getResult = _CleanCodeRepository.GetList(where);
            }
            catch (DataLayerHasException dlEx)
            {
                CreateCleanCodeInfra(dlEx).SendMessage(dlEx.Message);
            }
            catch (Exception ex)
            {
                CreateCleanCodeInfra(ex).DoLog().SendMessage(ex.Message);
            }
            return getResult;
        }

        public virtual IEnumerable<DemoType>? GetList(Expression<Func<DemoType, bool>> where = null, Func<IQueryable<DemoType>, IOrderedQueryable<DemoType>> orderBy = null)
        {
            IEnumerable<DemoType>? getResult = null;
            try
            {
                getResult = _CleanCodeRepository.GetList(where);
            }
            catch (DataLayerHasException dlEx)
            {
                CreateCleanCodeInfra(dlEx).SendMessage(dlEx.Message);
            }
            catch (Exception ex)
            {
                CreateCleanCodeInfra(ex).DoLog().SendMessage(ex.Message);
            }
            return getResult;
        }

        public virtual void Dispose()
        {
            _CleanCodeInfra ??= null;
        }


    }
}