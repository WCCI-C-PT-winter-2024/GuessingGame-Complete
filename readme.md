# WCCI - Guess the Number Game

<p style="text-align: center"><image src="WECANCodeIT.png" /></p>

## Summary
The Guessing Game in C# is a console-based project where the program generates a random number, and players attempt to guess the correct number within a specified range. It's designed to provide an interactive and entertaining experience for testing guessing skills.

## Skills Required
- delgetes
- events

### Features
- **Random Number Generation:** The game generates a random number within a user-defined range.
- **User Input:** Players can enter their guesses through the console.
- **Feedback Mechanism:** The program provides feedback on whether the guess is too high, too low, or correct.
- **Play Again Option:** After each round, players can choose to play again, making it a repeatable and engaging game.

### Welcome Message:
   - Upon running the program, a welcome message is displayed.
   - Prompt for the user name
### Guessing Process:
 - The program randomly selects a number within the specified range (e.g., 1 to 100).
 - Players are prompted to enter their guesses through the console.

### Feedback:
   - After each guess, the program provides feedback:
     - "Too low!" if the guess is below the target.
     - "Too high!" if the guess is above the target.
     - "Congratulations!" if the guess is correct.

### Play Again:
- Players can choose to play again after each round.
- The game resets with a new random number.

## Stretch Tasks

> We are enhancing the We Can Code It Guessing Game. Use the following user stories to build out your features.

- As a User I should be given 10 guesses so that I can maximize my chances of winning the game
- As a User I should be able to keep track of my total wins and losses so that I can show my friends
- As a User I want to be able to add my name to a leader board
- As a User I want the game to be more challenging and reward points based on the amount of guesses it took

## FYI

- The ZingBot class has been provided solely as a learning tool.
- All the stretch tasks can be completed from the Program class and may require more variables or methods