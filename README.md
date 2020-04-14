# CIS410_A2

John Lemon's Haunted Jaunt
Dot product: Used to detect when gargoyles are looking at John Lemon and vice versa. Walk towards a gargoyle statue within line of sight to trigger a red vignette, and look away to turn it off. (Raycasting makes the first gargoyle a bit buggy, not the dot product. However, the raycast is necessary for further gargoyles (i.e. to not have a red vignette when John Lemon looks at a gargoyle through a wall).
Linear interpolation: Used to intensify the red vignette when walking towards gargoyles (to simulate the flashlight getting brighter and warn the player of danger). Walking closer to gargoyles make the intensity of the red vignette appoach 1.
Particle effect: A simple particle effect of dust particles eminates from the ghosts to make 'em spookier. No trigger, they just... emminate.
I worked on this project solo and all contributions are from me. I pulled from various sources and examples to learn how to affect the overlay's vignettte through scripts. However, this example was the most helpful: https://answers.unity.com/questions/1355103/modifying-the-new-post-processing-stack-through-co.html

When building a WebGL player, it might be necessary to go to File> Build> Player Settings> Other Settings> Color Space > Change the option from Linear to Gamma.
