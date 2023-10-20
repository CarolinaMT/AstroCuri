using AstroCuri.API.Helpers;
using AstroCuri.Shared.Entities;
using AstroCuri.Shared.Enums;
using AstroCuri.API.Data;


namespace AstroCuri.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        //este solo se ejecuta una vez y sería el unico usurio que puede hacer lo que quiera (sofía)
        //sec es la inicial de los nombres de los integrantes.
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("10088", "sce", "sce", "sce@gmail.com", "301558666", "CR 42 1687", UserType.Admin);
        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType,
                };
                //el usuario de arriba se crea con esa contraseña
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Seguido.ToString());
            await _userHelper.CheckRoleAsync(UserType.Seguidor.ToString());
        }
    }
}
