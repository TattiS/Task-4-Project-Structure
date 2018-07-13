using DALProject.Models;
using System;
using System.Collections.Generic;

namespace DALProject
{
	public class DataSource
	{
		private IEnumerable<Flight> flights = new List<Flight> {
			new Flight {Id=1, DeparturePoint="Rome", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket { Id = 1, Price=25.00, FlightId=1},
													new Ticket { Id = 2, Price = 35.00, FlightId = 1 },
													new Ticket { Id = 3, Price = 45.00, FlightId = 1 } } },
			new Flight { Id = 2, DeparturePoint = "NY", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket { Id = 4, Price=25.00, FlightId=2},
													new Ticket { Id = 5, Price = 35.00, FlightId = 2 },
													new Ticket { Id = 6, Price = 45.00, FlightId = 2 } }},
			new Flight { Id = 3, DeparturePoint = "Ottawa", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket { Id = 7, Price=25.00, FlightId=3},
													new Ticket { Id = 8, Price = 35.00, FlightId = 3 },
													new Ticket { Id = 9, Price = 45.00, FlightId = 3 } } },
			new Flight {Id=4, DeparturePoint="Rome", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket { Id = 10, Price=25.00, FlightId=4},
													new Ticket { Id = 11, Price = 35.00, FlightId = 4 },
													new Ticket { Id = 12, Price = 45.00, FlightId = 4 } } },
			new Flight { Id = 5, DeparturePoint = "NY", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket { Id = 13, Price=25.00, FlightId=5},
													new Ticket { Id = 15, Price = 35.00, FlightId = 5 },
													new Ticket { Id = 16, Price = 45.00, FlightId = 5 } }  },
			new Flight { Id = 6, DeparturePoint = "Ottawa", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket { Id = 17, Price=25.00, FlightId=6},
													new Ticket { Id = 18, Price = 35.00, FlightId = 6 },
													new Ticket { Id = 19, Price = 45.00, FlightId = 6 } }  }
		};

		private IEnumerable<Departure> departures = new List<Departure> {
			new Departure { Id = 1, FlightId=2, DepartureDate=DateTime.Parse("2018-01-11T15:45:00"), PlaneItem=new Plane { Id = 1, Name="Boeing 787",
				TypeOfPlane =new PlaneType { Id = 2, AirLift=244900 , Model="Boeing 787 Dreamliner", Seats=250  },
				ReleaseDate = DateTime.Parse("2010-10-15"), OperationLife=DateTime.Parse("2022-10-15")-DateTime.Parse("2010-10-15")},
				CrewItem =new Crew{ Id=1, PilotId=1, StewardessesId=new List<int>(){ 1,2,4} } },
			new Departure { Id = 2, FlightId=3, DepartureDate=DateTime.Parse("2018-02-13T11:30:00"), PlaneItem=new Plane { Id = 2, Name="Boeing 737",
				TypeOfPlane =new PlaneType { Id = 1, AirLift=58100 , Model="Boeing 737-200", Seats=130 },
				ReleaseDate = DateTime.Parse("2013-02-01"), OperationLife=DateTime.Parse("2026-02-01")-DateTime.Parse("2013-02-01")},
				CrewItem =new Crew{ Id=2, PilotId=2, StewardessesId=new List<int>(){ 6,3,5} } },
			new Departure { Id = 3, FlightId=5, DepartureDate=DateTime.Parse("2018-01-11T15:45:00"), PlaneItem=new Plane { Id = 3, Name="Boeing 777",
				TypeOfPlane =new PlaneType { Id = 3, AirLift=351800 , Model="Boeing 777-300", Seats=550  },
				ReleaseDate = DateTime.Parse("2012-09-01"), OperationLife=DateTime.Parse("2028-09-01")-DateTime.Parse("2012-09-01")},
				CrewItem =new Crew{ Id=3, PilotId=3, StewardessesId=new List<int>(){ 5,2,4} } }
		};

		private IEnumerable<Pilot> pilots = new List<Pilot> {
			new Pilot { Id = 1, Name="Adam", Surname="Benn", BirthDate=DateTime.Parse("1978-11-01"), Experience= DateTime.Today-DateTime.Parse("2004-12-01") },
			new Pilot { Id = 2, Name="Max", Surname="Payne", BirthDate=DateTime.Parse("1964-06-12"), Experience= DateTime.Today-DateTime.Parse("1987-03-24")},
			new Pilot { Id = 3, Name="Francis", Surname="Castle", BirthDate=DateTime.Parse("1974-02-01"), Experience= DateTime.Today-DateTime.Parse("1992-04-30") }
		};

		private IEnumerable<Stewardess> stewardesses = new List<Stewardess> {
			new Stewardess { Id = 1, Name ="Eve", Surname="Fairy", BirthDate = DateTime.Parse("2001-06-12") },
			new Stewardess { Id = 2, Name ="Samantha", Surname="Simson", BirthDate = DateTime.Parse("1999-12-03") },
			new Stewardess { Id = 3, Name ="Gabrial", Surname="Fate", BirthDate = DateTime.Parse("1998-05-13")  },
			new Stewardess { Id = 1, Name ="Hannah", Surname="Screw", BirthDate = DateTime.Parse("1993-07-08") },
			new Stewardess { Id = 2, Name ="Jennah", Surname="Johns", BirthDate = DateTime.Parse("1996-04-03") },
			new Stewardess { Id = 3, Name ="Ivory", Surname="Rocket", BirthDate = DateTime.Parse("1992-08-19")  }
		};

		private IEnumerable<PlaneType> planeTypes = new List<PlaneType> {
			new PlaneType { Id = 1, AirLift=58100 , Model="Boeing 737-200", Seats=130 },
			new PlaneType { Id = 2, AirLift=244900 , Model="Boeing 787 Dreamliner", Seats=250  },
			new PlaneType { Id = 3, AirLift=351800 , Model="Boeing 777-300", Seats=550  }
		};




		public IEnumerable<Flight> Flights
		{
			get {
				return this.flights;
			}
		}
		public IEnumerable<Departure> Departures
		{
			get {
				return this.departures;
			}
		}
		public IEnumerable<Stewardess> Stewardesses
		{
			get {
				return this.stewardesses;
			}
		}
		public IEnumerable<Pilot> Pilots
		{
			get
			{
				return this.pilots;
			}
		}
		public IEnumerable<PlaneType> PlaneTypes
		{
			get
			{
				return this.planeTypes;
			}
		}
		


	}
}