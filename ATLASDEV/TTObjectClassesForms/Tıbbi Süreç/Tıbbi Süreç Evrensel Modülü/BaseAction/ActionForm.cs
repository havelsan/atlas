
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class ActionForm : TTForm
    {
        protected override void PreScript()
        {
            #region ActionForm_PreScript
            base.PreScript();

            //            bool resourceControl = false;
            //            if(this._BaseAction is LaboratoryRequest || this._BaseAction is Pathology || this._BaseAction is Radiology
            //               || this._BaseAction is NuclearMedicine ||  this._BaseAction is Genetic)
            //            {
            //               if(!(((EpisodeAction)this._BaseAction).Episode.CurrentStateDefID == Episode.States.Open &&(this._BaseAction.CurrentStateDefID == LaboratoryRequest.States.Completed || this._BaseAction.CurrentStateDefID == Pathology.States.Report
            //                      || this._BaseAction.CurrentStateDefID == Radiology.States.Completed || this._BaseAction.CurrentStateDefID == NuclearMedicine.States.Reported
            //                      || this._BaseAction.CurrentStateDefID == Genetic.States.Completed))) 
            //                {
            //                    if (Common.CurrentUser != null && Common.CurrentUser.UserObject != null)
            //                    {
            //                        if(!Common.CurrentUser.IsSuperUser)
            //                        {
            //                            foreach(UserResource userResource in ((ResUser)Common.CurrentUser.UserObject).UserResources)
            //                            {
            //                                if (((EpisodeAction)this._BaseAction).Episode.PatientExaminations != null)
            //                                {
            //                                    if(((EpisodeAction)this._BaseAction).Episode.PatientExaminations.Count > 0)
            //                                    {
            //                                        foreach(PatientExamination pe in ((EpisodeAction)this._BaseAction).Episode.PatientExaminations)
            //                                        {
            //                                            if(pe.MasterResource.ObjectID == userResource.Resource.ObjectID)
            //                                                resourceControl = true;
            //                                        }
            //                                        
            //                                        foreach(SubEpisode se in ((EpisodeAction)this._BaseAction).Episode.SubEpisodes )
            //                                        {
            //                                            foreach(SubActionProcedure sep in se.SubActionProcedures)
            //                                            {
            //                                                if(sep is ConsultationProcedure)
            //                                                {
            //                                                    if(((SubactionProcedureFlowable)sep).MasterResource.ObjectID == userResource.Resource.ObjectID)
            //                                                        resourceControl = true;
            //                                                }
            //                                            }
            //                                        }
            //                                    }
            //                                    else
            //                                        resourceControl = true;
            //                                }
            //                                else
            //                                    resourceControl = true;
            //                            }
            //                            if(!resourceControl)
            //                                throw new TTUtils.TTException("Hastanın Muayene Olduğu Birime Bağlı Değilsiniz.\r\nBu İşlemi Başlatamazsınız !");
            //                        }
            //                    }
            //                }
            //            }
            #endregion ActionForm_PreScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region ActionForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);
            if (transDef != null)
            {
                if (transDef.AllAttributes.ContainsKey("ReasonOfRejectAttribute"))
                {
                    StringEntryForm frm = new StringEntryForm();
                    this._BaseAction.ReasonOfReject = frm.ShowAndGetStringForm("Red Sebebi");
                }
                if (transDef.ToStateDef.Status == StateStatusEnum.Cancelled)
                {
                    StringEntryForm frm = new StringEntryForm();
                    this._BaseAction.ReasonOfCancel = frm.ShowAndGetStringForm("İşlem İptal Sebebi");
                }
            }
            #endregion ActionForm_ClientSidePostScript

        }

        #region ActionForm_Methods
        //TODO Medula!
        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    base.OnClosing(e);

        //    if (!string.IsNullOrEmpty(_BaseAction.TempProvisionNo))
        //    {
        //        IBindingList provisions = _BaseAction.ObjectContext.QueryObjects(typeof(MedulaProvision).Name, "PROVISIONNO = '" + _BaseAction.TempProvisionNo + "'");
        //        if (provisions.Count == 0)
        //        {
        //            HastaKabulIslemleri.takipSilGirisDVO takipSilGirisDVO = new HastaKabulIslemleri.takipSilGirisDVO();
        //            takipSilGirisDVO.takipNo = _BaseAction.TempProvisionNo;
        //            takipSilGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
        //            HastaKabulIslemleri.takipSilCevapDVO response = HastaKabulIslemleri.WebMethods.hastaKabulIptalSync(Sites.SiteLocalHost, takipSilGirisDVO);
        //            if (response.sonucKodu != "0000")
        //                throw new TTUtils.TTException("Takip silinemedi : " + response.sonucMesaji);
        //            else
        //                TTVisual.InfoBox.Alert("İşlemde oluşan sorun nedeni ile Medula'dan alınan takip başarı ile iptal edildi", MessageIconEnum.InformationMessage);
        //        }
        //    }
        //}

        #endregion ActionForm_Methods

        #region ActionForm_ClientSideMethods
        public ResUser SelectUser(TTObjectContext context, ResSection userResource, UserTypeEnum userType, Boolean multiSelect)
        {
            List<UserTypeEnum> userTypeList = new List<UserTypeEnum>();
            userTypeList.Add(userType);
            if (userType == UserTypeEnum.Doctor)
                userTypeList.Add(UserTypeEnum.Dentist);
            IList<ResUser> userList = (IList<ResUser>)ResUser.GetByUserResourceAndUserTypes(context, userResource.ObjectID.ToString(), userTypeList);
            MultiSelectForm pMSForm = new MultiSelectForm();
            foreach (ResUser user in userList)
                pMSForm.AddMSItem(user.Name, user.ObjectID.ToString(), user);

            string sKey;
            if (TTObjectClasses.SystemParameter.GetParameterValue("ForceToSelectUser", "FALSE").ToUpper() == "TRUE")
                sKey = pMSForm.GetMSItem(this, userResource.Name.ToString() + " kaynağında işlemi gerçekleştirecek kullanıcıyı seçiniz", false, true, multiSelect, false, true, true);
            else
                sKey = pMSForm.GetMSItem(this, userResource.Name.ToString() + " kaynağında işlemi gerçekleştirecek kullanıcıyı seçiniz", false, true, multiSelect);
            if (string.IsNullOrEmpty(sKey))
            {
                return null;
            }
            else
            {
                return (ResUser)pMSForm.MSSelectedItemObject;
            }
        }

        public ResUser SelectQueueUser(TTObjectContext context, ExaminationQueueDefinition queueDef, Boolean multiSelect)
        {
            if (queueDef != null)
            {
                bool selectDoctor = true;
                if (queueDef.NotAllowToSelectDoctor.HasValue == true && queueDef.NotAllowToSelectDoctor.Value == true)
                    selectDoctor = false;
                if (selectDoctor)
                {
                    IList<Resource> resources = ExaminationQueueDefinition.GetWorkingResources(queueDef);
                    MultiSelectForm pMSForm = new MultiSelectForm();
                    foreach (Resource resource in resources)
                    {
                        if (resource is ResUser)
                        {
                            pMSForm.AddMSItem(resource.Name, resource.ObjectID.ToString(), resource);
                        }
                    }
                    string sKey;
                    if (TTObjectClasses.SystemParameter.GetParameterValue("ForceToSelectQueueUser", "FALSE").ToUpper() == "TRUE")
                        sKey = pMSForm.GetMSItem(this, queueDef.Name.ToString() + " kuyruğunda hastanın atanacağı doktoru seçiniz.", false, true, multiSelect, false, true, true);
                    else
                        sKey = pMSForm.GetMSItem(this, queueDef.Name.ToString() + " kuyruğunda hastanın atanacağı doktoru seçiniz.", false, true, multiSelect);
                    if (string.IsNullOrEmpty(sKey))
                    {
                        return null;
                    }
                    else
                    {
                        return (ResUser)pMSForm.MSSelectedItemObject;
                    }
                }
            }
            return null;
        }


        public void SetAuthorizedUserBySelecting(ResSection userResource, UserTypeEnum userType, Boolean multiSelect)
        {
            ResUser resUser = this.SelectUser(this._BaseAction.ObjectContext, userResource, userType, multiSelect);
            if (resUser == null)
            {
                throw new Exception(SystemMessage.GetMessage(1038));
            }
            else
            {
                AuthorizedUser authorizedUser = new AuthorizedUser(this._BaseAction.ObjectContext);
                authorizedUser.User = (ResUser)resUser;
                this._BaseAction.AuthorizedUsers.Add(authorizedUser);
            }
        }

        //public void SetAuthorizedUserBySelecting(ResSection userResource, UserTypeEnum userType, Boolean multiSelect, BaseAction firedAction)
        //{
        //    ResUser resUser = this.SelectUser(firedAction.ObjectContext, userResource, userType, multiSelect);
        //    if (resUser != null)
        //    {
        //        AuthorizedUser authorizedUser = new AuthorizedUser(firedAction.ObjectContext);
        //        authorizedUser.User = (ResUser)resUser;
        //        firedAction.AuthorizedUsers.Add(authorizedUser);
        //    }
        //}


        public ExaminationQueueDefinition SelectQueue(TTObjectContext context, ResSection resource, Boolean multiSelect)
        {
            IList<ExaminationQueueDefinition> appQueueDefinitionList = (IList<ExaminationQueueDefinition>)ExaminationQueueDefinition.GetQueueByResource(context, resource.ObjectID.ToString());


            BindingList<ExaminationQueueItem> completedItems;
            MultiSelectForm pMSForm = new MultiSelectForm();
            foreach (ExaminationQueueDefinition appQueueDefinition in appQueueDefinitionList)
            {
                completedItems = ExaminationQueueItem.GetCompletedItemsByQueueAndDate(context, appQueueDefinition.ObjectID, Common.RecTime().Date, Common.RecTime().Date.AddDays(1));
                pMSForm.AddMSItem(appQueueDefinition.Name + " (Sırada " + appQueueDefinition.CurrentItemsCount.ToString() + " Hasta, Toplam " + (appQueueDefinition.CurrentItemsCount + completedItems.Count).ToString() + " Hasta)", appQueueDefinition.ObjectID.ToString(), appQueueDefinition);
            }

            string sKey;
            if (TTObjectClasses.SystemParameter.GetParameterValue("ForceToSelectQueue", "TRUE").ToUpper() == "TRUE" && !(this is PatientAdmissionForm))
                sKey = pMSForm.GetMSItem(this, resource.Name.ToString() + " kaynağında hastanın çağırılacağı kuyruğu seçiniz.", false, true, multiSelect, false, true, true);
            else
                sKey = pMSForm.GetMSItem(this, resource.Name.ToString() + " kaynağında hastanın çağırılacağı kuyruğu seçiniz.", false, true, multiSelect);
            if (string.IsNullOrEmpty(sKey))
            {
                return null;
            }
            else
            {
                return (ExaminationQueueDefinition)pMSForm.MSSelectedItemObject;
            }
        }


        public void SetAuthorizedUserByQueueUser(ResUser queueUser, BaseAction firedAction)
        {
            if (queueUser != null)
            {
                AuthorizedUser authorizedUser = new AuthorizedUser(firedAction.ObjectContext);
                authorizedUser.User = (ResUser)queueUser;
                firedAction.AuthorizedUsers.Add(authorizedUser);
            }
        }

        public Appointment SelectAppointment(TTObjectContext context, Patient patient, Boolean multiSelect)
        {
            DateTime recDate = Common.RecTime().Date;
            IList<Appointment> patientAppList = Appointment.GetPatientAdmissionAppointmentsByDate(context, patient.ObjectID, recDate, recDate.AddDays(1));
            MultiSelectForm pMSForm = new MultiSelectForm();
            foreach (Appointment app in patientAppList)
            {
                if (app.Resource != null)
                {
                    if (app.MasterResource != null)
                        pMSForm.AddMSItem(app.MasterResource.Name + " - " + app.Resource.Name, app.ObjectID.ToString(), app);
                    else
                        pMSForm.AddMSItem(app.Resource.Name, app.ObjectID.ToString(), app);
                }
                else
                    pMSForm.AddMSItem(app.MasterResource.Name, app.ObjectID.ToString(), app);
            }
            string sKey;
            if (TTObjectClasses.SystemParameter.GetParameterValue("ForceToSelectAppointment", "FALSE").ToUpper() == "TRUE")
                sKey = pMSForm.GetMSItem(this, "Hastanın aşağıdaki kaynaklarda bugün randevusu var. Hasta, randevusuna geldiyse lütfen seçiniz.", false, true, multiSelect, false, true, true);
            else
                sKey = pMSForm.GetMSItem(this, "Hastanın aşağıdaki kaynaklarda bugün randevusu var. Hasta, randevusuna geldiyse lütfen seçiniz.", false, true, multiSelect);
            if (string.IsNullOrEmpty(sKey))
            {
                return null;
            }
            else
            {
                return (Appointment)pMSForm.MSSelectedItemObject;
            }
        }

        


        public static MainStoreDefinition SelectAllMainStoreDefinition(System.Windows.Forms.IWin32Window parent)
        {
            MainStoreDefinition mainStoreDefinition = null;
            TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
            BindingList<MainStoreDefinition> mainStores = MainStoreDefinition.GetAllMainStores(readOnlyObjectContext);

            if (mainStores.Count == 1)
            {
                mainStoreDefinition = mainStores[0];
            }
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (MainStoreDefinition mainStore in mainStores)
                    mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.ToString(), mainStore);

                string mkey = mSelectForm.GetMSItem(parent, "İlgili Ana Depoyu Seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                    throw new Exception(SystemMessage.GetMessage(371));
                mainStoreDefinition = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
            }
            return mainStoreDefinition;
        }

        #endregion ActionForm_ClientSideMethods
    }
}