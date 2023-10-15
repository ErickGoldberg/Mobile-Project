using MongoConnection.Configure;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MongoConnection.Repository
{
    public class CrudRepository<T>
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public CrudRepository(string databaseName, string colletionName)
        {
            var mongoClient = DataBaseConfigure.ConfigureConnection();
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            _mongoCollection = mongoDatabase.GetCollection<T>(colletionName);
        }

        public void InsertOne(T obj)
        {
            _mongoCollection.InsertOne(obj);
        }

        public void InsertMany(List<T> obj)
        {
            _mongoCollection.InsertMany(obj);
        }

        public T FindBy(Expression<Func<T, bool>> predicate)
        {
            return _mongoCollection.Find(predicate).First();
        }

        public T FindById(Expression<Func<T, bool>> predicate)
        {
            return _mongoCollection.Find(predicate).First();
        }

        public List<T> GetAll()
        {
            List<T> objs = _mongoCollection.Find(_ => true).ToList();
            return objs;
        }

        public T FindByLoginAndPassword(string login, string password)
        {
            var filter = Builders<T>.Filter.Eq("Login", login) & Builders<T>.Filter.Eq("Password", password);
            var result = _mongoCollection.Find(filter).FirstOrDefault();
            return result;
        }

        public void UpdateObj(Expression<Func<T, bool>> filter, T update) => _mongoCollection.ReplaceOne(filter, update);

        public void RemoveObj(Expression<Func<T, bool>> filter) => _mongoCollection.DeleteOne(filter);
    }
}
