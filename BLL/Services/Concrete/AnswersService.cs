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
        private readonly DatabaseContext databaseContext;
        private int positiveScore = 1;
        private int negativeScore = 0;
        private double scoreForA = 0;
        private double scoreForB = 0;
        private double scoreForC = 0;
        private double scoreForD = 0;
        private double scoreForE = 0;
        private int totalTimePerTest = 0;
        private double percentPerDifficult = 0.0;
        private double formula;
        private string descriptionResult = "";

        public AnswersService(IAnswerRepository answerRepository, DatabaseContext databaseContext, 
            IUserRepository userRepository, IDailyTestRepository dailyTestRepository)
        {
            this.answerRepository = answerRepository;
            this.databaseContext = databaseContext;
            this.userRepository = userRepository;
            this.dailyTestRepository = dailyTestRepository;
        }

        private async Task<IEnumerable<Answer>> GetAllAnswers(Guid userId, Guid testId)
        {
            var result = await databaseContext.Answer.Where(a => a.PassedUserId.Id == userId).Where(a => a.DailyTest.Id == testId).Where(a => a.DateBegin.Value.Day == DateTime.Now.Day).ToListAsync();
            return result; 
        }

        public async void CheckTheAnswers(Guid userId, Guid testId)
        {
            var allAnswers = await GetAllAnswers(userId, testId);
            foreach(var answer in allAnswers)
            {
                var time = answer.DateBegin.Value.Minute - answer.DateEnd.Value.Minute;
                totalTimePerTest += time;
                if (answer.PassedUserId.UserLevel == answer.Question.DifficultyLevel)
                {
                    switch (answer.Question.DifficultyLevel)
                    {
                        case "A":
                            percentPerDifficult = 0.05;
                            if (answer.Question.Description.StartsWith("①"))
                            {
                                if (answer.QuestionAnswer == "Hi")
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
                                if (answer.QuestionAnswer == "Hi")
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
                            percentPerDifficult = 0.15;
                            if (answer.Question.Description.StartsWith("①"))
                            {
                                if (answer.QuestionAnswer == "Hi")
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
                                if (answer.QuestionAnswer == "Hi")
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
                            percentPerDifficult = 0.20;
                            break;
                        case "D":
                            percentPerDifficult = 0.25;
                            break;
                        case "E":
                            percentPerDifficult = 0.35;
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
            var dailyTest = await dailyTestRepository.GetById(testId);

            if(scoreForA != 0)
            {
                formula = ((DateTime.Now.Year - user.BirthDate.Year) * percentPerDifficult) + scoreForA + totalTimePerTest;
            } else if(scoreForB != 0)
            {
                formula = ((DateTime.Now.Year - user.BirthDate.Year) * percentPerDifficult) + scoreForB + totalTimePerTest;
            } else if(scoreForC != 0)
            {
                formula = ((DateTime.Now.Year - user.BirthDate.Year) * percentPerDifficult) + scoreForC + totalTimePerTest;
            } else if(scoreForD != 0)
            {
                formula = ((DateTime.Now.Year - user.BirthDate.Year) * percentPerDifficult) + scoreForD + totalTimePerTest;
            } else if(scoreForE != 0)
            {
                formula = ((DateTime.Now.Year - user.BirthDate.Year) * percentPerDifficult) + scoreForE + totalTimePerTest;
            }

            //if formula == ... THEN description ==

            //create new DailyTestResult obj and pass the parameters


        }
    }
}
