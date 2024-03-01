using AwesomeNetwork.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeNetwork.Data.Repository
{
    public class FriendsRepository : Repository<Friend>
    {
        public FriendsRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task AddFriend(User target, User friend)
        {
            var isFriendExist = await Set.AnyAsync(x => x.UserId == target.Id && x.CurrentFriendId == friend.Id);

            if (!isFriendExist)
            {
                var item = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = friend,
                    CurrentFriendId = friend.Id,
                };

                await Create(item);
            }
        }

        public async Task<List<User>> GetFriendsByUser(User target)
        {
            var friends = await Set
                .Where(x => x.UserId == target.Id)
                .Select(x => x.CurrentFriend)
                .ToListAsync();

            return friends;
        }

        public async Task DeleteFriend(User target, User friend)
        {
            var friendToDelete = await Set.FirstOrDefaultAsync(x => x.UserId == target.Id && x.CurrentFriendId == friend.Id);

            if (friendToDelete != null)
            {
                await Delete(friendToDelete);
            }
        }
    }
}
