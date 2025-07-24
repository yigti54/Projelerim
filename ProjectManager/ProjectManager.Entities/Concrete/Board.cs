using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Entities.Concrete
{
    public class Board : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
