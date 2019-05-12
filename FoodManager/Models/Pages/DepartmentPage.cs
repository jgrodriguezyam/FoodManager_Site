using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class DepartmentPage : Page
    {
        public DepartmentPage()
        {
            Departments = new List<Department>();
        }

        public List<Department> Departments { get; set; }
    }
}