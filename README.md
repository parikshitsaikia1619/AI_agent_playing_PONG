# AI_agent_playing_PONG
Developing a classic pong game with a minimalistic 2.5D graphics in Unity.
Implementation of nural networks to make an A.I pong agent.
Human vs AI , AI vs AI mode.
training , tuning the AI agent for smart gameplay style

gameplay image:
![pic1](https://github.com/parikshitsaikia1619/AI_agent_playing_PONG/blob/master/pics/Screenshot%20(51).png?raw=true)

# IMP NOTE : USE W AND S FOR PADDLE MOVEMENT , I forgot to add instructions in U.I

# making the court
It's damn simple.., just add lots of static meshes, make it look a PONG court ,
tag the walls for collsion detection and raycasting. Add materials to make it look beautiful.
Tadaaa...it's done.

*you can do it man , I believe in you*

here it should look like:
![pic2](https://github.com/parikshitsaikia1619/AI_agent_playing_PONG/blob/master/pics/Screenshot%20(47).png?raw=true)

# making movement of ball and paddle
I have added rigidbody to both of them , which makes movable by add force, velocity ... you know by Physics
So, for the paddle I have created a scripted like :

  if (key W is pressed )
    add constant velocity of say x (in up direction) in paddle.
  if (... S is ..pressed)
    add constant velocity -x
    
*Piece of cake right.. let move on to ball*

  I have added a physics material on ball , for its bouciness.
  its simple , on starting I added a random velocity to ball ,(rigidbody of ball , gravity is set to 0)
  *random initial velocity , zero gravity ... keep moving forward ... bouncing forever . Simple Logic isn't it :)*
  
  I have done some collision checks on the ball , to know what it is hitting... you know DEBUGGING,
  and also to change color of the ball , updating score in UI.
  
  
  *polishing the game :)*
  
  ----- OUR GAME ENVIRONMENT IS DONE ,NOW IT'S TIME FOR AI------------
  
  # A.I implementation of the paddle 
  
  *Now it is the boss fight level*
  
  TIME TO USE MACHINE LEARNING  * sigh * , I will keep as simple as possible
  So, I written my ANN from scratch.
  for this game we will use our ANN.
  
  So, lets figure out our inputs and outputs:
  
  inputs: 1. ball position x   
          2. ball position y   
          3. ball velocity x   
          4. ball velocity y    
          5. paddle position x   
          6. paddle position y
          
   outputs: paddle y velocity
   
   So, we created our 6 input , 1 output , 1 hidden layer with 4 nodes , learning rate 0.11
   
   hidden layer activation function is relu , for output act. func. is tanh ( for -1 to 1 velocity)
   
   *now for the interesting part creating error function...OK not that interesting, let keep moving*
   
   for the error function we will give the difference between the ball's y position (hitting on the backwall when misses)  and 
   paddle's y position.
   
   we can get the ball's hitting position by RAYCASTING 
   
   *that sounds terrifying* 
   
   this screenshot will give you an idea:
    ![pic3](https://github.com/parikshitsaikia1619/AI_agent_playing_PONG/blob/master/pics/Screenshot%20(52).png?raw=true)
    
   ![pic4](https://github.com/parikshitsaikia1619/AI_agent_playing_PONG/blob/master/pics/Screenshot%20(53).png?raw=true)
   
   So basically our model will take the inputs , give the output , minimise the error by updating the weights and bias
   to get better 
   
   *typical forward and backpropagation*
   
   FINALLY.... our model is ready our output will use to move the paddle.
   
   READ THE SCRIPTS FOR DETAILED UNDERSTANDING..
   # PLAY THE GAME TO TRAIN THE MODEL...ENJOY :)
   
   To play the game just go to Pvs AI folder , select the exe file
   
   
   
  
  
  
