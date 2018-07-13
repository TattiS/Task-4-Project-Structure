using System;
using System.Collections.Generic;
using DALProject.Models;
using DTOLibrary.DTOs;

namespace AirportService
{
	public interface IAirportService
	{
		void CreateFlight(FlightDTO flight);
		void UpdateFlight(FlightDTO flight);
		void DeleteFlight(int id);
		FlightDTO GetFlightById(int id);
		List<FlightDTO> GetFlights();
		List<FlightDTO> GetFlightsByArrival(DateTime time);
		List<FlightDTO> GetFlightsByDeparture(DateTime time);
		List<FlightDTO> GetFlightsByDestination(string destination);
		List<FlightDTO> GetFlightsByPoint(string departurePoint);


	}
}