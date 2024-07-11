Sunscreen - 2D Platformer Game
- 

Sunscreeen is a 2D platformer game designed to educate and promote sun safety by encouraging the audience to stay in the shade and wear sunscreen. The goal is to beat each level before the SPF value reaches 0. It starts at 20 and decreases by 1 every quarter second. Umbrellas provide shade such that the SPF value will not decrease, water droplets and rays will wipe away 10 SPF, while coolers and sand castles constitute standard obstacles. The victory condition for each is reaching the car at the end which will activate the next scene, and the victory condition for the game is beating the final level, which has a car that prompts a screen showing that the player has avoided contracting melanoma. The loss condition occurs when the player's SPF reaches 0, prompting the player to restart the game (from level 1, not the tutorial).

Throughout the game the player is presented with a series of micro-choices. Collecting sunscreen will increase their SPF and give them more time to make it to the end of the level, but sometimes the sunscreen is out of the way, requiring the player to spend precious time collecting it while risking colliding with an enemy. We tried to avoid failure states by having the player start in the shade, giving them time to adjust to their 2D surroundings. Also, we added an image to the tutorial that tells the player what keys to use to move around. Hopefully, these factors will keep the player from losing the game without knowing why.

This was a fun project which served as a cool introduction to Serious Games. It was helpful in honing coding skills in C# and in understanding general github workflows.


Features
- 
- Educational Gameplay: Players must manage their SPF by staying in the shade and collecting sunscreen. Dynamic SPF Mechanic: SPF starts at 20 and decreases over time. Shade protects SPF, while exposure to UV rays and water droplets reduces it.
- Obstacles and Challenges: Navigate through levels with obstacles like coolers and sand castles, while making micro-choices about collecting sunscreen.
- Victory and Loss Conditions: Reach the car at the end of each level to progress. Losing occurs when SPF reaches 0, prompting a restart from level 1.
- Serious Purpose: Raises awareness about melanoma and the importance of sunscreen use, inspired by real-world health issues.

Prerequisites
-
- Unity Hub
- Unity 20XX.XX.XX or later


Authors
- 
- Joe Mahoney
- Charlie Sager
- Will Rothschild
- Ben Tietjen
