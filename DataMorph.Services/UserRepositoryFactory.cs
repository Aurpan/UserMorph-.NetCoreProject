using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using UserMorph.Core.Enums;
using UserMorph.Core.Interfaces.Persistence;
using UserMorph.DataManagement.Contexts;
using UserMorph.DataManagement.Repositories;

namespace UserMorph.Services
{
    public class UserRepositoryFactory
    {
        private readonly DbContext _dbContext;

        public UserRepositoryFactory(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository GetUserRepository (DataSourceType sourceType)
        {
            switch (sourceType) 
            {
                case DataSourceType.Json:
                    return new UserJsonRepository();
                case DataSourceType.MSSQL:
                    return new UserRepository(_dbContext);
                default:
                    throw new ArgumentOutOfRangeException(nameof(sourceType), "Data source type is invalid");
            }
        }
    }
}
