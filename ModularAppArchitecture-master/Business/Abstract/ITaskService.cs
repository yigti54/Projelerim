using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ITaskService
    {
        IResult AddTask(AddTaskDto addTaskDto, Guid userId);
    }
}
