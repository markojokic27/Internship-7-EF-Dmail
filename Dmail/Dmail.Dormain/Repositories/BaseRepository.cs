using Dmail.Data.Entities;
using Dmail.Domain.Enums;

namespace Dmail.Domain.Repositories;
public abstract class BaseRepository
{
    protected readonly DmailDBContext DbContext;

    protected BaseRepository(DmailDBContext dbContext)
    {
        DbContext = dbContext;
    }

    protected ResponseResultType SaveChanges()
    {
        var hasChanges = DbContext.SaveChanges() > 0;
        if (hasChanges)
            return ResponseResultType.Success;

        return ResponseResultType.NoChanges;
    }
}
