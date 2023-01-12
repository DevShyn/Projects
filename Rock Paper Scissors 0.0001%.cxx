/* Rock Paper Scissors But You Have 0.0001% Chance Of Winning

Made By DevShyn

Got nothing to do so why not make another trash

Beware🚫: Beating the game is almost impossible since it is based on RNG, it took me approximately 40,926,186 loses :).

Created In: Jan 12, 2023
*/
#include <iostream>
#include <string>
using namespace std;


int ai(int a) {

srand(time(NULL));

int b = rand() % 1000 + 1;

if (b != 69) {

 if (a == 1) {
 return 2;
 } else if (a == 2) {
 return 3;
 } else if (a == 3) {
 return 1;
 }
 
} else if (b == 69) {
  if (a == 1) {
  return 3;
  } else if (a == 2) {
  return 1;
  } else if (a == 3) {
  return 2;
  }
}


 

}
int main(int argc, char *argv[])
{
	int choice;
	int computer_choice;
	int lose_count = 0;
	string str;
	string str2;
	bool win = false;
	
	cout << "Rock Paper Scissors ";
	while (!win) {
	cout << "\n\nChoice: ";
	getline(cin, str);
	
	
	transform(str.begin(),str.end(), str.begin(), ::toupper);
	
	if (str.find("ROCK") != -1) {
	choice = 1;
	
	} else if (str.find("PAPER") != -1) {
	
	choice = 2;
	} else if (str.find("SCISSORS") != -1) {
	
	choice = 3;
	} else {
	choice = 0;
	}
	
	computer_choice = ai(choice);
	switch (computer_choice) {
 
    case 1:
        str2 = "ROCK";
        break;
    case 2:
        str2 = "PAPER";
        break;
    case 3:
        str2 = "SCISSORS";
        break;
    default:
        str2 = "Invalid";
	}
	
	cout << "Computer Choice: " << str2;
	
	if (choice == 1) {
	   if (computer_choice == 2) {
	   cout << "\nYou Lose";
	   lose_count += 1;
	   } else {
	   cout << "\nYou Win";
	   win = true;
	   }
	} else if (choice == 2) {
		if (computer_choice == 3) {
	   cout << "\nYou Lose";
	   lose_count += 1;
		} else {
		cout << "\nYou Win";
		win = true;
		}
	} else if (choice == 3) {
	   if (computer_choice == 1) {
	   cout << "\nYou Lose";
	   lose_count += 1;
	   } else {
	   cout << "\nYou Win";
	   win = true;
	   }
	} else {
	  
	}
	
	  
	}
	
	cout << "\n\nCongrats 🥳, It took you " << lose_count << " loses";
}