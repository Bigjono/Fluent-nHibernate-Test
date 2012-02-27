using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace FluentNHibernateTEst.Infrastructure.Helpers.FluentConventions
{
    public class DefaultReferencesConvention : IReferenceConvention
    {


        public void Apply(IManyToOneInstance instance)
        {
            instance.Cascade.SaveUpdate();
        }
    }
}
