using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json.Converters;

namespace TheProjectToSend.Models
{
	public class Gender
	{
		public int GenderId { get; set; }
		public string Name { get; set; }		
		public List<Person> Person { get; set; }
	}
	
	
}

