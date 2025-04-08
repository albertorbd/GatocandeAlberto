using Microsoft.EntityFrameworkCore;
using Gatocan.Model;
using Microsoft.Extensions.Logging;


namespace Gatocan.Data
{
    public class GatocanContext : DbContext
    {
public GatocanContext(DbContextOptions<GatocanContext> options)
: base(options)
        {
        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Cart> Carts { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            modelBuilder.Entity<Cart>().HasKey(c => c.Id);

        
            modelBuilder.Entity<User>()
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

      
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Product)
                .WithMany()
                .HasForeignKey(t => t.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

         
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany() 
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<Cart>()
                .OwnsMany(c => c.Items, cb =>
                {
                    cb.WithOwner().HasForeignKey("CartId"); 
                    cb.Property<int>("Id"); 
                    cb.HasKey("Id");
                });

         

            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Juan",
                    Lastname = "Pérez",
                    Email = "juan@example.com",
                    Password = "pass123",
                    Balance = 100.0,
                    Role = "Cliente"
                },
                new User
                {
                    Id = 2,
                    Name = "Ana",
                    Lastname = "Gómez",
                    Email = "ana@example.com",
                    Password = "pass456",
                    Balance = 150.0,
                    Role = "Admin"
                }
            );

            
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Comida para perros",
                    Description = "Alimento balanceado para perros",
                    Price = 20.5,
                    Category = "Comida",
                    Brand = "MarcaA",
                    Stock = 50,
                    ImageUrl = "https://example.com/imagen1.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Juguete para gatos",
                    Description = "Juguete interactivo para gatos",
                    Price = 15.0,
                    Category = "Juguetes",
                    Brand = "MarcaB",
                    Stock = 30,
                    ImageUrl = "https://example.com/imagen2.jpg"
                }
            );

           
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    UserId = 1,
                    ProductId = 1,
                    Amount = 20.5,
                    Quantity = 1,
                    Date = new DateTime(2024, 5, 6, 0, 9, 2),
                    PaymentMethod = "Tarjeta",
                    Tipo = TransactionType.Compra
                },
                new Transaction
                {
                    Id = 2,
                    UserId = 1,
                    ProductId = 1,
                    Amount = 50.0,
                    Quantity = 1,
                    Date = new DateTime(2024, 5, 6, 0, 9, 12),
                    PaymentMethod = "Transferencia",
                    Tipo = TransactionType.Ingreso
                }
            );

           
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 1,
                    UserId = 1,
                    DateCreated = new DateTime(2024, 5, 10)
                }
            );

           
            modelBuilder.Entity<Cart>().OwnsMany(c => c.Items).HasData(
                new
                {
                    Id = 1,      
                    CartId = 1,  
                    ProductId = 2,
                    Quantity = 3
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}
