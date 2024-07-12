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

• ~~State Machine~~ DI (Zenject)

• Service Locator

• Object Pool

• Event Bus

• Reactive programming

• Factory

• MV*: MVP or something akin

## Plugins
• DOTween

• Zenject

# Road map
Now, in process

## Architecture 
✔ Create Entry Point

✔ StateMachine for game and Game Handler for handling game states

✔ Add ServiceLocator and register existing services

✔ Add BootstrapScene and adjust initialization of game

✔ Adjust trasit between scenes

✔ Separate view and logic (used MVP or something akin)

✔ Object Pool for spawn units

✔ Custom EventBus with adjustable listener call order

✔ Replace ServiceLocator to Zenject (DI is more relevant for serious games, so it will be a plus for the portfolio)

## Gameplay
✔ Create C# Unit class and his childrens

✔ Create C# Unit Factory

✔ Spawn units and show his stats (power, cost, special cost) in the console

✔ Create prefabs of units and spawn his on field by pressing buttons

✔ Adjsut flexible switching between units sprites

✔ Spawn units with inited stats (stats getted from IUnitStat)

✔ Dynamic unit types switching during the game

✔ Ability to clear the field from units

✔ Ability to delete a specific unit by clicking on it

✔ Recount units cost after changing their order on field

✔ Collecting statistic on field (all power, quantity of units, how much money left) with custom Reactive properties

⌛ Add tasks for the levels. Tasks are saved and configured in script objects for the convenience of game designers.

## Visual
✔ Create and adjsut UI on gameplay scene: prefabs, layout groups, buttons, texts etc.

✔ Add new type of units (new sprites)

✔ Initialization button view (sprites and stats)

⌛ Optimization with atlases

⌛ Dynamic themes switching (themes settings stored in ScriptableObjects and passed to View classes) 

⌛ Dynamic localization switching from an Excel file

⌛ Highlight completed tasks

⌛ Pop-up settings window where you can switch the theme, language, etc.

⌛ Guide with interactive explanation (create state machine and UI)

⌛ Create and adjust MenuScene

⌛ Level grid (load levels from saves)

⌛ Add infinity particles (like stars) to menu and "Confetti" after level finish

⌛ DOTween animation for appearance and deleting of units 

⌛ DOTween animation for certain GUI elements

## Other
⌛ Saves to JSON

⌛ Collect statistic about level (how much time is spent, how many moves are made, etc.)




