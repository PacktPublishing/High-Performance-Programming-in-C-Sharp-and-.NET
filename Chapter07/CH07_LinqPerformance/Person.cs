namespace CH07_LinqPerformance
{
	using Newtonsoft.Json;

	public struct Person
	{
		[JsonProperty(PropertyName = "firstName")]
		public string FirstName { get; set; }

		[JsonProperty(PropertyName = "lastName")]
		public string LastName { get; set; }

		[JsonProperty(PropertyName = "fullName")]
		public string FullName { get { return $"{FirstName} {LastName}"; } }

		public Person(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}
}