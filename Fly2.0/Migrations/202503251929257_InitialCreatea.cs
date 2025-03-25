namespace Fly2_0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreatea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        IdAddress = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                        PostAddress = c.String(),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.IdAddress);
            
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        IdAdministrator = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        NumberEmployee = c.String(),
                    })
                .PrimaryKey(t => t.IdAdministrator);
            
            CreateTable(
                "dbo.Aircrafts",
                c => new
                    {
                        IdAircaraft = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Company = c.String(),
                        SeatOnBoard = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAircaraft);
            
            CreateTable(
                "dbo.Airtickets",
                c => new
                    {
                        IdAirticket = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdTicketType = c.Int(nullable: false),
                        IdFlight = c.Int(nullable: false),
                        TicketNumber = c.String(),
                        SeatOnBoard = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdAirticket);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        IdContact = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdContact);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        IdFlight = c.Int(nullable: false, identity: true),
                        IdAircraft = c.Int(nullable: false),
                        FlightNumber = c.String(),
                        DepartureAirport = c.String(),
                        ArrivalAirport = c.String(),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        Distance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFlight);
            
            CreateTable(
                "dbo.Passports",
                c => new
                    {
                        IdPassport = c.Int(nullable: false, identity: true),
                        Nationality = c.String(),
                        Number = c.String(),
                        Validity = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdPassport);
            
            CreateTable(
                "dbo.TicketTypes",
                c => new
                    {
                        IdTicketType = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Сoefficient = c.Double(nullable: false),
                        Description = c.String(),
                        Bagath = c.String(),
                    })
                .PrimaryKey(t => t.IdTicketType);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        IdAddress = c.Int(nullable: false),
                        IdContact = c.Int(nullable: false),
                        IdPassport = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        Sex = c.String(),
                        DateOfBirth = c.DateTime(),
                        ParticipantNumber = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.TicketTypes");
            DropTable("dbo.Passports");
            DropTable("dbo.Flights");
            DropTable("dbo.Contacts");
            DropTable("dbo.Airtickets");
            DropTable("dbo.Aircrafts");
            DropTable("dbo.Administrators");
            DropTable("dbo.Addresses");
        }
    }
}
