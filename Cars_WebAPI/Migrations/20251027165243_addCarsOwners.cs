using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCarsOwners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
 SET IDENTITY_INSERT [dbo].[MyOwner] ON;

 INSERT INTO [dbo].[MyOwner] ([Id], [FullName], [Email], [Phone], [Address]) VALUES (1, N'Иван Иванов', N'ivan@example.com', N'+79112223344', N'ул. Ленина, д. 1');
 INSERT INTO [dbo].[MyOwner] ([Id], [FullName], [Email], [Phone], [Address]) VALUES (2, N'Петр Петров', N'petr@example.com', N'+79223334455', N'пр. Мира, д. 25, кв. 10');
 INSERT INTO [dbo].[MyOwner] ([Id], [FullName], [Email], [Phone], [Address]) VALUES (3, N'Анна Иванова', N'anna@example.com', N'+79334445566', N'ул. Садовая, д. 5');
        
 SET IDENTITY_INSERT [dbo].[MyOwner] OFF;


 SET IDENTITY_INSERT [dbo].[MyCar] ON;
        
 INSERT INTO [dbo].[MyCar] ([Id], [Brand], [Model], [Speed], [Price], [Data], [Weight], [OwnerId]) VALUES (1, N'Toyota', N'Camry', 220, 25000, 2022, 1500, 1);
 INSERT INTO [dbo].[MyCar] ([Id], [Brand], [Model], [Speed], [Price], [Data], [Weight], [OwnerId]) VALUES (2, N'Ford', N'Mustang', 250, 45000, 2023, 1700, 1);
 INSERT INTO [dbo].[MyCar] ([Id], [Brand], [Model], [Speed], [Price], [Data], [Weight], [OwnerId]) VALUES (3, N'BMW', N'X5', 240, 60000, 2021, 2200, 2);
 INSERT INTO [dbo].[MyCar] ([Id], [Brand], [Model], [Speed], [Price], [Data], [Weight], [OwnerId]) VALUES (4, N'Honda', N'Civic', 200, 22000, 2024, 1300, 3);
 INSERT INTO [dbo].[MyCar] ([Id], [Brand], [Model], [Speed], [Price], [Data], [Weight], [OwnerId]) VALUES (5, N'Audi', N'A4', 230, 42000, 2023, 1600, 3);

 SET IDENTITY_INSERT [dbo].[MyCar] OFF;
 ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
