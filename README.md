# Color Grid
Introducing **Color Grid**, an exhilarating local multiplayer game where players engage in a fierce 
competition to color the highest number of fields in their chosen color within a time 
limit of 3 minutes. However, there's a twist! An unpredictable UFO joins the gameplay, resetting 
any field it crosses back to its original white state.

## About the project
This game was created as the final project for the course *Engine Based Cross Reality Development*
at the St. Pölten University of Applied Sciences. The goal of the project was to create a small game with 
Unity to showcase what was learned during the class. The project uses:
- Basic Transforms
- New input system
- Multiple Scenes
- Animation
- Canvas
- Dynamic Instantiation of GameObjects
- Raycast
- Pathfinding with NavMesh
- Particles
- ...

## Built With
This project is built with Unity *2021.3.24f1*. To ensure that everything works properly it is recommended
to open this project wth this version.

When the project is located on you machine use Unity Hub to search for the project and open it. 
When the project is open you can run it by clicking on the play-button in the top middle of the screen.

### Export
A game export for Windows is provided to start the game double-click the file *ColorGrid.exe* 
in *ColorGrid_WindowsBuild*.

If you want to have an export for any other platform you need to open Unity Hub and open the project.
Then go to *File > Build Settings* and select the platform you want to export the game for. 
Then click on *Build* and select the folder you want to export the game to.

## Game-Play
In **ColorGrid** two players compete against each other to color the highest number of fields in their
chosen color within a time limit of 3 minutes. The players move with WASD (Player 1) and the arrow keys 
or IJKL (Player 2) around the playing field. To color a field the player has to move over it.

The players can activate a power up (yellow gems). This power up colors all neighbouring fields in the players
color. A power up is shown the grid for 10s and every 5 seconds a new power is spawned.

A UFO is flying around the playing field. When the UFO crosses a field it resets the field back to its original
white state and it is not anymore *controlled* by a player.

When a player falls of from the grid this player "dies" and the game ends. In this case the other player
wins, with disregard to which player has the higher score.

On the start screen the players can choose their color, by using their respective left- and right-keys; 
this would be A and D for Player 1 and the left and right arrow keys, as well as the J and L keys, for Player 2.

## License
This Source Code is provided under the MIT License. Please refer to the LICENSE file for more information.

## Contact
**Vanessa Köck**\
💻 www.vanessakoeck.dev \
📧 cc211026@fhstp.ac.at | me@vanessakoeck.dev

## Acknowledgements
The Assets for this game were taken from the following sources:
- [Jewel Pack](https://assetstore.unity.com/packages/3d/props/jewel-pack-19902) by outvector is licenced under [Standard Unity Asset Store EULA](https://unity.com/legal/as-terms)
- [Urban Night Sky](https://assetstore.unity.com/packages/2d/textures-materials/sky/urban-night-sky-134468)  by Kendall Weaver is licenced under [Standard Unity Asset Store EULA](https://unity.com/legal/as-terms)
- [Kawaii Slimes](https://assetstore.unity.com/packages/3d/characters/creatures/kawaii-slimes-221172)  by Awaii Studio is licenced under [Standard Unity Asset Store EULA](https://unity.com/legal/as-terms)
- [UFO](https://skfb.ly/6X7H6) by rowan11 is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).