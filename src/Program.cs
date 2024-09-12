using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Lncodes.Example.Generic;

internal static class Program
{
    /// <summary>
    /// Main entry point for the program.
    /// </summary>
    private static void Main()
    {
        var quizControllerTypeId = GetRandomQuizControllerId();
        switch (quizControllerTypeId)
        {
            case 0:
                var quizControllerType1 = new QuizController<string, int, List<int>>("1 + 1 =", 2, [1, 2, 3, 4]);
                ShowQuizData(quizControllerType1);
                CheckAnswer(quizControllerType1, int.Parse(Console.ReadLine()));
                break;
            case 1:
                var quizControllerType2 = new QuizController<string, bool, SortedSet<bool>>("Is the sky blue?", true, [true, false]);
                ShowQuizData(quizControllerType2);
                CheckAnswer(quizControllerType2, bool.Parse(Console.ReadLine()));
                break;
            case 2:
                var quizControllerType3 = new QuizController<string, string, HashSet<string>>("What is the capital of France?", "Paris", ["London", "Berlin", "Paris", "Madrid"]);
                ShowQuizData(quizControllerType3);
                CheckAnswer(quizControllerType3, Console.ReadLine());
                break;
            default:
                throw new InvalidOperationException($"Unexpected quiz type ID: {quizControllerTypeId}");
        }
    }

    /// <summary>
    /// Generates a random quiz controller ID.
    /// </summary>
    /// <returns cref="int">Random quiz controller ID.</returns>
    private static int GetRandomQuizControllerId()
    {
        const int amountOfEnemyTypes = 3;
        return RandomNumberGenerator.GetInt32(amountOfEnemyTypes);
    }

    /// <summary>
    /// Displays quiz data including question, choices, and answer type.
    /// </summary>
    /// <typeparam name="TQuestion">Type of the question.</typeparam>
    /// <typeparam name="TAnswer">Type of the answer.</typeparam>
    /// <typeparam name="TChoice">Type of the choices collection.</typeparam>
    /// <param name="quizController">The quiz controller instance.</param>
    private static void ShowQuizData<TQuestion, TAnswer, TChoice>(QuizController<TQuestion, TAnswer, TChoice> quizController) where TChoice : ICollection<TAnswer>
    {
        var choiceType = quizController.ChoiceCollection.GetType();
        var choiceName = choiceType.Name.Replace("`1", $"<{choiceType.GenericTypeArguments[0].Name}>");
        Console.WriteLine($"Question ({quizController.Question.GetType().Name}): {quizController.Question}");
        Console.Write($"Choice ({choiceName}): ");
        Console.WriteLine(string.Join(", ", quizController.ChoiceCollection));
        Console.Write($"Type your answer ({quizController.Answer.GetType().Name}): ");
    }

    /// <summary>
    /// Checks if the provided answer is correct and displays the result.
    /// </summary>
    /// <typeparam name="TQuestion">Type of the question.</typeparam>
    /// <typeparam name="TAnswer">Type of the answer.</typeparam>
    /// <typeparam name="TChoice">Type of the choices collection.</typeparam>
    /// <param name="quizController">The quiz controller instance.</param>
    /// <param name="answer">The user-provided answer.</param>
    private static void CheckAnswer<TQuestion, TAnswer, TChoice>(QuizController<TQuestion, TAnswer, TChoice> quizController, TAnswer answer) where TChoice : ICollection<TAnswer>
    {
        Console.WriteLine();
        quizController.CheckAnswer(answer);
    }
}