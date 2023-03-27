
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
    /// <summary>
    /// Randevu
    /// </summary>
    public partial class RadiologyTestAppointmentForm : SubactionProcedureAppointmentForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region RadiologyTestAppointmentForm_PreScript
    //base.PreScript();
            
            this.DropStateButton(RadiologyTest.States.AdmissionAppointment);

            this.AppointmentInformation.Text = string.Empty;
            //ITTTextBox pDescriptionBox = AppointmentInformation;
            //pDescriptionBox.ScrollBars = ScrollBars.Vertical;

            string appDesc = String.Empty;

            Patient _patient = this._RadiologyTest.Episode.Patient;

            if (this._RadiologyTest.CurrentStateDefID == RadiologyTest.States.Appointment)
            {
                appDesc = GetFullAppointmentDescription(this._RadiologyTest);
            }
            else if (this._RadiologyTest.CurrentStateDefID == RadiologyTest.States.AdmissionAppointment)
            {
                string injectionStr = "WHERE INITIALOBJECTID = '" + this._RadiologyTest.ObjectID + "'";
                IList appList = Appointment.GetByInjection(this._RadiologyTest.ObjectContext, injectionStr);
                if (appList.Count > 0)
                {
                    appDesc = BaseAction.GetFullAppointmentDescription(((TTObjectClasses.Appointment)appList[0]).Action);
                }
            }
            else
            {
                appDesc = GetFullCompletedAppointmentDescription(this._RadiologyTest);
            }

            StringBuilder builderDesc = new StringBuilder();
            builderDesc.Append(appDesc);
            builderDesc.Append("Rütbe : ");
         /*   if (_patient.Rank != null)
                builderDesc.Append(_patient.Rank.Name);*/
            builderDesc.Append("\r\nYaşı : ");
            //if (_patient.Age.Value != null)
                builderDesc.Append(_patient.Age.Value.ToString());
            builderDesc.Append("\r\nAçıklama : ");
            builderDesc.Append(this._RadiologyTest.Description);

            AppointmentInformation.Text = builderDesc.ToString();

            //this.cmdOK.Visible = false;
#endregion RadiologyTestAppointmentForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestAppointmentForm_PostScript
    base.PostScript(transDef);
#endregion RadiologyTestAppointmentForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestAppointmentForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);

            BindingList<Appointment> myNewAppointments = new BindingList<Appointment>();
            myNewAppointments = MyNewAppointments(this._RadiologyTest.ObjectID);


            if (myNewAppointments.Count > 0)
            {
                ResRadiologyEquipment equipment = myNewAppointments[0].Resource as ResRadiologyEquipment;
                if (equipment != null)
                {
                    this._RadiologyTest.Equipment = equipment;
                }
            }

            if(transDef !=null)
            {
                if (transDef.ToStateDefID == RadiologyTest.States.Procedure)
                {
                    foreach (Appointment app in myNewAppointments)
                    {
                        if (Convert.ToDateTime(_RadiologyTest.Episode.OpeningDate).AddDays(10) < TTObjectDefManager.ServerTime
                            && _RadiologyTest.SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu
                            && _RadiologyTest.Episode.PatientStatus.Value != PatientStatusEnum.Inpatient && SubEpisode.IsSGKSubEpisode(_RadiologyTest.SubEpisode)) ///yatan hasta ve sağlık kurulunda kabul randevusu oluşmayacak
                        {
                            
                            Guid savePointGuid = this._RadiologyTest.ObjectContext.BeginSavePoint();
                            Episode episodeWithSameSpeciality = PatientAdmission.ReturnEpisodeWithSameSpecialityInTenDays(this._RadiologyTest.SubEpisode.PatientAdmission,this._RadiologyTest.Episode.Patient);
                            if(episodeWithSameSpeciality != null)
                            {
                                string msg = "Hastanın 10 gün içerisinde " +  episodeWithSameSpeciality.MainSpeciality.Code +  " branşından " + episodeWithSameSpeciality.HospitalProtocolNo.ToString() + " protokol numarasına sahip vakası bulunmaktadır. Radyoloji işlemine bu vaka üzerinden devam edilecektir.";
                                InfoBox.Alert(msg, MessageIconEnum.InformationMessage);
                                bool boolCloneRadiology = false;
                                try
                                {
                                    SubEpisode subEpisode = null;
                                    if (episodeWithSameSpeciality.SubEpisodes.Count == 1)
                                        subEpisode = episodeWithSameSpeciality.SubEpisodes[0];
                                    else
                                    {
                                        foreach(PatientExamination pe in episodeWithSameSpeciality.PatientExaminations)
                                        {
                                            if(pe.CurrentStateDef.Status != StateStatusEnum.Cancelled && pe.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                                            {
                                                if(pe.SubEpisode != null)
                                                    subEpisode = pe.SubEpisode;
                                            }
                                        }
                                    }
                                    
                                    RadiologyTest originalRadiologyTest = this._RadiologyTest;
                                    Radiology originalRadiology = this._RadiologyTest.Radiology;
                                    RadiologyTest cloneRadiologyTest = (RadiologyTest)originalRadiologyTest.Clone();
                                    Radiology cloneRadiology = null;
                                    IList radList = Radiology.GetByEpisodeAndClonedObjectID(this._RadiologyTest.ObjectContext,episodeWithSameSpeciality.ObjectID,originalRadiology.ObjectID,null);
                                    if(radList.Count == 0)
                                    {
                                        boolCloneRadiology = true;
                                        cloneRadiology = (Radiology)originalRadiology.Clone();
                                        cloneRadiology.ClonedObjectID = (Guid?)originalRadiology.ObjectID;
                                    }
                                    else
                                    {
                                        boolCloneRadiology = false;
                                        cloneRadiology = (Radiology)radList[0];
                                    }
                                    
                                    TTSequence.allowSetSequenceValue = true;
                                    cloneRadiologyTest.ID.SetSequenceValue(0);
                                    cloneRadiologyTest.ID.GetNextValue();
                                    cloneRadiologyTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
                                    if(subEpisode != null)
                                        cloneRadiologyTest.SubEpisode = subEpisode;
                                    cloneRadiologyTest.Episode = episodeWithSameSpeciality;
                                    cloneRadiologyTest.Radiology = cloneRadiology;
                                    if(boolCloneRadiology)
                                    {
                                        TTSequence.allowSetSequenceValue = true;
                                        cloneRadiology.ID.SetSequenceValue(0);
                                        cloneRadiology.ID.GetNextValue();
                                        cloneRadiology.Episode = episodeWithSameSpeciality;
                                        if (subEpisode != null)
                                        {
                                            cloneRadiology.SubEpisode = subEpisode;
                                            cloneRadiology.PatientAdmission = subEpisode.PatientAdmission;
                                        }
                                    }
                                    _RadiologyTest.Description += "\r\n" + msg;
                                    _RadiologyTest.CurrentStateDefID = RadiologyTest.States.AdmissionAppointment;
                                    this._RadiologyTest.ObjectContext.Update();
                                }
                                catch(Exception ex)
                                {
                                    if(this._RadiologyTest.ObjectContext.HasSavePoint(savePointGuid))
                                        this._RadiologyTest.ObjectContext.RollbackSavePoint(savePointGuid);
                                    throw ex;
                                }
                            }
                            else
                            {
                                try
                                {
                                    InfoBox.Alert("Hastanın kabul tarihi üzerinden 10 gün geçtiği için, yeni hasta kabul işlemleri üzerinden devam edilecektir.", MessageIconEnum.InformationMessage);
                                    
                                    Patient selectedPatient =  this._RadiologyTest.Episode.Patient;
                                    AdmissionAppointment admissionAppointment = (AdmissionAppointment)this._RadiologyTest.ObjectContext.CreateObject("AdmissionAppointment");
                                    admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.New;
                                    admissionAppointment.SelectedPatient = selectedPatient;
                                    admissionAppointment.PatientName = _RadiologyTest.Episode.Patient.Name;
                                    admissionAppointment.PatientSurname = _RadiologyTest.Episode.Patient.Surname;
                                    admissionAppointment.SelectedPatientFiltered = _RadiologyTest.Episode.Patient.FullName;
                                    admissionAppointment.AppointmentDefinition = app.AppointmentDefinition;
                                    if (app.AppointmentDefinition.GiveToMaster == true)
                                        app.MasterResource = null;
                                    else
                                        app.MasterResource = _RadiologyTest.EpisodeAction.MasterResource;
                                    app.Action = (BaseAction)admissionAppointment;
                                    app.InitialObjectID = _RadiologyTest.ObjectID.ToString();
                                    admissionAppointment.MasterResource = app.MasterResource;
                                    admissionAppointment.WorkListDate = Convert.ToDateTime(app.StartTime);
                                    this._RadiologyTest.ObjectContext.Update();
                                    admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.Appointment;
                                    this._RadiologyTest.ObjectContext.Update();
                                    _RadiologyTest.CurrentStateDefID = RadiologyTest.States.AdmissionAppointment;

                                    //TODO : GetEditForm cagrıldıgı ıcın asagıdakı bolum kapatıldı. Daha sonra baska bır yontemle cozumlenebılır.
                                    //if (!selectedPatient.IsAllRequiredPropertiesExists(false))//true ise eksik bilgi yoktur kullanıcının seçimine bırakılabilir değilse
                                    //{
                                    //    TTVisual.TTForm frm = TTVisual.TTForm.GetEditForm(selectedPatient);
                                    //    TTFormDef frmDef = TTObjectDefManager.Instance.ObjectDefs["Patient"].FormDefs["PatientForm"];
                                    //    bool updatePatient = false;
                                    //    if(TTUser.CurrentUser.HasRight(frmDef, selectedPatient, (int)TTSecurityAuthority.RightsEnum.UpdateForm))
                                    //    {
                                    //        updatePatient=ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Hasta Kayıt Düzeltme", "Hastanın kimlik bilgileri eksik.\r\n\r\nHastanın eksik kimlik bilgilerini düzeltmek ister misiniz?") == "E";
                                    //        if(updatePatient)
                                    //        {
                                    //            PatientForm frmPatient = new PatientForm();
                                    //            if (frmPatient.ShowEdit(this, selectedPatient) == DialogResult.Cancel)
                                    //                throw new Exception("Hastanın eksik kimlik bilgileri tamamlanmadan hasta kabul yapılamaz.");
                                    //        }
                                    //        else
                                    //            throw new Exception("Hastanın eksik kimlik bilgileri tamamlanmadan hasta kabul yapılamaz.");
                                    //    }
                                    //    else
                                    //        throw new Exception("Hastanın eksik kimlik bilgileri tamamlanmadan hasta kabul yapılamaz.");
                                    //}
                                    
                                    
                                    PatientAdmission pa = null;
                                    //AdmissionApp nin null gönderilmesi kontrol edilip test edilecek
                                    pa = PatientAdmissionForm.FireNewPatientAdmission(selectedPatient,  null, null, admissionAppointment);
                                    if (pa == null)
                                        throw new Exception("Hasta kabul yapmadan işleme devam edemezsiniz.");

                                    admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.Completed;
                                    app.CurrentStateDefID = Appointment.States.Cancelled;
                                    this._RadiologyTest.ObjectContext.Update();
                                }
                                catch(Exception ex)
                                {
                                    if(this._RadiologyTest.ObjectContext.HasSavePoint(savePointGuid))
                                        this._RadiologyTest.ObjectContext.RollbackSavePoint(savePointGuid);
                                    throw ex;
                                }
                            }
                        }
                    }
                }
            }
#endregion RadiologyTestAppointmentForm_ClientSidePostScript

        }

#region RadiologyTestAppointmentForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == RadiologyTest.States.Procedure)
                {
                    Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                    //if(Sites.SiteXXXXXX06XXXXXX == siteID )
                    //{
                    string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
                    if (sysparam == "TRUE")
                    {
                        base.AfterContextSavedScript(transDef);
                        List<Guid> appIDs = new List<Guid>();
                        appIDs.Add(this._RadiologyTest.ObjectID);

                        TTObjectContext objectContext = new TTObjectContext(false);
                        RadiologyTest radTest = (RadiologyTest)objectContext.GetObject(this._RadiologyTest.ObjectID, "RADIOLOGYTEST");

                        if (radTest.IsMessageInPACS == true)
                        {
                            try
                            {
                                //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTcpClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01XO", "PACS");
                                //radTest.IsMessageInPACS = true;
                            }
                            catch
                            {
                                radTest.IsMessageInPACS = false;
                                throw;
                            }
                            finally
                            {
                                objectContext.Save();
                            }
                        }
                        else
                        {
                            try
                            {
                                //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTcpClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01", "PACS");
                                //radTest.IsMessageInPACS = true;
                                //radTest.Radiology.RequestDoctor.SendUserToPACS();
                            }
                            catch
                            {
                                radTest.IsMessageInPACS = false;
                                throw;
                            }
                            finally
                            {
                                objectContext.Save();
                            }
                        }
                    }
                    //}
                }
            }
            base.AfterContextSavedScript(transDef);
        }
        
#endregion RadiologyTestAppointmentForm_Methods
    }
}