using BuilderValidatorPOC.BuilderValidator;
using BuilderValidatorPOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderValidatorPOC
{
    public static class ValidatorTest
    {
        public static void Run(string emailRegex, string nameRegex)
        {
            var results = new List<bool>();
            var builder = new UserValidatorBuilder(results, emailRegex, nameRegex);
            var builderDirector = new ValidatorBuilderDirector(builder);

            var user1 = new User("Jan","Kowalski","jk@paparam.com", 29);
            var user2 = new User("203854","Vaie","ueueueueu", 110);
            var user3 = new User("jan","Kowalski","jk@payaac.pl", 14);
            var user4 = new User("Hello","Kitty","hq", -300);

            ValidateUser(builderDirector, user1);
            ValidateUser(builderDirector, user2);
            ValidateUser(builderDirector, user3);
            ValidateUser(builderDirector, user4);
        }

        public static void ValidateUser(ValidatorBuilderDirector builderDirector, User user)
        {
            Console.WriteLine($"-- User: {user.FirstName} {user.LastName} --");

            if (builderDirector.ValidateNames(user))
                Console.WriteLine("User's first name and last name are valid.");
            else
                Console.WriteLine("User's first name and last name are invalid!");

            if (builderDirector.ValidateAgeAndEmail(user))
                Console.WriteLine($"Age and email of the user are valid.");
            else
                Console.WriteLine("Age and email of the user are invalid!");

            if (builderDirector.ValidateAll(user))
                Console.WriteLine("All user's field are valid.");
            else
                Console.WriteLine("User's fields are invalid!");
        }
    }
}
