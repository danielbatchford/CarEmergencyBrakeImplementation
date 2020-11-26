# A Vehicle Emergency Brake Implementation

## Example
![](https://github.com/danielbatchford/CarEmergencyBrakeImplementation/blob/master/example.gif)
## Implementation
This control software was implemented in a 3D game engine, Unity. It model's a linear motion of both the throttle and brake pedals with `v = stuff`

The implementation is based off this model differential equation:

![](https://github.com/danielbatchford/CarEmergencyBrakeImplementation/blob/master/deEquation.png)

An iterative solution was formed based off the above equation:

![](https://github.com/danielbatchford/CarEmergencyBrakeImplementation/blob/master/iterEquation.png)

## Controls
`Space` to apply the throttle.
`B` to apply the brakes.

## Credits
[Unity](https://unity.com/)
