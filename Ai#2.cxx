/*B.O.B - BINARY OPERATION BETA
(BETA STAGE)
Made By Dev Shyn

Current Commands:
Program Currently Utilize Keywords Instead Of One Word Commands

Beta Version 3.3.0
Created: Sep 19, 2022
Last Updated: Nov 16, 2022

🧮What's New 3.3.0: (Update)
--(2.3)Quadratic Solver 2.0
----More Precise And Accurate 😎
--(2.3.1)Optimized Certain Commands
--(3.0)Implemented Guessing Game 😎
--(3.0)Implemented A Calculator 🧮
--(3.0.1)Minor Changes
---Optimization Of Functions
--(3.1.0)Made Some Commands Private (Admin Only)
--(3.1.2)Implemented Delay And Sleep Function
---Optimized Some Commands
--(3.1.5)Name Functions
--(3.2.0)Added Jokes 🤡
--(3.2.3)Change Name Function
--(3.2.4)Fixed Guessing Game Bug
--(3.3.0)Quadratic 3.0
---Can display irrational values

🧾TODO☑️
--Quadratic 3.0 ✅
----Display Irrational Discriminant
--Implement Guessing Game ✅
--Implement Calculator ✅
--Make Some Admin Commands ✅
--Option to change name ✅
*/
#include <iostream>
#include <ctime>
#include <cmath>
#include <string>
#include <algorithm>
#include <numeric>
#include <windows.h>
using namespace std;
//declaration of variables

//password
const string password = "091920221216";	
    string response;
	string response2;
	string pass;
	int size_of_names = 12;
	bool accept = false;
	bool admin = false;
	string name;
	string gender = "MALE";
	//keywords
	string y = "YOU";
	string w = "WHO";
	string c = "COMMAND";
	string p = "PI";
	string a = "ADD";
	string s = "SUBTRACT";
	string m = "MULTIPLY";
	string d = "DIVIDE";
	string ca = "CALCULAT";
	string q = "QUADRATIC";
	string j = "JOKE";
	string t = "TIME";
	string cr = "CREATOR";
	string n = "NONE";
	string n1 = "NOTHING";
	string m1 = "MALE";
	string f = "FEMALE";
	string commands_list[7] = {"Basic Operations(Add...)","Quadratic","Guessing Game","Joke","Time","Value Of PI", "Classified Commands"};
	const int ms = 1 / 1000;
	//jokes
	const string jokes[16] = {
	"",
	"I Invented A New Word! ", "Did you hear about the mathematician who’s afraid of negative numbers? ",
"Why do we tell actors to \"break a leg?\" ",
"Did you hear about the actor who fell through the floorboards? ",
"Did you hear about the claustrophobic astronaut? ", "Why don’t scientists trust atoms? ",
"How does Moses make tea? ",
"A man tells his doctor, \"Doc, help me. I’m addicted to Twitter!\" ", 
"Why don’t Calculus majors throw house parties? ",
"What do you call a fake noodle? ",
"What did the 0 say to the 8? ",
"Why can’t you hear a pterodactyl go to the bathroom? ",
"Why did the frog take the bus to work today? ",
"What did the buffalo say when his son left for college? ",
"What is an astronaut’s favorite part on a computer? "
	};
	const string joke_ans[16] = { 
"",
	"Plagiarism!",
	"He’ll stop at nothing to avoid them.",
	"Because every play has a cast.",
	"He was just going through a stage.",
	"He just needed a little space.",
	"Because They Make up everything.",
	"He Brews.",
	"The doctor replies, \“Sorry, I don’t follow you …\”",
	"Because you should never drink and derive.",
	"An Impasta!",
	"Nice Belt",
	"Because the \"P\" is silent.",
	"His car got \"toad\" away.",
	"Bison.",
	"The space bar."
	};
	const double pi = 3.141592;
	//keywords

   

//function for uppercase
int upper(int in = 0) {
    
    if (in == 1) {
    transform(gender.begin(), gender.end(),gender.begin(), ::toupper);
    }
    else {
    transform(response.begin(), response.end(),response.begin(), ::toupper);
    }
     
}
//function for voice testing
int voiceT() {

}

