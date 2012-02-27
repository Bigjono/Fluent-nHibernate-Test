using System;

namespace Fluent.Nhibernate.Test.Model
{
    public class OrderItem
    {
        public virtual int Id { get; private set; }
        public virtual string ProductName { get; set; }
        public virtual int Qty { get; set; }
        public virtual decimal ItemPrice { get; set; }
        public virtual DateTime? RequiredBy { get; set; }
    }
}
