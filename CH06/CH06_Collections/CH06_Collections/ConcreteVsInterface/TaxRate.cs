namespace CH06_Collections.ConcreteVsInterface
{
	using System;

	[Flags]
	internal enum TaxRate
	{
		TaxFreePersonalAllowance,
		StarterRate,
		BasicRate,
		IntermediateRate,
		HigherRate,
		AdditionalRate
	}
}
