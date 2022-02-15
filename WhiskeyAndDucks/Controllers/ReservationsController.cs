using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhiskeyAndDucks.DataAccess;
using WhiskeyAndDucks.Models;

namespace WhiskeyAndDucks.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        ReservationRepository _reservationRepo = new ReservationRepository();
        WhiskeyRepository _whiskeyRepo = new WhiskeyRepository();

        [HttpGet]
        public List<Reservation> GetAllReservations()
        {
            return _reservationRepo.GetAll();
        }

        [HttpGet("type/{occasionType}")]
        public IActionResult GetReservationByType(OccasionType occasionType)
        {
            var matches = _reservationRepo.GetByType(occasionType);

            if (matches != null) {
                return Ok(matches);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetReservationById(int id)
        {
            var match = _reservationRepo.GetById(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);

        }

        [HttpPost]
        public IActionResult PostNewReservation(Reservation newReservation)
        {
            if (newReservation == null)
            {
                return NotFound();
            }
            else if (!ValidNewReservation(newReservation))
            {
                return BadRequest();
            }
            else
            {
                _reservationRepo.Post(newReservation);
                return Ok(newReservation);
            }
            
        }

        private bool ValidNewReservation(Reservation newReservation)
        {
            if (_reservationRepo.GetById(newReservation.Id) != null)
            {
                return false;
            }

            if (newReservation.Whiskey != null)
            {
                if (_whiskeyRepo.GetByName(newReservation.Whiskey.Name) == null)
                {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(newReservation.Name) || newReservation.Date < DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}
