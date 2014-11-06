CommandPatternExample
=====================

CommandPatternExample

Points to consider:
-------------------

- Represent an action as an object
- Decouple clients that execute the command from the details and dependancies of the command logic
- Enables delayed exceution
  - Can queue commands for later execution
  - If command objects are also persistent, can delay across process restarts

Applicable for Logging, Validation, Undo

Structure
- http://i.imgur.com/zPrBNCS.png?1

One step further
- http://i.imgur.com/w7mr8xt.png

Consequences
- Commands must be completely self contained
  - The client doesnt pass in any arguments
- Easy to add new commands
  - Just add a new class (open/closed principle)

* Strategy pattern changes its own context according to what is passed into it

Related Patterns

- Factory Pattern
  - used to construct command objects
- Null Object Pattern
  - Handle null cases with same code flow
- Composite
  - A construct with several child commands
