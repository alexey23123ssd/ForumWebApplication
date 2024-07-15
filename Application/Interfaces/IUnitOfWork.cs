using Application.Interfaces.Repositiries;
using Application.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        IUserRepository userRepository { get; }
        IArticleRepository articleRepository { get; }
        IThemeRepository themeRepository { get; }
        ICommentRepository commentRepository { get; }
        Task<int> Save(CancellationToken cancellationToken);
        Task Rollback();
    }
}
