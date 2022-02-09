using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhiskeyAndDucks.Models;

namespace WhiskeyAndDucks.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static List<Reservation> _reservations = new List<Reservation>()
        {
            new Reservation()
            {
                ClubMember = true,
                Date = DateTime.Now,
                GroupSize = 4,
                Id = 1,
                Name = "Brian",
                Type = OccasionType.None
            },
            new Reservation()
            {
                ClubMember = false,
                Date = DateTime.Now.AddDays(7),
                GroupSize = 10,
                Id = 2,
                Name = "Nissa",
                Type = OccasionType.Graduation
            },
            new Reservation()
            {
                ClubMember = true,
                Date = DateTime.Now.AddMonths(1),
                GroupSize = 6,
                Id = 3,
                Name = "Madden",
                Type = OccasionType.None
            },
            new Reservation()
            {
                ClubMember = true,
                Date = DateTime.Now.AddDays(6),
                GroupSize = 2,
                Id = 4,
                Name = "Joe",
                Type = OccasionType.Anniversary
            },
        };

        [HttpGet]
        public List<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        [HttpGet("type/{occasionType}")]
        public IEnumerable<Reservation> GetReservationByType(OccasionType occasionType)
        {
            var matchingReservations =  _reservations.Where(reservation => reservation.Type == occasionType);

            return matchingReservations;
        }

        [HttpGet("{id}")]
        public IActionResult GetReservationById(int id)
        {
            var match = _reservations.FirstOrDefault( r => r.Id == id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);

        }

        [HttpPost]
        public IActionResult PostNewReservation(Reservation newReservation)
        {
            _reservations.Add(newReservation);

            return Ok(newReservation);
        }
    }
}
