using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace FluentNHibernateTEst.Infrastructure.Helpers.FluentConventions
{
    public class PrimaryKeyConvention : IIdConvention 
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
        }
    }
}
