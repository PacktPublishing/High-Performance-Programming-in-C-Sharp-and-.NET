namespace CH06_Collections.ConcreteVsInterface
{
	using System;

	internal class IntermediateRate : BaseTax
	{
		public IntermediateRate()
		{
			this.LowerLimit = 24945M;
			this.UpperLimit = 43430M;
			this.TaxType = TaxType.IncomeTax;
			this.TaxRate = TaxRate.IntermediateRate;
			this.Percentage = 0.21M;
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