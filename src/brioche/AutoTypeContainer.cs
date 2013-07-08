using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace brioche
{
    public class AutoTypeContainer : TypeContainer
    {
        /// <summary>
        /// Scans current app domain and attempts to register all classes and interfaces.
        /// </summary>
        public AutoTypeContainer()
            : base(new SimpleTypeRegistry(), new SimpleInstanceCreator())
        {
            AutoTypeDiscoverer discoverer = new AutoTypeDiscoverer(this);

            discoverer.Scan();
        }

        /// <summary>
        /// Scans current app domain and attempts to register all classes and interfaces
        /// in the specified namespace.
        /// </summary>
        /// <param name="inNamespace">Restrict to this namespace and below.</param>
        public AutoTypeContainer (string inNamespace)
            : this(inNamespace, new SimpleTypeRegistry(), new SimpleInstanceCreator())
        {
        }

        /// <summary>
        /// Scans current app domain and attempts to register all classes and interfaces
        /// in the specified namespace.
        /// </summary>
        /// <param name="inNamespace"></param>
        public AutoTypeContainer(string inNamespace, IRegisterTypes types, ICreateInstances instances)
            : base(types, instances)
        {
            AutoTypeDiscoverer discoverer = new AutoTypeDiscoverer(this, inNamespace);

            discoverer.Scan();
        }

    }
}
