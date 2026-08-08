using ConferenceSystem.Models;

namespace ConferenceSystem.Repositories
{
    public class AttendeeVisitRepository
    {
        private static readonly List<AttendeeVisit> _attendees = new();

        public IEnumerable<AttendeeVisit> GetAll() => _attendees;

        public AttendeeVisit? GetById(int id) => _attendees.FirstOrDefault(a => a.Id == id);

        public void Add(AttendeeVisit attendee)
        {
            attendee.Id = _attendees.Count > 0 ? _attendees.Max(a => a.Id) + 1 : 1;
            _attendees.Add(attendee);
        }

        public void Update(AttendeeVisit attendee)
        {
            var existing = GetById(attendee.Id);
            if (existing != null)
            {
                existing.TicketNumber = attendee.TicketNumber;
                existing.FirstName = attendee.FirstName;
                existing.LastName = attendee.LastName;
                existing.Organization = attendee.Organization;
                existing.ContactNumber = attendee.ContactNumber;
                existing.Email = attendee.Email;
                existing.EventName = attendee.EventName;
                existing.CheckInTime = attendee.CheckInTime;
                existing.CheckOutTime = attendee.CheckOutTime;
                existing.Status = attendee.Status;
                existing.Notes = attendee.Notes;
            }
        }
    }
}