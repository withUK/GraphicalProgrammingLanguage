![gpl_logo_vsml](https://user-images.githubusercontent.com/22601795/119051937-c3cdcf00-b9bb-11eb-8335-04aaa096a16f.png)
# SE4_GraphicalProgrammingLanguage
The practical assessment for the third year module for software engineering (SE4).

## Overview
Produce a fairly complex  program. The idea of the program is to produce a simplified environment for teaching simple  programming concepts. You are to create a simple programming language and environment  that has the basics of sequence, selection and iteration and allows a student programmer to  explore them using graphics.  

## Marking scheme

### Management (20 marks total)
#### Version Control  
- Set up version control ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Early commit ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- At least five commits of software (no marks if less) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Description with each commit about what has been done/changed and what is to be  done next. ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- For high marks I expect a professional standard with many and regular commits each  time something significant has been added with comprehensive descriptions. I also expect  Unit tests to be included. ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)

#### Code Documentation and Standards 
- Code documented with XML tags, XML documentation produced (I want to see the  documentation and not just the comments in the code). For high marks I expect  documentation to a professional standard. (5 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Use of exception handling (including user generated exceptions) (5 marks)   

### Unit Tests (10 marks total)
- Unit Test project set up (2 marks)  ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Minimal set of tests set up (2 marks)  ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Appropriately documented.(3 marks)  
- Full set of tests (3 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)

### Basic Implementation (30 marks total)
Your implementation must have a proper interface with a window/area for typing a  “program” into and a window/area for displaying the output of the “program”. You should  also have a command line where commands are executed immediately. The actual layout is  up to you.  
#### Appropriate UI conforming to above specification (1 mark) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
#### Command parser class  
- Reads and executes commands on command line one at a time (2 marks)  ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Reads a program (in the program window) and executes it with a “run”  command (typed into the command line). (5 marks) 
- Saves and loads a program (2 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Syntax checking 
  - Checks for valid commands (2 marks)  
  - Checks for valid parameters (2 marks)  
#### Basic drawing commands (all commands should be case insensitive)  
- Position pen (moveTo) (2 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png) 
- pen draw (drawTo) (2 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- clear command to clear the drawing area (1 mark) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- reset command to move pen to initial position at top left of the screen (1 mark) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Draw basic shapes:  
  - rectangle <width>, <height> (2 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
  - circle <radius> (2 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
  - triangle (you can do this any way you like) (2 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Colours and fills:  
  - pen <colour> e.g pen red, or pen green (three or four colours). (2 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
  - fill <on/off> e.g. fill on, makes subsequent shape operations  filled and not outline. (2 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)

The program should be written using inheritance and design patterns (specifically  marked below) so that additional commands could easily be added without affecting the rest  of the code. Marks may be deducted if this is not the case.

### Programming commands (30 marks total)
The idea here is that it behaves like a proper programming language with sequence,  selection and iteration. 
- Variables - allows variables to be used in loop and as parameters to draw  commands (5 marks)  
- Loop command (5 marks)  
  - Repeats everything between Loop on the first line and “end” on a later  line.  
- If statement (5 marks) 
  - for one line (2 marks) 
  - for block with “endif” (3 marks)
- Syntax checking (5 marks)  
  - Syntax of the program is checked before the program is run and  reported appropriately.  
- Methods (10 marks)  
This is quite complex and will require some thought.  
- Define a method with:
```  
Method myMethod(parameter list)  
Line 1  
Etc  
Endmethod  
```
- Call a method with:  
```
myMethod(<parameter list>)
```
  - working methods without parameters (5 marks)  
  - working with parameters (+5 marks)  

### Design and Implementation Standard (20 marks total) 
- Use of design patterns - factory class (5 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- All user created objects from classes that you have designed should use appropriate  inheritance but should also use the factory design pattern. It should be fairly straightforward  to add additional classes to the factory. ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)
- Use of additional design pattern/s (5 marks) ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)

### Additional functionality  
Here you can come up with your own functionality. Although the rest of the marks  make up full marks I may still be able to award any marks that you have missed elsewhere..  Here are some suggestions but you are free to come up with your own, however you should  discuss them with your tutor first.  ![tick](https://user-images.githubusercontent.com/22601795/123541061-4aec3080-d73a-11eb-98cf-efff87d37041.png)

Additional commands, one example might be to transform/rotate shape, more complex  shapes and the drawing of shapes. 

#### Command Examples 
The commands could be slightly different to this if necessary but the functionality must be  the same (i.e. you could have DrawTo (x,y).  
The pen position is stored in the drawing object. Commands should not be case sensitive. 
##### Basic commands 
- DrawTo x,y  
- MoveTo x,y 
- Circle <radius> 
- Rectangle <width>, <height> 
- Triangle <base>, <adj>, <hyp>  
Or you could have  
- Triangle width, height where it defines a box that the triangle is  drawn in 
- Polygon [points,...] 
##### Complex commands  
- If <variable>==10  
  - Line 1  
  - Line 2  
  - Endif 
- Radius = 20 
- Width = 20 
- Height = 20  
- Count = 1  
- While Count < 10 
  - Circle radius 
  - Radius = Radius+10  Rectangle width, height  Width = Width+10  Height = Height + 10  Count = Count+1  
  - Endloop
