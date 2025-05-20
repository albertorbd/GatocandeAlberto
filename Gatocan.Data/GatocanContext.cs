using Microsoft.EntityFrameworkCore;
using Gatocan.Model;
using Microsoft.Extensions.Logging;

namespace Gatocan.Data;

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
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            modelBuilder.Entity<Cart>().HasKey(c => c.Id);
            modelBuilder.Entity<CartItem>().HasKey(ci => ci.Id);

            
            modelBuilder.Entity<User>()
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

           modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Product)
            .WithMany()
            .HasForeignKey(t => t.ProductId)
            .IsRequired(false)       
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Juan",
                    Lastname = "Pérez",
                    Email = "juan@example.com",
                    Password = "pass123",
                    Balance = 100.0
                },
                new User
                {
                    Id = 2,
                    Name = "Alberto",
                    Lastname = "Riveiro",
                    Email = "albertoriveiro@hotmail.es",
                    Password = "pass456",
                    Balance = 150.0,
                    Role = Roles.Admin
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Royal Canin Maxi Adult pienso para perros",
                    Description = "Pienso para perros adultos de razas grandes que minimiza los efectos del envejecimiento y mejora la salud articular.",
                    longDescription = "Royal Canin Maxi Adult es el alimento indicado para aquellos perros que en edad adulta alcanzan más de 25 kg gracias a su receta, creada especialmente para mantener su organismo en un estado óptimo.",
                    Price = 20.5,
                    Category = "Alimentación",
                    Brand = "Royal Canin",
                    Stock = 50,
                    ImageUrl = "/images/products/royalcanin.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Advance Active Defense Medium Adult Pollo y Arroz pienso para perros",
                    Description = "Pienso de pollo y arroz para perros medianos adultos.",
                    longDescription = "Se trata de un alimento para perros especialmente diseñado para cubrir todas sus necesidades. Su composición cuenta con una destacada selección de proteínas e hidratos de carbono, lo que ayuda a mantener una digestibilidad muy alta y un correcto proceso digestivo. Además de pirofosfatos, un componente que evita el mal aliento y la formación de sarro.",
                    Price = 67.0,
                    Category = "Alimentación",
                    Brand = "Advance",
                    Stock = 25,
                    ImageUrl = "/images/products/advance.jpg"
                },
                 new Product
                {
                    Id = 3,
                    Name = "True Origins Pure Adult Atún y Sardina lata para gatos",
                    Description = "Comida húmeda de atún y sardinas para gatos adultos.",
                    longDescription = "Este delicioso alimento complementario para gatos de la marca True Origins es adecuado para que tu mascota se mantenga fuerte y sana, además de disfrutar de un delicioso alimento húmedo con muchas vitaminas y minerales esenciales para su alimentación.",
                    Price = 18.7,
                    Category = "Alimentación",
                    Brand = "True Origins",
                    Stock = 45,
                    ImageUrl = "/images/products/trueorigins.jpg"
                },

                 new Product
                {
                    Id = 4,
                    Name = "True Origins Pure Bocaditos Adult Crunchy de Pavo para gatos",
                    Description = "Snack totalmente natural sin cereales ni azúcares para gatos adultos.",
                    longDescription = "Los bocaditos para gatos Pure Crunchy de True Origins son ideales para ofrecer a tu felino adulto una golosina deliciosa en cualquier momento del día para recompensarle o mimarle, de esta forma, complementarás su dieta de manera óptima y saludable. Cuentan con una fórmula deliciosa que mezcla carne fresca de pavo con vegetales, junto a una textura crujiente única que a tu mascota le encantará masticar a cualquier hora.",
                    Price = 35.8,
                    Category = "Alimentación",
                    Brand = "True Origins",
                    Stock = 50,
                    ImageUrl = "/images/products/trueorigins2.jpg"
                },

                 new Product
                {
                    Id = 5,
                    Name = "Royal Canin Ageing 12+ sobre en salsa para gatos",
                    Description = "Alimento húmedo sano y equilibrado para gatos seniors.",
                    longDescription = "Los sobres de comida húmeda Royal Canin Ageing cuidan la salud de los gatos de edad avanzada, ya que se adaptan completamente a sus necesidades y evita el riesgo de que puedan padecer algunas enfermedades como la insuficiencia renal o artrosis.",
                    Price = 10.0,
                    Category = "Alimentación",
                    Brand = "Royal Canin",
                    Stock = 40,
                    ImageUrl = "/images/products/royalcanin2.jpg"
                },

                 new Product
                {
                    Id = 6,
                    Name = "Advance Sterilized Hairball Pavo y Cebada pienso para gatos",
                    Description = "Pienso para gatos esterilizados que pueden sufrir un aumento de peso. También ayuda a reducir la formación de bolas de pelo.",
                    longDescription = "El pienso para gatos Advance Sterilized Hairball es perfecto para aquellos gatos que han pasado por una esterilización o una castración y que presentan o pueden presentar los problemas típicos de este tipo de intervenciones, como el aumento de peso.",
                    Price = 49.0,
                    Category = "Alimentación",
                    Brand = "Advance",
                    Stock = 20,
                    ImageUrl = "/images/products/advance1.jpg"
                },

                new Product
                {
                    Id = 7,
                    Name = "Flamingo Happy Caña con flor para gatos",
                    Description = "Caña para gatos Flamingo Happy Flower",
                    longDescription = "La caña para gatos Flamingo Happy Flower con flor de peluche es un original juguete interactivo que desarrolla la motivación y concentración de tu mascota y con el que pasará muchos gratos y divertidos momentos. Un llamativo accesorio con el que conseguirás que tu pequeño amigo peludo esté activo y realice el ejercicio diario necesario para estar saludable.",
                    Price = 4.0,
                    Category = "Juguetes",
                    Brand = "Flamingo",
                    Stock = 60,
                    ImageUrl = "/images/products/flamingo.jpg"
                },

                 new Product
                {
                    Id = 8,
                    Name = "Tootoy! Comfort Denim Duck peluche con sonido y cuerda para perros",
                    Description = "Pato de peluche para perros, con sonido y mordedor circular de cuerda, fabricado en tejido vaquero suave.",
                    longDescription = "El peluche de pato de tejido vaquero de Tootoy! es se convertirá en el mejor amigo de tu perro. Su diseño adorable y su tejido vaquero suave lo convierten en el accesorio perfecto para dormir la siesta, mientras que el pitido que emite cuando lo muerden y el mordedor de cuerda circular que incorpora este juguete, les divierte y estimula su curiosidad. A tu perro le encantará este peluche ¿Quién le dice que ese pato nunca correrá ni volará para él?",
                    Price = 15.0,
                    Category = "Juguetes",
                    Brand = "Tootoy!",
                    Stock = 25,
                    ImageUrl = "/images/products/tootoy.jpg"
                },

                 new Product
                {
                    Id = 9,
                    Name = "Nylabone Extreme Chew Pollo Hueso Mordedor para perros",
                    Description = "Nylabone hueso mordedor de nylon para perros.",
                    longDescription = "Mordedor para perros de Nylabone diseñado para satisfacer los instintos naturales de tu mascota, evitando así que muerda muebles u otros objetos, además fortalece la mandíbula dándole un mejor agarre, también protege los dientes en cada mordida que le da al juguete, ya que limpia y evita la aparición de sarro. Este masticador para perros contiene un sabor delicioso y duradero a pollo, lo que hará que tu mascota pase mucho más tiempo jugando.",
                    Price = 5.0,
                    Category = "Juguetes",
                    Brand = "Nylabone",
                    Stock = 35,
                    ImageUrl = "/images/products/nylabone.jpg"
                },

                 new Product
                {
                    Id = 10,
                    Name = "Flamingo Wilco Calamar Azul de Peluche para perros",
                    Description = "El Calamar azul de Flamingo es un juguete para perros que posee termoplástico en la cabeza y a su vez de felpa que masajea las encías de tu mascota, previene el sarro y la placa.",
                    longDescription = "El divertido calamar azul de peluche para perros es un excelente juguete de Flamingo, pues es un artículo funcional para tu mascota. Por un lado, tu peludo amigo se entretendrá mordiendo la parte superior del peluche y por otro, debido a sus filamentos de termoplástico, se hará auto-limpieza dental para mantener una buena higiene bucodental. ",
                    Price = 6.9,
                    Category = "Juguetes",
                    Brand = "Flamingo",
                    Stock = 32,
                    ImageUrl = "/images/products/flamingo1.jpg"
                },
                  new Product
                {
                    Id = 11,
                    Name = "TK-Pet Minerva Bandeja Sanitaria para gatos",
                    Description = "La bandeja sanitaria cerrada TK-Pet Minerva es un práctico aseo de color rojo para gatos de cualquier raza y tamaño, con el que hacen sus necesidades cómodamente.",
                    longDescription = "Como sucede con los humanos, los animales también necesitan intimidad cuando se trata de hacer sus necesidades. Por ello, TK Pet lanza al mercado la bandeja sanitaria cerrada Minerva para gatos, un accesorio agradable y amplio adecuado para felinos de todas las razas y tamaños.",
                    Price = 22.6,
                    Category = "Higiene",
                    Brand = "TK-Pet",
                    Stock = 31,
                    ImageUrl = "/images/products/tkpet.jpg"
                },
                  new Product
                {
                    Id = 12,
                    Name = "Furminator Cepillo para perros de pelo largo",
                    Description = "Furminator cepillo para perros. Ideal para eliminar el pelo muerto de tu mascota de una forma fácil",
                    longDescription = "No siempre es fácil mantener el mejor aspecto en tu mascota, sobre todo, si esta tiene un largo pelaje. Pero con el cepillo Furminator para perros estos problemas desaparecerán, ya que con él podrás eliminar el pelo muerto de tu mascota de forma más sencilla. Este accesorio está diseñado para perros de largo pelaje, ya que elimina el pelo muerto de la mascota y ayuda a la producción de aceites naturales y a conseguir una piel más sana.",
                    Price = 32.9,
                    Category = "Higiene",
                    Brand = "Furminator",
                    Stock = 20,
                    ImageUrl = "/images/products/furminator.jpg"
                },
                  new Product
                {
                    Id = 13,
                    Name = "PSH Sensitive Skin Champú para perros y gatos",
                    Description = "Champú para perros y gatos, indicado para pieles sensibles, con irritaciones o intolerancias dérmicas",
                    longDescription = "Champú para perros y gatos, indicado para pieles sensibles, con irritaciones o intolerancias dérmicas, hidrata y humecta la piel, aporta suavidad y elasticidad, elimina impurezas.",
                    Price = 15.9,
                    Category = "Higiene",
                    Brand = "PSH",
                    Stock = 60,
                    ImageUrl = "/images/products/psh.jpg"
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

            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
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
