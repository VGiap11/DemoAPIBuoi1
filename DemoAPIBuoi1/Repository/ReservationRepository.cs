using DemoAPIBuoi1.Model;
using DemoAPIBuoi1.Repository.IRepository;

namespace DemoAPIBuoi1.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private Dictionary<int , Reservation> reservations;
        public ReservationRepository() 
        {
            reservations = new Dictionary<int, Reservation>();
            new List<Reservation>() {
                new Reservation() {Id = 1, Name ="ThepV",StartLocation="Ha Noi",EndLocation="Thai Binh" },
                new Reservation() {Id = 2, Name="Fpoly",StartLocation="Ha Noi",EndLocation="Ha Noi" }
            }.ForEach(r => AddReservation(r));
        
        }
        public Reservation this[int id] => reservations.ContainsKey(id) ? reservations[id] : null;

        public IEnumerable<Reservation> Reservations => reservations.Values;

        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.Id == 0)
            {
                int key = reservations.Count();
                while(reservations.ContainsKey(key)) { key++; }
                reservation.Id = key;
            }
            reservations[reservation.Id] = reservation;
            return reservation;
        }

        public void DeleteReservation(int id) => reservations.Remove(id);

        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);
        
    }
}
