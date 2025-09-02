using System.Text;

namespace ProjetoBackEndInfnet.Repositories;

public abstract class BaseRepository<T> : IRepository<T>
    where T : class, new()
{
    protected readonly string FilePath;

    protected BaseRepository(string filePath)
    {
        FilePath = filePath;

        // cria o arquivo se não existir
        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, string.Empty);
        }
    }

    // Retorna todas as entidades
    public List<T> GetAll()
    {
        var list = new List<T>();
        var lines = File.ReadAllLines(FilePath);

        if (lines.Length == 0)
            return list;

        var headers = lines[0].Split(',');

        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            var obj = new T();

            for (int j = 0; j < headers.Length; j++)
            {
                var prop = typeof(T).GetProperty(headers[j]);
                if (prop != null)
                {
                    object value = Convert.ChangeType(values[j], prop.PropertyType);
                    prop.SetValue(obj, value);
                }
            }

            list.Add(obj);
        }

        return list;
    }

    // Retorna uma entidade pelo Id
    public T? GetById(int id)
    {
        return GetAll().FirstOrDefault(e =>
        {
            var prop = typeof(T).GetProperty("Id");
            if (prop == null) return false;
            return (int)prop.GetValue(e)! == id;
        });
    }

    // Adiciona uma nova entidade
    public void Add(T entity)
    {
        var list = GetAll();
        var idProp = typeof(T).GetProperty("Id");
        if (idProp == null)
            throw new Exception("Entity does not have an Id property.");

        // Define o Id automático
        int newId = list.Count > 0 ? list.Max(e => (int)idProp.GetValue(e)!) + 1 : 1;
        idProp.SetValue(entity, newId);

        list.Add(entity);
        SaveAll(list);
    }

    // Atualiza uma entidade existente
    public void Update(T entity)
    {
        var list = GetAll();
        var idProp = typeof(T).GetProperty("Id");
        if (idProp == null)
            throw new Exception("Entity does not have an Id property.");

        int id = (int)idProp.GetValue(entity)!;
        var index = list.FindIndex(e => (int)idProp.GetValue(e)! == id);

        if (index < 0)
            throw new Exception("Entity not found.");

        list[index] = entity;
        SaveAll(list);
    }

    // Remove uma entidade
    public void Delete(int id)
    {
        var list = GetAll();
        var idProp = typeof(T).GetProperty("Id");
        if (idProp == null)
            throw new Exception("Entity does not have an Id property.");

        list.RemoveAll(e => (int)idProp.GetValue(e)! == id);
        SaveAll(list);
    }

    // Salva todas as entidades no CSV
    private void SaveAll(List<T> list)
    {
        var props = typeof(T).GetProperties();
        var sb = new StringBuilder();

        sb.AppendLine(string.Join(",", props.Select(p => p.Name)));

        foreach (var entity in list)
        {
            var values = props.Select(p => p.GetValue(entity)?.ToString() ?? "");
            sb.AppendLine(string.Join(",", values));
        }

        File.WriteAllText(FilePath, sb.ToString());
    }
}