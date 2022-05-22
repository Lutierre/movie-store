using System.Linq.Expressions;
using DAL.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CommentRepository : GenericRepository<Comment>
{
    public CommentRepository(MovieStoreContext context) : base(context)
    {
    }
    
    public override async Task<List<Comment>> GetFilteredAsync(Expression<Func<Comment, bool>> predicate)
        => await Context.Set<Comment>().Include(comment => comment.Movie).Where(predicate).ToListAsync();
}
