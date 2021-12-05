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
        private readonly IUnitOfWork unitOfWork;
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

        public AnswersService(IUnitOfWork unitOfWork, DatabaseContext databaseContext)
        {
            this.unitOfWork = unitOfWork;
            this.databaseContext = databaseContext;
        }

        private async Task<IEnumerable<Answer>> GetAllAnswers(Guid userId, Guid testId)
        {
            try
            {
                var result = await databaseContext.Answer.Where(a => a.PassedUserId.Id == userId).Where(a => a.DailyTest.Id == testId).Where(a => a.DateBegin.Value.Day == DateTime.Now.Day)
                    .Include(o => o.DailyTest).Include(o => o.PassedUserId).Include(o => o.Question).ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task CheckTheAnswers(Guid userId, Guid testId)
        {
            var allAnswers = await GetAllAnswers(userId, testId);
            // > 10
            if (allAnswers.Count() > 1)
            {
                Debug.Assert(false);
                return;
            }
            foreach(var answer in allAnswers)
            {
                var time = answer.DateEnd.Value.Minute - answer.DateBegin.Value.Minute;
                totalTimePerTest += time;
                if (answer.PassedUserId.UserKnowledgeLevel == answer.Question.DifficultyLevel)
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

                await unitOfWork.AnswerRepository.Update(answer);
            }

            var user = await unitOfWork.UserRepository.GetById(userId);
            var userAge = DateTime.Now.Year - user.BirthDate.Year;
            var dailyTest = await unitOfWork.DailyTestRepository.GetById(testId);

            if (scoreForA != 0)
            {
                formula = (userAge * percentPerDifficult) + scoreForA + totalTimePerTest;
                descriptionResult = CheckFormulaAResults(formula, userAge);
                if(descriptionResult.Contains("Congratulations"))
                {
                    user.UserKnowledgeLevel = "B";
                } else
                {
                    user.UserKnowledgeLevel = "A";

                }
            } else if(scoreForB != 0)
            {
                formula = (userAge * percentPerDifficult) + scoreForB + totalTimePerTest;
                descriptionResult = CheckFormulaBResults(formula, userAge);
                if (descriptionResult.Contains("Congratulations"))
                {
                    user.UserKnowledgeLevel = "C";
                }
                else
                {
                    user.UserKnowledgeLevel = "B";

                }
            } else if(scoreForC != 0)
            {
                formula = (userAge * percentPerDifficult) + scoreForC + totalTimePerTest;
                descriptionResult = CheckFormulaCResults(formula, userAge);
                if (descriptionResult.Contains("Congratulations"))
                {
                    user.UserKnowledgeLevel = "C";
                }
                else
                {
                    user.UserKnowledgeLevel = "B";

                }
            }
            await unitOfWork.UserRepository.Update(user);

            var testResultId = Guid.NewGuid();

            DailyTestResult testResult = new DailyTestResult()
            {
                Id = testResultId,
                DailyTest = dailyTest,
                PassedUserId = user,
                Score = formula,
                Description = descriptionResult
            };
            await unitOfWork.DailyTestResultRepository.Add(testResult);
        }

        private string CheckFormulaAResults(double formula, int userAge)
        {
            string description = "";
            switch(userAge)
            {
                case 5:
                    minGoodA = 8.25;
                    minBadA = 32.25;
                    if(formula >= minGoodA && formula < minBadA)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    } else if(formula < minGoodA || formula > minBadA)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 6:
                    minGoodA = 8.5;
                    minBadA = 32.5;
                    if (formula >= minGoodA && formula < minBadA)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodA || formula > minBadA)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 7:
                    minGoodA = 8.75;
                    minBadA = 32.75;
                    if (formula >= minGoodA && formula < minBadA)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodA || formula > minBadA)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 8:
                    minGoodA = 9;
                    minBadA = 33;
                    if (formula >= minGoodA && formula < minBadA)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodA || formula > minBadA)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 9:
                    minGoodA = 9.25;
                    minBadA = 33.25;
                    if (formula >= minGoodA && formula < minBadA)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodA || formula > minBadA)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 10:
                    minGoodA = 9.5;
                    minBadA = 33.5;
                    if (formula >= minGoodA && formula < minBadA)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodA || formula > minBadA)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
            }

            return description;
        }

        private string CheckFormulaBResults(double formula, int userAge)
        {
            string description = "";

            switch (userAge)
            {
                case 5:
                    minGoodB = 8.75;
                    minBadB = 32.5;
                    if (formula >= minGoodB && formula < minBadB)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodB || formula > minBadB)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 6:
                    minGoodB = 9.1;
                    minBadB = 33.1;
                    if (formula >= minGoodB && formula < minBadB)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodB || formula > minBadB)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 7:
                    minGoodB = 9.45;
                    minBadB = 32.45;
                    if (formula >= minGoodB && formula < minBadB)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodB || formula > minBadB)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 8:
                    minGoodB = 9.8;
                    minBadB = 33.8;
                    if (formula >= minGoodB && formula < minBadB)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodB || formula > minBadB)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 9:
                    minGoodB = 10.15;
                    minBadB = 34.15;
                    if (formula >= minGoodB && formula < minBadB)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodB || formula > minBadB)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 10:
                    minGoodB = 10.5;
                    minBadB = 34.5;
                    if (formula >= minGoodB && formula < minBadB)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodB || formula > minBadB)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
            }
            return description;
        }

        private string CheckFormulaCResults(double formula, int userAge)
        {
            string description = "";

            switch (userAge)
            {
                case 5:
                    minGoodC = 9;
                    minBadC = 33;
                    if (formula >= minGoodC && formula < minBadC)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodC || formula > minBadC)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 6:
                    minGoodC = 9.4;
                    minBadC = 33.4;
                    if (formula >= minGoodC && formula < minBadC)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodC || formula > minBadC)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 7:
                    minGoodC = 9.8;
                    minBadC = 33.8;
                    if (formula >= minGoodC && formula < minBadC)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodC || formula > minBadC)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 8:
                    minGoodC = 10.2;
                    minBadC = 34.2;
                    if (formula >= minGoodC && formula < minBadC)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodC || formula > minBadC)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 9:
                    minGoodC = 10.6;
                    minBadC = 34.6;
                    if (formula >= minGoodC && formula < minBadC)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodC || formula > minBadC)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
                case 10:
                    minGoodC = 11;
                    minBadC = 35;
                    if (formula >= minGoodC && formula < minBadC)
                    {
                        description = "The test result is good, it equals to " + formula + " points. Your level has increased. Congratulations!";
                    }
                    else if (formula < minGoodC || formula > minBadC)
                    {
                        description = "The test result is not so good, it equals to " + formula + " points. Your level hasn't changed. Try to work harder next time!";
                    }
                    break;
            }

            return description;
        }


    }
}
