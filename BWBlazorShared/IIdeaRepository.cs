namespace BWBlazorShared
{
    public interface IIdeaRepository
    {
        Task<Idea> AddIdea(Idea idea);
        Task<List<Idea>> GetIdeas();
    }
}
