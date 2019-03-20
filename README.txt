
 _____           ___        _ 
/  ___|         / _ \      (_)
\ `--.__      _/ /_\ \_ __  _ 
 `--. \ \ /\ / /  _  | '_ \| |
/\__/ /\ V  V /| | | | |_) | |
\____/  \_/\_/ \_| |_/ .__/|_|
                     | |      
                     |_|      


An API scrapper that reads in the SW ships and calculates the count of necessary resupply stops needed for any of the ships to travel a given distance

SwApi was build using Visual Studio 2017 with the .NET Core 2.1 SDK

Unit tests can be run from within the solution




_____________
PREREQUISITES
_____________

Ensure you have the .NET Core 2.1.x runtime installed on your system
-- Available here: https://bit.ly/2Ngmzgq
Navigate to the "SwApi" directory in your command/terminal window of choice

_____
USAGE
_____

Enter the following to the command window to run the application:

__________________
Standard execution
__________________

dotnet run -- x

Where x is distance the number of mega lights 
Input is taken as integer value in numbers greater than zero

EXAMPLE INPUT:

dotnet run -- 1000000

dotnet run -- 999999999

_________________
Verbose execution
_________________

dotnet run -- x -v

Where x is distance the number of mega lights 
Input is taken as integer value in numbers greater than zero

EXAMPLE IM=NPUT:

dotnet run -- 1000000 -v

dotnet run -- 999999999 -v
