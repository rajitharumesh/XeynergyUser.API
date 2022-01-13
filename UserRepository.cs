using XeynergyUser.API.Data;
using XeynergyUser.API.Models;

namespace XeynergyUser.API
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {   

                var dddd = (from d in context.AccessRule.Include("UserGroup")
                            join c in context.UserGroup on d.RuleId equals c.RuleId
                            join s in context.User on c.GroupId equals s.GroupId
                            where d.Permission == true
                            select s).ToList();


                var result = (from a in context.AccessRule
                              join b in context.UserGroup on a.RuleId equals b.RuleId
                              select a.UserGroups).Distinct();

                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(UserRepository));
                return new List<User>();
            }
        }

        public override async Task<bool> Upsert(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.UserId == entity.UserId)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.EmailAddress = entity.EmailAddress;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.UserId == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(UserRepository));
                return false;
            }
        }
    }
}
