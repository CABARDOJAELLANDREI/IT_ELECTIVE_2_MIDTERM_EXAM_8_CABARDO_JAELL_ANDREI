using System.ComponentModel.DataAnnotations;

namespace ConferenceSystem.Models
{
    public enum AttendeeStatus
    {
        Present,
        [Display(Name = "Left Event")]
        LeftEvent
    }

    public class AttendeeVisit
    {
        public int Id { get; set; }

        [Required, Display(Name = "Ticket Number")]
        public string TicketNumber { get; set; } = string.Empty;

        [Required, Display(Name = "First Name"), StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, Display(Name = "Last Name"), StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, Display(Name = "Company/School")]
        public string Organization { get; set; } = string.Empty;

        [Required, Phone, Display(Name = "Contact Number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, Display(Name = "Event Name")]
        public string EventName { get; set; } = string.Empty;

        [Required, DataType(DataType.DateTime), Display(Name = "Check-In Time")]
        public DateTime CheckInTime { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime), Display(Name = "Check-Out Time")]
        public DateTime? CheckOutTime { get; set; }

        public AttendeeStatus Status { get; set; } = AttendeeStatus.Present;

        [StringLength(250)]
        public string? Notes { get; set; }
    }
}