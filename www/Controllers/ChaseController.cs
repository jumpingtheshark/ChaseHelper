using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChaseHelper;
using Newtonsoft.Json;

namespace www.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ChaseController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<ChaseController> _logger;

		public ChaseController(ILogger<ChaseController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[Route("hi")]
		public string hi()
		{
			ChaseProcessor cp= new ChaseHelper.ChaseProcessor( @"c:\a2\f.csv", @"c:\a2\bills.json");
			cp.loadData();
			cp.daysDiscrete(-30);
		string s=	JsonConvert.SerializeObject(cp.dailySpendingList, Formatting.Indented);
			return s;
			//[  cp.dailySpendingList.ToList()

			

		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
