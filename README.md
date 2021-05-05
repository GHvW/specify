# specify
A tiny library for composeable specifications

Heavily inspired by Eric Evans' book [Domain Driven Design](https://www.goodreads.com/book/show/179133.Domain_Driven_Design)

### Usage
The main feature of specify is the `ISpecification<A>` interface. `ISpecification<A>` is essentially a predicate. By implementing
its `IsSatisfiedBy` method you get the ability to compose with `Or` and `And`. `ISpecification<A>`s can be inverted with the `Not` class.

```csharp
public class AtLeast5FeetTall : ISpecification<Guest> {

	public bool IsSatisfiedBy(Guest item) => item.Height >= 5.0;
}

public class AtLeast15YearsOld : ISpecification<Guest> {

	public bool IsSatisfiedBy(Guest item) => item.Age >= 15;
}

// ...

var canRideRollerCoaster = new AtLeast5FeetTall().And(new AtLeast15YearsOld());

// ...

var cannotRideRollerCoaster = new Not(canRideRollerCoaster);
```

specify has a `GeneralSpecification` that can be used for ad hoc specifications. Not recommended, but it's an option

```csharp
var isLessThan100 = new GeneralSpecification<int>((it) => it < 100);
```

### Background
I recently read Eric Evans' Domain Driven Design, and loved the idea of Specifications presented in Chapter 9. But I wanted a way
to compose Specifications. I thought I'd turn a class into a predicate with an interface `ISpecification`. 
It would define a `Call(A item)` method to implement. In doing so, implementers would get `Or` and `And`methods for free.

When I saw Eric's declarative implementation in Chapter 10, I loved the wording "is satsified by" for calling the predicate. 
It sounded like a name more concerned with shaping a domain than the technical aspects of the construct. Something I've struggled with.

So I stole it :satisfied:.

The implementation here is a little different, but I think the core concepts are the same as the Chapter 10 design. If you
haven't read [Domain Driven Design](https://www.goodreads.com/book/show/179133.Domain_Driven_Design) it is fantastic.
I can't recommend it enough
