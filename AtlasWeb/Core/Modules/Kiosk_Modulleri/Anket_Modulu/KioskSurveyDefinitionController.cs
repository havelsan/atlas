using Core.Models;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTReportClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class KioskSurveyDefinitionController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetSurveyDefinition getAllSurveyDefinition()
        {
            GetSurveyDefinition surveyDefinition = new GetSurveyDefinition();
            surveyDefinition.surveyDefinitionListDTOs = new List<SurveyDefinitionListDTO>();
            surveyDefinition.surveyDefinitionListDTOs = KioskSurveyDefinition.GetKioskSurveyDefinitionList(string.Empty).Select(x => new SurveyDefinitionListDTO()
            {
                Name = x.Name,
                ObjectID = x.ObjectID.Value,
                IsActive = x.IsActive.Value
            }).ToList();
            return surveyDefinition;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SurveyDefinitionOutputItem getSurveyDefinitionItem(GetSurveyDefinition_Input input)
        {
            using (var objectContect = new TTObjectContext(false))
            {
                SurveyDefinitionOutputItem outputItem = new SurveyDefinitionOutputItem();

                KioskSurveyDefinition surveyDefinition = objectContect.GetObject<KioskSurveyDefinition>(input.ObjectID);
                outputItem.Name = surveyDefinition.Name;
                outputItem.EndDate = (DateTime)surveyDefinition.EndDate;
                outputItem.IsActive = (bool)surveyDefinition.IsActive;
                outputItem.isNew = false;
                outputItem.ObjectID = surveyDefinition.ObjectID;
                outputItem.StartDate = (DateTime)surveyDefinition.StartDate;

                outputItem.SurveyQuestions = new List<SurveyQuestion>();
                foreach (var questionItem in surveyDefinition.SurveyQuestions.Select(string.Empty))
                {
                    SurveyQuestion surveyQuestion = new SurveyQuestion();
                    surveyQuestion.Description = questionItem.Description;
                    surveyQuestion.ObjectID = questionItem.ObjectID;
                    surveyQuestion.Question = questionItem.Question;
                    surveyQuestion.QuestionOrder = (int)questionItem.QuestionOrder;

                    surveyQuestion.detail = new List<SurveyAnswer>();
                    foreach (var answerItem in questionItem.SurveyAnswers.Select(string.Empty))
                    {
                        SurveyAnswer surveyAnswer = new SurveyAnswer();
                        surveyAnswer.Answer = answerItem.Answer;
                        surveyAnswer.Description = answerItem.Description;
                        surveyAnswer.ObjectID = answerItem.ObjectID;
                        surveyAnswer.Point = (int)answerItem.Point;

                        surveyQuestion.detail.Add(surveyAnswer);
                    }
                    outputItem.SurveyQuestions.Add(surveyQuestion);
                }

                if(MadeOfSurvey.GetDescitionByQuestion(surveyDefinition.ObjectID).Count > 0)
                {
                    outputItem.isReadOnlyForm = true;
                }
                else
                {
                    outputItem.isReadOnlyForm = false;
                }

                return outputItem;
            }
        }




        [HttpPost]
        public string saveObject(SurveyDefinitionOutputItem input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                KioskSurveyDefinition surveyDefinition = null;
                if (input.isNew == true)
                {
                    surveyDefinition = new KioskSurveyDefinition(objectContext);
                }
                else
                {
                    surveyDefinition = objectContext.GetObject<KioskSurveyDefinition>(input.ObjectID);
                    foreach (var question in surveyDefinition.SurveyQuestions.Select(string.Empty))
                    {
                        foreach (var answer in question.SurveyAnswers.Select(string.Empty))
                        {
                            ((ITTObject)answer).Delete();
                        }
                         ((ITTObject)question).Delete();
                    }
                }

                surveyDefinition.StartDate = input.StartDate;
                surveyDefinition.EndDate = input.EndDate;
                surveyDefinition.Name = input.Name;
                surveyDefinition.IsActive = input.IsActive;

                List<SurveyQuestion> surveyQuestions = new List<SurveyQuestion>();
                foreach (var questionItem in input.SurveyQuestions)
                {
                    TTObjectClasses.SurveyQuestion surveyQuestion = new TTObjectClasses.SurveyQuestion(objectContext);
                    surveyQuestion.Description = questionItem.Description;
                    surveyQuestion.Question = questionItem.Question;
                    surveyQuestion.QuestionOrder = (int)questionItem.QuestionOrder;

                    foreach (var answerItem in questionItem.detail)
                    {
                        TTObjectClasses.SurveyAnswer surveyAnswer = new TTObjectClasses.SurveyAnswer(objectContext);
                        surveyAnswer.Answer = answerItem.Answer;
                        surveyAnswer.Description = answerItem.Description;
                        surveyAnswer.Point = (int)answerItem.Point;
                        surveyQuestion.SurveyAnswers.Add(surveyAnswer);
                    }
                    surveyDefinition.SurveyQuestions.Add(surveyQuestion);
                }


                objectContext.Save();
                objectContext.Dispose();
                return "Anket Kayıt İşlemi Yapılmıştır";
            }
            catch
            {
                return " Anket Kayıt İşlemi Sırasında Hata Alınmıştır..";
            }
        }



        [HttpGet]
        public List<GetSurveyDTO> getSurveyList()
        {
            List<GetSurveyDTO> getSurveyDTO = new List<GetSurveyDTO>();
            GetSurveyDTO surveyDefinition = new GetSurveyDTO();
            getSurveyDTO = KioskSurveyDefinition.GetKioskSurveyDefinitionList(" WHERE ISACTIVE = 1").Select(x => new GetSurveyDTO()
            {
                SurveyDefinitionObjectId = x.ObjectID.Value,
                SurveyName = x.Name,
            }).ToList();
            return getSurveyDTO;
        }


        [HttpPost]
        public List<GetQuestion> getQuestions([FromBody]SurveyID input)
        {
            List<GetQuestion> getQuestions = new List<GetQuestion>();
            using (var objectContect = new TTObjectContext(false))
            {
                KioskSurveyDefinition surveyDefinition = objectContect.GetObject<KioskSurveyDefinition>(new Guid(input.surveyObjID));
                foreach (var questionItem in surveyDefinition.SurveyQuestions.Select(string.Empty))
                {
                    GetQuestion question = new GetQuestion();
                    question.QuestionObjectID = questionItem.ObjectID;
                    question.Question = questionItem.Question;
                    question.QuestionOrder = (int)questionItem.QuestionOrder;

                    question.Answers = new List<GetAnswer>();
                    foreach (var answerItem in questionItem.SurveyAnswers.Select(string.Empty))
                    {
                        GetAnswer surveyAnswer = new GetAnswer();
                        surveyAnswer.Answer = answerItem.Answer;
                        surveyAnswer.AnswerObjectID = answerItem.ObjectID;
                        surveyAnswer.Point = (int)answerItem.Point;
                        question.Answers.Add(surveyAnswer);
                    }
                    getQuestions.Add(question);
                }

                return getQuestions;
            }
        }


        [HttpPost]
        public string saveSurveyAnswers([FromBody]AllSelectedChoose input)
        {
            using (var objectContect = new TTObjectContext(false))
            {
                TTObjectContext readOnlyContext = new TTObjectContext(true);
                KioskSurveyDefinition surveyDefinition = readOnlyContext.GetObject<KioskSurveyDefinition>(new Guid(input.SurveyObjectID));

                MadeOfSurvey madeOfSurvey = new MadeOfSurvey(objectContect);
                madeOfSurvey.KioskSurveyDefinition = surveyDefinition;
                madeOfSurvey.Desciption = input.Desciption;
                foreach (SelectedChoose item in input.allSelectedChoose)
                {
                    MadeOfSurveyDetail madeOfSurveyDetail = new MadeOfSurveyDetail(objectContect);
                    madeOfSurveyDetail.SurveyQuestion = readOnlyContext.GetObject<TTObjectClasses.SurveyQuestion>(new Guid(item.QuestionObjectID));
                    madeOfSurveyDetail.SurveyAnswer = readOnlyContext.GetObject<TTObjectClasses.SurveyAnswer>(new Guid(item.AnswerObjectID));
                    madeOfSurvey.MadeOfSurveyDetails.Add(madeOfSurveyDetail);
                }
                objectContect.Save();
            }

            return "Ok";
        }

        [HttpPost]
        public OutputDTO getSurveyQuestion([FromBody]InputDTO input)
        {
            TTObjectContext objectContect = new TTObjectContext(false);
            OutputDTO outputDTO = new OutputDTO();
            if (input != null)
            {
                BindingList<MadeOfSurvey.GetTotalParticipation_Class> total = MadeOfSurvey.GetTotalParticipation(new Guid(input.SurveyObjectID));
                outputDTO.TotalParticipation = Int32.Parse(total[0].Total.ToString());
                outputDTO.questionLists = new List<QuestionList>();

                KioskSurveyDefinition surveyDefinition = objectContect.GetObject<KioskSurveyDefinition>(new Guid(input.SurveyObjectID));
                foreach (var questionItem in surveyDefinition.SurveyQuestions.Select(string.Empty))
                {
                    QuestionList question = new QuestionList();
                    question.ObjectId = questionItem.ObjectID;
                    question.Question = questionItem.Question;

                    question.AnswersList = MadeOfSurveyDetail.GetMadeOfAnswersByQuestion(questionItem.ObjectID).Select(x => new AnwerChart()
                    {
                        AnswerName = x.Answer,
                        AnswerObjectId = x.Answerid.Value,
                        Point = x.Point.Value,
                        TotalSelect = Int32.Parse(x.Totalselect.ToString())
                    }).ToList();
                    outputDTO.questionLists.Add(question);
                }
            }
            return outputDTO;
        }

        

        [HttpPost]
        public List<DesciptionOutput> getSurveyQuestionDesciption([FromBody]InputDTO input)
        {
            TTObjectContext objectContect = new TTObjectContext(false);
            List<DesciptionOutput> outputDTO = new List<DesciptionOutput>();
            if (input != null)
            {
                int count = 0;
                BindingList<MadeOfSurvey.GetDescitionByQuestion_Class> desciptions = MadeOfSurvey.GetDescitionByQuestion(new Guid(input.SurveyObjectID));
                foreach (MadeOfSurvey.GetDescitionByQuestion_Class item in desciptions)
                {
                    if(item.Desciption != null)
                    {
                        DesciptionOutput desciption = new DesciptionOutput();
                        desciption.Desciption = item.Desciption;
                        desciption.Count = count;
                        outputDTO.Add(desciption);
                        count++;

                    }
                }
            }
            return outputDTO;
        }

        public class DesciptionOutput
        {
            public string Desciption { get; set; }
            public int Count { get; set; }
        }

        public class OutputDTO
        {
            public int TotalParticipation { get; set; }
            public List<QuestionList> questionLists { get; set; }
        }

        public class QuestionList
        {

            public string Question { get; set; }
            public Guid ObjectId { get; set; }

            public List<AnwerChart> AnswersList { get; set; }

        }

        public class AnwerChart
        {
            public string AnswerName { get; set; }
            public Guid AnswerObjectId { get; set; }
            public int Point { get; set; }
            public int TotalSelect { get; set; }
        }

        public class InputDTO
        {
            public string SurveyObjectID { get; set; }
        }

        public class AllSelectedChoose
        {
            public List<SelectedChoose> allSelectedChoose { get; set; }
            public string SurveyObjectID { get; set; }

            public string Desciption { get; set; }
        }

        public class SelectedChoose
        {
            public string QuestionObjectID { get; set; }
            public string AnswerObjectID { get; set; }
          
        }

        public class SurveyID
        {
            public string surveyObjID { get; set; }
        }
        public class SurveyDTO
        {
            public Guid SurveyObjectID { get; set; }
            public List<QuestionAnwserDTO> QuestionAnwserDTOs { get; set; }

        }
        public class QuestionAnwserDTO
        {
            public Guid QuestionID { get; set; }
            public Guid AnswerID { get; set; }
            public int AnswerPoint { get; set; }
            public string AnswerDesciption { get; set; }
        }

        public class GetSurveyDTO
        {
            public Guid SurveyDefinitionObjectId { get; set; }
            public string SurveyName { get; set; }
        }

        public class GetQuestion
        {
            public string Question { get; set; }
            public List<GetAnswer> Answers { get; set; }
            public Guid QuestionObjectID { get; set; }
            public int QuestionOrder { get; set; }


        }

        public class GetAnswer
        {
            public string Answer { get; set; }
            public int Point { get; set; }
            public Guid AnswerObjectID { get; set; }
        }




        public class GetSurveyDefinition_Input
        {
            public Guid ObjectID { get; set; }
        }

        public class SurveyDefinitionOutputItem
        {
            public bool isReadOnlyForm { get; set; }
            public bool isNew { get; set; }
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public List<SurveyQuestion> SurveyQuestions { get; set; }
        }
        public class SurveyQuestion
        {

            public Guid ObjectID { get; set; }
            public string Description { get; set; }
            public int QuestionOrder { get; set; }
            public string Question { get; set; }
            public List<SurveyAnswer> detail { get; set; }

        }
        public class SurveyAnswer
        {
            public Guid ObjectID { get; set; }
            public string Description { get; set; }
            public int Point { get; set; }
            public string Answer { get; set; }
        }


        public class GetSurveyDefinition
        {
            public List<SurveyDefinitionListDTO> surveyDefinitionListDTOs { get; set; }
        }

        public class SurveyDefinitionListDTO
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
