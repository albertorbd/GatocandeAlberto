using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gatocan.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    longDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price", "Stock", "longDescription" },
                values: new object[,]
                {
                    { 1, "Royal Canin", "Alimentación", "Pienso para perros adultos de razas grandes que minimiza los efectos del envejecimiento y mejora la salud articular.", "/images/products/royalcanin.jpg", "Royal Canin Maxi Adult pienso para perros", 20.5, 50, "Royal Canin Maxi Adult es el alimento indicado para aquellos perros que en edad adulta alcanzan más de 25 kg gracias a su receta, creada especialmente para mantener su organismo en un estado óptimo." },
                    { 2, "Advance", "Alimentación", "Pienso de pollo y arroz para perros medianos adultos.", "/images/products/advance.jpg", "Advance Active Defense Medium Adult Pollo y Arroz pienso para perros", 67.0, 25, "Se trata de un alimento para perros especialmente diseñado para cubrir todas sus necesidades. Su composición cuenta con una destacada selección de proteínas e hidratos de carbono, lo que ayuda a mantener una digestibilidad muy alta y un correcto proceso digestivo. Además de pirofosfatos, un componente que evita el mal aliento y la formación de sarro." },
                    { 3, "True Origins", "Alimentación", "Comida húmeda de atún y sardinas para gatos adultos.", "/images/products/trueorigins.jpg", "True Origins Pure Adult Atún y Sardina lata para gatos", 18.699999999999999, 45, "Este delicioso alimento complementario para gatos de la marca True Origins es adecuado para que tu mascota se mantenga fuerte y sana, además de disfrutar de un delicioso alimento húmedo con muchas vitaminas y minerales esenciales para su alimentación." },
                    { 4, "True Origins", "Alimentación", "Snack totalmente natural sin cereales ni azúcares para gatos adultos.", "/images/products/trueorigins2.jpg", "True Origins Pure Bocaditos Adult Crunchy de Pavo para gatos", 35.799999999999997, 50, "Los bocaditos para gatos Pure Crunchy de True Origins son ideales para ofrecer a tu felino adulto una golosina deliciosa en cualquier momento del día para recompensarle o mimarle, de esta forma, complementarás su dieta de manera óptima y saludable. Cuentan con una fórmula deliciosa que mezcla carne fresca de pavo con vegetales, junto a una textura crujiente única que a tu mascota le encantará masticar a cualquier hora." },
                    { 5, "Royal Canin", "Alimentación", "Alimento húmedo sano y equilibrado para gatos seniors.", "/images/products/royalcanin2.jpg", "Royal Canin Ageing 12+ sobre en salsa para gatos", 10.0, 40, "Los sobres de comida húmeda Royal Canin Ageing cuidan la salud de los gatos de edad avanzada, ya que se adaptan completamente a sus necesidades y evita el riesgo de que puedan padecer algunas enfermedades como la insuficiencia renal o artrosis." },
                    { 6, "Advance", "Alimentación", "Pienso para gatos esterilizados que pueden sufrir un aumento de peso. También ayuda a reducir la formación de bolas de pelo.", "/images/products/advance1.jpg", "Advance Sterilized Hairball Pavo y Cebada pienso para gatos", 49.0, 20, "El pienso para gatos Advance Sterilized Hairball es perfecto para aquellos gatos que han pasado por una esterilización o una castración y que presentan o pueden presentar los problemas típicos de este tipo de intervenciones, como el aumento de peso." },
                    { 7, "Flamingo", "Juguetes", "Caña para gatos Flamingo Happy Flower", "/images/products/flamingo.jpg", "Flamingo Happy Caña con flor para gatos", 4.0, 60, "La caña para gatos Flamingo Happy Flower con flor de peluche es un original juguete interactivo que desarrolla la motivación y concentración de tu mascota y con el que pasará muchos gratos y divertidos momentos. Un llamativo accesorio con el que conseguirás que tu pequeño amigo peludo esté activo y realice el ejercicio diario necesario para estar saludable." },
                    { 8, "Tootoy!", "Juguetes", "Pato de peluche para perros, con sonido y mordedor circular de cuerda, fabricado en tejido vaquero suave.", "/images/products/tootoy.jpg", "Tootoy! Comfort Denim Duck peluche con sonido y cuerda para perros", 15.0, 25, "El peluche de pato de tejido vaquero de Tootoy! es se convertirá en el mejor amigo de tu perro. Su diseño adorable y su tejido vaquero suave lo convierten en el accesorio perfecto para dormir la siesta, mientras que el pitido que emite cuando lo muerden y el mordedor de cuerda circular que incorpora este juguete, les divierte y estimula su curiosidad. A tu perro le encantará este peluche ¿Quién le dice que ese pato nunca correrá ni volará para él?" },
                    { 9, "Nylabone", "Juguetes", "Nylabone hueso mordedor de nylon para perros.", "/images/products/nylabone.jpg", "Nylabone Extreme Chew Pollo Hueso Mordedor para perros", 5.0, 35, "Mordedor para perros de Nylabone diseñado para satisfacer los instintos naturales de tu mascota, evitando así que muerda muebles u otros objetos, además fortalece la mandíbula dándole un mejor agarre, también protege los dientes en cada mordida que le da al juguete, ya que limpia y evita la aparición de sarro. Este masticador para perros contiene un sabor delicioso y duradero a pollo, lo que hará que tu mascota pase mucho más tiempo jugando." },
                    { 10, "Flamingo", "Juguetes", "El Calamar azul de Flamingo es un juguete para perros que posee termoplástico en la cabeza y a su vez de felpa que masajea las encías de tu mascota, previene el sarro y la placa.", "/images/products/flamingo1.jpg", "Flamingo Wilco Calamar Azul de Peluche para perros", 6.9000000000000004, 32, "El divertido calamar azul de peluche para perros es un excelente juguete de Flamingo, pues es un artículo funcional para tu mascota. Por un lado, tu peludo amigo se entretendrá mordiendo la parte superior del peluche y por otro, debido a sus filamentos de termoplástico, se hará auto-limpieza dental para mantener una buena higiene bucodental. " },
                    { 11, "TK-Pet", "Higiene", "La bandeja sanitaria cerrada TK-Pet Minerva es un práctico aseo de color rojo para gatos de cualquier raza y tamaño, con el que hacen sus necesidades cómodamente.", "/images/products/tkpet.jpg", "TK-Pet Minerva Bandeja Sanitaria para gatos", 22.600000000000001, 31, "Como sucede con los humanos, los animales también necesitan intimidad cuando se trata de hacer sus necesidades. Por ello, TK Pet lanza al mercado la bandeja sanitaria cerrada Minerva para gatos, un accesorio agradable y amplio adecuado para felinos de todas las razas y tamaños." },
                    { 12, "Furminator", "Higiene", "Furminator cepillo para perros. Ideal para eliminar el pelo muerto de tu mascota de una forma fácil", "/images/products/furminator.jpg", "Furminator Cepillo para perros de pelo largo", 32.899999999999999, 20, "No siempre es fácil mantener el mejor aspecto en tu mascota, sobre todo, si esta tiene un largo pelaje. Pero con el cepillo Furminator para perros estos problemas desaparecerán, ya que con él podrás eliminar el pelo muerto de tu mascota de forma más sencilla. Este accesorio está diseñado para perros de largo pelaje, ya que elimina el pelo muerto de la mascota y ayuda a la producción de aceites naturales y a conseguir una piel más sana." },
                    { 13, "PSH", "Higiene", "Champú para perros y gatos, indicado para pieles sensibles, con irritaciones o intolerancias dérmicas", "/images/products/psh.jpg", "PSH Sensitive Skin Champú para perros y gatos", 15.9, 60, "Champú para perros y gatos, indicado para pieles sensibles, con irritaciones o intolerancias dérmicas, hidrata y humecta la piel, aporta suavidad y elasticidad, elimina impurezas." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Balance", "Email", "Lastname", "Name", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, null, 100.0, "juan@example.com", "Pérez", "Juan", "pass123", null, "user" },
                    { 2, null, 150.0, "albertoriveiro@hotmail.es", "Riveiro", "Alberto", "pass456", null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "DateCreated", "UserId" },
                values: new object[] { 1, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Date", "PaymentMethod", "ProductId", "Quantity", "Tipo", "UserId" },
                values: new object[] { 1, 20.5, new DateTime(2024, 5, 6, 0, 9, 2, 0, DateTimeKind.Unspecified), "Tarjeta", 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
