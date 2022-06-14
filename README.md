# airport-simulation-wpf

## Disclaimer

The current project is not finished. The project, when run, will only start a program with a design template.
The project itself isn't currently working as intended, even if some of the code is already done.

## Project

To simulate an Airport, there are some entities that we need to define beforehand:
- `Tower Control (Broker)`: will receive requests from each pilot and performs operations for them to take off and land the plane.
- `Pilot`: will request the Control Tower to schedule for departure and land.
- `Hangar`: Place where all the planes are located at the start and after they land, and can request a schedule to take off.
- `Sky`: Place where all the planes are located after they take off, and can request a schedule to land.
- `Track`: Landing track where planes can either take off or land. Needs to make sure that only one is accessing it at any time.
- `GRI (General Repository of Information)`: will take care of the logging process behind the scenes, making sure that every action performed by every entity is recorded.

![The Diagram is as follows](https://raw.githubusercontent.com/raimas1996/airport-simulation-wpf/main/AirportDiagram.png)
