using Cinema.Bilhetes.Domain.Bilhetes;
using MongoDB.Driver;

namespace Cinema.Bilhetes.Infra.Data.Repository
{
    public class BilheteRepository : IBilheteRepository
    {
        private readonly IMongoCollection<Bilhete> _collection;

        public BilheteRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Bilhete>("bilhetes");
        }

        public async Task<Bilhete> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Bilhete>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(Bilhete entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Bilhete entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Bilhete>> GetBilhetesByUser(string idUsuario)
        {
            return await _collection.Find(x => x.UsuarioId == idUsuario).ToListAsync();
        }
    }
}
