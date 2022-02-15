using WhiskeyAndDucks.Models;

namespace WhiskeyAndDucks.DataAccess
{
    public class ReservationRepository
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

        internal object GetById(int id)
        {
            var match = _reservations.FirstOrDefault(r => r.Id == id);

            return match;
        }

        internal IEnumerable<Reservation> GetByType(OccasionType occasionType)
        {
            var matchingReservations = _reservations.Where(reservation => reservation.Type == occasionType);

            return matchingReservations;
        }

        internal void Post(Reservation newReservation)
        {
            _reservations.Add(newReservation);
        }

        internal List<Reservation> GetAll()
        {
            return _reservations;
        }
    }
}
