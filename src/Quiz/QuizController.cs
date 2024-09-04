using System;
using System.Collections.Generic;

namespace Lncodes.Example.Generic;

public sealed class QuizController<TQuestion, TAnswer, TChoicesCollection> where TChoicesCollection : ICollection<TAnswer>
{
    public TQuestion Question { get; }
    public TAnswer Answer { get; }
    public TChoicesCollection ChoiceCollection { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuizController{TQuestion, TAnswer, TChoicesCollection}"/> class.
    /// </summary>
    /// <param name="question">The quiz question.</param>
    /// <param name="answer">The correct answer to the quiz question.</param>
    /// <param name="choiceCollection">A collection of possible answers.</param>
    public QuizController(TQuestion question, TAnswer answer, TChoicesCollection choiceCollection) =>
        (Question, Answer, ChoiceCollection) = (question, answer, choiceCollection);

    /// <summary>
    /// Checks if the provided answer matches the correct answer.
    /// </summary>
    /// <param name="answer">The user's answer.</param>
    public void CheckAnswer(TAnswer answer)
    {
        if (answer.Equals(Answer))
            Console.WriteLine("Your answer is correct.");
        else
        {
            Console.WriteLine("Your answer is incorrect.");
            Console.WriteLine($"The correct answer is: {this.Answer}");
        }
    }
}