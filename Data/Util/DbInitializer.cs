using Data.Repositories;

namespace Services
{
    public interface IDbInitializer
    {
        void Initialize();
    }

    public class DbInitializer : IDbInitializer
    {
        private readonly Repository _repository;

        public DbInitializer(Repository repository)
        {
            _repository = repository;
        }
        public void Initialize()
        {
            try

            {
                _repository.Database.EnsureCreated();
                //use if a relational database provider is used.
                //if (_repository.Database.GetPendingMigrations().Count() > 0)
                //{
                //    _repository.Database.Migrate();
                //}
            }
            catch (Exception ex)
            {

            }

            if (!_repository.Staffs.Any(u => u.Email == "admin"))
            {
                var newUser = new Staff
                {
                    Email = "admin",
                    Name = "admin",
                    Password = "password123",
                    Role = nameof(StaffRoleTypes.Teacher)

                };

                _repository.Staffs.Add(newUser);
                _repository.SaveChanges();
            }

        }
    }
}
