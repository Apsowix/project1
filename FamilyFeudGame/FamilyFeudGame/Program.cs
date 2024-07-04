using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyFeudConsoleApp
{
    class Program
    {
        // Structure to hold questions and their respective answers with points.
        class Question
        {
            public string Text { get; set; }
            public List<(string Answer, int Points)> Answers { get; set; }
        }

        // Sample questions for the game.
        static List<Question> Questions = new List<Question>
        {
            new Question
            {
                Text = "Name a fruit you might eat for breakfast.",
                Answers = new List<(string, int)>
                {
                    ("Banana", 30),
                    ("Apple", 25),
                    ("Orange", 20),
                    ("Grapes", 15),
                    ("Strawberry", 10)
                }
            },
            new Question
            {
                Text = "Name something you would find in a kitchen.",
                Answers = new List<(string, int)>
                {
                    ("Refrigerator", 35),
                    ("Oven", 25),
                    ("Sink", 20),
                    ("Dishwasher", 10),
                    ("Microwave", 10)
                }
            },
            new Question
            {
                Text = "Name a popular pet.",
                Answers = new List<(string, int)>
                {
                    ("Dog", 40),
                    ("Cat", 30),
                    ("Fish", 15),
                    ("Bird", 10),
                    ("Hamster", 5)
                }
            },
            new Question
            {
                Text = "Name a type of transportation.",
                Answers = new List<(string, int)>
                {
                    ("Car", 40),
                    ("Bus", 30),
                    ("Bicycle", 15),
                    ("Train", 10),
                    ("Airplane", 5)
                }
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Family Feud!");
            int totalScore = 0;
            const int maxAttempts = 3;

            foreach (var question in Questions)
            {
                Console.WriteLine($"\nQuestion: {question.Text}");
                bool answeredCorrectly = false;

                for (int attempt = 0; attempt < maxAttempts; attempt++)
                {
                    Console.Write("Your answer: ");
                    string answer = Console.ReadLine()?.Trim().ToLower();

                    if (string.IsNullOrWhiteSpace(answer))
                    {
                        Console.WriteLine("Please enter a valid answer.");
                        attempt--; // Allow the user to retry without counting this as an attempt.
                        continue;
                    }

                    var matchingAnswer = question.Answers.FirstOrDefault(a => a.Answer.ToLower() == answer);

                    if (matchingAnswer != default)
                    {
                        Console.WriteLine($"Correct! You earned {matchingAnswer.Points} points.");
                        totalScore += matchingAnswer.Points;
                        answeredCorrectly = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that's not on the board. Try again.");
                    }
                }

                if (!answeredCorrectly)
                {
                    Console.WriteLine("You've exhausted your attempts for this question.");
                }
            }

            Console.WriteLine($"\nGame over! Your total score is: {totalScore}");

            // Ending message based on score.
            if (totalScore >= 100)
            {
                Console.WriteLine("Great job! You really know your stuff!");
            }
            else if (totalScore >= 50)
            {
                Console.WriteLine("Not bad! You did pretty well!");
            }
            else
            {
                Console.WriteLine("Better luck next time!");
            }

            Console.WriteLine("Thank you for playing Family Feud!");
        }
    }
}
