using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using EmployeeManager.Models;

namespace EmployeeManager.ViewModels
{
    public partial class EmployeeListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<EmployeeModel> _employees = new ObservableCollection<EmployeeModel>()
        {
            new EmployeeModel()
            {
                Id = "G001",
                Name = "Nguyen Van Son",
                Email = "nguyenvanson98123@gmail.com",
                CreatedDate = new DateTime(2018,9,15),
                Dob = new DateTime(1998,9,15),
                Role = "Manager",
                Status = "Active"
            }
        };

    }
}
