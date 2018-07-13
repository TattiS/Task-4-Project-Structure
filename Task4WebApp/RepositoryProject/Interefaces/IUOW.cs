using DALProject.Models;
using DALProject.Repositories;

namespace DALProject
{
	public interface IUOW
	{
		GenRepository<Departure> DepartureRepository { get; }
		GenRepository<Flight> FlightRepository { get; }
		GenRepository<Pilot> PilotRepository { get; }
		GenRepository<Stewardess> StewardessRepository { get; }
		GenRepository<PlaneType> TypeRepository { get; }

		void SaveChanges();
	}
}