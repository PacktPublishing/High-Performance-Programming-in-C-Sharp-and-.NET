namespace CH06_Collections.ConcreteVsInterface
{
	using System;

	internal class BasicRate : BaseTax
	{
		public BasicRate()
		{
			this.LowerLimit = 14550M;
			this.UpperLimit = 24944M;
			this.TaxType = TaxType.IncomeTax;
			this.TaxRate = TaxRate.BasicRate;
			this.Percentage = 0.2M;
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
