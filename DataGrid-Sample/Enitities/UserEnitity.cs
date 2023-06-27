using System;

namespace DataGrid_Sample.Enitities
{
    public sealed class UserEnitity
    {
        public int Id { get; }

        public string Name { get; }

        public int Age { get; }

        public string BrithDay { get; }

        public string Sex { get; }

        public string Email { get; }

        public string Tell { get; }

        public UserEnitity(int id, string name, string age, string brithDay, string sex, string email, string tell)
        {
            Id = id;
            Name = name;
            Age = Int32.Parse(age);
            BrithDay = brithDay;
            Sex = sex;
            Email = email;
            Tell = tell;
        }

    }
}