//function for name insert
int insert(string x = "Sir ") {
    name.insert(0, x);
}

//function for subtraction
//function for addition
//function for multiplication
//function for division
int calculator() {
	
double num[10]; // default 10
double total; // answer
int n; //size of array
char op; // operation
char sp; // special operation
string ope; // string ope
string response1; // string response

	cout << " \n How many numbers Are Involved: ";
	cin >> n;
	
	// if size of array is more than 2
	if (n >= 2) {
	cout << "Enter Operation: ";
	cin >> op;
	cout << "Enter Here: ";
	//loop for getting input of array
	for (int i = 0; i < n; i++) {
		cin >> num[i];
	}
	//because I use 0 as parameter for the "initial value, which is of type int; and this deduces num = int. simplest way to solve this problem is add a .0 to the initial value
 
	//switch/case for operations
	switch(op) {
	case '+': // addition  
	total = accumulate(num, num+n, 0.0, plus<double>());
	ope = "Sum of";
	break;
	
	case '-': // subtraction
	total = accumulate(num, num+n, num[0]*2 + 0.0, minus<double>());
	ope = "Difference of";
	break;
	
	case 'x': // multiplication
	total = accumulate(num, num+n, 1.0, multiplies<>());
	ope = "Product of";
	break;
	
	case '/': // division
	total = accumulate(num, num+n, pow(num[0], 2) + 0.0, divides<>());
	ope = "Quotient of";
	break;
	}
	
	//output
	cout << ope << " "<< num[0] << " to " << num[n-1] << " is " << total << endl;
	} 
	// if size of array is 1
	else if (n == 1) {
	 
	 cout << "Enter Special Operation: ";
	 cin >> sp;
	 cout << "Enter Here: ";
	 cin >> num[0];
	 
	 switch (sp) {
	   case '1': //sqrt
	   total = sqrt(num[0]);
	   cout << "The Square Root Of " << num[0] << " is " << total << endl;
	   break;
	   
	   case '2': // power
	   int dg;
	   cout << "Degree: ";
	   cin >> dg;
	   total = pow(num[0], dg);
	   cout << num[0] << " raised to " << dg << " is " << total << endl;
	   break;
	 }
	}
	
// Made By Dev Shyn
    //Restart Or Exit
    cout << "Enter (A/a) to continue and (X/x) to exit: ";
	getline(cin, response1);
	getline(cin, response1);
	
	transform(response1.begin(), response1.end(), response1.begin(), ::toupper);
	
	//if restart
	if (response1.find('A') != string::npos) {
	   calculator(); 
	} 
	// if exit
	else if (response1.find('X') != string::npos) {
		cout << " \n Thank You For Using My Calculator - Bob :) \n";
		sleep(1);
		cout << "What Else Can I Do For You? ";
		getline(cin, response);
		upper();
	return 0; // return 0 / exit
	}		
	
}

//function for joke
int joke() {
	
	srand(time(NULL));
	int x = rand() % 15 + 1;
	
	cout << "\n" << jokes[x] << endl;
	sleep(3);
	cout << joke_ans[x] << endl;
	sleep(1);
	
	cout << "\nAnother One? ";
		getline(cin, response);
		upper();	
		
	    if (response.find("YES") != string::npos) {
	     joke();
	    } else {
	    cout << "\nThen what else can I do for you? ";
	    getline(cin,response);
	    upper();
	    }

}

