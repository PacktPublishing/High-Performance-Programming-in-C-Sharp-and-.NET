namespace CH06_Collections.ConcreteVsInterface
{
	using System;

	internal class TaxFreePersonalAllowance : BaseTax
	{
		public TaxFreePersonalAllowance()
		{
			this.LowerLimit = 0M;
			this.UpperLimit = 12500M;
			this.TaxType = TaxType.IncomeTax;
			this.TaxRate = TaxRate.TaxFreePersonalAllowance;
			this.Percentage = 0M;
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
