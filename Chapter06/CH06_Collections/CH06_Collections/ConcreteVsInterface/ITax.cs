namespace CH06_Collections.ConcreteVsInterface
{
	internal interface ITax
	{
		int Id { get; set; }
		TaxType TaxType { get; set; }
		TaxRate TaxRate { get; set; }
		decimal LowerLimit { get; set; }
		decimal UpperLimit { get; set; }
		decimal Percentage { get; set; }
		decimal Calculate(decimal amount);
	}
}
