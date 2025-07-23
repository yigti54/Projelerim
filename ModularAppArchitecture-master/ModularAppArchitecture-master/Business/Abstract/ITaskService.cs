using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITaskService
    {
        Task<IDataResult<List<TaskDto>>> GetAllAsync();
        Task<IDataResult<TaskDto>> GetByIdAsync(int taskId);
        Task<IDataResult<List<TaskDto>>> GetByUserIdAsync(int userId);
        Task<IResult> AddAsync(TaskCreateDto taskCreateDto);
        Task<IResult> UpdateAsync(TaskUpdateDto taskUpdateDto);
        Task<IResult> DeleteAsync(int taskId);
    }
}