﻿namespace Cinema.Bilhetes.Domain.Bilhetes
{
    public interface IBilheteRepository
    {
        Task<Bilhete> GetByIdAsync(string id);
        Task<IEnumerable<Bilhete>> GetAllAsync();
        Task<IEnumerable<Bilhete>> GetBilhetesByUser(string idUsuario);
        Task CreateAsync(Bilhete entity);
        Task UpdateAsync(Bilhete entity);
        Task DeleteAsync(string id);
    }
}
