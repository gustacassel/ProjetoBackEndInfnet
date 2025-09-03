namespace ProjetoBackEndInfnet.Repositories;

public interface IRepository<T> where T : class, IEntity
{
    /// <summary>
    /// Asynchronously retrieves all items of type <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>The returned list may be empty if no items are available. This method does not guarantee any
    /// specific order of the items.</remarks>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. Passing a canceled token will immediately terminate the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all items of type
    /// <typeparamref name="T"/>.</returns>
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity of type <typeparamref
    /// name="T"/>  if found; otherwise, <see langword="null"/>.</returns>
    Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously adds the specified entity to the data store.
    /// </summary>
    /// <param name="entity">The entity to add. Cannot be <see langword="null"/>.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Updates the specified entity in the data store asynchronously.
    /// </summary>
    /// <remarks>This method performs an update operation on the provided entity. Ensure that the entity is
    /// valid and already exists in the data store before calling this method.</remarks>
    /// <param name="entity">The entity to update. The entity must not be null and must exist in the data store.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. Passing a canceled token will throw an <see
    /// cref="OperationCanceledException"/>.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes the entity with the specified identifier asynchronously.
    /// </summary>
    /// <remarks>This method performs the delete operation asynchronously. Ensure that the specified <paramref
    /// name="id"/> corresponds to an existing entity. If the entity does not exist, the behavior may depend on the
    /// implementation.</remarks>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Saves all the specified entities to the data store asynchronously.
    /// </summary>
    /// <remarks>This method ensures that all entities in the provided list are persisted to the data store. 
    /// If the operation is canceled via the <paramref name="cancellationToken"/>, the task will be  marked as
    /// canceled.</remarks>
    /// <param name="entities">The list of entities to be saved. Cannot be null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    Task SaveAllAsync(List<T> entities, CancellationToken cancellationToken);
}