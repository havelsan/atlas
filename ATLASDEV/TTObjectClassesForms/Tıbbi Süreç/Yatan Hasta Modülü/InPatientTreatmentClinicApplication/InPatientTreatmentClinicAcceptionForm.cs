
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
    /// Yatan Hasta Klinik İşlemleri
    /// </summary>
    public partial class InPatientTreatmentClinicAcceptionForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            TurnReserveToUsed.Click += new TTControlEventDelegate(TurnReserveToUsed_Click);
            RoomGroup.SelectedObjectChanged += new TTControlEventDelegate(RoomGroup_SelectedObjectChanged);
            Room.SelectedObjectChanged += new TTControlEventDelegate(Room_SelectedObjectChanged);
            MasterResource.SelectedObjectChanged += new TTControlEventDelegate(MasterResource_SelectedObjectChanged);
            PhysicalStateClinic.SelectedObjectChanged += new TTControlEventDelegate(PhysicalStateClinic_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TurnReserveToUsed.Click -= new TTControlEventDelegate(TurnReserveToUsed_Click);
            RoomGroup.SelectedObjectChanged -= new TTControlEventDelegate(RoomGroup_SelectedObjectChanged);
            Room.SelectedObjectChanged -= new TTControlEventDelegate(Room_SelectedObjectChanged);
            MasterResource.SelectedObjectChanged -= new TTControlEventDelegate(MasterResource_SelectedObjectChanged);
            PhysicalStateClinic.SelectedObjectChanged -= new TTControlEventDelegate(PhysicalStateClinic_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void TurnReserveToUsed_Click()
        {
#region InPatientTreatmentClinicAcceptionForm_TurnReserveToUsed_Click
   if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null)
            {
                IList myResevedToUsedBedList = BaseBedProcedure.GetByBaseInpatientAdmissionAndUseStatus(this._InPatientTreatmentClinicApplication.ObjectContext, this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.ObjectID.ToString(), UsedStatusEnum.ReservedToUse);
                string result = "";
                foreach (BaseBedProcedure myResevedToUsedBed in myResevedToUsedBedList)
                {
                    if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed != null)
                    {
                        if (myResevedToUsedBed.Bed.ObjectID != this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.ObjectID)
                        {
                            myResevedToUsedBed.UsedStatus = UsedStatusEnum.WasReserved;
                            result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Rezerveye,&Seçilene", "R,S", "Uyarı", "Hastayı Hangi Yatağa Yatırmak İstersiniz?", "Hastanın rezerve yatağı " + myResevedToUsedBed.Bed.Name + " iken . Yatak alanından " + this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.Name + " seçilmişdir hastayı hangi yatağa yatırmak istersiniz?", 1);
                            if (result == "")
                            {
                                InfoBox.Show("İşlemden vazgeçildi");
                                return;
                            }
                        }
                    }
                    else
                    {
                        result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Rezerveye Al,&Boşalt", "R,B", "Uyarı", "Hastayı Hangi Yatağa Yatırmak İstersiniz?", "Hastanın rezerve yatağı " + myResevedToUsedBed.Bed.Name + " iken yatak alanı boş altılmıştır", 1);
                        if (result == "")
                        {
                            InfoBox.Show("İşlemden vazgeçildi");
                            return;
                        }
                    }

                    myResevedToUsedBed.UsedStatus = UsedStatusEnum.WasReserved;

                    if (result == "R")
                    {
                        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup = myResevedToUsedBed.RoomGroup;
                        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room = myResevedToUsedBed.Room;
                        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed = myResevedToUsedBed.Bed;
                    }
                    if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed != null)
                    {
                        BaseBedProcedure baseBedProcedure = new BaseBedProcedure(this._InPatientTreatmentClinicApplication.ObjectContext);
                        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.BedProcedures.Add(baseBedProcedure);
                        baseBedProcedure.Bed = this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed;
                        baseBedProcedure.Room = this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room;
                        baseBedProcedure.RoomGroup = this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup;
                        baseBedProcedure.UsedStatus = UsedStatusEnum.Used;
                    }
                    break;
                }
                if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed != null)
                {
                    InfoBox.Show("Hasta " + this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.Name + " yatağına alınacaktır.Lütfen işlemi kaydetmeyi unutmayınız!");
                }
                else
                {
                    InfoBox.Show("Hastanın rezervasyonlu yatağı boşaltılacaktır.Lütfen işlemi kaydetmeyi unutmayınız!");
                }
            }
