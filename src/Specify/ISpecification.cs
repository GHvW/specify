using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specify {

    public interface ISpecification<A> {

        public bool IsSatisfiedBy(A item);

        public ISpecification<A> Or(ISpecification<A> other) {
            return new GeneralSpecification<A>((it) => this.IsSatisfiedBy(it) || other.IsSatisfiedBy(it));
        }

        public ISpecification<A> And(ISpecification<A> other) {
            return new GeneralSpecification<A>((it) => this.IsSatisfiedBy(it) && other.IsSatisfiedBy(it));
        }
    }
}
