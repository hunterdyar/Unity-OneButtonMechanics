# Sample Project: One Button Mechanics
A collection of minigames, but really a collection of useful components for students completing the one-button project prompt

## First, explore the various games. Then look at and into all of the components that make them up. I have split up components as much as possible to aid in flexibility. 

## Usability
To be honest, I wouldn't copy these scripts directly into your projects. Instead, make your own as appropriate, and then use the techniques in the code. These scripts are not to be used like an asset, but to be hacked apart and explored. 

For example, the ContinuousSpawner function is setup to use always spawn objects randomly between two points, instead of freely choosing one of the spawn functions in ObjectSpawner. While it would be easy to set up an enum to make the script hyper-usable and flexible without any coding required, but that is not the use-case of the project. 

_So if you want to change the continuousSpawners spawning function, then dig in and change which method it calls._

## Complexity
I have minimized complexity where possible. The games here are just mechanics, with no proper game loop/manager system for restarting or such. I avoid using coroutines, avoid c#8 features, and I don't really bother with optimizing code. I have commented where apropriate, but most of the code remains uncommented.

## Events
Where reasonable, I have created UnityEvents that one could use to easily hook up other systems or player feedback, like playing audio and so on.
