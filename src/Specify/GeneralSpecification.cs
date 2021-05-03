using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specify {

    public class GeneralSpecification<A> : ISpecification<A> {

        private readonly Func<A, bool> predicate;

        public GeneralSpecification(Func<A, bool> predicate) {
            this.predicate = predicate;
        }

        public bool IsSatisfiedBy(A item) => predicate(item);
    }
}
