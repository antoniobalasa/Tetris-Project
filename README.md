# Tetris-Project
Translation of some of the major parts of the Tetris project

Form 1 - login/signup page, middle button for playing without signing up, bottom button for close, form does some validation for login data based on a list of accounts saved in Program.

Form2 - Tetris game. 2 timers (1 for clicks in game, 1 for when to change ad banner). Functions for drawing squares in a 10 x 20 space. Lists for different shapes (4 squares) and configurations. Load checks player and abilities he owns. It displays active profile picture data and abilities. Functions for random select of shape and updates every second (falling down one row).  Function for arrow key events. Every move, game checks if the shape squares are out of limits (left, right) and it does not let the shape go left or right further. Every move down (from game update or from down arrow) checks if shape hits an already occupied square from a list of occupied squares. It adds the shape to occupied squares and checks for a complete line. Function to update occupied squares by taking out complete lines. Checks game over if a shape reaches the top. I coded special game abilities like removing all squares, laser to remove column, skip to a new shape, remove a line, remove ads, change shape to vertical line. 

ScoruriTop - keeps the top 10 highest score by veryfing after the game has ended if the player that was playing has a higher score then any of the players that are on the table and if the current player manage to get a higher score than a messegebox pop-up asking him for a name to put on the leaderboard. At the end the list is saved with the current information.

Inscriere - This is a registration page for a new player so that they can keep track of their xp earning (xp is an in game currency for buying stuff at the shop), and it checks to see if the user name is already used or if the passwords are matching.

Meniu -This is the player menu, where you cand see how much xp or T-gold you have and you can also change your profile picture from a drop-down menu and from this page you can also access the shop, play the game, change your password, see the leaderboard or just log off.

Shop - This is the game shop where you can buy in-game abilities and special profile pictures using xp earned by playing the game or with T-gold. T-gold can also be bought from the shop but with "real money" (not with XP).    

  
  
