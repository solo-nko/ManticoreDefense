using System;
namespace Program.cs
{
	class ManticoreDefense
	{
		public static void Main(string[] args)
		{
			/* Psuedocode:
			 * Present premise to user
			 * Ask user if they're ready to play. if y, proceed. if n, exit. if other, loop
			 * roundNum variable
			 * cityHealth variable
			 * manticoreHealth variable
			 * defenseAttack variable
			 * manticoreDistance variable
			 * userGuess variable
			 * if userGuess greater than or less than manticoreDistance, inform user
			 * if userGuess == manticoreDistance, inform user, do damage
			 *		if roundNum multiple of 3 or 5, do extra damage
			 * if manticoreHealth > 0 and cityHealth > 0, increment roundNum and loop 
			 */
			Console.WriteLine("Welcome to Manticore Defense! In this game, you need to man the defenses of your city, because the enemy airship Manticore is approaching!\n" +
				"The Manticore is flying at a certain distance from the city, somewhere between 1 and 100 kilometers. Each round, you will get another chance to guess what the distance is. Guess correctly before the Manticore destroys your city!");
			Console.WriteLine("Do you want to play? Answer \"Yes\" or \"No.\" ");

			string startAnswer = Console.ReadLine().ToLower();
			while (startAnswer != "yes")
			{
				if (startAnswer == "no")
				{
					return;
				}
				Console.WriteLine("Sorry, you need to answer \"Yes\" or \"No.\" Try again:");
				startAnswer = Console.ReadLine().ToLower();
			}
			int roundNum = 0;
			int cityHealth = 15;
			int manticoreHealth = 10;
			Random rnd = new Random();
			int manticoreDistance = rnd.Next(1, 101);

			Console.WriteLine("The Manticore has appeared! What distance should we shoot it at???");
			int userGuess;
			bool inputValidate;
			while (cityHealth > 0 & manticoreHealth > 0)
			{
				do
				{
					roundNum++;
					inputValidate = Int32.TryParse(Console.ReadLine(), out userGuess); //attempt to get a number from user input. if successful, place the number in userGuess and mark inputValidate true. if unsuccessful, mark inputValidate false.
					if (inputValidate == false)
					{
						Console.WriteLine("Sorry, you need to input a number between 1 and 100.");
					}
				} while (inputValidate == false);
				if (userGuess == manticoreDistance)
				{
					if (roundNum % 3 == 0 & roundNum % 5 == 0) //on certain rounds we do more damage than usual, to allow the user to catch up to and overtake Manticore in damage.
					{
						manticoreHealth -= 10;
						Console.WriteLine("Direct hit! Your engineers and wizards have teamed up to deal a final desperate blow!!!");
					} else if (roundNum % 5 == 0)
					{
						manticoreHealth -= 5;
						Console.WriteLine("Direct hit! Your wizards call lightning down on the Manticore!!");
					} else if (roundNum % 3 == 0)
					{
						manticoreHealth -= 3;
						Console.WriteLine("Direct hit! Your engineers launch fireballs at the Manticore!!");
					} else
					{
						manticoreHealth -= 1;
						Console.WriteLine("Direct hit! The Manticore has suffered damage.");
					}
					
				} else if (userGuess > manticoreDistance)
				{
					Console.WriteLine("Overshot! Your attack landed too far!");
				} else if (userGuess < manticoreDistance)
				{
					Console.WriteLine("Too close! Your attack didn't make it far enough.");
				}
				cityHealth--;
				Console.WriteLine($"The Manticore is attacking! Your city has {cityHealth} health remaining. \nWhat distance should we shoot it at?");
			}
			if (cityHealth <= 0)
			{
				Console.WriteLine("The Manticore has destroyed your city... GAME OVER");
			} else if (manticoreHealth <= 0)
			{
				Console.WriteLine("The Manticore is sunk! You defended the city!");
			}
		}
	}
}
