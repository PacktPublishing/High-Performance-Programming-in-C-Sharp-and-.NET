namespace CH06_Collections.ConcreteVsInterface
{
	using System;

	[Flags]
	internal enum TaxType
	{
		CorporationTax,
		ValueAddedTax,
		IncomeTax,
		NationInsuranceContributions,
		ExciseDuties,
		RoadTax,
		StampDuty
	}
}
