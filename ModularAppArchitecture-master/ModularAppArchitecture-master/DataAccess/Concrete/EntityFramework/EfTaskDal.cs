using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete.EntityFramework.Context;
using Entities.Concrete.EntityFramework.Entities;
using Task = Entities.Concrete.EntityFramework.Entities.Task;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTaskDal : EfEntityRepositoryBase<Task, ContextDb>, ITaskDal
    {
        public EfTaskDal(ContextDb context) : base(context)
        {
        }
    }
}