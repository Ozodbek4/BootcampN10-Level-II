using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N43Home1.Services;

namespace N43Home1.Services
{
    internal class EmployeeService
    {
        private readonly UserService _userService;

        public EmployeeService(UserService userService)
        {
            _userService = userService;
        }

        public void CreatePerformanceRecordAsync(Guid id)
        {
            var mutex = new Mutex(false, "file");
            Task.Run(() =>
            {
                mutex.WaitOne();
                if (CreateFile(MakePath(id)))
                {
                    _userService.Users.Find(x => x.Id == id).IsActive = true;
                    Console.WriteLine("Fayl yartildi");
                    Thread.Sleep(10000);
                    mutex.ReleaseMutex();
                    return;
                }
                Thread.Sleep(10000);
                Console.WriteLine("Fayl yaratilmadi");
                mutex.ReleaseMutex();
            });
        }

        private string MakePath(Guid id)
        {

            var fullName = _userService.Users.Find(x => x.Id == id);
            return $"{fullName.FirstName + fullName.LastName}.txt";
        }

        private bool CreateFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    var file = File.Create(path);
                    file.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
