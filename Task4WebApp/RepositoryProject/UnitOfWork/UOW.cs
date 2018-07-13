using DALProject.Models;
using DALProject.Repositories;

namespace DALProject
{
	//основная задача убедиться, что данніе из одного набора данных
	public class UOW : IUOW
	{
		//private DataSource dataSet = new DataSource();
		private DataSource dataSource;
		private GenRepository<Flight> flightRepository;
		private GenRepository<Departure> departureRepository;
		private GenRepository<Stewardess> stewardessRepository;
		private GenRepository<Pilot> pilotRepository;
		private GenRepository<PlaneType> typeRepository;

		public UOW(DataSource source)
		{
			this.dataSource = source;
		}

		public GenRepository<Flight> FlightRepository
		{
			get
			{
				if (this.flightRepository == null)
				{
					this.flightRepository = new GenRepository<Flight>(dataSource.Flights);
				}
				return this.flightRepository;
			}
		}
		public GenRepository<Departure> DepartureRepository
		{
			get
			{
				if (this.departureRepository == null)
				{
					this.departureRepository = new GenRepository<Departure>(dataSource.Departures);
				}
				return this.departureRepository;
			}
		}
		public GenRepository<Stewardess> StewardessRepository
		{
			get
			{
				if (this.stewardessRepository == null)
				{
					this.stewardessRepository = new GenRepository<Stewardess>(dataSource.Stewardesses);
				}

				return this.stewardessRepository;
			}
		}
		public GenRepository<Pilot> PilotRepository
		{
			get
			{
				if(this.pilotRepository == null)
				{
					this.pilotRepository = new GenRepository<Pilot>(dataSource.Pilots);
				}
				return this.pilotRepository;
			}
		}
		public GenRepository<PlaneType> TypeRepository
		{
			get
			{
				if (this.typeRepository == null)
				{
					this.typeRepository = new GenRepository<PlaneType>(dataSource.PlaneTypes);
				}
				return this.typeRepository;
			}
		}

		//при использовании базі данніх
		public void SaveChanges()
		{
			//this.dataSet.Save();
		}
	}

	
}
