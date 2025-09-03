using System.Text.Json;

namespace ProjetoBackEndInfnet.Repositories;

public abstract class BaseRepository<T> : IRepository<T>
    where T : class, IEntity
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true
    };

    protected readonly string _fullPath;
    protected BaseRepository(string fileName)
    {
        var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        Directory.CreateDirectory(folderPath);
        _fullPath = Path.Combine(folderPath, fileName);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        if (!File.Exists(_fullPath))
        {
            return [];
        }

        await using var stream = File.OpenRead(_fullPath);

        var items = await JsonSerializer
            .DeserializeAsync<List<T>>(stream, _jsonOptions, cancellationToken)
            ?? throw new Exception($"Erro ao desserializar o arquivo {typeof(T)}");

        return items;
    }

    public async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        if (!File.Exists(_fullPath))
        {
            return null;
        }

        await using var stream = File.OpenRead(_fullPath);

        var enumerable = JsonSerializer
            .DeserializeAsyncEnumerable<T>(stream, _jsonOptions, cancellationToken);

        await foreach (var item in enumerable)
        {
            if (item is not null && item.Id == id)
            {
                return item;
            }
        }

        return null;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        var entities = await GetAllAsync(cancellationToken);

        entity.Id = 1;

        if (entities.Count != 0)
        {
            entity.Id = entities.Max(e => e.Id) + 1;
        }

        entities.Add(entity);

        await SaveAllAsync(entities, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        var entities = await GetAllAsync(cancellationToken);

        var index = entities.FindIndex(e => e.Id == entity.Id);
        if (index == -1)
        {
            throw new Exception($"Entity with Id {entity.Id} not found.");
        }

        entities[index] = entity;
        await SaveAllAsync(entities, cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var entities = await GetAllAsync(cancellationToken);

        var entityToRemove = entities.FirstOrDefault(e => e.Id == id)
            ?? throw new Exception($"Entity with Id {id} not found.");

        entities.Remove(entityToRemove);
        await SaveAllAsync(entities, cancellationToken);
    }

    public async Task SaveAllAsync(List<T> entities, CancellationToken cancellationToken)
    {
        await using var stream = File.Open(_fullPath, FileMode.Create, FileAccess.Write);

        await JsonSerializer.SerializeAsync(stream, entities, _jsonOptions, cancellationToken);

        await stream.FlushAsync(cancellationToken);
    }
}