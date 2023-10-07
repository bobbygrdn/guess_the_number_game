using Godot;
using System;

public partial class Main : Control 
{
	// Nodes
	Label randomNumberHolder;
	TextEdit guessHolder;
	Label numberOfGuessesHolder;
	Label response;
	Button submit;
	Button guessAgain;
	Button playAgain;
	
	// Dependant Variables
	Random rand = new Random();	
	int randomNumber;
	int guess;
	int numberOfGuesses = 0;
	
	public override void _Ready() 
	{
		randomNumberHolder = GetNode<Label>("./RandomNumberHolder");
		guessHolder = GetNode<TextEdit>("./GuessHolder");
		numberOfGuessesHolder = GetNode<Label>("./NumberOfGuessesHolder");
		response = GetNode<Label>("./Response");
		submit = GetNode<Button>("./Submit");
		guessAgain = GetNode<Button>("./GuessAgain");
		playAgain = GetNode<Button>("./PlayAgain");
		
		randomNumber = rand.Next(1,100);
		
		GD.Print("Nodes Loaded!");
	}

	private void _on_guess_holder_text_changed()
	{
		guess = int.Parse(guessHolder.Text);
	}
	
	private void _on_submit_pressed()
	{
		submit.Disabled = true;
		guessAgain.Disabled = false;
		guessHolder.Editable = false;
		checkNumber(randomNumber, guess);
		numberOfGuessesHolder.Text = $"{numberOfGuesses}"; 
	}


	private void _on_guess_again_pressed()
	{
		guessAgain.Disabled = true;
		submit.Disabled = false;
		guessHolder.Editable = true;
		guessHolder.Text = "";
		response.Text = "";
		guessHolder.GrabFocus();
	}
	
	private void checkNumber(int randomNumber, int guess) {
		if(guess < randomNumber) {
			numberOfGuesses++;
			response.Text = "Higher!!!";
		} else if(guess > randomNumber) {
			numberOfGuesses++;
			response.Text = "Lower!!!";
		} else {
			numberOfGuesses++;
			response.Text = "You got it!! You guessed " + numberOfGuesses + " times.";
			guessAgain.Disabled = true;
			playAgain.Disabled = false;
			playAgain.Modulate = new Color(1,1,1);
			randomNumberHolder.Text = $"{randomNumber}";
		}
	}

	private void _on_play_again_pressed()
	{
		guessAgain.Disabled = true;
		submit.Disabled = false;
		guessHolder.Text = "";
		response.Text = "";
		numberOfGuessesHolder.Text = "";
		playAgain.Disabled = true;
		playAgain.Modulate = new Color(1,1,1,0);
		randomNumberHolder.Text = "?";
		numberOfGuesses = 0;
		numberOfGuessesHolder.Text = "0";
		guessHolder.Editable = true;
		randomNumber = rand.Next(1,100);
	}	
}
