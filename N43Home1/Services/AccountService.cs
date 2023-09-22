using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N43Home1.Services
{
    internal class AccountService
    {
        private readonly UserService _userService;

        public AccountService(UserService userService)
        {
            _userService = userService;
        }

        public void CreateReportAsync(Guid id)
        {
            // yuqoridagi ikki service ni ishlatgan holda yuz uchun faly yartishi va faylga malumot yozish
            var userA =  new EmployeeService(_userService);
            var userB = new PerformanceService(_userService);
            userA.CreatePerformanceRecordAsync(id);
            userB.ReportPersformanceAsync(id);
        }
    }
}
