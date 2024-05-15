using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using ReservationGraphQL.Data;
using System.Reflection;

namespace ReservationGraphQL.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
