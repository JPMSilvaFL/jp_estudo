namespace agenda_api.Collections.Repository
{
	public interface IRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id); // Recuperar por ID
		Task<IList<T>> GetAllAsync(); // Recuperar todos os registros
		Task AddAsync(T entity); // Adicionar um novo
		void Update(T entity); // Atualizar um existente
		Task DeleteAsync(int id); // Deletar por ID
	}
}