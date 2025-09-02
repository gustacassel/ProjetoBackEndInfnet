using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public sealed class ProductRepository : BaseRepository<Product>
{
    private ProductRepository(string filePath) : base(filePath)
    { }

    public static ProductRepository Create()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var folder = Path.Combine(appData, nameof(ProjetoBackEndInfnet));
        Directory.CreateDirectory(folder);
        var filePath = Path.Combine(folder, "products.csv");

        return new ProductRepository(filePath);
    }
}