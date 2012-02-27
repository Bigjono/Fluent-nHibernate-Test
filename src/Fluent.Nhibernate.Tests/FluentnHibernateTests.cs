using System;
using System.Linq;
using Fluent.Nhibernate.Infrastructure.nHibernate;
using Fluent.Nhibernate.Test.Model;
using NHibernate;
using NHibernate.Linq;
using Xunit;

namespace Fluent.Nhibernate.Tests
{
    public class FluentnHibernateTests : IDisposable
    {

        #region dependancy
        private readonly ISession _session;
        #endregion


        #region ctor & tear down
        public FluentnHibernateTests()
        {
            _session = SessionHelper.OpenSession();
        }

        public void Dispose()
        {
            _session.Close();
        }
        #endregion


        [Fact]
        public void Can_Create_New_Order_With_New_Customer_From_Single_Update()
        {
            using (var trans = _session.BeginTransaction())
            {
                var order = new Order
                                {
                                    DateOfOrder = DateTime.Now,
                                    Customer = new Customer()
                                                   {
                                                       FirstName = "Bob",
                                                       Surname = "Smith",
                                                       EmailAddress = "bobsmith@test.com",
                                                       DateOfBirth = new DateTime(1970, 1, 1)
                                                   }
                                };


                order.AddOrderItem("Widget 1", 3, (decimal)49.99, null);
                _session.Save(order);
                trans.Commit();
            }

            var orderReadBack = _session.Query<Order>().Single(x => x.Customer.EmailAddress == "bobsmith@test.com");

            Assert.NotEqual(0, orderReadBack.Id);



            // customer will not delete from order
            // only children like order items.
            using(var trans =_session.BeginTransaction())
            {
                var customer = orderReadBack.Customer;

                _session.Delete(orderReadBack);
                _session.Delete(customer);
                trans.Commit();
            }

        }


    }


}
