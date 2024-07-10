# Gather an Army
## Game Description
This is an exciting strategy game that will test your planning and resource management skills.

## In Gather an Army you will:

• Create an army from unique units.

• Manage your resources - you have a limited number of coins that you will spend on buying units.

• Complete missions by gathering an army that meets certain criteria.

• Go through levels. Each level has new missions and unit characteristics.

## Key Features:

Diverse units: Each unit has a unique strength and price.

Strategic choice: Decide which units to buy to create the right army for each mission.

Special price: Every third unit on the field costs a special price.

## Used Patterns:
• Entry point

• State Machine

• Service Locator

• Object Pool

• Event Bus

• Reactive programming

• Factory

• MV*: MVP or something akin

## Plugins
• DOTween

## Features
• Dynamic replacement of unit sprites during the game. The sprites are optimized and drawn independently. There are currently 2 types of units: medieval and soldiers.

• Dynamic theme change during the game. Theme settings are in ScriptableObjects. There are currently 2 themes: light and dark.

• Dynamic localization change during the game. Localization is pulled from an excel file. There are currently 3 languages: English, Armenian and Russian.

• There is a tutorial with pointers on where to click.

• There are saves in json.

• A menu with a list of levels and their update when new levels are added.

• Tasks in scriptable for the convenience of the game designer.

• Statistics calculation after passing the level: time, number of moves, button clicks to create, button clicks to clear.

• Particles after passing the level.

• Appearance and deletion of units with DOTWEEN animation.

• GUI animation using DOTWEEN. 

# Road map

✔ Create and adjsut UI on gameplay scene: prefabs, layout groups, buttons, texts etc.

✔Create C# Unit class and his childrens

✔ Create C# Unit Factory

✔ Spawn units and show his stats (power, cost, special cost) in the console

✔ Create prefabs of units and spawn his on field by pressing buttons

✔ Add new type of units (new sprites) and adjsut flexible switching between them

✔ Spawn units with inited stats (stats getted from IUnitStat)

✔ Create Entry Point

✔ StateMachine for game and Game Handler for handling game states

✔ Add ServiceLocator and register existing services

✔ Add BootstrapScene and adjust initialization of game

✔ Adjust trasit between scenes

✔ Separate view and logic (used MVP or something akin)

✔ Dinamically switching between unit types during the game

✔ Object Pool for spawn units

✔ Ability to clear the field from units

✔ Ability to delete a specific unit by clicking on it

✔ Recount units cost after changing their order on field

✔ Initialization button (sprites and stats)

✔ EventBus with adjustable listener call order

✔ Collecting statistic on field (all power, quantity of units, how much money left) with custom Reactive properties

In process

