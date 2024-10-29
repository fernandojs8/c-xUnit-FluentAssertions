using System.Text;

namespace CS_xUnit_FluentAssertion.Model
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }

        public Person(string fullname)
        {
            this.FullName = fullname;
            this.SplitFullName();
        }

        private void SplitFullName()
        {
            var names = this.FullName?.Split(' ');
            var lastName = new StringBuilder();

            for (int i = 0; i < names?.Length; i++)
            {
                if (i == 0)
                {
                    this.FirstName = names[i];
                }
                else
                {
                    lastName.Append($"{names[i]} ");
                }
            }

            this.LastName = lastName.ToString().Trim();
        }
    }
}