//function for time
int time() {
	time_t now = time(0);
	
	char* date_time = ctime(&now);
	
	cout << "\nCurrent Time and Date is: " << date_time << "\n";
	sleep(1);
	cout << "What Else? ";
	getline(cin,response);
	
}
//function for quadratic
int quadratic() {
  int a;
  int b;
  int c;
  int x;
  int x2;
  
  cout << "\nInput Value Of A:";
  cin >> a;
  
  cout << "Input Value Of B:";
  cin >> b;
  
  cout << "Input Value Of C:";
  cin >> c;
  
  
  int discriminant = pow(b,2) + (-4 * a * c);
  int root = (sqrt(discriminant));
  
  x = ( -1*b - root);
 
  x2 = ( -1*b + root);
  
  int x3 = 2*a;
  int x4 = x3;
 
  if (pow(root,2) == discriminant && discriminant >=  0) { 
  
while(x % 2 == 0 && x3 % 2 == 0)  {
     x = x /2;
     x3 = x3/2;
     } 
     while (x % 3 == 0 && x3 % 3 == 0)  {
     x = x /3;
     x3 = x3/3;
     } 
     while (x % 5 == 0 && x3 % 5 == 0)  {
     x = x /5;
     x3 = x3/5;
     } 
     
     //2nd root
     while(x2 % 2 == 0 && x4 % 2 == 0)  {
     x2 /= 2;
     x4 /= 2;
     } 
     while (x2 % 3 == 0 && x4 % 3 == 0)  {
     x2 /= 3;
     x4 /= 3;
     } 
     while (x2 % 5 == 0 && x4 % 5 == 0)  {
     x2 /= 5;
     x4 /= 5;
     } 
     
     if (x % x3 == 0 && x2 % x4 == 0) {
       cout << "X is equal to: " << x / x3 << " or " << x2 / x4 << "\n";
     } else if (x % x3 != 0 && x2 % x4 != 0){
    cout << " X is equal to: " << x << "/" << x3 << " or " << x2 << "/" << x4 <<"\n";
     } else if (x % x3 == 0 && x2 % x4 != 0) {
     cout << " X is equal to: " << x / x3 << " or " << x2 << "/" << x4 <<"\n";
     } else if (x % x3 != 0 && x2 % x4 == 0) {
     cout << " X is equal to: " << x << "/" << x3 << " or " << x2 / x4 <<"\n";
     }
  
  //check if x is a real number or na
  } else if (discriminant >= 0){
  	cout << '(' << -1 * b << " +- √" << discriminant << ") / " << 2 *a << endl;
     
  } else {
     cout << "No roots or real solution" << endl;
  }
  
  cout << "What Else? ";
  getline(cin,response);
  getline(cin,response);
}
//function for guessing game
int guessing_game(int x = 0) {
    
	srand(time(NULL));
	int randnum = rand() % 100 + 1;
	int guess;
	int guesscount = 0;
	int tries;
	int max = 10;
	int response3;
	bool out = false;
	string plr;
	string any;

	cout << "\nBOB Guessing Game \n";
	cout << " Guess The Number Between 1 And 100!\n" << endl;
	
	sleep(2);
	cout << "  Enter Anything To Get Random Tries: ";
	if (x == 1) {
	getline(cin, any);
	getline(cin, any);
	}
	else {
	getline(cin, any);
	}
	
	if (any == "Omsim")
	{
		tries = max;
	}
	else
	{
		tries = rand() % max + 1;
	}

	if (tries > 1)
	{
		plr = "tries";
	}
	else
	{
		plr = "try";
	}

	cout << "\tYou Have " << tries << " " << plr << " goodluck" << endl;

//while randnum is not guessed
	while (guess != randnum && out == false)
	{
		//if you still have tries
		if (guesscount < tries)
		{
			cout << "Enter Your Guess: ";
			cin >> guess;

			if (guess < randnum)
			{
				cout << "Higher \n";
			}
			else if (guess > randnum)
			{
				cout << "Lower \n";
			}
			guesscount++;
		}
		// if tries run out
		else
		{
			out = true;
		}
	}

//if gameover
	if (out)
	{
		cout << "\nYou Lose, The Number is " << randnum;
	}
	//if win
	else
	{
		cout << "\nYou Win :)";
	}
	
    cout << "\n Input 1 To Play Again And 0 To End: ";
    cin >> response3;
    
    switch (response3) {
        case 1:
           guessing_game(1);
           
           break;
        case 0:
           cout << "\nThen What Else Can I Do For You? ";
           getline(cin,response);
           getline(cin,response);
           upper();
           break;   
    }
}

