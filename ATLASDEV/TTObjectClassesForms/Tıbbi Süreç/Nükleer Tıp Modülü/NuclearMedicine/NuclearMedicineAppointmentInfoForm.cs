
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
    /// Randevu Bilgileri
    /// </summary>
    public partial class NuclearMedicineAppointmentInfoForm : AppointmentFormBase
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
#region NuclearMedicineAppointmentInfoForm_PreScript
    base.PreScript();
            
            this.DropStateButton(NuclearMedicine.States.AdmissionAppointment);
            string appDesc = String.Empty;

            if(this._NuclearMedicine.CurrentStateDefID == NuclearMedicine.States.AppointmentInfo)
            {
                appDesc = BaseAction.GetFullAppointmentDescription(this._NuclearMedicine);
                
                foreach (NuclearMedicineGridPharmDefinition radPharmMat in ((NuclearMedicineTestDefinition)this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject).PharmMaterials)
                {
                    if (radPharmMat.Material != null)
                    {
                        NucMedRadPharmMatGrid newMaterial = new NucMedRadPharmMatGrid(this._NuclearMedicine.ObjectContext);
                        newMaterial.Material = radPharmMat.Material;
                        newMaterial.EpisodeAction = this._NuclearMedicine;
                        if ((NucMedRadioPharmMatDef)radPharmMat.Material != null)
                        {
                            foreach (MaterialBarcodeLevel level in ((NucMedRadioPharmMatDef)radPharmMat.Material).MaterialBarcodeLevels)
                            {
                                newMaterial.Note = level.PackageAmount.ToString();
                                newMaterial.Amount = level.PackageAmount;
                                break;
                            }
                        }
                    }
                }
            }
            else if(this._NuclearMedicine.CurrentStateDefID == NuclearMedicine.States.AdmissionAppointment)
            {
                string injectionStr = "WHERE INITIALOBJECTID = '" +this._NuclearMedicine.ObjectID + "'";
                IList appList = Appointment.GetByInjection(this._NuclearMedicine.ObjectContext, injectionStr);
                if(appList.Count > 0)
                {
                    appDesc = BaseAction.GetFullAppointmentDescription(((TTObjectClasses.Appointment)appList[0]).Action);
                }
            }
            else
            {
                appDesc = BaseAction.GetFullCompletedAppointmentDescription(this._NuclearMedicine);
            }
            
            if (this._NuclearMedicine.NuclearMedicineTests.Count > 0)
            {
                if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject != null)
                {
                    nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
                }
            }
            
            StringBuilder builderDesc = new StringBuilder();
            
            builderDesc.Append(appDesc);
            builderDesc.Append("\r\nAçıklama : ");
            builderDesc.Append(this._NuclearMedicine.DescriptionForWorkList);

            pDescriptionBox.Text = builderDesc.ToString();

            foreach (ITTTabPage tabPage in TABNuclearMedicine.TabPages)
            {
                if (tabPage.Visible == false)
                    TABNuclearMedicine.HideTabPage(tabPage);
            }
#endregion NuclearMedicineAppointmentInfoForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region NuclearMedicineAppointmentInfoForm_PostScript
    base.PostScript(transDef);
#endregion NuclearMedicineAppointmentInfoForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region NuclearMedicineAppointmentInfoForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);

            BindingList<Appointment> myCompletedAppointments = new BindingList<Appointment>();
            myCompletedAppointments = EpisodeAction.MyCompletedAppointments(this._NuclearMedicine.ObjectID);

            if (myCompletedAppointments.Count > 0)
            {
                ResNuclearMedicineEquipment equipment = myCompletedAppointments[0].Resource as ResNuclearMedicineEquipment;

                if (equipment != null)
                {
                    this._NuclearMedicine.NuclearMedicineTests[0].Equipment = equipment;
                }
            }
            
            if(transDef !=null)
            {
                if (transDef.ToStateDefID == NuclearMedicine.States.Preparation)
                {
                    foreach (Appointment app in EpisodeAction.GetMyNewAppointments(_NuclearMedicine.ObjectID))
                    {
                        if (Convert.ToDateTime(_NuclearMedicine.Episode.OpeningDate).AddDays(10) < TTObjectDefManager.ServerTime
                            && _NuclearMedicine.SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu
                            && _NuclearMedicine.Episode.PatientStatus.Value != PatientStatusEnum.Inpatient && _NuclearMedicine.SubEpisode.PatientAdmission.IsSGKPatientAdmission) ///yatan hasta ve sağlık kurulunda kabul randevusu oluşmayacak
                        {
                            
                            Guid savePointGuid = this._NuclearMedicine.ObjectContext.BeginSavePoint();
                            Episode episodeWithSameSpeciality = PatientAdmission.ReturnEpisodeWithSameSpecialityInTenDays(this._NuclearMedicine.SubEpisode.PatientAdmission,this._NuclearMedicine.Episode.Patient);
                            if(episodeWithSameSpeciality != null)
                            {
                                string msg = "Hastanın 10 gün içerisinde " +  episodeWithSameSpeciality.MainSpeciality.Code +  " branşından " + episodeWithSameSpeciality.HospitalProtocolNo.ToString() + " protokol numarasına sahip vakası bulunmaktadır. Nükleer Tıp işlemine bu vaka üzerinden devam edilecektir.";
                                InfoBox.Alert(msg);
                                bool boolCloneNucleerMedicine = false;
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
                                    //Şu anda nükleer tıp da istekler tek tek giriliyor. Çoklu girilmeye başlandığında bu kısım radyolojide olduğu gibi düzenlenmeli.
                                    NuclearMedicine originalNuclearMedicine = this._NuclearMedicine;
                                    NuclearMedicineTest originalNuclearMedicineTest = this._NuclearMedicine.NuclearMedicineTests[0];
                                    NuclearMedicine cloneNuclearMedicine = (NuclearMedicine)originalNuclearMedicine.Clone();
                                    NuclearMedicineTest cloneNuclearMedicineTest = (NuclearMedicineTest)originalNuclearMedicineTest.Clone();

                                    TTSequence.allowSetSequenceValue = true;
                                    cloneNuclearMedicine.ID.SetSequenceValue(0);
                                    cloneNuclearMedicine.ID.GetNextValue();
                                    TTSequence.allowSetSequenceValue = true;
                                    cloneNuclearMedicineTest.ID.SetSequenceValue(0);
                                    cloneNuclearMedicineTest.ID.GetNextValue();

                                    cloneNuclearMedicine.Episode = episodeWithSameSpeciality;
                                    if (subEpisode != null)
                                    {
                                        cloneNuclearMedicine.SubEpisode = subEpisode;
                                        cloneNuclearMedicine.PatientAdmission = subEpisode.PatientAdmission;
                                    }
                                    cloneNuclearMedicine.ClonedObjectID = (Guid?)originalNuclearMedicine.ObjectID;
                                    cloneNuclearMedicine.CurrentStateDefID = NuclearMedicine.States.Request;
                                    cloneNuclearMedicineTest.NuclearMedicine = cloneNuclearMedicine;
                                    cloneNuclearMedicineTest.Episode = episodeWithSameSpeciality;
                                    if(subEpisode != null)
                                        cloneNuclearMedicineTest.SubEpisode = subEpisode;
                                    originalNuclearMedicineTest.Eligible = false;
                                    this._NuclearMedicine.ObjectContext.Update();
                                    cloneNuclearMedicine.CurrentStateDefID = NuclearMedicine.States.RequestAcception;
                                    this._NuclearMedicine.ObjectContext.Update();
                                    cloneNuclearMedicine.CurrentStateDefID = NuclearMedicine.States.Preparation;
                                    this._NuclearMedicine.ObjectContext.Update();
                                    _NuclearMedicine.DescriptionForWorkList += "\r\n" + msg;
                                    _NuclearMedicine.CurrentStateDefID = NuclearMedicine.States.AdmissionAppointment;
                                    this._NuclearMedicine.ObjectContext.Update();
                                }
                                catch(Exception ex)
                                {
                                    if(this._NuclearMedicine.ObjectContext.HasSavePoint(savePointGuid))
                                        this._NuclearMedicine.ObjectContext.RollbackSavePoint(savePointGuid);
                                    throw ex;
                                }
                            }
                            else
                            {
                                try
                                {
                                    InfoBox.Alert("Hastanın kabul tarihi üzerinden 10 gün geçtiği için, yeni hasta kabul işlemleri üzerinden devam edilecektir. ");
                                    
                                    Patient selectedPatient =  this._NuclearMedicine.Episode.Patient;
                                    AdmissionAppointment admissionAppointment = (AdmissionAppointment)this._NuclearMedicine.ObjectContext.CreateObject("AdmissionAppointment");
                                    admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.New;
                                    admissionAppointment.SelectedPatient = selectedPatient;
                                    admissionAppointment.PatientName = _NuclearMedicine.Episode.Patient.Name;
                                    admissionAppointment.PatientSurname = _NuclearMedicine.Episode.Patient.Surname;
                                    admissionAppointment.SelectedPatientFiltered = _NuclearMedicine.Episode.Patient.FullName;
                                    admissionAppointment.AppointmentDefinition = app.AppointmentDefinition;
                                    if (app.AppointmentDefinition.GiveToMaster == true)
                                        app.MasterResource = null;
                                    else
                                        app.MasterResource = _NuclearMedicine.MasterResource;
                                    app.Action = (BaseAction)admissionAppointment;
                                    app.InitialObjectID = _NuclearMedicine.ObjectID.ToString();
                                    admissionAppointment.MasterResource = app.MasterResource;
                                    admissionAppointment.WorkListDate = Convert.ToDateTime(app.StartTime);
                                    this._NuclearMedicine.ObjectContext.Update();
                                    admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.Appointment;
                                    this._NuclearMedicine.ObjectContext.Update();
                                    _NuclearMedicine.CurrentStateDefID = NuclearMedicine.States.AdmissionAppointment;
                                    
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
                                    this._NuclearMedicine.ObjectContext.Update();
                                }
                                catch(Exception ex)
                                {
                                    if(this._NuclearMedicine.ObjectContext.HasSavePoint(savePointGuid))
                                        this._NuclearMedicine.ObjectContext.RollbackSavePoint(savePointGuid);
                                    throw ex;
                                }
                            }
                        }
                    }
                }
            }
#endregion NuclearMedicineAppointmentInfoForm_ClientSidePostScript

        }
    }
}