namespace HannahAI.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        // Add your repository interfaces here
        // IYourRepository YourRepository { get; }
        Task<int> CompleteAsync();
    }
}
