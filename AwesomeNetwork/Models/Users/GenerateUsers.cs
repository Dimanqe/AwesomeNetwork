using System;
using System.Collections.Generic;

namespace AwesomeNetwork.Models.Users
{
    public class GenerateUsers
    {
        private string[] firstNames = { "Vasya", "Petya", "Misha", "Kolya", "Dima", "Sasha", "Arthur", "Vanya" };
        private string[] secondNames = { "Vasilyev", "Petrov", "Ivanov", "Sidorov", "Kuzmin", "Sergeev", "Sokolov", "Kabanov" };

        public IEnumerable<User> Populate(int userCount)
        {
            var users = new List<User>(userCount);
            Random random = new Random();

            for (int i = 0; i < userCount; i++)
            {
                var firstName = firstNames[random.Next(firstNames.Length)];
                var lastName = secondNames[random.Next(secondNames.Length)];
                var email = $"{firstName.ToLower()}.{lastName.ToLower()}@gmail.com";

                users.Add(new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Image = "https://thispersondoesnotexist.com",
                    Status = "Ура! Я в соцсети!",
                    About = "Информация обо мне.",
                    BirthDate = DateTime.Now,
                    EmailConfirmed = false,
                    UserName = firstName+lastName
                    
                    

                });
            }

            return users;
        }




    }
}

