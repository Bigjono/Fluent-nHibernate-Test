using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace FluentNHibernateTEst.Infrastructure.Helpers.FluentConventions
{
    public class DefaultOneToManyConvention : IHasManyConvention  
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Cascade.All();
        }

    
    }
}
