namespace BWBlazorShared
{
    public class IdeaRepositoryInMemory : IIdeaRepository
    {
        List<Idea> idea;

        public IdeaRepositoryInMemory()
        {
            idea = new List<Idea>();
        }

        public async Task<Idea> AddIdea(Idea idea)
        {
            return await Task.Run(() =>
            {
                idea.Id = this.idea.Count + 1;
                this.idea.Add(idea);
                return idea;
            });
        }

        public async Task<List<Idea>> GetIdeas()
        {
            return await Task.Run(() =>
            {
                if (this.idea == null)
                    return new List<Idea>();

                return this.idea;
            });
        }
    }
}
