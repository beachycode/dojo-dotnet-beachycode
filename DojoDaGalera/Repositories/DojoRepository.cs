using DojoDaGalera.Classes;
using DojoDotnet.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DojoDaGalera.Repositories
{
    public class DojoRepository : IDojoRepository
    {
        private readonly IMongoCollection<Dojo> _mongoCollection;

        public DojoRepository(IOptions<MongoDBDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            _mongoCollection = mongoDatabase.GetCollection<Dojo>(options.Value.DojoCollectionName);
        }

        public async Task<Dojo> Get(string id)
        {
            return await _mongoCollection.Find(dojo => dojo.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Dojo>> Get()
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Dojo> Add(Dojo dojo)
        {
            await _mongoCollection.InsertOneAsync(dojo);

            return dojo;
        }

        public async Task<Dojo> Update(string id, Dojo dojo)
        {
            var filter = Builders<Dojo>.Filter.Eq(x => x.Id, id);
            dojo.Id = id;
            await _mongoCollection.ReplaceOneAsync(filter, dojo);

            return dojo;
        }

        public async Task<bool> Delete(string id)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(x => x.Id.Equals(id));

            return deleteResult.IsAcknowledged;
        }
    }
}