# Mastermind
Mastermind implementation with a menu with 4 options.<br />
1. Random try <br />
A random generated list of ints representing different color pins as the code<br />
Another random generated list of ints representig different collor pins as a try<br />
Printing the result depending if it's a lucky try or not.<br />

2. Play against computer player<br />
Computer generates a list of random ints between 0 and the numberOfEachColor parameter from the beginning.<br />
User has (2 * numberOfEachColor) tries available and is returned the selection and the number of correct matches he did in a turn after getting the input.<br />
If user guesses the correct list in the available tries number, he wins, otherwise the computer wins.<br />

3. Play against human player <br />
First user is prompted to choose a list of ints between 0 and the numberOfEachColor parameter from the beginning.<br />
Then the second player has (2 * numberOfEachColor) tries available and is returned the selection and the number of correct matches he did in a turn after getting the input.<br />
If the second player guesses the correct list in the available tries number, he wins, otherwise the first player wins.<br />

4. Help menu<br />
A short info screen.
