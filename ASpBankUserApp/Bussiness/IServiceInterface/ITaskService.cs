using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;

namespace ASpBankUserApp.Bussiness.IServiceInterface
{
    public interface ITaskService
    {
        TaskEntity GetTaskByID(int TaskID);
        IEnumerable<TaskEntity> GetAllTasks();
        int CreateTask(TaskEntity taskEntity);
        bool UpdateTask(int UserID, TaskEntity taskEntity);
        bool DeleteTask(int UserID);
    }
}
