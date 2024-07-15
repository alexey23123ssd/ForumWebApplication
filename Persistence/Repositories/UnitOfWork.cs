using Application.Interfaces;
using Application.Interfaces.Repositiries;
using Application.Interfaces.Repositories;
using Domain;
using Persistence.Contexts;
using System.Collections;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private Hashtable? _repositories;
        private IUserRepository _userRepository;
        private IThemeRepository _themeRepository;
        private IArticleRepository _articleRepository;
        private ICommentRepository _commentRepository;
        private bool _disposed;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if(_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if(!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)),_dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }   

        public IUserRepository userRepository
        {
            get
            {
                return new UserRepository(_dbContext);
            }
        }

        public IArticleRepository articleRepository
        {
            get
            {
                return new ArticleRepository(_dbContext);
            }
        }

        public IThemeRepository themeRepository
        {
            get
            {
                return new ThemeRepository(_dbContext);
            }
        }

        public ICommentRepository commentRepository
        {
            get
            {
                return new CommentRepository(_dbContext);
            }
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }


        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(e => e.Reload());
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
