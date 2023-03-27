
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
    public partial class AdmissionAppointmentFormEx : ActionForm
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
#region AdmissionAppointmentFormEx_PreScript
            if (this._AdmissionAppointment.CurrentStateDefID == AdmissionAppointment.States.Appointment)
            {
                AppointmentInformation.Text= BaseAction.GetFullAppointmentDescription(this._AdmissionAppointment);
            }
            else
            {
                AppointmentInformation.Text = BaseAction.GetFullCompletedAppointmentDescription(this._AdmissionAppointment);
            }
            // TODO PnlButton!
            //this.cmdOK.Visible = false;
#endregion AdmissionAppointmentFormEx_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AdmissionAppointmentFormEx_PostScript
    if(transDef!=null)
            {

                if(transDef.ToStateDefID==AdmissionAppointment.States.Completed)
                {
                    Guid savePointGuid = this._AdmissionAppointment.ObjectContext.BeginSavePoint();
                    Episode episodeWithSameSpeciality = AdmissionAppointment.CheckHasSameSpecialityAdmissionInTenDays(this._AdmissionAppointment);
                    if (episodeWithSameSpeciality != null)
                    {
                        string msg = "Hastanın 10 gün içerisinde " + episodeWithSameSpeciality.MainSpeciality.Code + " branşından " + episodeWithSameSpeciality.HospitalProtocolNo.ToString() + " protokol numarasına sahip vakası bulunmaktadır.Bu vakaya kontrol muayenesi oluşturularak devam edilecektir.";
                        TTVisual.InfoBox.Alert(msg);

                        try
                        {
                            SubEpisode subEpisode = null;
                            if (episodeWithSameSpeciality.SubEpisodes.Count == 1)
                                subEpisode = episodeWithSameSpeciality.SubEpisodes[0];
                            else
                            {
                                foreach (PatientExamination pe in episodeWithSameSpeciality.PatientExaminations)
                                {
                                    if (pe.CurrentStateDef.Status != StateStatusEnum.Cancelled && pe.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                                    {
                                        if (pe.SubEpisode != null)
                                            subEpisode = pe.SubEpisode;
                                    }
                                }
                            }

                            FollowUpExamination newFollowUpExamination = new FollowUpExamination(this._AdmissionAppointment.ObjectContext);
                            newFollowUpExamination.ID.SetSequenceValue(0);
                            //newFollowUpExamination.ID.GetNextValue();
                            newFollowUpExamination.MasterAction = this._AdmissionAppointment;
                            foreach (Appointment app in BaseAction.GetMyNewAppointments(this._AdmissionAppointment))
                            {
                                if (app.Resource is ResUser)
                                {
                                    newFollowUpExamination.ProcedureDoctor = (ResUser)app.Resource;
                                    break;
                                }
                            }
                            newFollowUpExamination.Episode = episodeWithSameSpeciality;
                            newFollowUpExamination.SubEpisode = subEpisode;
                            newFollowUpExamination.PatientAdmission = subEpisode.PatientAdmission;
                            newFollowUpExamination.CurrentStateDefID = FollowUpExamination.States.New;
                            if(this._AdmissionAppointment.MasterResource is ResSection)
                                 newFollowUpExamination.MasterResource = (ResSection)this._AdmissionAppointment.MasterResource;
                            this._AdmissionAppointment.ObjectContext.Update();
                            

                        }
                        catch (Exception ex)
                        {
                            if (this._AdmissionAppointment.ObjectContext.HasSavePoint(savePointGuid))
                                this._AdmissionAppointment.ObjectContext.RollbackSavePoint(savePointGuid);
                            throw ex;
                        }
                    }

                }
                base.PostScript(transDef);
            }
#endregion AdmissionAppointmentFormEx_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region AdmissionAppointmentFormEx_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef.ToStateDefID==AdmissionAppointment.States.Cancelled)
            {
                string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Randevu İptali","Randevu(lar) iptal edilecek. Devam etmek istediğinize emin misiniz?",2);
                if (result == "H")
                    throw new Exception("İptalden vazgeçildi.");
            }
            
            if(transDef.ToStateDefID==AdmissionAppointment.States.Completed)
            {
                foreach(Appointment appointment in BaseAction.GetMyNewAppointments(this._AdmissionAppointment))
                {
                    if(Convert.ToDateTime(appointment.AppDate).Date > DateTime.Now.Date)
                        throw new Exception("Randevunun günü gelmeden hasta kabül yapılamaz.");
                }
                
                Episode episodeWithSameSpeciality = AdmissionAppointment.CheckHasSameSpecialityAdmissionInTenDays(this._AdmissionAppointment);
                if (episodeWithSameSpeciality == null)
                {
                     if (this._AdmissionAppointment.SelectedPatient != null)
                        {
                            Patient selectedPatient = this._AdmissionAppointment.SelectedPatient;

                            //TODO : GetEditForm cagrıldıgı ıcın asagıdakı bolum kapatıldı. Daha sonra baska bır yontemle cozumlenebılır.
                            //if (!selectedPatient.IsAllRequiredPropertiesExists(false))//true ise eksik bilgi yoktur kullanıcının seçimine bırakılabilir değilse
                            //{
                            //    TTVisual.TTForm frm = TTVisual.TTForm.GetEditForm(selectedPatient);
                            //    TTFormDef frmDef = TTObjectDefManager.Instance.ObjectDefs["Patient"].FormDefs["PatientForm"];
                            //    bool updatePatient = false;
                            //    if (TTUser.CurrentUser.HasRight(frmDef, selectedPatient, (int)TTSecurityAuthority.RightsEnum.UpdateForm))
                            //    {
                            //        updatePatient = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Hasta Kayıt Düzeltme", "Hastanın kimlik bilgileri eksik.\r\n\r\nHastanın eksik kimlik bilgilerini düzeltmek ister misiniz?") == "E";
                            //        if (updatePatient)
                            //        {
                            //            PatientForm frmPatient = new PatientForm();
                            //            if (frmPatient.ShowEdit(this, selectedPatient) == DialogResult.Cancel)
                            //                throw new Exception("Hastanın eksik kimlik bilgileri tamamlanmadan hasta kabül yapılamaz.");
                            //        }
                            //        else
                            //            throw new Exception("Hastanın eksik kimlik bilgileri tamamlanmadan hasta kabül yapılamaz.");
                            //    }
                            //    else
                            //        throw new Exception("Hastanın eksik kimlik bilgileri tamamlanmadan hasta kabül yapılamaz.");
                            //}
                            
                        
                            //                        SpecialityDefinition examinationSpeciality = this._AdmissionAppointment.CheckHasSameSpecialityAdmissionInTenDays();
                            //                        if(examinationSpeciality == null)
                            //                        {
                            PatientAdmission pa = null;

                            //PatientForm.FireNewPatientAdmission methoduna cagrılacak. Patient objesy yenı ATLAS a tasındıgı zaman. 
                            pa = PatientAdmissionForm.FireNewPatientAdmission(selectedPatient,null, null, this._AdmissionAppointment);
                            if (pa == null)
                                throw new Exception("Hasta kabul yapmadan işleme devam edemezsiniz.");
                            //                        }
                            //                        else
                            //                        {
                            //                            MessageBox.Show("Hastanın, 10 gün içinde '" + examinationSpeciality.Name + "' uzmanlık dalına yapılmış bir kabulü zaten mevcut. Yeni hasta kabul başlatılmayacaktır.","Uyarı", MessageBoxButtons.OK,MessageBoxIcon.Information);
                            //                        }
                        }
                        else
                        {
                            Patient patient = this.CreatePatient();
                            if (this._AdmissionAppointment.PatientAdmission != null && this._AdmissionAppointment.PatientAdmission.Count > 0)
                            {
                                foreach (Appointment appointment in this._AdmissionAppointment.Appointments)
                                {
                                    if (appointment.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        appointment.Patient = patient;
                                }

                                //this._AdmissionAppointment.Update();
                                //this._AdmissionAppointment.ObjectContext.Update();
                                //this._AdmissionAppointment.SelectedPatient = patient;
                                patient.MyAdmissionAppointment = null;
                            }
                            else
                                throw new Exception("Hasta kabul yapmadan işleme devam edemezsiniz.");
                        }
                    }
                
            }
#endregion AdmissionAppointmentFormEx_ClientSidePostScript

        }

#region AdmissionAppointmentFormEx_Methods
        public Patient CreatePatient()
        {
            Patient appPatient=null;
            Guid savePointGuid= this._AdmissionAppointment.ObjectContext.BeginSavePoint();
            try
            {
                Patient patient = new Patient(this._AdmissionAppointment.ObjectContext);
                patient.Name=this._AdmissionAppointment.PatientName;
                patient.Surname=this._AdmissionAppointment.PatientSurname;
                patient.MyAdmissionAppointment=this._AdmissionAppointment;
                
                //TODO ShowEdit!
                //TTFormClasses.PatientForm patientForm= new PatientForm();
                ////patientForm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
                ////patient.Update();
                //DialogResult dialogResult= DialogResult.OK;
                //try{
                //    dialogResult=patientForm.ShowEdit(this.FindForm(),patient);
                //}
                //catch(Exception ex)
                //{
                //    throw;// InfoBox.Show(ex.ToString());
                //}
                //if(dialogResult!= DialogResult.OK && patient.ChangedPatient==null)
                //{
                //    throw new Exception("Hasta kayıt yapılması zorunludur.");
                //}
                if (patient.ChangedPatient==null)
                    appPatient=patient;
                else{
                    appPatient=patient.ChangedPatient;
                    this._AdmissionAppointment.ObjectContext.RollbackSavePoint(savePointGuid);
                }
                //                appPatient.OpenPatientInfoForm=true;
                //                this.OnObjectUpdated(appPatient);
                return appPatient;
            }
            catch (Exception ex)
            {
                this._AdmissionAppointment.ObjectContext.RollbackSavePoint(savePointGuid);
                throw;// new Exception(ex.ToString());
            }
            
        }      
        
        //        public PatientAdmission FirePatientAdmission(Patient patient)
        //        {
        //            Guid savePointGuid= patient.ObjectContext.BeginSavePoint();
        //            try
        //            {
//
        //                string objectDefName="";
        //                if (patient.UnIdentified==true)
        //                {
        //                    objectDefName="PA_EMERGENCY";
        //                }
        //                else
        //                {
        //                    string PADefDescription="";
        //                    TTObjectDef objDef;
        //                    SortedList<object,object> patientGroupList = new SortedList<object,object>();
        //                    SortedList<object,object> selectedMSItems = new SortedList<object,object>();
//
        //                    TTObjectDef patientAdmissionDef = TTObjectDefManager.Instance.ObjectDefs["PatientAdmission"];
        //                    foreach( TTObjectDef PADef in TTObjectDefManager.Instance.ObjectDefs)
        //                    {
        //                        if (PADef.BaseObjectDef!= null)
        //                        {
        //                            if(PADef.BaseObjectDef.Equals(patientAdmissionDef))
        //                            {
        //                                if (PADef.Description==null)
        //                                {
        //                                    PADefDescription=PADef.Name;
        //                                }
        //                                else
        //                                {
        //                                    PADefDescription=PADef.Description;
        //                                }
        //                                if (!(patientGroupList.ContainsValue((object)PADef) || patientGroupList.ContainsKey((object)PADefDescription)))
        //                                {
        //                                    if(PADef.IsOfType(typeof(PA_Emergency).Name.ToUpperInvariant())==false)
        //                                    {
        //                                        patientGroupList.Add(PADefDescription,(object)PADef);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
//
        //                    selectedMSItems=Common.GetS electedMSItemList(patientGroupList,false,"Hasta Grupları");
        //                    if (selectedMSItems.Count<1)
        //                    {
        //                        throw new Exception("Hasta Grubunu seçmediniz");
        //                    }
//
        //                    objDef=(TTObjectDef)selectedMSItems.Values[0];
//
        //                    if (objDef.IsOfType(typeof(PatientAdmission).Name.ToUpperInvariant()) == false)
        //                    {
        //                        throw new Exception(objDef.Name + " Hasta Kabul İşlemi değildir.");
        //                    }
        //                    objectDefName=objDef.Name;
        //                }
        //                ////hasta kabul Fire etme kısmı
        //                PatientAdmission firedAction = (PatientAdmission)patient.ObjectContext.CreateObject(objectDefName);
        //                BindingList<TTObjectStateDef> states = (BindingList<TTObjectStateDef>)((ITTObject)firedAction).GetNextStateDefs();
        //                if (states.Count > 0)
        //                {
        //                    firedAction.CurrentStateDef = (TTObjectStateDef)states[0];
        //                }
//
        //                firedAction.ActionDate = DateTime.Now;
        //                //firedAction.Cancelled = false;//kaldirildi...YY
        //                firedAction.AdmissionAppointment=this._AdmissionAppointment;
        //                firedAction.Patient=patient;
        //                firedAction.ReasonForAdmission=this._AdmissionAppointment.AppointmentDefinition.ReasonForAdmission;
//
        //                TTForm frm = TTForm.GetE ditForm(firedAction);
        //                DialogResult result = DialogResult.None;
        //                if (frm == null)
        //                {
        //                    InfoBox.Sho w(firedAction.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından hasta kabul işlemi açılamamaktadır");
        //                }
        //                else
        //                {
        //                    result = frm.ShowEdit(this,firedAction);
        //                }
//
        //                if(result != DialogResult.OK)
        //                {
        //                    throw new Exception("Hasta Kabul yapılması zorunludur.");
        //                }
//
//
        //                return firedAction;
        //            }
        //            catch (Exception ex)
        //            {
        //                patient.ObjectContext.RollbackSavePoint(savePointGuid);
        //                throw new Exception(ex.ToString());
//
        //            }
//
        //        }
        
        void ShowAction_ObjectUpdated(TTObject ttObject)
        {
            ttObject.Update();
        }
        
#endregion AdmissionAppointmentFormEx_Methods
    }
}