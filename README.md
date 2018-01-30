# Advanced Game Dev Platformer Assignment

were looking for 2d platformer using sprite animation and 
the following gameplay:

- The main character must be able to move left and right through the level and jump to get over gaps and to reach higher-level platforms. 

- Take advantage of the 2D platformer prefab in the 2D Standard Asset, available from the Unity menu Assets
 ->Import Package->2D (Also, get comfortable with the Asset Store).

- The player must be able to kill enemies by dropping onto them from above and die if being hit by an enemy from the side.

- Define above as any collision where the bottom of the players sprite is at least as high or higher than half the enemys height above its bottom, i.e., Player.min >= Enemy.min + Enemy.height * 0.5f.

- Consider playing with different enemy height ratios for the definition of above such as 0.75 and 0.90 to see how they affect gameplay.  Requirement is simply somewhere above 0.5.

- Enemies should have simple behaviors such as moving in a side-to-side patrol or moving in a fixed direction until they hit something and then turn the other direction.

- The game is wonwhen the player reaches anend of level trigger(this can be as simple as popping up the textYou win in a dialog box.)

 # Controls:
 left, right, and space for jump.
 - If the character is next to a wall, he can execute a wall jump to get higher. 
 - Wall jumps close to the bottom of the jump launch the player higher
 - jumping on an enemy adds a moderate amount of hight to the jump
 - enemies will kill the player unless jumped on directly from the top (side or angle results in death)
 - single level parkour style platformer.
