namespace CH06_Collections.ConcreteVsInterface
{
	using System;

	internal abstract class BaseTax : ITax
	{
		public int Id { get; set; }
		public TaxType TaxType { get; set; }
		public TaxRate TaxRate { get; set; }
		public decimal LowerLimit { get; set; }
		public decimal UpperLimit { get; set; }
		public decimal Percentage { get; set; }
		public abstract decimal Calculate(decimal amount);
	}
}