int main()
{
	//Initialization 
	cout << "B.O.B Program  \n";
	
	cout << "\nEnter Commands For List Of Commands" << "\n \n";
	sleep(1);
	cout << "What's Your Name? ";
	getline(cin, name);

while (name.empty() || name == " ") {
if (name.empty() || name == " ") {
   
   cout << "Are you an orphan? Don't You Have A Name? ";
   getline(cin, response);
   
   if (response.find("Yes") != string::npos) {
   cout << "Sad to here that you don't have parents so I'll just call you Orp \n";
   name = "Orp";
   } else {
   cout << "Enter Another Name Then: ";
   getline(cin,name);
   }
}
}	
//Name Input	
	if (name == "2736281") {
		accept = true;
		name = "Creator 👨‍💻";
		admin = true;
		insert();
	}
//Password Input
	 else {
		
	cout << "What's The Password First 👴🏻 ";
	cin >> pass;
	
	if (pass == password) {
		accept = true;
		cout << "Password Accepted :) \n";
		
		//gender checker
cout << "What's Your Gender? ";
   getline(cin, gender);
   getline(cin, gender);
   upper(1);
   
   if (gender.find(m1) != string::npos && gender.find(f) == string::npos) {
   	insert();
   } else if (gender.find(f) != string::npos && gender.find(m1) != string::npos) {
       insert("Ma'am ");
   } else {
     name = name;
   }
	} else {
	   accept = false;
	} 
	 
	}

//If Password Is True or Name is Authorized	
	if (accept == true) {

if (!admin) {		
   cout << "Greetings " << name << ", I am B.O.B, What Can I Do For You? ";
} else if (admin) {
   cout << "Greetings Sir, How Can I Help You? ";
}
	//idk why but I need two getline function when an unauthorized person logs in
	
	getline(cin, response);
	
	//transform string to upper case
	upper();
	//Loop The Ifs
   while (response.find(n) == string::npos && response.find(n1) == string::npos) {
    
    upper();
    //description
    if(response.find(w) != string::npos && response.find(y) != string::npos) 
    {
    	cout << "\nMy Name Is B.O.B short for Binary Operation Beta and I am a prototype created to do basic things :). Obviously I am made in C++ 😎\n";  
    	  	
    	cout << "I am created by 'Creator' from Grade 9 STEP \n";
    	sleep(3);
    	cout << "\nHow can I help you " << name <<"? ";
    	getline(cin,response);
    	upper();
    	
    } 
    //Command List
    else if (response.find(c) != string::npos && response.find("CLASSIFIED") == string::npos) 
    {
    	cout << "\nI can't provide you everything but here's a brief summary of commands: \n";
    for (int i = 0; i < 7; i++ ) {
    	cout << commands_list[i] << endl;
    	}
    	sleep(2);
    	cout << "What Else Can I Do For You? ";
    	getline(cin,response);
    	upper();
    }
    //if classified 
    else if (response.find("CLASSIFIED") != string::npos && response.find(c) != string::npos) 
    {
      cout << "\nI can't tell you cause they're classified 😉" << endl;
      sleep(1);
      cout << "\nWhat Else Can I Do For You? ";
       getline(cin, response);
       upper();
    }
    //if PI
    else if (response.find(p) != string::npos) 
    {
    	cout << "\nThe value of pi is: "<< pi << "\n";
    	cout << "What Else Can I Do For You? ";
    	getline(cin,response);
        upper();
    }
	//if calculate
	else if (response.find(a) != string::npos || response.find(s) != string::npos || response.find(m) != string::npos || response.find(d) != string::npos || response.find(ca) != string::npos || response.find("MULTIPLICATION") != string::npos || response.find("DIVISION") != string::npos) 
	{
	//initialization
    //list of operations
	cout << "\n'The BOB Calculator 🧮' \n" << endl;
	sleep(1);
	cout << "Operations: \n";
	cout << "'+' - Addition \n";
	cout << "'-' - Subtraction \n";
	cout << "'x' - Multiplication \n";
	cout << "'/' - Division \n";
	sleep(1);
	cout << "Special Operations: \n";
	 cout << "'1' - Square Root \n";
	 cout << "'2' - Exponent" << endl;
	 sleep(1);
		calculator();
		upper();
	}
	//if joke
	else if (response.find(j) != string::npos)    
	 {
	    cout << "\nI Have One For You \n";
	    sleep(1);
		joke();
		
	}
	//if time
    else if (response.find(t) != string::npos)    
     {
    	time();
    	upper();
    }
    //if quadratic
    else if (response.find(q) != string::npos) 
    {
    	quadratic();
    	upper();
    } 
    //if creator
    else if (response.find(w) != string::npos && response.find(cr) != string::npos)
    {
    	cout << "\n'Creator', you probably know him by the name Shyn. He created me on September 19,2022 around 12:00pm as a practice program. I don't know much about him besides that he's a human :). \n";
    	
    	sleep(4);	
    	cout << "Ask him yourself if you wanna tell him something cause he didn't programmed me to do such thing \n "; 
    	sleep(3);
    	cout << "\nAnything else I can help you with " << name << " ? ";
    	getline(cin,response);
    	upper();
    }
   
    else if (response.find("GUESS") != string::npos) {
    
    guessing_game();
    
    }
    else if (response.find("YOU") != string::npos && response.find("BETA") != string::npos) {
    
    if (!admin) {
      cout << "\nYes, I am currently on BETA stage so please expect some minor and major bugs while using the program. 'Creator' will try his best to fix it if he finds any :) \n";
      sleep(3);
      cout << "\nAnything Else You Want Me To Do? ";
      getline(cin,response);
      upper();
     
    } else if (admin) {
    
      cout << "\nYou're the one who created me so why are you asking me in the first place 🤨. \n";
      sleep(3);
      cout << "Maybe you're not 'Creator'? But that would be impossible cause no one knows his code name.\n";
      sleep(3);
      cout << "You're just playing with me sir 🤡. Please stop asking dumb questions. \n";
      sleep(3);
      cout << "Now what do you really want me to do sir? ";
      getline(cin,response);
      upper();
    }
    }
    else if (response.find("CHANGE") != string::npos && response.find("NAME") != string::npos) {
    
    cout << "\nWhat would you like me to call you? ";
    getline(cin, name);
   
  if (name.find("Sir") != string::npos || name.find("Ma'am") != string::npos) {
    
  } else {
   
   if (gender == "MALE") {
      insert();
    } else if (gender == "FEMALE") {
      insert("Ma'am ");
    }
  }
    
    cout << "You want me to call you " << name << "? ";
    getline(cin, response);
    upper();
    if (response.find("YES") != string::npos) {
    
    cout << "Ok " << name << endl;
    cout << "How can I help You? ";
    getline(cin, response);
    upper();
    }
    else {
    
    cout << "Ok then what else can I do for you?";
    getline(cin, response);
    upper();
    }
    }
    else if (response.find("WHAT") != string::npos && response.find("NAME") != string::npos) {
    
    if (gender == "MALE") {
     name.erase(0,4);
    } else if (gender == "FEMALE") {
     name.erase(0,6);
    } else {
    
    }
    cout << "\nYour name is " << name << endl;
    
    if (gender == "MALE") {
      insert();
    } else if (gender == "FEMALE") {
      insert("Ma'am ");
    }
    
    cout <<"What Else Can I Do For You? ";
    getline(cin,response);
    upper();
    }

   //if wrong command
	 else 
	 { 	
		cout << "\nSorry I dont understand, it appears that I'm currently unable to do what you're saying. But I can do other things :) ";
		getline(cin,response);
	    upper();
	 }
    }
    //if wrong password and you're not charles vincent
	} else {
		accept = false;
		if (name != "Vincent") {
		cout << "Wrong Password, Restart The Program To Try Again \n";
		}
	   
	}
	
	if (name == "Vincent") {
	     cout << "My creator had permanently banned you from using this program my deepest apologies :) \n";
	     sleep(2);
	     cout << "He Left A Message For You: \n";
	     sleep(2);
	     cout << "\"Yes - Creator\"";
	   }
	   
	//if respond == none, program ends
	if (accept == true && response.find(n) != string::npos || response.find(n1) != string::npos) {	
	
	if (!admin) {
     cout << "You're very welcome " << name << ", glad I can help :)\n";
	} else if (admin) {
	  cout << "I am happy to be of assistance sir.\n";
	}
	
	}
		return 0;	  
}

