namespace CH01_TargetedTypeEpressions
{
    public record Student
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public Student(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public void Deconstruct(out string firstName, out string lastName)
            => (firstName, lastName) = (_firstName, _lastName);
    }
}
