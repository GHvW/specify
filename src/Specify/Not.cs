using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specify {

    public class Not<A> : ISpecification<A> {

        private readonly ISpecification<A> specification;

        public Not(ISpecification<A> specification) {
            this.specification = specification;
        }

        public bool IsSatisfiedBy(A item) => 
            !this.specification.IsSatisfiedBy(item);
    }
}
