using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await context.Database.MigrateAsync();

            if (!await context.Products.AnyAsync())
            {
                var products = new List<Product>
                {
                    new() { Id = Guid.NewGuid(), Name = "Laptop Dell XPS 13", Description = "Ultrabook con pantalla InfinityEdge de 13 pulgadas y procesador Intel i7", Price = 6500000m },
                    new() { Id = Guid.NewGuid(), Name = "iPhone 14 Pro", Description = "Smartphone Apple con cámara Pro de 48MP y chip A16 Bionic", Price = 5800000m },
                    new() { Id = Guid.NewGuid(), Name = "Samsung Galaxy S23", Description = "Teléfono Android con pantalla AMOLED 6.1'' y procesador Snapdragon 8 Gen 2", Price = 4200000m },
                    new() { Id = Guid.NewGuid(), Name = "Monitor LG UltraWide 34''", Description = "Monitor curvo con resolución QHD", Price = 2200000m },
                    new() { Id = Guid.NewGuid(), Name = "Teclado Mecánico Logitech G915", Description = "Teclado inalámbrico gamer con switches low-profile y RGB LIGHTSYNC", Price = 950000m },
                    new() { Id = Guid.NewGuid(), Name = "Mouse Razer DeathAdder V3", Description = "Ratón ergonómico para gaming con sensor óptico Focus Pro 30K", Price = 420000m },
                    new() { Id = Guid.NewGuid(), Name = "Audífonos Sony WH-1000XM5", Description = "Auriculares inalámbricos con cancelación activa de ruido líder en la industria", Price = 1600000m },
                    new() { Id = Guid.NewGuid(), Name = "Apple Watch Series 9", Description = "Reloj inteligente con pantalla Retina Always-On y seguimiento avanzado de salud", Price = 2100000m },
                    new() { Id = Guid.NewGuid(), Name = "Disco SSD Samsung 980 Pro 1TB", Description = "Unidad de estado sólido NVMe PCIe 4.0", Price = 550000m },
                    new() { Id = Guid.NewGuid(), Name = "Silla Gamer Secretlab Titan Evo", Description = "Silla ergonómica premium con soporte lumbar ajustable y memory foam", Price = 2800000m }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
