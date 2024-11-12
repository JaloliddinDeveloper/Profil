using Microsoft.EntityFrameworkCore;
using Profil.Models.Foundations.Users;
using System.Linq;
using System.Threading.Tasks;

namespace Profil.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user) =>
            await InsertAsync(user);

        public async ValueTask<IQueryable<User>> SelectAllUsersAsync() =>
           await SelectAllAsync<User>();

        public async ValueTask<User> SelectUserByIdAsync(int userId) =>
            await SelectAsync<User>(userId);

        public async ValueTask<User> UpdateUserAsync(User user) =>
            await UpdateAsync(user);

        public async ValueTask<User> DeleteUserAsync(User user) =>
            await DeleteAsync(user);
    }
}
