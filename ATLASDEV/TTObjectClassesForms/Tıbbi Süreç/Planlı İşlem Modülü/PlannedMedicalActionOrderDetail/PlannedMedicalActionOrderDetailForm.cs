
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
    /// Planlı Tıbbi İşlem Uygulaması
    /// </summary>
    public partial class PlannedMedicalActionOrderDetailForm : SubactionProcedureFlowableForm
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
#region PlannedMedicalActionOrderDetailForm_PreScript
    base.PreScript();
            this.FillInpatientLists(((PlannedMedicalActionOrder)this._PlannedMedicalActionOrderDetail.OrderObject).PlannedMedicalActionRequest.InPatientsBed);
            
            int index = 0;
            
            this.tttextboxDescription.Text = string.Empty;
            //TODO:PanelButtons!
            //ITTTextBox pDescriptionBox = (ITTTextBox)this.pnlControls.Controls["tttextboxDescription"];
            //pDescriptionBox.ScrollBars= ScrollBars.Vertical;
            
            if (this._PlannedMedicalActionOrderDetail.GetStateHistory().Count > 1)
            {
                index = this._PlannedMedicalActionOrderDetail.GetStateHistory().Count-1;
                if(this._PlannedMedicalActionOrderDetail.GetStateHistory()[index].IsUndo == true || this._PlannedMedicalActionOrderDetail.CurrentStateDefID != PlannedMedicalActionOrderDetail.States.Execution)
                {
                    this.tttextboxDescription.Text = this.GetFullCompletedAppointmentDescription(this._PlannedMedicalActionOrderDetail);
                }
                else
                {
                    this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._PlannedMedicalActionOrderDetail);
                }
            }
            else
            {
                this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._PlannedMedicalActionOrderDetail);
            }
            
            if(this._PlannedMedicalActionOrderDetail.CurrentStateDefID == PlannedMedicalActionOrderDetail.States.Execution)
            {
                if (this._PlannedMedicalActionOrderDetail.PrevState != null)
                {
                    if(this._PlannedMedicalActionOrderDetail.PrevState.StateDefID == PlannedMedicalActionOrderDetail.States.ApprovalForCancel)
                    {
                        this.labelCancelRequestDescription.Visible = true;
                        this.CancelRequestDescription.Visible = true;
                        this.labelDoctorReturnDescription.Visible = true;
                        this.DoctorReturnDescription.Visible = true;
                    }
                }
                else
                {
                    this.labelCancelRequestDescription.Visible = false;
                    this.CancelRequestDescription.Visible = false;
                    this.labelDoctorReturnDescription.Visible = false;
                    this.DoctorReturnDescription.Visible = false;
                }
            }
            else if (this._PlannedMedicalActionOrderDetail.CurrentStateDefID == PlannedMedicalActionOrderDetail.States.ApprovalForCancel)
            {
                if(this._PlannedMedicalActionOrderDetail.PrevState.PrevState != null)
                {
                    if (this._PlannedMedicalActionOrderDetail.PrevState.PrevState.StateDefID == PlannedMedicalActionOrderDetail.States.ApprovalForCancel)
                    {
                        this.labelCancelRequestDescription.Visible = true;
                        this.CancelRequestDescription.Visible = true;
                        this.labelDoctorReturnDescription.Visible = true;
                        this.DoctorReturnDescription.Visible = true;
                    }
                }
                else
                {
                    this.labelCancelRequestDescription.Visible = true;
                    this.CancelRequestDescription.Visible = true;
                    this.labelDoctorReturnDescription.Visible = false;
                    this.DoctorReturnDescription.Visible = false;
                }
                
            }
            
            //DP Gelistirme asagidaki kod commentlendi. tedavi requestteki Islemi yapacak kullanici PROCEDUREBYUSER degeri set edilecek
            //if (this._PlannedMedicalActionOrderDetail.OrderObject.ProcedureDoctor != null)
            //{
            //    this.ProcedureDoctor.SelectedObject = this._PlannedMedicalActionOrderDetail.OrderObject.ProcedureDoctor;
            //}
            
             //DP Gelistirme, ilk acilista islemi yapacak olan operator bilgisi Tibbi islem Emrinde girilen kullanici bilgisi olarak set edilecek.
            if (this._PlannedMedicalActionOrderDetail.OrderObject.ProcedureByUser != null)
            {
                 if (this._PlannedMedicalActionOrderDetail.ProcedureByUser == null)
                    this.ProcedureDoctor.SelectedObject = this._PlannedMedicalActionOrderDetail.OrderObject.ProcedureByUser;
            }
  
            
            if(((PlannedMedicalActionOrder)this._PlannedMedicalActionOrderDetail.OrderObject).PlannedMedicalActionRequest.ProcedureDoctor != null)
            {
                ResUser doctor = ((PlannedMedicalActionOrder)this._PlannedMedicalActionOrderDetail.OrderObject).PlannedMedicalActionRequest.ProcedureDoctor;
                if(doctor.ResourceSpecialities.Count > 0)
                {
                    bool searchForMainSpeciality = false;
                    if(doctor.ResourceSpecialities.Count>1)
                        searchForMainSpeciality = true;
                    foreach(ResourceSpecialityGrid speciality in doctor.ResourceSpecialities)
                    {
                        if(searchForMainSpeciality == false)
                        {
                            this.ProcedureSpeciality.SelectedObject = speciality.Speciality;
                            break;
                        }
                        else
                        {
                            if (speciality.MainSpeciality == true)
                            {
                                this.ProcedureSpeciality.SelectedObject = speciality.Speciality;
                                break;
                            }
                        }
                    }
                }
            }
            
            if (this._PlannedMedicalActionOrderDetail.CurrentStateDefID == PlannedMedicalActionOrderDetail.States.Execution)
            {
                this._PlannedMedicalActionOrderDetail.ActionDate = Common.RecTime();
            }
            //this.cmdOK.Visible = false;
            
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["PlannedMedicalActionTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
#endregion PlannedMedicalActionOrderDetailForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PlannedMedicalActionOrderDetailForm_PostScript
    base.PostScript(transDef);
#endregion PlannedMedicalActionOrderDetailForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region PlannedMedicalActionOrderDetailForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if (transDef != null)
            {
                StringEntryForm rtfForm = new StringEntryForm();
                if(transDef.ToStateDefID == PlannedMedicalActionOrderDetail.States.ApprovalForCancel)
                {
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("İptal İstek Sebebi");
                    this.CancelRequestDescription.Text = this.CancelRequestDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
                else if (transDef.ToStateDefID == PlannedMedicalActionOrderDetail.States.Execution)
                {
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("Küre Devam İstek Sebebi");
                    this.DoctorReturnDescription.Text = this.DoctorReturnDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
            }
            
            if (this._PlannedMedicalActionOrderDetail.ActionDate == null)
                throw new Exception(SystemMessage.GetMessage(1178));
            
            if(this._PlannedMedicalActionOrderDetail.ProcedureSpeciality == null)
                throw new Exception(SystemMessage.GetMessage(993));
#endregion PlannedMedicalActionOrderDetailForm_ClientSidePostScript

        }

#region PlannedMedicalActionOrderDetailForm_Methods
        protected void FillInpatientLists(bool? ifCheckedInPatientsBed)
        {
            PlannedMedicalActionRequest pmaRequest = ((PlannedMedicalActionOrder)this._PlannedMedicalActionOrderDetail.OrderObject).PlannedMedicalActionRequest;
            PlannedMedicalActionOrder pmaOrder = ((PlannedMedicalActionOrder)this._PlannedMedicalActionOrderDetail.OrderObject);
            if(ifCheckedInPatientsBed == true)
            {
                Episode e = this._PlannedMedicalActionOrderDetail.Episode.Patient.InpatientEpisode;
                if(e != null)
                {
                    if(pmaRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        pmaRequest.InpatientBed = e.Bed;
                    this.Bed.SelectedObject = e.Bed;
                    if(e.Bed != null)
                    {
                        this.Room.SelectedObject = e.Bed.Room;
                        if(e.Bed.Room != null)
                        {
                            this.RoomGroup.SelectedObject = e.Bed.Room.RoomGroup;
                            if(e.Bed.Room.RoomGroup != null)
                            {
                                this.PhysicalStateClinic.SelectedObject = e.Bed.Room.RoomGroup.Ward;
                                if(e.Bed.Room.RoomGroup.Ward !=null)
                                {
                                    if(pmaRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        pmaRequest.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                    if(pmaOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        pmaOrder.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                    if(this._PlannedMedicalActionOrderDetail.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        this._PlannedMedicalActionOrderDetail.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                }
                            }
                        }
                    }
                    else
                    {
                        if(pmaRequest.InpatientBed != null)
                        {
                            this.Bed.SelectedObject = pmaRequest.InpatientBed;
                            this.Room.SelectedObject = pmaRequest.InpatientBed.Room;
                            this.RoomGroup.SelectedObject = pmaRequest.InpatientBed.Room.RoomGroup;
                            this.PhysicalStateClinic.SelectedObject = pmaRequest.InpatientBed.Room.RoomGroup.Ward;
                        }
                    }
                }
                else
                {
                    if(pmaRequest.InpatientBed != null)
                    {
                        this.Bed.SelectedObject = pmaRequest.InpatientBed;
                        this.Room.SelectedObject = pmaRequest.InpatientBed.Room;
                        this.RoomGroup.SelectedObject = pmaRequest.InpatientBed.Room.RoomGroup;
                        this.PhysicalStateClinic.SelectedObject = pmaRequest.InpatientBed.Room.RoomGroup.Ward;
                    }
                }
            }
        }
        
#endregion PlannedMedicalActionOrderDetailForm_Methods
    }
}