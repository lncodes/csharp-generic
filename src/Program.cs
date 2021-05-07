using System;
using System.Collections;

namespace Lncodes.Example.Generic
{
    public class Program
    {
        static void Main()
        {
            //Create QuizController Instance
            var quizController = new QuizController<string, int, int[]>(question: "1 + 1 =", correctAnswer: 2, choiceCollection: new[] { 1, 2, 3, 4 });
            
            ShowQuizQuestion(quizController);
            CheckAnswer(quizController, Convert.ToInt32(GetUserAnswer()));
        }

        /// <summary>
        /// Method for get user answer
        /// </summary>
        /// <returns cref="string"></returns>
        private static string GetUserAnswer()
        {
            Console.Write("Type your answer : ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Method for showing quiz question
        /// </summary>
        /// <typeparam name="TQuestion"></typeparam>
        /// <typeparam name="TAnswer"></typeparam>
        /// <typeparam name="TChoice"></typeparam>
        /// <param name="quizController"></param>
        private static void ShowQuizQuestion<TQuestion,TAnswer,TChoice>(QuizController<TQuestion,TAnswer,TChoice> quizController) where TChoice : ICollection
        {
            Console.WriteLine("Quiz Program \n");
            Console.WriteLine($"Question : {quizController.Question}");
            Console.Write("Choice : ");
            foreach (var choice in quizController.ChoiceCollection)
                Console.Write($"[{choice}] ");
            Console.WriteLine();
        }

        /// <summary>
        /// Method for checking answer
        /// </summary>
        /// <typeparam name="TQusetion"></typeparam>
        /// <typeparam name="TAnswer"></typeparam>
        /// <typeparam name="TChoice"></typeparam>
        /// <param name="quizController"></param>
        /// <param name="userAnswer"></param>
        private static void CheckAnswer<TQusetion,TAnswer,TChoice>(QuizController<TQusetion,TAnswer,TChoice> quizController, TAnswer userAnswer) where TChoice : ICollection
        {
            Console.WriteLine();
            quizController.CheckAnswer(userAnswer);
        }
    }
}