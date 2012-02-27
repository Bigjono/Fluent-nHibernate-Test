using FluentMigrator;

namespace DBMigration
{

    [Migration(201202241052)]
    public class Migrations_201202241052 : Migration
    {
        public override void Up()
        {
            Create.Table("OrderItem")
                .WithColumn("OrderItemId").AsInt32().PrimaryKey().Identity()
                .WithColumn("ProductName").AsString(255).Nullable()
                .WithColumn("Qty").AsInt32().Nullable()
                .WithColumn("ItemPrice").AsDecimal().Nullable()
                .WithColumn("RequiredBy").AsDateTime().Nullable()
                .WithColumn("Order_id").AsInt32().Nullable();


            Create.Index("ix_Order_id")
                    .OnTable("OrderItem")
                    .OnColumn("Order_id")
                    .Ascending();
                        



            Create.ForeignKey("fx_OrderItem_OrderItd_Order_OrderId")
                .FromTable("OrderItem")
                .ForeignColumn("Order_Id")
                .ToTable("Order").
                PrimaryColumn("OrderId");

        }

        public override void Down()
        {
            Delete.ForeignKey("fx_OrderItem_OrderItd_Order_OrderId");
            Delete.Index("ix_Order_id");
            Delete.Table("OrderItem");
        }
    }


    [Migration(201202231603)]  //  date time  (yyyymmmddhhmm)
    public class Migrations_201202231603 : Migration
    {
        public override void Up()
        {
            Create.Table("Customer")
                .WithColumn("CustomerId").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(100).Nullable()
                .WithColumn("Surname").AsString(100).Nullable()
                .WithColumn("DateOfBirth").AsDateTime().Nullable()
                .WithColumn("EmailAddress").AsString(244).Nullable();

            Create.Index("ix_emailaddress")
                        .OnTable("Customer")
                        .OnColumn("EmailAddress")
                        .Ascending()
                        .WithOptions().Unique();

            Create.Table("Order")
                .WithColumn("OrderId").AsInt32().PrimaryKey().Identity()
                .WithColumn("DateOfOrder").AsDateTime().Nullable()
                .WithColumn("Customer_Id").AsInt32().Nullable();



            Create.Index("ix_Customer_Id")
                .OnTable("Order")
                .OnColumn("Customer_Id")
                .Ascending();
                         


            Create.ForeignKey("fx_Order_CustomerId_Customer_CustomerId")
                .FromTable("Order")
                .ForeignColumn("Customer_Id")
                .ToTable("Customer").PrimaryColumn("CustomerId");

        }

        public override void Down()
        {
            Delete.Table("Customer");
            Delete.Table("Order");
        }
    }
}
