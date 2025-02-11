using DemoAPIBuoi1.Model;
using DemoAPIBuoi1.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoBuoi1WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationRepository reservationRepository;
        public ReservationController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get() => reservationRepository.Reservations;

        [HttpGet("{Id}")]
        public ActionResult<Reservation> Get(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            return Ok(reservationRepository[Id]);
        }

        [HttpPost]
        public Reservation Post([FromBody] Reservation reservation) =>
            reservationRepository.AddReservation(
                    new Reservation
                    {
                        Name = reservation.Name,
                        StartLocation = reservation.StartLocation,
                        EndLocation = reservation.EndLocation,
                    }

            );

        [HttpPut]
        public Reservation Put([FromBody] Reservation res) => reservationRepository.UpdateReservation(res);

        [HttpDelete]
        public void Delete(int Id) => reservationRepository.DeleteReservation(Id);
    }
}
