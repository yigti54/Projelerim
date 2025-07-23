using AutoMapper;
using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Task = Entities.Concrete.EntityFramework.Entities.Task; // System.Threading.Tasks ile çakışmayı önlemek için

namespace Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly ITaskDal _taskDal;
        private readonly IUserDal _userDal; // Kullanıcının varlığını kontrol etmek için
        private readonly IMapper _mapper;

        public TaskManager(ITaskDal taskDal, IMapper mapper, IUserDal userDal)
        {
            _taskDal = taskDal;
            _mapper = mapper;
            _userDal = userDal;
        }

        public async Task<IResult> AddAsync(TaskCreateDto taskCreateDto)
        {
            // Görev eklenmek istenen kullanıcı sistemde var mı?
            var userExists = await _userDal.GetAsync(u => u.Id == taskCreateDto.UserId);
            if (userExists == null)
            {
                return new ErrorResult(SystemMessages.UserNotFound); // SystemMessages sınıfınıza uygun bir mesaj ekleyin
            }

            var task = _mapper.Map<Task>(taskCreateDto);
            task.CreatedDate = DateTime.Now;
            task.IsCompleted = false;

            await _taskDal.AddAsync(task);
            return new SuccessResult(SystemMessages.OperationSuccessful);
        }

        public async Task<IResult> DeleteAsync(int taskId)
        {
            var taskToDelete = await _taskDal.GetAsync(t => t.Id == taskId);
            if (taskToDelete == null)
            {
                return new ErrorResult(SystemMessages.ResourceNotFound); // SystemMessages sınıfınıza uygun bir mesaj ekleyin
            }

            await _taskDal.DeleteAsync(taskToDelete);
            return new SuccessResult(SystemMessages.OperationSuccessful);
        }

        public async Task<IDataResult<List<TaskDto>>> GetAllAsync()
        {
            var tasks = await _taskDal.GetListAsync();
            var tasksDto = _mapper.Map<List<TaskDto>>(tasks);
            return new SuccessDataResult<List<TaskDto>>(tasksDto);
        }

        public async Task<IDataResult<TaskDto>> GetByIdAsync(int taskId)
        {
            var task = await _taskDal.GetAsync(t => t.Id == taskId);
            if (task == null)
            {
                return new ErrorDataResult<TaskDto>(default, SystemMessages.ResourceNotFound);
            }
            var taskDto = _mapper.Map<TaskDto>(task);
            return new SuccessDataResult<TaskDto>(taskDto);
        }

        public async Task<IDataResult<List<TaskDto>>> GetByUserIdAsync(int userId)
        {
            var tasks = await _taskDal.GetListAsync(t => t.UserId == userId);
            var tasksDto = _mapper.Map<List<TaskDto>>(tasks);
            return new SuccessDataResult<List<TaskDto>>(tasksDto);
        }

        public async Task<IResult> UpdateAsync(TaskUpdateDto taskUpdateDto)
        {
            var taskToUpdate = await _taskDal.GetAsync(t => t.Id == taskUpdateDto.Id);
            if (taskToUpdate == null)
            {
                return new ErrorResult(SystemMessages.ResourceNotFound);
            }

            // Gelen DTO'daki verileri mevcut entity üzerine işle
            _mapper.Map(taskUpdateDto, taskToUpdate);

            await _taskDal.UpdateAsync(taskToUpdate);
            return new SuccessResult(SystemMessages.OperationSuccessful);
        }
    }
}