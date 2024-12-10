using Microsoft.AspNetCore.Mvc;
using MedicalAppointmentSystem.Models;
using MedicalAppointmentSystem.Repositories;

namespace MedicalAppointmentSystem.Controllers;

public class AppointmentsController : Controller
{
    private readonly AppointmentRepository _repository = new();

    public IActionResult Index()
    {
        var appointments = _repository.GetAll();
        return View(appointments);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Appointment appointment)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(appointment);
            return RedirectToAction(nameof(Index));
        }
        return View(appointment);
    }

    public IActionResult Edit(int id)
    {
        var appointment = _repository.GetById(id);
        if (appointment == null) return NotFound();
        return View(appointment);
    }

    [HttpPost]
    public IActionResult Edit(Appointment appointment)
    {
        if (ModelState.IsValid)
        {
            _repository.Update(appointment);
            return RedirectToAction(nameof(Index));
        }
        return View(appointment);
    }

    public IActionResult Delete(int id)
    {
        var appointment = _repository.GetById(id);
        if (appointment == null) return NotFound();
        return View(appointment);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _repository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}