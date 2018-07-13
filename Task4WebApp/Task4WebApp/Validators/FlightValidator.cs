using DTOLibrary.DTOs;
using FluentValidation;

namespace Task4WebApp.Validators
{
	public class FlightValidator:AbstractValidator<FlightDTO>
    {
		public FlightValidator()
		{
			RuleFor(reg => reg.DeparturePoint).NotEmpty();
			RuleFor(reg=>reg.Destination).NotEmpty();
			RuleFor(reg => reg.DepartureTime).LessThan(p => p.ArrivalTime);
			
		}
    }
}
