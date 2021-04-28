# BLAIR
***The magic of code***🧙‍♀️🔮

BLAIR© is a programming language made in ```C#``` with the intention of learning the operation, structure and logic of raw programming languages

<img src="https://github.com/Krauzy/blair/blob/main/Example.png" width="800">

# Analysis
A compiler has:

| Name | Description | Example |
| ------ | ------ | ------ |
| Tokens | The compiler creates a list of tokens by analyzing all the words written in the code against the reserved words of the language grammar (EBNF) | <code>if</code> <code>else</code> <code>while</code> |
| Output Errors | The compiler has a list of errors that are displayed during or after the end of the compilation and are made up of errors found in any of the three compilation analyzes | Unexpected Token  |
| Lexical Analysis | The first phase of compiler analysis, here, the compiler identifies and lists tokens and identifies lexical errors | [Reference](https://www.tutorialspoint.com/compiler_design/compiler_design_lexical_analysis.htm#:~:text=Lexical%20analysis%20is%20the%20first,comments%20in%20the%20source%20code.) |
| Syntactic Analysis | The second phase of compiler analysis, here, the compiler identifies whether tokens are following the rules of language grammar | [Reference](https://www.tutorialspoint.com/compiler_design/compiler_design_syntax_analysis.htm) |
| Semantic Analysis | The third and final analysis phase, here, the compiler checks whether the value of the variable tokens (```numbers```, ```string```, ```boolean```, etc.) are inserted in logically correct operations | [Reference](https://www.tutorialspoint.com/compiler_design/compiler_design_semantic_analysis.htm) |

<img src="https://slidetodoc.com/presentation_image_h/29b578585db11eafc4a2f2e122d35ade/image-5.jpg" width="400">

## Lexical✔️

- [x] Consistent grammar
- [x] Definition of First and Follow rules
- [x] Token recognition (with details)

## Syntatic❌

- [ ] Complete syntatic analysis
- [x] Error identification and indication (row and column)
- [x] Error handling

## Semantic❌

- [ ] Types check
- [ ] Inicialization check
- [ ] Non-use check
- [ ] Use of casting
