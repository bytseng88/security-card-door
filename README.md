# security-card-door
This project models doors that can be only be opened with cards of certain security levels. 
This solution demonstrates a more purely object-oriented approach to solving the problem.

## project specs
There are three security levels (from least restrictive to most): low, medium, and high. 
Cards can only open doors with the corresponding security level or lower, i.e. cards with a low security level can only open doors with a low security level; cards with a medium security level can open doors with medium or low security level; cards with a high security level can open doors of any level. 
Similarly, doors can only accept cards with the correpsonding security level or higher, i.e. doors with a low security level can accept any card; doors with a medium security level can only accepts cards with medium or high security level; doors with a high security level can only accepts cards with high security level.
