using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N43Home1.Services
{
    internal class PerformanceService
    {
        private readonly UserService _userService;

        public PerformanceService(UserService userService)
        {
            _userService = userService;
        }

        public void ReportPersformanceAsync(Guid id)
        {
            // falyga "All good :)", yozish
            var mutex = new Mutex(false,"file");
            var fileName = _userService.Users.Find(x => x.Id == id);
            mutex.WaitOne();
            var text = File.Open(fileName.FirstName + fileName.LastName + ".txt", FileMode.Append);
            text.Write(Encoding.UTF8.GetBytes("All good :)\n"));
            text.Close();
            mutex.ReleaseMutex();
        }
    }
}