#endregion InPatientTreatmentClinicAcceptionForm_TurnReserveToUsed_Click
        }

        private void RoomGroup_SelectedObjectChanged()
        {
#region InPatientTreatmentClinicAcceptionForm_RoomGroup_SelectedObjectChanged
   this.SetNumberOfEmptyBedsByPhysicalStateClinic();
            SetFirstEmptyBedByRoomGroup();
#endregion InPatientTreatmentClinicAcceptionForm_RoomGroup_SelectedObjectChanged
        }

        private void Room_SelectedObjectChanged()
        {
#region InPatientTreatmentClinicAcceptionForm_Room_SelectedObjectChanged
   SetFirstEmptyBedByRoom();
#endregion InPatientTreatmentClinicAcceptionForm_Room_SelectedObjectChanged
        }

        private void MasterResource_SelectedObjectChanged()
        {
#region InPatientTreatmentClinicAcceptionForm_MasterResource_SelectedObjectChanged
        if (this._InPatientTreatmentClinicApplication.GetMyActiveToInPatientTrtmentClinicApp() == null)// aktif yatan işlemler için 
            {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.TreatmentClinic = (ResClinic)this.MasterResource.SelectedObject;
               // this._InPatientTreatmentClinicApplication.Episode.TreatmentClinic = (ResClinic)this.MasterResource.SelectedObject;
            }
            foreach (NursingApplication nursingApplication in this._InPatientTreatmentClinicApplication.NursingApplications)
            {
                nursingApplication.MasterResource = (ResSection)this.MasterResource.SelectedObject;
            }
            foreach (InPatientPhysicianApplication InpatientPhyApp in this._InPatientTreatmentClinicApplication.InPatientPhysicianApplication)
            {
                InpatientPhyApp.MasterResource = (ResSection)this.MasterResource.SelectedObject;
            }
#endregion InPatientTreatmentClinicAcceptionForm_MasterResource_SelectedObjectChanged
        }

        private void PhysicalStateClinic_SelectedObjectChanged()
        {
#region InPatientTreatmentClinicAcceptionForm_PhysicalStateClinic_SelectedObjectChanged
   SetFirstEmptyBedByPhysicalStateClinic();
#endregion InPatientTreatmentClinicAcceptionForm_PhysicalStateClinic_SelectedObjectChanged
        }

        protected override void PreScript()
        {
            #region InPatientTreatmentClinicAcceptionForm_PreScript
            this.SetProcedureDoctorAsCurrentResource();

            //MCA
            bool isRoleAssigned = false;  // kullanıcıya rol atanmışmı bakıyor.
            foreach (TTUserRole role in TTUser.CurrentUser.Roles)
            {
                if (TTUser.CurrentUser.HasRole(Common.ChangePhysicalStateClinicRoleID) == true)
                {
                    isRoleAssigned = true;
                    break;
                }
            }

            if (this.PhysicalStateClinic.SelectedValue == null)
            {

                this.PhysicalStateClinic.ReadOnly = false;

            }

            else if (this.PhysicalStateClinic.SelectedValue != null)
            {
                if (Common.CurrentUser.IsSuperUser || isRoleAssigned) // kullanıcıya o rol atanmışsa super user olmasına gerek yok.
                {
                    this.PhysicalStateClinic.ReadOnly = false;
                }
                else
                {
                    this.PhysicalStateClinic.ReadOnly = true;
                }
            }

            //MCA

            //if (this._InPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Acception)
            //    this.Text = "Yatan Hasta Klinik / Servis Kabul";
            base.PreScript();
            //if (this.Owner is InPatientAdmissionBaseForm)
            //    SetFormReadOnly();

            this.DropStateButton(InPatientTreatmentClinicApplication.States.Transferred);

            bool dropDischargeButton = true;
            int counter = 0;
            if (this._InPatientTreatmentClinicApplication.InPatientPhysicianApplication != null && this._InPatientTreatmentClinicApplication.InPatientPhysicianApplication.Count > 0)
            {
                if (this._InPatientTreatmentClinicApplication.InPatientPhysicianApplication[0].CurrentStateDefID == InPatientPhysicianApplication.States.Discharged)
                    counter++;
            }

            foreach (NursingApplication nursingApplication in this._InPatientTreatmentClinicApplication.NursingApplications)
            {
                if (nursingApplication.CurrentStateDefID == NursingApplication.States.Discharged)
                    counter++;
            }

            if (counter > 1) // Klinik Doktor İşlemleri ve Hemşirelik Hizmetleri Taburcu aşamasındaysa, ama bir şekilde Klinik İşlemleri Taburcu aşamasına geçmediyse Taburcu butonunu kaldırmamak için
                dropDischargeButton = false;

            if (dropDischargeButton == true)
                this.DropStateButton(InPatientTreatmentClinicApplication.States.Discharged);
            //this.NumberOfEmptyBeds.Text=Convert.ToString(Common.GetNumberOfEmptyBeds(this._InPatientTreatmentClinicApplication.ObjectContext));
            this.SetNumberOfEmptyBedsByPhysicalStateClinic();
            bool showTurnReserveToUsed = false;



                if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null)
                {
                    if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission is InpatientAdmission)
                        this.QuarantineProtocolNo.Text = ((InpatientAdmission)this._InPatientTreatmentClinicApplication.BaseInpatientAdmission).QuarantineProtocolNo.ToString();
                }

            if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null)
            {
                IList myResevedToUsedBedList = BaseBedProcedure.GetByBaseInpatientAdmissionAndUseStatus(this._InPatientTreatmentClinicApplication.ObjectContext, this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.ObjectID.ToString(), UsedStatusEnum.ReservedToUse);
                if (myResevedToUsedBedList.Count > 0)
                {
                    IList allUsedBedList = BaseBedProcedure.GetByPatientAndUseStatus(this._InPatientTreatmentClinicApplication.ObjectContext, this._InPatientTreatmentClinicApplication.Episode.Patient.ObjectID.ToString(), UsedStatusEnum.Used);
                    if (allUsedBedList.Count < 1)
                    {
                        showTurnReserveToUsed = true;
                    }
                }
            }


            if (showTurnReserveToUsed)
            {
                this.TurnReserveToUsed.Visible = true;
            }
            else
            {
                this.TurnReserveToUsed.Visible = false;
            }

            //Kota olayını bozduğu için aşağıdaki kod yazıldı.
            //if (TTObjectClasses.SystemParameter.GetParameterValue("IGNOREINPATIENTQUOTACONTROL", "TRUE") != "TRUE")
            //{
            //    if (Common.CurrentUser.IsPowerUser || Common.CurrentUser.IsSuperUser)
            //        this.MasterResource.ReadOnly = false;
            //    else
            //        this.MasterResource.ReadOnly = true;
            //}


            //            // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
            //            
            //            if(this._InPatientTreatmentClinicApplication.Episode.IsMedulaEpisode() == true){
            //                if(this._InPatientTreatmentClinicApplication.MedulaProvision == null){
            //                    MedulaProvision _medulaProvision= new MedulaProvision(this._InPatientTreatmentClinicApplication.ObjectContext);
            //                    this._InPatientTreatmentClinicApplication.setMedulaProvisionInitalProperties(_medulaProvision);
            //                    this._InPatientTreatmentClinicApplication.MedulaProvision= _medulaProvision;
            //                }
            //            }

          
            //
            #endregion InPatientTreatmentClinicAcceptionForm_PreScript

        }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InPatientTreatmentClinicAcceptionForm_PostScript
    base.PostScript(transDef);
            if (this.MasterResource == null)
                throw new Exception("'Hastanın Tedavi Gördüğü Klinik' boş geçilemez");

            if (transDef != null)
            {
                if (transDef.ToStateDefID != InPatientTreatmentClinicApplication.States.Cancelled)
                {

                    if (this._InPatientTreatmentClinicApplication.ProcedureDoctor == null)
                        throw new Exception("'Sorumlu Doktor' alanı boş geçilemez.");

                }

                if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission is InpatientAdmission)
                {
                    if (transDef.ToStateDefID == InPatientTreatmentClinicApplication.States.Procedure)
                    {
                        if (this.RequiresAdvance())
                            throw new Exception(SystemMessage.GetMessage(137));
                    }
                }
            }
