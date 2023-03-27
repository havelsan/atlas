using Core.Models;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.Model;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTDefinitionManagement;
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
    public class ComplaintSuggestionController : Controller
    {


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetComplationSuggestion getAllComplaintSuggestionList()
        {
            GetComplationSuggestion complationSuggestion = new GetComplationSuggestion();
            complationSuggestion.complaintSuggestionListDTOs = new List<ComplationSuggestionListDTO>();
            complationSuggestion.complaintSuggestionListDTOs = ComplaintAndSuggestion.GetComplaintAndSuggestion(string.Empty).Select(x => new ComplationSuggestionListDTO()
            {
                ComplationOrSuggestionType = x.ComplationOrSuggestion.Value,
                Desciption = x.Desciption,
                IsRead = x.IsRead.Value,
                ObjectID = x.ObjectID.Value

            }).ToList();

            return complationSuggestion;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ComplationAndSuggestionOutputItem getComplationAndSuggestionOutputItem(GetComplationAndSuggestion_Input input)
        {
            using (var objectContect = new TTObjectContext(false))
            {
                ComplationAndSuggestionOutputItem outputItem = ComplaintAndSuggestion.GetComplaintAndSuggestion("WHERE OBJECTID = " + TTConnectionManager.ConnectionManager.GuidToString(input.ObjectID)).Select(x => new ComplationAndSuggestionOutputItem()
                {
                    ComplationOrSuggestion = x.ComplationOrSuggestion.Value,
                    Surname = x.Surname,
                    ObjectID = x.ObjectID.Value,
                    Desciption = x.Desciption,
                    EMail = x.EMail,
                    IsRead = x.IsRead.Value,
                    MobilePhone = x.MobilePhone,
                    Name = x.Name
                }).FirstOrDefault();
                return outputItem;
            }
        }

        [HttpPost]
        public string saveObjectForAtlas(ComplationAndSuggestionOutputItem input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                ComplaintAndSuggestion complaintAndSuggestion = objectContext.GetObject<ComplaintAndSuggestion>(input.ObjectID);
                complaintAndSuggestion.IsRead = input.IsRead;

                objectContext.Save();
                objectContext.Dispose();
                return "Şikayet / Öneriniz Okunmuştur.";
            }
            catch
            {
                return " Hata";
            }
        }

        [HttpPost]
        public string saveObject([FromBody]ComplaintSuggestionDTO input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                ComplaintAndSuggestion complaintAndSuggestion = new ComplaintAndSuggestion(objectContext);

                if (input.ComplationOrSuggestion.Contains("Şikayet")) { complaintAndSuggestion.ComplationOrSuggestion = ComplationAndSuggestionTypeEnum.Complaint; }
                else { complaintAndSuggestion.ComplationOrSuggestion = ComplationAndSuggestionTypeEnum.Suggestion; }
                complaintAndSuggestion.Desciption = input.Desciption;
                complaintAndSuggestion.EMail = input.EMail;
                complaintAndSuggestion.MobilePhone = input.MobilePhone;
                complaintAndSuggestion.Name = input.Name;
                complaintAndSuggestion.Surname = input.Surname;
                complaintAndSuggestion.IsRead = false;

                objectContext.Save();
                objectContext.Dispose();
                return "Şikayet / Öneriniz Alınmıştır. Teşekkür Eder sağlıklı Günler Dileriz..";
            }
            catch
            {
                return " Kayıt Sırasında Bir Hata Oluşmuştur Lüften Tekrar Deneyiniz..";
            }
        }

        public class ComplaintSuggestionDTO
        {
            public string Desciption { get; set; }
            public string EMail { get; set; }
            public string MobilePhone { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string ComplationOrSuggestion { get; set; }

        }


        public class ComplationSuggestionListDTO
        {
            public Guid ObjectID { get; set; }
            public ComplationAndSuggestionTypeEnum ComplationOrSuggestionType { get; set; }
            public string Desciption { get; set; }
            public bool IsRead { get; set; }
        }

        public class GetComplationSuggestion
        {
            public List<ComplationSuggestionListDTO> complaintSuggestionListDTOs { get; set; }
        }

        public class GetComplationAndSuggestion_Input
        {
            public Guid ObjectID
            {
                get; set;
            }
        }


        public class ComplationAndSuggestionOutputItem
        {
            public bool IsRead { get; set; }
            public Guid ObjectID { get; set; }

            public string Desciption { get; set; }
            public string EMail { get; set; }
            public string MobilePhone { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public ComplationAndSuggestionTypeEnum ComplationOrSuggestion { get; set; }
        }
    }
}
