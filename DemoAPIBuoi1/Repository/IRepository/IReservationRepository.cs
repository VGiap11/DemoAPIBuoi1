using DemoAPIBuoi1.Model;

namespace DemoAPIBuoi1.Repository.IRepository
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> Reservations { get; }
        Reservation this[int id] { get; }
        Reservation AddReservation (Reservation reservation);
        Reservation UpdateReservation (Reservation reservation);
        void DeleteReservation (int id);
    }
}
