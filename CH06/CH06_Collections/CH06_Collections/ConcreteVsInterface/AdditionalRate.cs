namespace CH06_Collections.ConcreteVsInterface
{
	using System;

	internal class AdditionalRate : BaseTax
	{
		public AdditionalRate()
		{
			this.LowerLimit = 150000M;
			this.UpperLimit = decimal.MaxValue;
			this.TaxType = TaxType.IncomeTax;
			this.TaxRate = TaxRate.AdditionalRate;
			this.Percentage = 0.46M;
		}

		public override decimal Calculate(decimal amount)
		{
			if (Percentage > 1)
				throw new Exception("Invalid percentage. Percentage must be between 0 and 1.");
			if (amount < LowerLimit & amount > UpperLimit)
				return 0;
			return Percentage * amount;
		}
	}
}