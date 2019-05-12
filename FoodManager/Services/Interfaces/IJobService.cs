using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IJobService
    {
        Job Get(int id);
        JobPage Filter(JobFilter request);
        List<Job> OnlyStatusActivated();
        void Create(Job request);
        void Update(Job request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
    }
}