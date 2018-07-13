using DALProject;
using DALProject.Models;
using System;
using System.Collections.Generic;
using AutoMapper;
using DTOLibrary.DTOs;

namespace AirportService
{
    public class AirportService : IAirportService
	{

		private static UOW unitOfWork = new UOW(new DataSource());
		private static IMapper mapper;
		public AirportService()
		{
			
			var mapConfig = new MapperConfiguration(c =>
			{
				c.CreateMap<Flight, FlightDTO>().ReverseMap();
				c.CreateMap<Departure, DepartureDTO>().ReverseMap();
				c.CreateMap<Ticket, TicketDTO>().ReverseMap();
				c.CreateMap<Crew, CrewDTO>().ReverseMap();
				c.CreateMap<Pilot, PilotDTO>().ForMember(e => e.StartedIn, opt => opt.MapFrom(src=> (DateTime.Today.Subtract(src.Experience))));
				c.CreateMap<PilotDTO,Pilot>().ForMember(e => e.Experience, opt => opt.MapFrom(src => (DateTime.Today-src.StartedIn))).ReverseMap();
				c.CreateMap<Plane, PlaneDTO>().ReverseMap();
				c.CreateMap<Stewardess, StewardessDTO>().ReverseMap();
				c.CreateMap<PlaneType, PlaneTypeDTO>().ReverseMap();
			});
			mapConfig.AssertConfigurationIsValid();
			if (mapper == null)
			{
				mapper = mapConfig.CreateMapper();
			}
			
		}

		#region flights

		//GET: /api/flights
		public List<FlightDTO> GetFlights()
		{
			List<Flight> result = unitOfWork.FlightRepository.GetAll();
			return mapper.Map<List<Flight>,List<FlightDTO>>(result);
		}
		//GET: /api/flights/:id
		public FlightDTO GetFlightById(int id)
		{
			FlightDTO result;
			result = mapper.Map<Flight,FlightDTO>(unitOfWork.FlightRepository.GetById(id));
			return result;
		}

