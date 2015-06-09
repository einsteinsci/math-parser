# Math Parser
This project uses a [Pratt Parser](http://journal.stuffwithstuff.com/2011/03/19/pratt-parsers-expression-parsing-made-easy/) to parse mathematical expresssions in a made-up language. This library takes a string, can convert it into a token stream, parse that stream into a parse tree (returning the root node), and evaluate that into a result. The language has support for multiple types, currently only integers, reals (`double`), lists (`List<double>`), booleans, and strings. This library provides many built-in functions for many mathematical calculations, from square roots to permutations to a help function.

## Usage
In order to use this library, go ahead and download the corresponding Nuget package, which is currently being uploaded this very minute. This library depends on the MathPlus library for some of its functions ([nuget](https://www.nuget.org/packages/MathPlus.Desktop/0.2.0)) ([github](https://github.com/einsteinsci/math-plus)), but it should be downloaded with this package if Nuget is used.

If all you need is something that can parse a string and evaluate the result, `Evaluator.Evaluate()` is the simplist way to do this. To evaluate the string `"5.5 * (34.6 + 2)"`, use this code:
```csharp
double result = Evaluator.Evaluate("5.5 * (34.6 + 2)").ToDouble();
```
The result of `Evaluator.Evaluate()`, or the result from evaluating a parse tree (or any of its nodes), will always be an `IEvaluatable`. This interface defines methods to convert to the C#-friendly types you need for the rest of your code, such as `ToDouble()` above. It also defines the property `CoreValue`, which is a simple object that holds the C#-friendly data without casting it.

## Syntax
The syntax to this language is mostly a blend of C-based languages with mathematical notation.

### Types
The types used by this library are listed in the enumeration `MathType`. Each of these types has multiple equivalent system types so that excessive casting is avoided. To convert from a `MathType` to a system `Type`, use the static class `MathTypes`. All of these types can be converted to all the others, though some with more difficulty or risk of exceptions than others.

| MathType | Stored Internal Type | Valid Convertible System Types |
|:--------:|:--------------------:| ----------------------- |
| `Real` | `double` | `double`, `float`, `decimal` |
| `Integer` | `long` | `long`, `int`, `short` |
| `String` | `string` | `string` |
| `Boolean` | `bool` | `bool` |
| `List` | `List<double>` | Various* |
\* Specifically, `List<double>`, `List<float>`, `List<decimal>`, `double[]`, `float[]`, and `decimal[]`.

### Operators
| Operator | Functionality | Valid Types | C# Equivalent |
|:--------:|:-------------:|:-----------:|:-------------:|
| `+` | Addition | Real, Integer | `+` |
| `-` | Subtraction | Real, Integer | `-` |
| `*` | Multiplication* | Real, Integer | `*` |
| `/` | Division | Real, Integer | `/` |
| `%` | Modulus | Real, Integer | `%` |
| `^` | Exponentiation | Real, Integer | `Math.Pow()` |
| `!` | Unary Factorial (Postfix) | Integer | `MathPlus.Probability.Factorial()` |
| `&` | Conditional 'And' | Boolean | `&&` |
| `|` | Conditional 'Or' | Boolean | `||` |
| `~` | Unary 'Not' (Prefix) | Boolean | `!` |
| `=` | Equivalence | (All) | `==` |
| `~=` | Nonequivalence | (All) | `!=` |
| `<` `>` `<=` `>=` | Comparison | Real, Integer | `<` `>` `<=` `>=` |
| `<>` | String Concatenation | String | `System.String.operator+()` |
| `? :` | Conditional Expression** | (All) | `? :` |
\* Implicit mutiplication (like `3a`) is **not** allowed. This is due to the fact that variables (currently only accessible through `VariableRegistry`) can have names longer than one character. If implicit multiplication was allowed, there would be no way to determine if, for example, the input string `"ab"` references a variable called `ab` or two variables `a` and `b` multiplied together implicitly.

\** This uses the same mixfix syntax as in C.

### Comments
Portions of math can be "commented out" by surrounding them with /* and */, just as in C. Note that there is no "line comment" alternative.

### Functions
Functions are called using the same syntax in C: `functionName(arg1, arg2, ...)`. A list of all registered functions can be found by calling the function `helpall()`. It will return a string listing all the functions in a table-like format.

---

## Extensibility
One of the main goals of this project is extensibility. The user of this library should be able to add their own additions to the language for their own use, without having to recompile the original source code (right here). The user can add their own functions very easily by simply applying a few attributes and loading the assembly into the `Extensibility` class. Custom infix, prefix, and suffix operators can be created quite easily by creating several classes, implementing the abstract methods and properties, and applying the necessary atributes. For the more adventurous, custom sytax rules can be created by also implementing the `IInfixParselet` or `IPrefixParselet` interfaces and loading them in your initialization code. For now, only the types mentioned earlier are useable, but custom types may eventually be implemented.


