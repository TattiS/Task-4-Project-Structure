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
				//c.CreateMap<Pilot, PilotDTO>().ForMember(e => e.StartedIn, opt => opt.MapFrom(src => (DateTime.Today.Subtract(src.Experience))));
				c.CreateMap<Pilot, PilotDTO>().ForMember(e => e.StartedIn, opt => opt.Ignore());
				c.CreateMap<PilotDTO,Pilot>().ForMember(e => e.Experience, opt => opt.MapFrom(src => (DateTime.Today.Subtract(src.StartedIn))));
				c.CreateMap<Plane, PlaneDTO>().ForMember(e => e.ExpiryDate, opt => opt.Ignore());
				c.CreateMap<PlaneDTO, Plane>().ForMember(e=>e.OperationLife, opt=> opt.MapFrom(src=> (src.ExpiryDate.Subtract(src.ReleaseDate))));
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

		public List<FlightDTO> GetFlights()
		{
			List<Flight> result = unitOfWork.FlightRepository.GetAll();
			return mapper.Map<List<Flight>,List<FlightDTO>>(result);
		}
		public FlightDTO GetFlightById(int id)
		{
			FlightDTO result;
			result = mapper.Map<Flight,FlightDTO>(unitOfWork.FlightRepository.GetById(id));
			return result;
		}
		public List<FlightDTO> GetFlightsByPoint(string departurePoint)
		{
			List<FlightDTO> result;
			result = mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.GetBy(f => f.DeparturePoint == departurePoint));
			return result;
		}
		public List<FlightDTO> GetFlightsByDeparture(DateTime time)
		{
			List<FlightDTO> result;
			result = mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.GetBy(f => f.DepartureTime == time));
			return result;
		}
		public List<FlightDTO> GetFlightsByDestination(string destination)
		{
			List<FlightDTO> result;
			result = mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.GetBy(f => f.Destination == destination));
			return result;
		}
		public List<FlightDTO> GetFlightsByArrival(DateTime time)
		{
			List<FlightDTO> result;
			result = mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.GetBy(f => f.ArrivalTime == time));
			return result;
		}
		public void CreateFlight(FlightDTO flight)
		{
			if (flight == null)
			{
				Flight newFlight = mapper.Map<FlightDTO, Flight>(flight);
				unitOfWork.FlightRepository.Create(newFlight);
			}
		}
		public void UpdateFlight(FlightDTO flight)
		{
			if(flight != null)
			{
				Flight insertingFlight = mapper.Map<FlightDTO, Flight>(flight);
				unitOfWork.FlightRepository.Insert(insertingFlight);
			}
		}
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
		public List<DepartureDTO> GetDepartures()
		{
			List<Departure> result = unitOfWork.DepartureRepository.GetAll();
			return mapper.Map<List<Departure>, List<DepartureDTO>>(result);
		}
		public DepartureDTO GetDepartureById(int id)
		{
			Departure departure = unitOfWork.DepartureRepository.GetById(id);
			return mapper.Map<Departure, DepartureDTO>(departure);
		}
		public void CreateDeparture(DepartureDTO departure)
		{
			if (departure != null)
			{
				Departure newDepart = mapper.Map<DepartureDTO, Departure>(departure);
				unitOfWork.DepartureRepository.Insert(newDepart);
			}
		}
		public void UpdateDeparture(DepartureDTO departure)
		{
			if (departure != null)
			{
				Departure updatedDepart = mapper.Map<DepartureDTO, Departure>(departure);
				unitOfWork.DepartureRepository.Insert(updatedDepart);
			}
		}
		public void DeleteDeparture(int id)
		{
			if (unitOfWork.DepartureRepository.GetById(id) != null)
			{
				unitOfWork.DepartureRepository.Delete(id);
			}
			
		}
		#endregion

		#region stewardesses
		public List<StewardessDTO> GetStewardesses()
		{
			List<Stewardess> stewardesses = unitOfWork.StewardessRepository.GetAll();
			return mapper.Map<List<Stewardess>, List<StewardessDTO>>(stewardesses);
		}
		public StewardessDTO GetStewardessById(int id)
		{
			Stewardess stewardess = unitOfWork.StewardessRepository.GetById(id);
			return mapper.Map<Stewardess, StewardessDTO>(stewardess);
		}
		public void CreateStewardess(StewardessDTO stewardess)
		{
			if(stewardess != null)
			{
				Stewardess newStewardess = mapper.Map<StewardessDTO, Stewardess>(stewardess);
				unitOfWork.StewardessRepository.Create(newStewardess);
			}
		}
		public void UpdateStewardess(StewardessDTO stewardess)
		{
			if (stewardess != null)
			{
				Stewardess updtStewardess = mapper.Map<StewardessDTO, Stewardess>(stewardess);
				unitOfWork.StewardessRepository.Insert(updtStewardess);
			}

		}
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
		public List<PilotDTO> GetPilots()
		{
			List<Pilot> pilots = unitOfWork.PilotRepository.GetAll();
			return mapper.Map<List<Pilot>, List<PilotDTO>>(pilots);
		}
		public PilotDTO GetPilotById(int id)
		{
			Pilot pilot = unitOfWork.PilotRepository.GetById(id);
			return mapper.Map<Pilot, PilotDTO>(pilot);
		}
		public void CreatePilot(PilotDTO pilot)
		{
			if (pilot != null)
			{
				Pilot newPilot = mapper.Map<PilotDTO, Pilot>(pilot);
				unitOfWork.PilotRepository.Create(newPilot);
			}
		}
		public void UpdatePilot(PilotDTO pilot)
		{
			if (pilot != null)
			{
				Pilot updtPilot = mapper.Map<PilotDTO, Pilot>(pilot);
				unitOfWork.PilotRepository.Insert(updtPilot);
			}

		}

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
		public List<PlaneTypeDTO> GetPlaneTypes()
		{
			List<PlaneType> planeTypes = unitOfWork.TypeRepository.GetAll();
			return mapper.Map<List<PlaneType>, List<PlaneTypeDTO>>(planeTypes);
		}
		public PlaneTypeDTO GetPlaneTypeById(int id)
		{
			PlaneType type = unitOfWork.TypeRepository.GetById(id);
			return mapper.Map<PlaneType, PlaneTypeDTO>(type);
		}
		public void CreatePlaneType(PlaneTypeDTO planeType)
		{
			if (planeType != null)
			{
				PlaneType newPlaneType = mapper.Map<PlaneTypeDTO, PlaneType>(planeType);
				unitOfWork.TypeRepository.Create(newPlaneType);
			}
		}

		public void UpdateType(PlaneTypeDTO planeType)
		{
			if (planeType != null)
			{
				PlaneType updtPlaneType = mapper.Map<PlaneTypeDTO, PlaneType>(planeType);
				unitOfWork.TypeRepository.Insert(updtPlaneType);
			}

		}

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
		public List<TicketDTO> GetTickets()
		{
			List<Flight> flights = unitOfWork.FlightRepository.GetAll().FindAll(p => p.Tickets != null && p.Tickets.Count>0);
			if (flights != null && flights.Count > 0)
			{
				var tickets = new List<Ticket>();
				foreach (var item in flights)
				{
					tickets.AddRange(item.Tickets);
				}
				return mapper.Map<List<Ticket>, List<TicketDTO>>(tickets);
			}
			else
			{
				throw new Exception("Error: There are no tickets.");
			}

		}
		public List<TicketDTO> GetTicketsByFlightId(int flightId)
		{
			List<Ticket> tickets = unitOfWork.FlightRepository.GetById(flightId).Tickets;
			return mapper.Map<List<Ticket>, List<TicketDTO>>(tickets);
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
		public void UpdateTicket(TicketDTO value)
		{
			if (value != null)
			{
				Ticket changedTicket = mapper.Map<TicketDTO, Ticket>(value);
				var tickets = unitOfWork.FlightRepository.GetById(value.FlightId).Tickets;
				var ticket = tickets.Find(k => k.Id == value.Id);
				if (ticket != null)
				{
					tickets.Remove(ticket);
					tickets.Add(changedTicket);
				}
				else
				{
					throw new Exception("Error: There is no such ticket in this flight.");
				}
 			}
			else
			{
				throw new ArgumentNullException();
			}
		}
		public void DeleteTicket(int id)
		{
			var tickets = unitOfWork.FlightRepository.GetAll().Find(p => p.Tickets.Exists(i => i.Id == id)).Tickets;
			if (tickets != null && tickets.Count > 0)
			{
				tickets.RemoveAll(p => p.Id == id);
			}
			else
			{
				throw new Exception("Error: There is no the ticket with such id.");
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
		public void UpdateCrew(CrewDTO value)
		{
			if (value != null)
			{
				Crew newCrew = mapper.Map<CrewDTO, Crew>(value);
				unitOfWork.DepartureRepository.GetBy(p => p.CrewItem.Id.Equals(value.Id)).ForEach(c => c.CrewItem = newCrew);
			}
			else
			{
				throw new ArgumentNullException();
			}
		}

		public void DeleteCrew(int id)
		{
			var itemsToDelete = unitOfWork.DepartureRepository.GetAll().FindAll(p=>p.CrewItem.Id == id);
			if (itemsToDelete != null && itemsToDelete.Count>0)
			{
				unitOfWork.DepartureRepository.DeleteAll(p=>p.CrewItem.Id==id);
			}
			else
			{
				throw new Exception("Can't find such crew!");
			}
		}
		#endregion

		#region plane
		public List<PlaneDTO> GetPlanes()
		{
			var departures = unitOfWork.DepartureRepository.GetBy(p=>p.PlaneItem != null);
			List<Plane> planes = new List<Plane>();
			if (departures != null && departures.Count > 0)
			{
				foreach (var item in departures)
				{
					planes.Add(item.PlaneItem);
				}
				return mapper.Map<List<Plane>, List<PlaneDTO>>(planes);
			}
			else
			{
				throw new Exception("Error: There isn't any plane.");
			}
			
		}
		public PlaneDTO GetPlaneById(int id)
		{
			return GetPlanes().Find(p => p.Id == id);
		}
		public void CreatePlane(int departId, PlaneDTO value)
		{
			var departure = unitOfWork.DepartureRepository.GetById(departId);
			if (departure != null)
			{
				var plane = mapper.Map<PlaneDTO, Plane>(value);
				if (plane == null)
				{
					throw new Exception("Error: Can't add this crew to the the departure!");
				}
				departure.PlaneItem = plane;
			}
			else
			{
				throw new Exception("Error: Can't find such departure!");
			}
		}

		public void UpdatePlane(PlaneDTO value)
		{
			if (value != null)
			{
				Plane newPlane = mapper.Map<PlaneDTO, Plane>(value);
				unitOfWork.DepartureRepository.GetBy(p => p.PlaneItem.Id.Equals(value.Id)).ForEach(c => c.PlaneItem = newPlane);
			}
			else
			{
				throw new ArgumentNullException();
			}
		}

		public void DeletePlane(int id)
		{
			var itemsToDelete = unitOfWork.DepartureRepository.GetAll().FindAll(p => p.PlaneItem.Id == id);
			if (itemsToDelete != null && itemsToDelete.Count > 0)
			{
				unitOfWork.DepartureRepository.DeleteAll(p => p.PlaneItem.Id == id);
			}
			else
			{
				throw new Exception("Can't find such plane!");
			}
		}
		#endregion
	}
}
