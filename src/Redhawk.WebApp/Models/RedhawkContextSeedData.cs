using System;
using System.Collections.Generic;
using System.Linq;

namespace Redhawk.WebApp.Models
{
	public class RedhawkContextSeedData
	{
		private RedhawkContext _context;

		public RedhawkContextSeedData(RedhawkContext context)
		{
			_context = context;
		}

		public void EnsureSeedData()
		{
			if (!_context.Trips.Any())
			{
				var usTrip = new Trip()
				{
					Name = "US Trip",
					Created = DateTime.UtcNow,
					Username = "",
					Stops = new List<Stop>()
					{
						new Stop() { Name = "Atlanta, GA", Arrival = new DateTime(2015, 4, 12), Latitude = 33.748995, Longitude = -84.387982, Order = 0 },
						new Stop() { Name = "Orlando, FL", Arrival = new DateTime(2015, 6, 12), Latitude = 34.748995, Longitude = -23.387982, Order = 1 },
						new Stop() { Name = "Seattle, WA", Arrival = new DateTime(2015, 8, 20), Latitude = 65.748995, Longitude = -84.387982, Order = 2 },
						new Stop() { Name = "Lexington, KY", Arrival = new DateTime(2015, 10, 18), Latitude = 13.748995, Longitude = -84.387982, Order = 3 }
					}

				};

				_context.Trips.Add(usTrip);
				_context.Stops.AddRange(usTrip.Stops);

				var ohioTrip = new Trip()
				{
					Name = "Ohio Trip",
					Created = DateTime.UtcNow,
					Username = "",
					Stops = new List<Stop>()
					{
						new Stop() { Name = "Columbus, OH", Arrival = new DateTime(2015, 4, 12), Latitude = 33.748995, Longitude = -84.387982, Order = 0 },
						new Stop() { Name = "Dublin, OH", Arrival = new DateTime(2015, 6, 12), Latitude = 34.748995, Longitude = -23.387982, Order = 1 },
						new Stop() { Name = "Cincinnati, OH", Arrival = new DateTime(2015, 8, 20), Latitude = 65.748995, Longitude = -84.387982, Order = 2 },
						new Stop() { Name = "Cleveland, OH", Arrival = new DateTime(2015, 10, 18), Latitude = 13.748995, Longitude = -84.387982, Order = 3 }
					}

				};

				_context.Trips.Add(ohioTrip);
				_context.Stops.AddRange(ohioTrip.Stops);

				_context.SaveChanges();
			}
		}
	}
}
