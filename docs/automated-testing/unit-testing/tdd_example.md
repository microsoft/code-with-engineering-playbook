# Test-Driven Development Example

With this method, rather than writing all your tests up front, you write one test at a time and then switch to write the
system code that would make that test pass. It's important to write the bare minimum of code necessary even if it is not
actually "correct". Once the test passes you can refactor the code to make it maybe make more sense, but again the logic
should be simple. As you write more tests, the logic gets more and more complex, but you can continue to make the
minimal changes to the system code with confidence because all code that was written is covered.

As an example, let's assume we are trying to write a new function that validates a string is a valid password format.
The password format should be a string larger than 8 characters containing at least one number. We start with the
simplest possible test; one of the easiest ways to do this is to first write tests that validate inputs into the
function:

```csharp
// Tests.cs
public class Tests
{
    [Fact]
    public void ValidatePassword_NullInput_Throws()
    {
        var s = new MyClass();
        Assert.Throws<ArgumentNullException>(() => s.ValidatePassword(null));
    }
}

// MyClass.cs
public class MyClass
{
    public bool ValidatePassword(string input)
    {
        return false;
    }
}
```

If we run this code, the test will fail as no exception was thrown since our code in `ValidateString` is just a stub.
This is ok! This is the "Red" part of Red-Green-Refactor. Now we want to move onto the "Green" part - making the minimal
change required to make this test pass:

```csharp
// MyClass.cs
public class MyClass
{
    public bool ValidatePassword(string input)
    {
        throw new ArgumentNullException(nameof(input));
    }
}
```

Our tests pass! But wait, this function doesn't really work, it will always throw the exception. That's ok! As we
continue to write tests we will slowly add the logic for this function and it will build on itself, all while
guaranteeing the tests we have continue to pass.

We will skip the "Refactor" stage at this point because there isn't anything to refactor. Next let's add a test that
checks that the function returns false if the password is less than size 8:

```csharp
[Fact]
public void ValidatePassword_SmallSize_ReturnsFalse()
{
    var s = new MyClass();
    Assert.False(s.ValidatePassword("abc"));
}
```

This test will pass as it still only throws an `ArgumentNullException`, but again, that is an expected failure. Fixing
our function should see it pass:

```csharp
public bool ValidatePassword(string input)
{
    if (input == null)
    {
        throw new ArgumentNullException(nameof(input));
    }

    return false;
}
```

Finally some code that looks real! Note how it wasn't the test that checked for null that had us add the `if` statement
for the null-check, but rather the subsequent test which unlocked a whole new branch. By adding that if statement, we
made the bare minimum change necessary in order to get **both** tests to pass. But we still have work to do.

In general, working in the order of adding a negative test first before adding a positive test will ensure that both
cases get covered by the code in a way that can get tests. Red-Green-Refactor makes that process super easy by requiring
the bare minimum change - since we only want to make the bare minimum changes, we just simply return false here, knowing
full well that we will be adding logic later that will expand on this.

Speaking of which, let's add the positive test now:

```csharp
[Fact]
public void ValidatePassword_RightSize_ReturnsTrue()
{
    var s = new MyClass();
    Assert.True(s.ValidatePassword("abcdefgh1"));
}
```

Again, this test will fail at the start. One thing to note here if that its important that we try and make our tests
resilient to future changes. When we write the code under test, we act very naively, only trying to make the current
tests we have pass; when you write tests though, you want to ensure that everything you are doing is a valid case in the
future. In this case, we could have written the input string as `abcdefgh` and when we eventually write the function it
would pass, but later when we add tests that validate the function has the rest of the proper inputs it would fail
incorrectly.

Anyways, the next code change is:

```csharp
public bool ValidatePassword(string input)
{
    if (input == null)
    {
        throw new ArgumentNullException(nameof(input));
    }

    if (input.Length > 8)
    {
        return true;
    }
    return false;
}
```

Here we now have a passing test! But if you notice, the logic doesn't actually make much sense. We did the bare minimum
change which was adding a new condition that passed for longer strings, but thinking forward a little bit we know this
won't work as soon as we add additional validations. So let's use our first "Refactor" step in the Red-Green-Refactor flow!

```csharp
public bool ValidatePassword(string input)
{
    if (input == null)
    {
        throw new ArgumentNullException(nameof(input));
    }

    if (input.Length < 8)
    {
        return false;
    }
    return true;
}
```

That looks better. Note how from a functional perspective, inverting the if-statement has no changes in the actual
returns of any of the functions and our functions still return the same. This is an important part of the refactor flow,
maintaining the logic by doing provably safe refactors, usually through the use of tooling and automated refactors from
your IDE.

Finally we have one last requirement for our `ValidatePassword` method and that is that it needs to check that there is
a number in the password. Let's again start with the negative test and validate that with a string with the valid length
that the function returns `false` if we do not pass in a number:

```csharp
[Fact]
public void ValidatePassword_ValidLength_ReturnsFalse()
{
    var s = new MyClass();
    Assert.False(s.ValidatePassword("abcdefghij"));
}
```

And of course the test fails as it is only checking length requirements. Let's fix the method to check for numbers:

```csharp
public bool ValidatePassword(string input)
{
    if (input == null)
    {
        throw new ArgumentNullException(nameof(input));
    }

    if (input.Length < 8)
    {
        return false;
    }

    if (!input.Any(char.IsDigit))
    {
        return false;
    }
    return true;
}
```

Here we use a handy LINQ method to check if any of the `char`s in the `string` are a digit, and if not, return false.
Tests now pass and we can refactor. For readability, why not combine the `if` statements:

```csharp
public bool ValidatePassword(string input)
{
    if (input == null)
    {
        throw new ArgumentNullException(nameof(input));
    }

    if ((input.Length < 8) ||
        (!input.Any(char.IsDigit)))
    {
        return false;
    }

    return true;
}
```

As we make these refactors, we feel 100% confident in the changes we made as we have 100% test coverage which tests both
positive and negative scenarios. In this case we actually already have a method that tests the positive case from the
previous tests and our function is done!

Now that our code is completely tested we can make all sorts of changes and still have confidence that it works. For
example, if we wanted to change the implementation of the method to use regex, all of our tests would still pass and
still be valid.

And that is it! We finished writing our function, we have 100% test coverage, and if we had done something a little more
complex, we would been guaranteed that whatever we designed is already testable since the tests were written first!
