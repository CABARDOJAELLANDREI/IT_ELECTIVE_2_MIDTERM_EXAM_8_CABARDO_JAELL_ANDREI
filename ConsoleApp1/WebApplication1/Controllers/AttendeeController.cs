using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ConferenceSystem.Models;
using ConferenceSystem.Repositories;

namespace ConferenceSystem.Controllers
{
    [Authorize]
    public class AttendeeController : Controller
    {
        private readonly AttendeeVisitRepository _attendeeRepo = new();

        public IActionResult Index(string searchString)
        {
            var attendees = _attendeeRepo.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                attendees = attendees.Where(a =>
                    a.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    a.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    a.TicketNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    a.Organization.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }
            return View(attendees);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(AttendeeVisit attendee)
        {
            if (ModelState.IsValid)
            {
                _attendeeRepo.Add(attendee);
                return RedirectToAction(nameof(Index));
            }
            return View(attendee);
        }

        public IActionResult Edit(int id)
        {
            var attendee = _attendeeRepo.GetById(id);
            if (attendee == null) return NotFound();
            return View(attendee);
        }

        [HttpPost]
        public IActionResult Edit(AttendeeVisit attendee)
        {
            if (ModelState.IsValid)
            {
                _attendeeRepo.Update(attendee);
                return RedirectToAction(nameof(Index));
            }
            return View(attendee);
        }

        public IActionResult Details(int id)
        {
            var attendee = _attendeeRepo.GetById(id);
            if (attendee == null) return NotFound();
            return View(attendee);
        }

        public IActionResult Checkout(int id)
        {
            var attendee = _attendeeRepo.GetById(id);
            if (attendee == null) return NotFound();

            attendee.CheckOutTime = DateTime.Now;
            attendee.Status = AttendeeStatus.LeftEvent;
            _attendeeRepo.Update(attendee);

            return RedirectToAction(nameof(Index));
        }
    }
}