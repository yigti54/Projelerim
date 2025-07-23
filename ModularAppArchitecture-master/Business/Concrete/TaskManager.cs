using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.EntityFramework.Entities;
using Entities.Dtos;
using System;
using Task = Entities.Concrete.EntityFramework.Entities.Task;

namespace Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly ITaskDal _taskDal;
        private readonly IErrorLogService _errorLogService;

        public TaskManager(ITaskDal taskDal, IErrorLogService errorLogService)
        {
            _taskDal = taskDal;
            _errorLogService = errorLogService;
        }

        public IResult AddTask(AddTaskDto addTaskDto, Guid userId)
        {
            try
            {
                var task = new Task
                {
                    UserId = userId,
                    Title = addTaskDto.Title,
                    Description = addTaskDto.Description,
                    DueDate = addTaskDto.DueDate,
                    IsCompleted = false,
                    CreatedDate = DateTime.Now
                };

                _taskDal.Add(task);
                return new SuccessResult("Görev başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                _errorLogService.LogError(ex, new { addTaskDto }, userId.ToString(), "AddTask", "TaskManager");
                return new ErrorResult("Görev eklenirken bir hata oluştu.");
            }
        }
    }
}
