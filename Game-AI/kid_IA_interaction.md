# AI element

The AI element of our game will take the appearance of the player's children. The role of the AI element is to add difficulties to the player's game.

## Presentation 

This file is used to define the IA element in the game.
Specifically, it will describe the behaviour of the IA element and list how the IA element can interact with objects in the game and the effects those interactions (ie. turn on the TV, open a window in winter, ...).


## General behaviour

As explained previously the AI is here to make the game more difficult. It does so by interacting with elements of the house in order to lower the final score of the player. 

The AI kid moves freely, the more it stays in the player's field of vision the less likely it is to cause problems. The more the kid is not in the field of vision of the player, the more likely it is to cause problems.

## Possible problems

In function of each room in the house the kid can interact with different elements to create problems.

### Garage 

No elements to interact

### Laundry room

- Turn on the heating if off : consumes more electricity.
- Turn off the heating if on : drops the temperature.
- Turn off the electrical panel : Complete electricity stop in whole house.
- Open the freezer : consumes more electricity.

### First bathroom (1st floor)

- Turn on the shower : consumes more water

### Office

No elements to interact. 

### Lounge

- Turn on TV if off : consumes electricity.
- Turn off fire in winter : drops the temperature.

### kitchen

- turn on the oven : consumes electricity.

### Kitchen storage

- open fridge : consumes electricity.

### Garden (outside)

- Fell in the swimming pool.

### Children room

No elements to interact.

### 2st bathroom (2st floor)

- turn on the water : consumes more water.

### Toilet (upstairs)

No elements to interact.

### Mezzanine

No elements to interact.