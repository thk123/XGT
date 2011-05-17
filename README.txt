XGT

XGT is a set of tools and libraries to speed up the developement of 2D PC C# games

Namespace summary:

-Animation -- includes AnimatedSprite class which is an easy way to create automatically animated sprites from sprite sheets
-SpriteFontMaker -- a tool to quickly create .spritefont files and the code required to import them
-XmlFileDesigner -- a tool to design XML documents, populate them with content and automatically parse them in to the game
-Input -- Manange keyboard (and mouse) interaction specifically allowing users to hook up key press events to actual events
-Collision -- Provide a collision manager for 2D objects
-GameSreen -- Provide a set of classes to manage games with multiple (potentially nested) screens

	-Animation
		-Demonstration of use

	-SpriteFontMaker
		-Tidy up design

	-XmlFileDesinger
		-Be able to create new schemas 
		-Add data to the schemas
		-Generate the code to import the xml files

	-Input
		-ButtonManager stuff
		-Events for listening to specific keys

	-Collision
		-Collision Manager
		-Collision object

	-Gamescreen	
		-Screen Manager
-LevelDesigner -- A robust xml level editor. Allows you to position textures, define properties for them and export as an xml

Features:
-Working animation class that allows for rapid deployment of animated sprites with multiple stances
-Event based Keyboard, Mouse and Button managers
-Keys and mouse clicks can fire events after specified time
-Buttons support hover, pressed and released events,

Todo:
-Input
         -Mouse - double click events with specifiable time delay
         -Access to see how long button been pressed
         -Buttons - right & middle click functionality
         -ButtonManager get what button is being pressed or hovered
         -Keyboard - modify events to provide information on how long that key has been pressed
-Collision
         -Yet to implement
-GameScreen
         -Yet to implement
-SpriteFontMaker
          -General UI improvements
-XmlFileDesigner
          -Yet to implement

		-Screen
		-Nested screen
