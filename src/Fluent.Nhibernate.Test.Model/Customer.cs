using System;

namespace Fluent.Nhibernate.Test.Model
{
    public class Customer
    {
        public virtual int Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string Surname { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual string EmailAddress { get; set; }
    }




}
