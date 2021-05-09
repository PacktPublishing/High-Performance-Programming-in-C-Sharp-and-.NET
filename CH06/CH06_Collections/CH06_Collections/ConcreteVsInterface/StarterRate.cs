namespace CH06_Collections.ConcreteVsInterface
{
	using System;

	internal class StarterRate : BaseTax
	{
		public StarterRate()
		{
			this.LowerLimit = 12501M;
			this.UpperLimit = 14549M;
			this.TaxType = TaxType.IncomeTax;
			this.TaxRate = TaxRate.StarterRate;
			this.Percentage = 0.19M;
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