		//GET: /api/flights/:departure-point
		public List<FlightDTO> GetFlightsByPoint(string departurePoint)
		{
			List<FlightDTO> result;
			result = mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.GetBy(f => f.DeparturePoint == departurePoint));
			return result;
		}
		//GET: /api/flights/:departure-time
		public List<FlightDTO> GetFlightsByDeparture(DateTime time)
		{
			List<FlightDTO> result;
			result = mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.GetBy(f => f.DepartureTime == time));
			return result;
		}
		//GET: /api/flights/:destination
		public List<FlightDTO> GetFlightsByDestination(string destination)
		{
			List<FlightDTO> result;
			result = mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.GetBy(f => f.Destination == destination));
			return result;
		}
		//GET: /api/flights/:arrival-time
		public List<FlightDTO> GetFlightsByArrival(DateTime time)
		{
			List<FlightDTO> result;
			result = mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.GetBy(f => f.ArrivalTime == time));
			return result;
		}
		//POST: /api/flights/
		//BODY:{ departurePoint: string, departureTime: DateTime, destination: string, arrivalTime: DateTime, ticketItem: List<Ticket>}
		public void CreateFlight(FlightDTO flight)
		{
			if (flight == null)
			{
				Flight newFlight = mapper.Map<FlightDTO, Flight>(flight);
				unitOfWork.FlightRepository.Create(newFlight);
			}
		}
		//PUT: /api/flights/:id
		//BODY:{ id: int, departurePoint: string, departureTime: DateTime, destination: string, arrivalTime: DateTime, ticketItem: List<Ticket >}
		public void UpdateFlight(FlightDTO flight)
		{
			if(flight != null)
			{
				Flight insertingFlight = mapper.Map<FlightDTO, Flight>(flight);
				unitOfWork.FlightRepository.Insert(insertingFlight);
			}
		}
		//DELETE: /api/flights/:id
		public void DeleteFlight(int id)
		{
			Flight flightToDelete = unitOfWork.FlightRepository.GetById(id);
			if (flightToDelete != null)
			{
				unitOfWork.DepartureRepository.DeleteAll(p => p.FlightId == id);
				unitOfWork.FlightRepository.Delete(id);
			}
			
			
		}

		#endregion flights
		#region departures
		//		GET: /api/departures
		public List<DepartureDTO> GetDepartures()
		{
			List<Departure> result = unitOfWork.DepartureRepository.GetAll();
			return mapper.Map<List<Departure>, List<DepartureDTO>>(result);
		}
		//GET: /api/departures/:id
		public DepartureDTO GetDepartureById(int id)
		{
			Departure departure = unitOfWork.DepartureRepository.GetById(id);
			return mapper.Map<Departure, DepartureDTO>(departure);
		}
		//POST: /api/departures
		public void CreateDeparture(DepartureDTO departure)
		{
			if (departure != null)
			{
				Departure newDepart = mapper.Map<DepartureDTO, Departure>(departure);
				unitOfWork.DepartureRepository.Insert(newDepart);
			}
		}
		//	PUT: /api/departures/:id
		public void UpdateDeparture(DepartureDTO departure)
		{
			if (departure != null)
			{
				Departure updatedDepart = mapper.Map<DepartureDTO, Departure>(departure);
				unitOfWork.DepartureRepository.Insert(updatedDepart);
			}
		}
		//	DELETE: /api/departures/:id
		public void DeleteDeparture(int id)
		{
			if (unitOfWork.DepartureRepository.GetById(id) != null)
			{
				unitOfWork.DepartureRepository.Delete(id);
			}
			
		}
		#endregion
		#region stewardesses
		//		GET: /api/stewardesses
		public List<StewardessDTO> GetStewardesses()
		{
			List<Stewardess> stewardesses = unitOfWork.StewardessRepository.GetAll();
			return mapper.Map<List<Stewardess>, List<StewardessDTO>>(stewardesses);
		}
		//	GET: /api/stewardesses/:id
		public StewardessDTO GetStewardessById(int id)
		{
			Stewardess stewardess = unitOfWork.StewardessRepository.GetById(id);
			return mapper.Map<Stewardess, StewardessDTO>(stewardess);
		}
		//	GET: /api/stewardesses/:name
		//	GET: /api/stewardesses/:surname
		//	GET: /api/stewardesses/:birth-date

		//	POST: /api/stewardesses
		//	BODY
		public void CreateStewardess(StewardessDTO stewardess)
		{
			if(stewardess != null)
			{
				Stewardess newStewardess = mapper.Map<StewardessDTO, Stewardess>(stewardess);
				unitOfWork.StewardessRepository.Create(newStewardess);
			}
		}
		//	PUT: /api/stewardesses/:id
		//BODY
		//	{
		//		id:int,
		//name: string,
		//surname: string,
		//birthDate: DateTime
		//	}
		public void UpdateStewardess(StewardessDTO stewardess)
		{
			if (stewardess != null)
			{
				Stewardess updtStewardess = mapper.Map<StewardessDTO, Stewardess>(stewardess);
				unitOfWork.StewardessRepository.Insert(updtStewardess);
			}

		}
		//	DELETE: api/stewardesses/:id
		public void DeleteStewardess(int id)
		{
			Stewardess stewardessToDelete = unitOfWork.StewardessRepository.GetById(id);
			if(stewardessToDelete != null)
			{
				//unitOfWork.DepartureRepository.GetBy(s => s.CrewItem.StewardessesId.Contains(id)).ForEach(d => d.CrewItem.StewardessesId.RemoveAll(i => i.Equals(id)));
				unitOfWork.StewardessRepository.Delete(id);
			}
		}
		#endregion
		#region pilots
		//		GET: /api/pilots
		public List<PilotDTO> GetPilots()
		{
			List<Pilot> pilots = unitOfWork.PilotRepository.GetAll();
			return mapper.Map<List<Pilot>, List<PilotDTO>>(pilots);
		}
		//GET: /api/pilots/:id
		public PilotDTO GetPilotById(int id)
		{
			Pilot pilot = unitOfWork.PilotRepository.GetById(id);
			return mapper.Map<Pilot, PilotDTO>(pilot);
		}

		//GET: /api/pilots/:name
		//GET: /api/pilots/:surname
		//GET: /api/pilots/:birth-date
		//GET: /api/pilots/:experience

		//POST: api/pilots
		//BODY
		public void CreatePilot(PilotDTO pilot)
		{
			if (pilot != null)
			{
				Pilot newPilot = mapper.Map<PilotDTO, Pilot>(pilot);
				unitOfWork.PilotRepository.Create(newPilot);
			}
		}

		//	PUT: api/pilots/:id
		//	BODY
		public void UpdatePilot(PilotDTO pilot)
		{
			if (pilot != null)
			{
				Pilot updtPilot = mapper.Map<PilotDTO, Pilot>(pilot);
				unitOfWork.PilotRepository.Insert(updtPilot);
			}

		}

		//	DELETE: api/pilots/:id
		public void DeletePilot(int id)
		{
			Pilot pilotToDelete = unitOfWork.PilotRepository.GetById(id);
			if (pilotToDelete != null)
			{
				//unitOfWork.DepartureRepository.GetBy(s => s.CrewItem.PilotId.Equals(id)).ForEach(p=> p.CrewItem.PilotId=0);
				unitOfWork.PilotRepository.Delete(id);
			}
		}

		#endregion
		#region plane-types
		//		GET: /api/plane-types
		public List<PlaneTypeDTO> GetPlaneTypes()
		{
			List<PlaneType> planeTypes = unitOfWork.TypeRepository.GetAll();
			return mapper.Map<List<PlaneType>, List<PlaneTypeDTO>>(planeTypes);
		}
		//GET: /api/plane-types/:id
		public PlaneTypeDTO GetPlaneTypeById(int id)
		{
			PlaneType type = unitOfWork.TypeRepository.GetById(id);
			return mapper.Map<PlaneType, PlaneTypeDTO>(type);
		}

		//GET: /api/plane-types/model/:model
		//GET: /api/plane-types/:seats
		//GET: /api/plane-types/:airlift

		//POST: /api/plane-types
		//BODY
		public void CreatePlaneType(PlaneTypeDTO planeType)
		{
			if (planeType != null)
			{
				PlaneType newPlaneType = mapper.Map<PlaneTypeDTO, PlaneType>(planeType);
				unitOfWork.TypeRepository.Create(newPlaneType);
			}
		}

		//	PUT: /api/plane-types/:id
		//	BODY
		public void UpdateType(PlaneTypeDTO planeType)
		{
			if (planeType != null)
			{
				PlaneType updtPlaneType = mapper.Map<PlaneTypeDTO, PlaneType>(planeType);
				unitOfWork.TypeRepository.Insert(updtPlaneType);
			}

		}

		//	DELETE: /api/plane-types/:id
		public void DeletePlaneType(int id)
		{
			PlaneType typeToDelete = unitOfWork.TypeRepository.GetById(id);
			if (typeToDelete != null)
			{
				unitOfWork.TypeRepository.Delete(id);
			}
		}

		#endregion
		#region ticket
		//		GET: /api/flights/:id/ticket
		public IEnumerable<TicketDTO> GetTicketsByFlightId(int flightId)
		{
			IEnumerable<Ticket> tickets = unitOfWork.FlightRepository.GetById(flightId).Tickets;
			return mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(tickets);
		}

		public void CreateTicket(int flightId, TicketDTO value)
		{
			var tickets = unitOfWork.FlightRepository.GetById(flightId).Tickets;
			if (tickets != null)
			{
				var ticket = mapper.Map<TicketDTO, Ticket>(value);
				if (ticket == null)
				{
					throw new Exception("Error: Can't add this ticket to the the flight!");
				}
				tickets.Add(ticket);
			}
			else
			{
				throw new Exception("Error: Can't find such flight!");
			}
		}

		#endregion

		#region crew
		public List<CrewDTO> GetCrews()
		{
			List<Crew> crews = new List<Crew>();
			foreach (var i in unitOfWork.DepartureRepository.GetAll())
			{
				if (i.CrewItem != null)
				{ crews.Add(i.CrewItem); }
			}
			return mapper.Map<List<Crew>, List<CrewDTO>>(crews);
		}

		public CrewDTO GetCrewById(int id)
		{
			return GetCrews().Find(p => p.Id == id);
		}
		public List<CrewDTO> GetCrewsBy(Predicate<CrewDTO>  predicate)
		{
			return GetCrews().FindAll(predicate);
		}

		public void CreateCrew(int departId, CrewDTO value)
		{
			var departure = unitOfWork.DepartureRepository.GetById(departId);
			if (departure != null)
			{
				var crew = mapper.Map<CrewDTO, Crew>(value);
				if (crew == null)
				{
					throw new Exception("Error: Can't add this crew to the the departure!");
				}
				departure.CrewItem = crew;
			}
			else
			{
				throw new Exception("Error: Can't find such departure!");
			}
		}
		#endregion
		#region plane
		//		GET: /api/departures/:id/plane
		//GET: /api/departures/:plane-id
		//GET: /api/departures/:plane-type-id
		//GET: /api/departures/:plane-type-model
		//GET: /api/departures/:plane-type-seats
		//GET: /api/departures/:plane-type-airlift
		//GET: /api/departures/:plane-release
		//GET: /api/departures/:plane-operation-life

		//POST: /api/departures/:id/plane
		//BODY
		//		{
		//			name: string,
		//typeOfPlane: PlaneType,
		//releaseDate: DateTime,
		//operationLife: TimeSpan
		//	}
		//	PUT: /api/departures/:plane-id
		//	BODY
		//	{
		//		id: int,
		//name: string,
		//typeOfPlane: PlaneType,
		//releaseDate: DateTime,
		//operationLife: TimeSpan
		//	}

		//	DELETE: /api/departures/:id/plane

		#endregion
	}
}
