using Core.DataAccess;
using Entities.Concrete.EntityFramework.Entities;
using Task = Entities.Concrete.EntityFramework.Entities.Task;

namespace DataAccess.Abstract
{
    public interface ITaskDal : IEntityRepository<Task>
    {
        // Task'e özel veritabanı işlemleri gerekirse gelecekte buraya eklenebilir.
    }
}