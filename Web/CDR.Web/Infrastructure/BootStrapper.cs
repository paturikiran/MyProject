using CDR.Web.Models.LookupModels;

namespace CDR.Web.Infrastructure
{
    using System.Configuration;
    using System.Web.Mvc;
    using StructureMap;
    using CDR.Web.Models;
    using CDR.Web.Api;
    using CDR.Web.Agents;

    /// <summary>
    /// Initializes the objects.
    /// </summary>
    internal class StructureMapBootStrapper
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="StructureMapBootStrapper"/> class from being created.
        /// </summary>
        private StructureMapBootStrapper()
        {
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>Instance of IContainer.</returns>
        internal static IContainer Initialize()
        {
            ObjectFactory.Initialize(expression =>
            {
                expression.For<ISubRequest>().Use<DOCUS_SUB_REQUEST>();
                expression.For<IAssignments>().Use<DOCUS_ASM_ASSIGNMENTS>();
                expression.For<IAssignmentLookupAgent>().Use<AssignmentLookupAgent>();
                expression.For<ISubRequestLookupAgent>().Use<SubRequestLookupAgent>();
                expression.For<ICustodianDetails>().Use<CustodianDetails>();
                expression.For<ILookupModel>().Use<LookupModel>();
                expression.For<INotes>().Use<AssignmentNotes>();

            });
            DependencyResolver.SetResolver(new SMDependencyResolver(ObjectFactory.Container));
            return ObjectFactory.Container;
        }
    }
}
