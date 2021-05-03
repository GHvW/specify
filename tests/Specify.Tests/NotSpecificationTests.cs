using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Specify.Tests {

    public class NotSpecificationTests {

        [Fact]
        // TODO - better name for this and split up
        public void GivenASpecification_WhenInverted_ReturnsInverseOfSpecification() {

            // Arrange
            var lessThan100 = new GeneralSpecification<int>((it) => it < 100);

            var oneHundredOrMore = new Not<int>(lessThan100);

            // Act
            var actualAt100 = oneHundredOrMore.IsSatisfiedBy(100);
            var actualMoreThan100 = oneHundredOrMore.IsSatisfiedBy(101);
            var actualLessThan100 = oneHundredOrMore.IsSatisfiedBy(99);

            // Assert
            Assert.True(actualAt100);
            Assert.True(actualMoreThan100);
            Assert.False(actualLessThan100);
        }
    }
}
