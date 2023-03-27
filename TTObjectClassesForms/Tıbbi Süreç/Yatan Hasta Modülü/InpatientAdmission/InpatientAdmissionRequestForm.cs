
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
    /// Hasta Yatış
    /// </summary>
    public partial class InpatientAdmissionRequestForm : InPatientAdmissionBaseForm
    {
        override protected void BindControlEvents()
        {
            btnEmptyBedsInClinic.Click += new TTControlEventDelegate(btnEmptyBedsInClinic_Click);
            RoomGroup.SelectedObjectChanged += new TTControlEventDelegate(RoomGroup_SelectedObjectChanged);
            Room.SelectedObjectChanged += new TTControlEventDelegate(Room_SelectedObjectChanged);
            PhysicalStateClinic.SelectedObjectChanged += new TTControlEventDelegate(PhysicalStateClinic_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnEmptyBedsInClinic.Click -= new TTControlEventDelegate(btnEmptyBedsInClinic_Click);
            RoomGroup.SelectedObjectChanged -= new TTControlEventDelegate(RoomGroup_SelectedObjectChanged);
            Room.SelectedObjectChanged -= new TTControlEventDelegate(Room_SelectedObjectChanged);
            PhysicalStateClinic.SelectedObjectChanged -= new TTControlEventDelegate(PhysicalStateClinic_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void btnEmptyBedsInClinic_Click()
        {
#region InpatientAdmissionRequestForm_btnEmptyBedsInClinic_Click
   if (this.PhysicalStateClinic.SelectedObject != null)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> physicalStateClinic = new TTReportTool.PropertyCache<object>();
                physicalStateClinic.Add("VALUE", _InpatientAdmission.PhysicalStateClinic.ObjectID.ToString());
                parameter.Add("WARD", physicalStateClinic);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_EmptyBedsByClinicReport), true, 1, parameter);
            }
#endregion InpatientAdmissionRequestForm_btnEmptyBedsInClinic_Click
        }

        private void RoomGroup_SelectedObjectChanged()
        {
#region InpatientAdmissionRequestForm_RoomGroup_SelectedObjectChanged
   SetFirstEmptyBedByRoomGroup();
#endregion InpatientAdmissionRequestForm_RoomGroup_SelectedObjectChanged
        }

        private void Room_SelectedObjectChanged()
        {
#region InpatientAdmissionRequestForm_Room_SelectedObjectChanged
   SetFirstEmptyBedByRoom();
#endregion InpatientAdmissionRequestForm_Room_SelectedObjectChanged
        }

        private void PhysicalStateClinic_SelectedObjectChanged()
        {
#region InpatientAdmissionRequestForm_PhysicalStateClinic_SelectedObjectChanged
   SetNumberOfEmptyBedsByPhysicalStateClinic();
            SetFirstEmptyBedByPhysicalStateClinic();
#endregion InpatientAdmissionRequestForm_PhysicalStateClinic_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region InpatientAdmissionRequestForm_PreScript
    base.PreScript();

            //Hasta grubu uygun değilse yatış başlatılamasın
            /* AdmissionTypeDefinition reasonForAdmission = _InpatientAdmission.SubEpisode.PatientAdmission.AdmissionType;
             if(reasonForAdmission.AllowedForInpatientAdmission != null && reasonForAdmission.AllowedForInpatientAdmission == false)
                 throw new TTUtils.TTException(reasonForAdmission.Description + " türündeki kabullerde hasta yatışa izin verilmemektedir.");
             */
            this.SetProcedureDoctorAsCurrentResource();

            if (_InpatientAdmission.CurrentStateDefID == InpatientAdmission.States.Request)
            {
                DateTime openingDate = _InpatientAdmission.Episode.OpeningDate.Value;
                DateTime today =  Common.RecTime();
                System.TimeSpan timeSpan = today.Subtract(openingDate);
                int dayDiff = (int)timeSpan.TotalDays;
                if (dayDiff > 10) {
                    throw new TTUtils.TTException("Epizode açılış tarihinden 10 gün geçmiş vakalara yatış işlemi başlatamazsınız!");
                }
            }
            
            
            // Acil serviste muayeneleri YEŞİL ALAN olarak işaretlenen hastaların kliniklere yatışına Medulada ödeme kapsamında olmadığı için  izin verilmemektedir.

            if (this._EpisodeAction != null){
                if (this._EpisodeAction.Episode != null)
                {
                    foreach (EmergencyIntervention ei in this._EpisodeAction.Episode.EmergencyInterventions)
                    {
                        foreach (InPatientPhysicianApplication ippa in ei.InPatientPhysicianApplications)
                        {
                            //if (ippa.IsGreenAreaExamination != null)
                            {
                                if(ippa.IsGreenAreaExamination == true)
                                    throw new Exception("Acil serviste muayeneleri YEŞİL ALAN olan hastaların kliniklere yatışına izin verilmemektedir.");
                                
                            }
                        }
                    }
                }
            }

            //Günübirlik Takip üzerinden yatış başlatılamaz
            
            if (this._EpisodeAction != null){
                if (this._EpisodeAction.Episode != null && this._EpisodeAction.SubEpisode.PatientAdmission != null)
                {
                    // Hasta Kabul aynı Gün
                    if(this._EpisodeAction.SubEpisode.PatientAdmission.ActionDate != null && Common.RecTime().Date == Convert.ToDateTime(this._EpisodeAction.SubEpisode.PatientAdmission.ActionDate).Date)
                    {
                        // Kabul Sebebi Günübirlik
                       
                        if(this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType != null && this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily) == true)
                        {
                            throw new Exception("Hasta Kabul Sebebi 'Günübirlik' olduğundan Yatış başlatılamaz. Kabul Sebebi alanı hasta kabul düzeltmeden 'Normal Muayene' olacak şekilde güncellenerek yatış başlatılabilir.");
                        }
                        // Takip Tipi Günübirlik
                        else if(this._EpisodeAction.SubEpisode?.PatientAdmission?.SEP?.MedulaTakipTipi.takipTipiKodu.Equals("T") == true)
                        {
                            throw new Exception("Takip Tipi 'Tanı Amaçlı Günübirlik' olduğundan Yatış başlatılamaz. Hasta kabul düzeltme adımından Takip Tipi, 'Normal' olacak şekilde güncellenerek yatış başlatılabilir.");
                            
                        }
                    }
                    //Hasta Kabul Farklı Gün
                    else
                    {
                      
                        // Kabul Sebebi Günübirlik
                        if( this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType != null && this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily) == true)
                        {
                            throw new Exception("Hasta Kabul Sebebi 'Günübirlik' olduğundan Yatış başlatılamaz.Kabul Sebebi, 'Normal Muayene' olacak şekilde yeni kabul yapılarak Yatış başlatılabilir.");
                        }
                        // Takip Tipi Günübirlik
                        else if(this._EpisodeAction.SubEpisode?.PatientAdmission?.SEP?.MedulaTakipTipi.takipTipiKodu.Equals("T") == true)
                        {
                            throw new Exception("Takip Tipi 'Tanı Amaçlı Günübirlik' olduğundan Yatış başlatılamaz.Takip Tipi, 'Normal' olacak şekilde yeni kabul yapılarak Yatış başlatılabilir.");
                        }
                        
                        
                    }
                }
            }
         
            if (this._EpisodeAction != null && this._EpisodeAction.Episode != null && this._EpisodeAction.SubEpisode.PatientAdmission != null)
            {
                // Kabul Sebebi Sağlık Kurulu Muayenesi
                if(this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType != null && this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.HealthCommitteeExamination) == true)
                {
                    throw new Exception("Hasta Kabul Sebebi 'Sağlık Kurulu Muayenesi' olan kabullerde Hasta Yatış işlemi başlatılamaz. Yatış işlemi için 'Normal Muayene' kaydı açınız.");
                }
            }
            
            

            if (string.IsNullOrEmpty(this.ReturnToRequestReason.Text))
            {
                this.ReturnToRequestReason.Visible = false;
                this.labelReturnToRequestReason.Visible = false;
            }

            this.SetTreatmentClinicListFilter();
        #endregion InpatientAdmissionRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InpatientAdmissionRequestForm_PostScript
    base.PostScript(transDef);


            //            if(transDef!=null)
            //            {
            //                if(transDef.ToStateDefID!=InpatientAdmission.States.Cancelled)
            //                {
            //                    this._InpatientAdmission.IsPatientApprovalFormGiven=GetIfPatientApprovalFormIsGiven(this._InpatientAdmission.IsPatientApprovalFormGiven);
            //                }
            //            }

            Guid inPatientForBirthGuid = new Guid("8695c125-cc84-4391-9d2b-db2d84afe8cf");
            if (_InpatientAdmission.InpatientReason.ObjectID == inPatientForBirthGuid && _InpatientAdmission.Episode.Patient.Sex.ADI == "ERKEK")
                throw new TTUtils.TTException("Erkek hastaları doğum sebebi ile yatıramazsınız");
#endregion InpatientAdmissionRequestForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region InpatientAdmissionRequestForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
#endregion InpatientAdmissionRequestForm_ClientSidePostScript

        }

#region InpatientAdmissionRequestForm_Methods
        //        protected void SetNumberOfEmptyBeds()
        //        {
        //            if(this.PhysicalStateClinic.SelectedValue==null)
        //            {
        //                this.NumberOfEmptyBeds.Text="";
        //            }
        //            else
        //            {
        //                this.NumberOfEmptyBeds.Text=Convert.ToString(Common.GetNumberOfEmptyBeds((Guid)this.PhysicalStateClinic.SelectedObjectID));
        //            }
        //
        //        }
        protected void SetFirstEmptyBedByPhysicalStateClinic()
        {
            bool setValue = false;
       
            if (this.PhysicalStateClinic.SelectedValue != null) // Hastanın yatacağı klinik seçilmişsse aşağıdakileri yapacak.
            {
                if (this.RoomGroup.SelectedValue == null)
                {
                    setValue = true;
                }
                else if (this._InpatientAdmission.RoomGroup.Ward != this._InpatientAdmission.PhysicalStateClinic)
                {
                    setValue = true;
                }

                if (setValue)
                {
                    this.RoomGroup.SelectedValue = null;
                    this.Room.SelectedValue = null;
                    this.Bed.SelectedObject = Common.GetFirstfEmptyBedV2( (Guid)this.PhysicalStateClinic.SelectedObjectID);
                }
            }
        }
        protected void SetFirstEmptyBedByRoomGroup()
        {
            bool setValue = false;
            if (this.RoomGroup.SelectedValue != null)
            {
                if (Room.SelectedValue == null)
                {
                    setValue = true;

                }
                else if (this._InpatientAdmission.Room.RoomGroup != this._InpatientAdmission.RoomGroup)
                {
                    setValue = true;

                }
                if (setValue)
                {
                    this.Room.SelectedValue = null;
                    this.Bed.SelectedObject = Common.GetFirstfEmptyBedV3( (Guid)this.PhysicalStateClinic.SelectedObjectID, (Guid)this.RoomGroup.SelectedObjectID);
                }
            }
        }
        protected void SetFirstEmptyBedByRoom()
        {
            bool setValue = false;
            if (this.Room.SelectedValue != null)
            {
                if (Bed.SelectedValue == null)
                    this.Bed.SelectedObject = Common.GetFirstfEmptyBedV4( (Guid)this.PhysicalStateClinic.SelectedObjectID, (Guid)this.RoomGroup.SelectedObjectID, (Guid)this.Room.SelectedObjectID);
                else if (this._InpatientAdmission.Bed.Room != this._InpatientAdmission.Room)
                    this.Bed.SelectedObject = Common.GetFirstfEmptyBedV4( (Guid)this.PhysicalStateClinic.SelectedObjectID, (Guid)this.RoomGroup.SelectedObjectID, (Guid)this.Room.SelectedObjectID);
            }
        }
        protected void SetTreatmentClinicListFilter()
        {
            if ((TTObjectClasses.SystemParameter.GetParameterValue("TREATMENTCLINICFILTER", "FALSE") == "TRUE"))
            {
                string filterString = "OBJECTID IN (''";
                bool isEmergency = false;
                bool hasResourceSpeciality = false;
                if (this._EpisodeAction.FromResource != null)
                {
                    foreach (ResourceSpecialityGrid spg in this._EpisodeAction.FromResource.ResourceSpecialities)
                    {
                        hasResourceSpeciality = true;
                        if (spg.Speciality != null)
                        {
                            if (spg.Speciality.Code == TTObjectClasses.SystemParameter.GetParameterValue("EMERGENCYSPECIALITYDEFINITIONCODE", "4400").ToString()) //Acil Tıp
                                isEmergency = true;
                            foreach (ResourceSpecialityGrid rsg in spg.Speciality.ResourceSpecialities)
                            {
                                if (rsg.Resource is ResClinic)
                                    filterString += " ,'" + rsg.Resource.ObjectID.ToString() + "'";
                            }
                        }
                        filterString += ")";
                    }
                }
                if (!isEmergency && hasResourceSpeciality)//Havale Eden Acil Bölümü değilse ve ResourceSpeciality'si varsa
                {
                    //filterString = "DEPARTMENT = '" + this._EpisodeAction.FromResource.ObjectID + "'";                
                    ((ITTObjectListBox)TreatmentClinic).ListFilterExpression = filterString;
                }
            }
        }
        
#endregion InpatientAdmissionRequestForm_Methods
    }
}