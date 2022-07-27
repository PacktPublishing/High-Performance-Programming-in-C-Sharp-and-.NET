namespace CH06_Collections.ConcreteVsInterface
{
	using System;

	internal class HigherRate : BaseTax
	{
		public HigherRate()
		{
			this.LowerLimit = 43431M;
			this.UpperLimit = 150000M;
			this.TaxType = TaxType.IncomeTax;
			this.TaxRate = TaxRate.HigherRate;
			this.Percentage = 0.41M;
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