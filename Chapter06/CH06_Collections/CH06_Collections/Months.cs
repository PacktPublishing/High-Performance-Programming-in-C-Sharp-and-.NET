namespace CH06_Collections
{
	using System.Collections.Generic;

	internal class Months
	{
		public IEnumerable<Month> MonthsOfYear
		{
			get
			{
				yield return new Month { Name = "January", MonthOfYear = 1 };
				yield return new Month { Name = "February", MonthOfYear = 2 };
				yield return new Month { Name = "March", MonthOfYear = 3 };
				yield return new Month { Name = "April", MonthOfYear = 4 };
				yield return new Month { Name = "May", MonthOfYear = 5 };
				yield return new Month { Name = "June", MonthOfYear = 6 };
				yield return new Month { Name = "July", MonthOfYear = 7 };
				yield return new Month { Name = "August", MonthOfYear = 8 };
				yield return new Month { Name = "September", MonthOfYear = 9 };
				yield return new Month { Name = "October", MonthOfYear = 10 };
				yield return new Month { Name = "November", MonthOfYear = 11 };
				yield return new Month { Name = "December", MonthOfYear = 12 };
			}
		}
	}
}
