using BLL.Services.Abstract;
using CIL.Models;
using DAL;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Concrete
{
    public class AnswersService : IAnswersService
    {
        private readonly IAnswerRepository answerRepository;
        private readonly IUserRepository userRepository;
        private readonly IDailyTestRepository dailyTestRepository;
        private readonly IDailyTestResultRepository dailyTestResultRepository;
        private readonly DatabaseContext databaseContext;

        private int positiveScore = 1;
        private int negativeScore = 0;
        private double scoreForA = 0;
        private double scoreForB = 0;
        private double scoreForC = 0;
        private int totalTimePerTest = 0;
        private double percentPerDifficult = 0.0;
        private double formula;
        private string descriptionResult = "";
        private double minGoodA = 0.0;
        private double minGoodB = 0.0;
        private double minGoodC = 0.0;
        private double minBadA = 0.0;
        private double minBadB = 0.0;
        private double minBadC = 0.0;

        public AnswersService(IAnswerRepository answerRepository, DatabaseContext databaseContext, 
            IUserRepository userRepository, IDailyTestRepository dailyTestRepository,
            IDailyTestResultRepository dailyTestResultRepository)
        {
            this.answerRepository = answerRepository;
            this.databaseContext = databaseContext;
            this.userRepository = userRepository;
            this.dailyTestRepository = dailyTestRepository;
            this.dailyTestResultRepository = dailyTestResultRepository;
        }

        private async Task<IEnumerable<Answer>> GetAllAnswers(Guid userId, Guid testId)
        {
            var result = await databaseContext.Answer.Where(a => a.PassedUserId.Id == userId).Where(a => a.DailyTest.Id == testId).Where(a => a.DateBegin.Value.Day == DateTime.Now.Day).ToListAsync();
            return result; 
        }

        public async void CheckTheAnswers(Guid userId, Guid testId)
        {
            var allAnswers = await GetAllAnswers(userId, testId);
            if(allAnswers.Count() > 10)
            {
                Debug.Assert(false);
                return;
            }
            foreach(var answer in allAnswers)
            {
                var time = answer.DateBegin.Value.Minute - answer.DateEnd.Value.Minute;
                totalTimePerTest += time;
                if (answer.PassedUserId.UserLevel == answer.Question.DifficultyLevel)
                {
                    switch (answer.Question.DifficultyLevel)
                    {
                        case "A":
                            percentPerDifficult = 0.25;
                            if (answer.Question.Description.StartsWith("①"))
                            {
                                if (answer.QuestionAnswer == DateTime.Now.DayOfWeek.ToString())
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("②"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("③"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("④"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑤"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑥"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑦"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑧"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑨"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑩"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForA++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            break;
                        case "B":
                            percentPerDifficult = 0.35;
                            if (answer.Question.Description.StartsWith("①"))
                            {
                                if (answer.QuestionAnswer == DateTime.Now.DayOfWeek.ToString())
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("②"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("③"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("④"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑤"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑥"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑦"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑧"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑨"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑩"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForB++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            break;
                        case "C":
                            percentPerDifficult = 0.40;
                            if (answer.Question.Description.StartsWith("①"))
                            {
                                if (answer.QuestionAnswer == DateTime.Now.DayOfWeek.ToString())
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("②"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("③"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("④"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑤"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑥"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑦"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑧"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑨"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            else if (answer.Question.Description.StartsWith("⑩"))
                            {
                                if (answer.QuestionAnswer.ToLower() == answer.Question.CorrectAnswer)
                                {
                                    answer.Score = positiveScore;
                                    scoreForC++;
                                }
                                else
                                {
                                    answer.Score = negativeScore;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    Debug.Assert(false);
                }

                await answerRepository.Update(answer);
            }

            var user = await userRepository.GetById(userId);
            var userAge = DateTime.Now.Year - user.BirthDate.Year;
            var dailyTest = await dailyTestRepository.GetById(testId);

            if (scoreForA != 0)
            {
                formula = (userAge * percentPerDifficult) + scoreForA + totalTimePerTest;
                descriptionResult = CheckFormulaAResults(formula, userAge);
                if(descriptionResult.Contains("Congratulations"))
                {
                    user.UserLevel = "B";
                } else
                {
                    user.UserLevel = "A";

                }
            } else if(scoreForB != 0)
            {
                formula = (userAge * percentPerDifficult) + scoreForB + totalTimePerTest;
            } else if(scoreForC != 0)
            {
                formula = (userAge * percentPerDifficult) + scoreForC + totalTimePerTest;
            }
            await userRepository.Update(user);

            var testResultId = Guid.NewGuid();

            DailyTestResult testResult = new DailyTestResult()
            {
                Id = testResultId,
                DailyTest = dailyTest,
                PassedUserId = user,
                Score = formula,
                Description = descriptionResult
            };
            await dailyTestResultRepository.Add(testResult);

            // Add blocker to have one test per user on one day
            //Refresh UserLevel after the result
            // Add blocker not to pass the same level test, if you have another level
            //Add GET -> show test with related questions depending on UserLevel
            // Add POST -> add answers with guid test, guid question
            // Add Controllers for DailyTestResult
        }

        private string CheckFormulaAResults(double formula, int userAge)
        {
            string description = "";
            switch(userAge)
            {
                case 5:
                    minGoodA = 8.25;
                    minBadA = 32.25;
                    if(formula >= 8.25 && formula < 32.25)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    } else if(formula < 8.25)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
            }

            return description;
        }

        private string CheckFormulaBResults(double formula, int userAge)
        {
            string description = "";

            return description;
        }

        private string CheckFormulaCResults(double formula, int userAge)
        {
            string description = "";

            return description;
        }


    }
}
