using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class ArchiveDeliveryServiceController : Controller
    {


        [HttpGet]
        public ArchiveDeliveryFormViewModel LoadArchiveDeliveryFormViewModel(string EpisodeActionID)
        {
            ArchiveDeliveryFormViewModel model = new ArchiveDeliveryFormViewModel();
            model.FolderContentList = new List<FolderContent>();
            model.DeliverUserList = new List<UserObject>();
            model.RecipientUserList = new List<UserObject>();
            using (var objectContext = new TTObjectContext(true))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(EpisodeActionID));
                SubEpisode subepisode = episodeAction.SubEpisode;
                //Hasta Bilgileri
                model.PatientNameSurname = subepisode.Episode.Patient.Name + " " + subepisode.Episode.Patient.Surname;
                model.ProtocolNo = subepisode.ProtocolNo;

                EpisodeAction starterEpisodeAction = episodeAction.SubEpisode.StarterEpisodeAction;
                if (starterEpisodeAction is InPatientTreatmentClinicApplication)
                {
                    var TreatmentClinicApp = (InPatientTreatmentClinicApplication)starterEpisodeAction;
                    if (TreatmentClinicApp.BaseInpatientAdmission.Room != null)
                        model.RoomNumber = TreatmentClinicApp.BaseInpatientAdmission.Room.Name;
                    else model.RoomNumber = "";
                    if (TreatmentClinicApp.BaseInpatientAdmission.Bed != null)
                        model.BedNumber = TreatmentClinicApp.BaseInpatientAdmission.Bed.Name;
                    else model.BedNumber = "";
                    if (TreatmentClinicApp.ClinicInpatientDate != null)
                    {
                        model.ClinicDate = TreatmentClinicApp.ClinicInpatientDate.Value.ToShortDateString().ToString();
                    }
                    else model.ClinicDate = "";

                    if (TreatmentClinicApp.ClinicDischargeDate != null)
                    {
                        model.DischargeDate = TreatmentClinicApp.ClinicDischargeDate.Value.ToShortDateString().ToString();
                    }
                    else model.DischargeDate = "";

                    if (TreatmentClinicApp.ProcedureDoctor != null)
                        model.DoctorName = TreatmentClinicApp.ProcedureDoctor.Name;
                    else model.DoctorName = "";

                    model.ClinicName = starterEpisodeAction.FromResource.Name;
                }

                model.SubepisodeID = subepisode.ObjectID.ToString();
                //Kullanıcı Listeleri
                List<ResUser.GetResUser_Class> users = ResUser.GetResUser(" AND ISACTIVE = 1 ").ToList();
                foreach (ResUser.GetResUser_Class user in users)
                {
                    UserObject o = new UserObject();
                    o.ObjectID = user.ObjectID.ToString();
                    o.Name = user.Name;
                    model.DeliverUserList.Add(o);
                    model.RecipientUserList.Add(o);
                }

                //Kayıtlı kontrolü
                BindingList<ArchiveDeliveryForm> form = ArchiveDeliveryForm.GetArchiveDeliveryFormBySubepisodeID(objectContext, subepisode.ObjectID);
                if (form.Count > 0)
                {
                    model.IsNew = false;
                    model.Description = form[0].Description;
                    model.ObjectID = form[0].ObjectID.ToString();
                    if (form[0].Deliverer != null)
                    {
                        //UserObject o = new UserObject();
                        //o.ObjectID = form[0].Deliverer.ObjectID.ToString();
                        //o.Name = form[0].Deliverer.Name;
                        //model.SelectedDelivererUser = o;
                        model.SelectedDelivererUserID = form[0].Deliverer.ObjectID.ToString();
                    }
                    if (form[0].Recipient != null)
                    {
                        //UserObject o = new UserObject();
                        //o.ObjectID = form[0].Recipient.ObjectID.ToString();
                        //o.Name = form[0].Recipient.Name;
                        //model.SelectedRecipientUser = o;
                        model.SelectedRecipientUserID = form[0].Recipient.ObjectID.ToString();
                    }

                    foreach (ArchiveDeliveryFormDetails detail in form[0].ArchiveDeliveryFormDetails)
                    {
                        FolderContent content = new FolderContent();
                        content.IsSelected = Convert.ToBoolean(detail.IsSelected);
                        content.ContentName = detail.FolderContent.FileName;
                        content.PageNumber = detail.PageNumber;
                        content.ContentDefObjectID = detail.FolderContent.ObjectID.ToString();
                        content.ObjectID = detail.ObjectID.ToString();
                        model.FolderContentList.Add(content);
                    }
                }
                else //Yeni
                {

                    model.Description = "";
                    model.IsNew = true;
                    List<PatientFolderContentDefinition.GetPatientFolderContent_Class> patientFolderContentList = PatientFolderContentDefinition.GetPatientFolderContent(" WHERE ACTIVE = 1 ").ToList();
                    foreach (PatientFolderContentDefinition.GetPatientFolderContent_Class folderContent in patientFolderContentList)
                    {
                        FolderContent content = new FolderContent();
                        content.IsSelected = true;
                        content.ContentName = folderContent.FileName;
                        content.PageNumber = "";
                        content.ContentDefObjectID = folderContent.ObjectID.ToString();

                        model.FolderContentList.Add(content);
                    }
                }
            }

            return model;
        }

        [HttpPost]
        public void SaveArchiveDeliveryFormViewModel(ArchiveDeliveryFormViewModel model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (model.IsNew == true)
                {
                    ArchiveDeliveryForm archiveDeliveryForm = new ArchiveDeliveryForm(objectContext);
                    archiveDeliveryForm.SubepisodeID = new Guid(model.SubepisodeID);
                    archiveDeliveryForm.Description = model.Description;
                    if (model.SelectedDelivererUserID != null)
                    {
                        ResUser delivererUser = objectContext.GetObject<ResUser>(new Guid(model.SelectedDelivererUserID));
                        archiveDeliveryForm.Deliverer = delivererUser;
                    }
                    if (model.SelectedRecipientUserID != null)
                    {
                        ResUser recipientUser = objectContext.GetObject<ResUser>(new Guid(model.SelectedRecipientUserID));
                        archiveDeliveryForm.Recipient = recipientUser;
                    }
                    foreach (FolderContent content in model.FolderContentList)
                    {
                        ArchiveDeliveryFormDetails detail = new ArchiveDeliveryFormDetails(objectContext);
                        detail.ArchiveDeliveryForm = archiveDeliveryForm;
                        detail.IsSelected = content.IsSelected;
                        detail.PageNumber = content.PageNumber;
                        PatientFolderContentDefinition condentDef = objectContext.GetObject<PatientFolderContentDefinition>(new Guid(content.ContentDefObjectID));
                        detail.FolderContent = condentDef;
                    }

                }
                else
                {
                    ArchiveDeliveryForm archiveDeliveryForm = objectContext.GetObject<ArchiveDeliveryForm>(new Guid(model.ObjectID));
                    archiveDeliveryForm.Description = model.Description;
                    if (model.SelectedDelivererUserID != null)
                    {
                        ResUser delivererUser = objectContext.GetObject<ResUser>(new Guid(model.SelectedDelivererUserID));
                        archiveDeliveryForm.Deliverer = delivererUser;
                    }
                    if (model.SelectedRecipientUserID != null)
                    {
                        ResUser recipientUser = objectContext.GetObject<ResUser>(new Guid(model.SelectedRecipientUserID));
                        archiveDeliveryForm.Recipient = recipientUser;
                    }

                    foreach (FolderContent content in model.FolderContentList)
                    {
                        ArchiveDeliveryFormDetails detail = objectContext.GetObject<ArchiveDeliveryFormDetails>(new Guid(content.ObjectID));
                        detail.IsSelected = content.IsSelected;
                        detail.PageNumber = content.PageNumber;

                    }

                }
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class ArchiveDeliveryFormViewModel
    {
        public string ObjectID { get; set; }
        public string SubepisodeID { get; set; }
        public List<FolderContent> FolderContentList;
        public string Description { get; set; }
        public bool IsNew { get; set; }
        //Teslim alan ve veren eklenecek
        public List<UserObject> DeliverUserList;
        public List<UserObject> RecipientUserList;
        public string PatientNameSurname { get; set; }
        public string ProtocolNo { get; set; }
        public string ClinicName { get; set; }
        public string RoomNumber { get; set; }
        public string BedNumber { get; set; }
        public string DoctorName { get; set; }
        public string ClinicDate { get; set; }
        public string DischargeDate { get; set; }
        public string SelectedDelivererUserID { get; set; }
        public string SelectedRecipientUserID { get; set; }
    }

    public class FolderContent
    {
        public bool IsSelected { get; set; }
        public string ContentName { get; set; }
        public string PageNumber { get; set; }
        public string ContentDefObjectID { get; set; }
        public string ObjectID { get; set; }
    }
    public class UserObject
    {

        public string ObjectID { get; set; }
        public string Name { get; set; }

    }


}


