using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Infrastructure.Helpers;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Infrastructure.Filters;


namespace Core.Controllers
{
    public partial class MHRSExceptionalServiceController
    {
        
        [HttpGet]
        public MHRSExceptionalFormViewModel MHRSExceptionalForm()
        {
            var viewModel = new MHRSExceptionalFormViewModel();
            return viewModel;
        }
        [HttpPost]
        public bool IsDocumentRequiredForAction(MHRSActionTypeDefinition action)
        {
            if (action.IsDocumentRequired == true)
                return true;
            else
                return false;
        }
        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<bool> Upload()
        {
            var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<MHRSExceptionalFormViewModel>(this);
            var objectResult = result as ObjectResult;
            var viewModel = objectResult.Value as MHRSExceptionalFormViewModel;
            bool bildirildi = false;
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    MHRSServis.TelefonIletisimBilgileriType telefonIletisimBilgileri = new MHRSServis.TelefonIletisimBilgileriType();
                    if (viewModel.PhoneType == PhoneTypeEnum.Home)
                        telefonIletisimBilgileri.NumaraTipi = 1;
                    else if (viewModel.PhoneType == PhoneTypeEnum.GSM)
                        telefonIletisimBilgileri.NumaraTipi = 2;

                    if (!string.IsNullOrEmpty(viewModel.PhoneNumber))
                    {
                        telefonIletisimBilgileri.AlanKodu = viewModel.PhoneNumber.Substring(1, 3);
                        telefonIletisimBilgileri.TelefonNo = viewModel.PhoneNumber.Substring(5, 7);
                    }
                    
                    MHRSServis.IstisnaDokumanType istisnaDokuman = new MHRSServis.IstisnaDokumanType();                 

                    Schedule schedule = (Schedule)objectContext.GetObject(viewModel.schedule, typeof(Schedule));
                    MHRSActionTypeDefinition actionType = (MHRSActionTypeDefinition)objectContext.GetObject(viewModel.actionTypeObjectId, typeof(MHRSActionTypeDefinition));

                    if (viewModel.Attachments != null && viewModel.Attachments.Count > 0)
                    {
                        var formFile = viewModel.Attachments.FirstOrDefault();
                        var content = StreamHelpers.ToByteArray(formFile.OpenReadStream());
                        istisnaDokuman.IstisnaDokuman = content;
                        istisnaDokuman.IstisnaDokumanAdi = formFile.FileName;
                    }
                     bildirildi = schedule.MHRSIstisnaEkle(viewModel.Email, viewModel.Description, istisnaDokuman, telefonIletisimBilgileri, schedule, actionType);
                    if (bildirildi)
                    {
                        schedule.MHRSScheduleType = MHRSScheduleTypeEnum.WaitingApproval;

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return bildirildi;
        }

        
    }
}
namespace Core.Models
{
    public partial class MHRSExceptionalFormViewModel
    {
        public Guid schedule { get; set; }
        public string Email { get; set; }
        public PhoneTypeEnum PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public Guid actionTypeObjectId { get; set; }
        public MHRSActionTypeDefinition ActionType { get; set; }
        public string DocumentPath { get; set; }
        public IList<FormFile> Attachments { get; set; }
        public bool Result { get; set; }

        //public byte[] Document { get; set; }
    }
}
