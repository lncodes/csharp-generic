using System;
using System.Collections.Generic;

namespace Lncodes.Example.Generic
{
    public sealed class QuizController<TQuestion, TAnswer, TChoice> where TChoice : ICollection<TAnswer>
    {
        public readonly TAnswer Answer;
        public readonly TQuestion Question;
        public readonly TChoice ChoiceCollection;

        // Constructor
        public QuizController(TQuestion question, TAnswer answer, TChoice choiceCollection) =>
            (Question, Answer, ChoiceCollection) = (question, answer, choiceCollection);

        /// <summary>
        /// Method to Check a Answer
        /// </summary>
        /// <param name="answer">User Answer</param>
        public void CheckAnswer(TAnswer answer)
        {
            if (answer.Equals(Answer))
                Console.WriteLine("Answer correct");
            else
            {
                Console.WriteLine("Answer wrong");
                Console.WriteLine($"The correct answer is {this.Answer}");
            }
        }
    }
}