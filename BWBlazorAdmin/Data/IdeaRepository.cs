using BWBlazorAdmin.Data;
using Microsoft.EntityFrameworkCore;

namespace BWBlazorShared
{
    public class IdeaRepository : IIdeaRepository
    {
        private readonly ApplicationDbContext context;

        public IdeaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Idea> AddIdea(Idea idea)
        {
            context.Ideas?.Add(idea);
            await context.SaveChangesAsync();
            return idea;
        }

        public async Task<List<Idea>> GetIdeas()
        {
            if (context.Ideas == null)
                return new List<Idea>();

            return await context.Ideas.ToListAsync();
        }
    }
}
