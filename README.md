HSFizzBuzz

HSFizzBuzz allows for a range of numbers to entered into the FizzBuzz Processor to be processed according to predefined rules based up on the IFBItem interface.

Each implemenation of the IFBItem interface allows for the specification of a numeric condition and what message to display if the condition is found to be true for a given integer.

The FBPRocessor class accepts a list of objects that implement IFBItem and a range of integers. It then checks each integer in the ranges against all conditions.  Conditions are checked in descending order based on the OrderCheck property.  Once a condition is met, no further conditions are checked.  If no conditions are met, then the integer is returned and nothing special message.

The console application, FizzBuzz3, shows example outputs of several different kinds of IFBItem collections.  

The FizzBuzzLib project contains all code for how processing is built.

FizzBuzz Tests contains unit tests for the various implementations.  The "Outside Client Implementations" test category shows how an external client can implement the IFBItem interface and create custom rules that are passed to the FBProcessor.


