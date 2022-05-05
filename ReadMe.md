# Basic Calculator
This calculator is created for test purposes only

## Code Explanation 
There are a total of 5 functions ( 1 main, 4 private )

##### Main Function Positive Input
The while loop is created to make sure that the function will keep on looping until the user type in an input of the term 'END'. 
When running the project this is what will be shown : 
```
Type in END to stop.
Calculation : 
```
When user type in the numbers that need to be counted it will be something like this ( With spaces between the numbers and the symbols ) :
```
Type in END to stop.
Calculation : 2 + 2
```
The code will then get the input and remove any starting space or ending space cause those are not required in the calculation.
Then the code will check is the input matches the word 'END', if so stop the whole calculator.

##### Main Function If User Type In END
Case if END was typed in : 
```
Type in END to stop.
Calculation : END
Thank you for using me.
```

##### Main Function If Wrong Input
Case if END was typed in : 
```
Type in END to stop.
Calculation : 6sdf
Invalid inputs. Please try again

Type in END to stop.
Calculation :
```
