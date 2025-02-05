using HostpitalMS.Data;
using HostpitalMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HostpitalMS.Controllers
{
    public class AppointmentController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public IActionResult Index(int id)
        {
            var doctor = dbContext.Doctors.Find(id);
            return View(doctor);
        }

        public IActionResult NotFoundPage()
        {

            return View();
        }
        public IActionResult ShowTable()
        {
            var AppointmentList = dbContext.Appointments.Include(e=>e.Doctor).ToList();
            return View(AppointmentList);
        }
        public IActionResult AddAppointment(int DoctorId, string patientName, DateOnly appointmentDate, string appointmentTime)
        {
            if (patientName == null || appointmentTime==null)
            {
                return RedirectToAction("NotFoundPage");
            }
            else
            {
                dbContext.Appointments.Add(new()
                {
                    patientName = patientName,
                    AppointmentDate = appointmentDate,
                    AppointmentTime = appointmentTime,
                    DoctorId = DoctorId
                });
                dbContext.SaveChanges();
                return RedirectToAction("Index","Home");
            }
        }
    }

}