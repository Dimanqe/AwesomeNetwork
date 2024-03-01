using AwesomeNetwork.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeNetwork.Models.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }

        public string Status { get; set; }

        public string About { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }

        public User()
        {
            /*Image = "https://i.ibb.co/9bCtHR6/default-profile-icon-24.jpg";*/
            Image = "https://thispersondoesnotexist.com";
            Status = "Ура! Я в соцсети!";
            About = "Информация обо мне.";
        }
        public void Convert(EditViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            MiddleName = model.MiddleName;
            BirthDate = model.BirthDate;
            Image = model.Image;
            Status = model.Status;
            About = model.About;
            Email = model.Email;
            UserName = model.UserName;
            //Id = model.UserId;
        }



    }
}
