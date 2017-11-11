# DieRoller

An interpreter for a simple language so you can roll dice more easily.

# How to use:

An expression may be:  
* an integer
* a unary operator followed by an expression
* an expression followed by a binary operator followed by a binary operator
* an expression contained within parentheses '`(`' and '`)`'

The unary operators are:
* `+` - unary addition (does nothing)
* `-` - additive inverse (works as expected)
* `d` - rolls a die of specified size

The binary operators are:
* `+` - addition (works as expected)
* `-` - subtraction (works as expected)
* `d` - roll dice


## How the unary and binary `d` works.

The `d` is called the die roll operator or die operator for short. There is a unary and binary version of the die operator, however the unary may be converted into the binary version

Let `A` and `B` be valid expressions.
Then the expression `AdB` would work as
1. Evaluate `A`, let us call the result `a`.
2. Evaluate `B`, let us call the result `b`.
3. Roll a `b` sided die `a` times and return the sum.
  * The `d` operator is only defined if `a >= 0` and `b > 0`

The expression `dA` would be equivlent to `1dA`. So if `A` evaluates to the result `a` then we roll one `a` sided die and return the result.

### Definition of die:  
When we say roll a die we must specific. A die with n sides has numbers {1, 2, ..., n}, and each value is equally likely. More specifically rolling a die with n sides returns a positive integer less than or equal to n with a uniform probability distribution.

## Order of operations:

Precedence level | Name | Type of operator | Associativity | Operators
--- | --- | --- | --- | ---
0 | Unary Arithmatic | Unary Prefix | N/a | `+`, `-`, `d`
1 | Die Operation | Binary | Left | `d`
2 | Arithmatic | Binary | Left | `+`, `-`



