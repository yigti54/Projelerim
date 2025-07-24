using ProjectManager.Core.DataAccess;
using ProjectManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
