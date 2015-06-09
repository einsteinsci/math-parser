# Math Parser
A [Pratt Parser](http://journal.stuffwithstuff.com/2011/03/19/pratt-parsers-expression-parsing-made-easy/) to parse mathematical expresssions in a made-up language. This library takes a string, can convert it into a token stream, parse that stream into a parse tree (returning the root node), and evaluate that into a result. The language has support for multiple types, currently only integers, reals (`double`), lists (`List<double>`), booleans, and strings. This library provides many built-in functions for many mathematical calculations, from square roots to permutations to a help function.

## Usage
If all you need is something that can parse a string and evaluate the result, `Evaluator.Evaluate()` is the simplist way to do this. To evaluate the string `"5.5 * (34.6 + 2)"`, use this code:
```csharp
double result = Evaluator.Evaluate("5.5 * (34.6 + 2)").ToDouble();
```
The result of `Evaluator.Evaluate()`, or the result from evaluating a parse tree (or any of its nodes), will always be an `IEvaluatable`. This interface defines methods to convert to the C#-friendly types you need for the rest of your code, such as `ToDouble()` above. It also defines the property `CoreValue`, which is a simple object that holds the C#-friendly data without casting it.

## Syntax
The syntax to this language is mostly a blend of C-based languages with mathematical notation.

### Operators
| Operator | Functionality | C# Equivalent |
|:--------:|:-------------:|:-------------:|
| `+` | Addition | `+` |
| `-` | Subtraction | `-` |
| `*` | Multiplication | `*` |
| `/` | Division | `/` |
| `%` | Modulus | `%` |
| `^` | Exponentiation | `Math.Pow()` |
| `&` | Conditional 'And' | `&&` |
| `|` | Conditional 'Or' | `||` |
| `=` | Equivalence | `==` |

---

## Extensibility
One of the main goals of this project is extensibility. The user of this library should be able to add their own additions to the language for their own use, without having to recompile the original source code (right here). The user can add their own functions very easily by simply applying a few attributes and loading the assembly into the `Extensibility` class. Custom infix, prefix, and suffix operators can be created quite easily by creating several classes, implementing the abstract methods and properties, and applying the necessary atributes. For the more adventurous, custom sytax rules can be created by also implementing the `IInfixParselet` or `IPrefixParselet` interfaces and loading them in your initialization code. For now, only the types mentioned earlier are useable, but custom types may eventually be implemented.