#endregion InPatientTreatmentClinicAcceptionForm_PostScript

            }
            
         #region InPatientTreatmentClinicAcceptionForm_Methods
        protected void SetNumberOfEmptyBedsByPhysicalStateClinic()
        {

            if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic == null)
            {
                this.NumberOfEmptyBeds.Text = "";
            }
            else
            {
                this.NumberOfEmptyBeds.Text = Convert.ToString(Common.GetNumberOfEmptyBeds((Guid)this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic.ObjectID));
                
            }

        }
        protected void SetFirstEmptyBedByPhysicalStateClinic()
        {
            bool setValue = false;
            if (this.PhysicalStateClinic.SelectedValue != null) // Hastanın yatacağı klinik seçilmişsse aşağıdakileri yapacak.
            {
                if (this.RoomGroup.SelectedValue == null)
                {
                    setValue = true;
                }
                else if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup.Ward != this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic)
                {
                    setValue = true;
                }

                if (setValue)
                {
                    this.RoomGroup.SelectedValue = null;
                    this.Room.SelectedValue = null;
                    this.Bed.SelectedObject = Common.GetFirstfEmptyBedV2((Guid)this.PhysicalStateClinic.SelectedObjectID);
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
                else if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room.RoomGroup != this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup)
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
                else if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.Room != this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room)
                    this.Bed.SelectedObject = Common.GetFirstfEmptyBedV4((Guid)this.PhysicalStateClinic.SelectedObjectID, (Guid)this.RoomGroup.SelectedObjectID, (Guid)this.Room.SelectedObjectID);
            }
        }
        
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null && transDef.ToStateDefID == InPatientTreatmentClinicApplication.States.Discharged)
            {
                EpisodeAction.CheckAndCloseEpisode(this._InPatientTreatmentClinicApplication.ObjectID);
            }
        }

        private void btnShowGivenMaterialsStatus_Click()
        {
            //#region InPatientAdmissionClinicProcedure_ttbutton1_Click
            //string givenMsg = Episode.GivenValuableMaterialsMsg(this._InPatientTreatmentClinicApplication.Episode);
            //string takenMsg = Episode.TakenValuableMaterialsMsg(this._InPatientTreatmentClinicApplication.Episode);
            //this.GivenStatus.Text = givenMsg;
            //this.TakenStatus.Text = takenMsg;
           // #endregion InPatientAdmissionClinicProcedure_ttbutton1_Click
        }

        private void NoCupboard_CheckedChanged()
        {
            //#region InPatientAdmissionClinicProcedure_NoCupboard_CheckedChanged
            //if (this.NoCupboard.Value == true)
            //{
            //    this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Cupboard = null;
            //    this.Cupboard.ReadOnly = true;
            //}
            //else
            //{
            //    this.Cupboard.ReadOnly = false;
            //}
            //#endregion InPatientAdmissionClinicProcedure_NoCupboard_CheckedChanged
        }

   

        #endregion InPatientTreatmentClinicAcceptionForm_Methods
    }
}