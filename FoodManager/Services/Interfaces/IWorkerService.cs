using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Models.Reports;
using Worker = FoodManager.Models.Worker;

namespace FoodManager.Services.Interfaces
{
    public interface IWorkerService
    {
        void Login(WorkerLogin request);
        void Logout();
        Worker Get(int id);
        WorkerPage Filter(WorkerFilter request);
        List<Worker> OnlyStatusActivated();
        void Create(Worker request);
        void Update(Worker request);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
        WorkerReportResponse Report(WorkerReport request);
    }
}