using MedicalAppointmentSystem.Models;

namespace MedicalAppointmentSystem.Repositories;

public class AppointmentRepository
{
    private static List<Appointment> _appointments = new();

    public List<Appointment> GetAll() => _appointments;

    public Appointment? GetById(int id) => _appointments.FirstOrDefault(a => a.Id == id);

    public void Add(Appointment appointment)
    {
        appointment.Id = _appointments.Count > 0 ? _appointments.Max(a => a.Id) + 1 : 1;
        _appointments.Add(appointment);
    }

    public void Update(Appointment appointment)
    {
        var existing = GetById(appointment.Id);
        if (existing != null)
        {
            existing.PatientName = appointment.PatientName;
            existing.DoctorName = appointment.DoctorName;
            existing.AppointmentDate = appointment.AppointmentDate;
            existing.Status = appointment.Status;
        }
    }

    public void Delete(int id) => _appointments.RemoveAll(a => a.Id == id);
}