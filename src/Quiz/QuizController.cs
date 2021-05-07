using System;
using System.Collections;

namespace Lncodes.Example.Generic
{
    public sealed class QuizController<TQuestion, TCorrectAnswer, TChoice> where TChoice : ICollection
    {
        public readonly TQuestion Question;
        public readonly TChoice ChoiceCollection;
        public readonly TCorrectAnswer CorrectAnswer;

        // Constructor
        public QuizController(TQuestion question, TCorrectAnswer correctAnswer, TChoice choiceCollection) =>
            (Question, CorrectAnswer, ChoiceCollection) = (question, correctAnswer, choiceCollection);

        /// <summary>
        /// Method For Check a Answer
        /// </summary>
        /// <param name="answer">User Answer</param>
        public void CheckAnswer(TCorrectAnswer answer)
        {
            if (answer.Equals(CorrectAnswer))
                Console.WriteLine("Answer correct");
            else
            {
                Console.WriteLine("Answer wrong");
                Console.WriteLine($"The correct answer is {CorrectAnswer}");
            }
        }
    }
}