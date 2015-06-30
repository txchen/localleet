using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

// Make the xunit test execution in order
[assembly: TestCollectionOrderer("LocalLeet.DisplayNameOrderer", "csharp")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace LocalLeet
{
    public class DisplayNameOrderer : ITestCollectionOrderer
    {
        public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
        {
            return testCollections.OrderBy(collection => collection.DisplayName);
        }
    }
}
