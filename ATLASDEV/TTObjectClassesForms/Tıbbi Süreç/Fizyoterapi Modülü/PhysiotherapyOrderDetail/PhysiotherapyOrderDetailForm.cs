
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
    /// Fizyoterapi Uygulaması
    /// </summary>
    public partial class PhysiotherapyOrderDetailForm : SubactionProcedureFlowableForm
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
#region PhysiotherapyOrderDetailForm_PreScript
    base.PreScript();
            this.FillInpatientLists(((PhysiotherapyOrder)this._PhysiotherapyOrderDetail.OrderObject).PhysiotherapyRequest.InPatientsBed);
            
            int index = 0;
            
            this.tttextboxDescription.Text = string.Empty;
            //TextBox pDescriptionBox = (TextBox)this.pnlControls.Controls["tttextboxDescription"];
            //pDescriptionBox.ScrollBars= ScrollBars.Vertical;
            
            if (this._PhysiotherapyOrderDetail.GetStateHistory().Count > 1)
            {
                index = this._PhysiotherapyOrderDetail.GetStateHistory().Count-1;
                if(this._PhysiotherapyOrderDetail.GetStateHistory()[index].IsUndo == true || this._PhysiotherapyOrderDetail.CurrentStateDefID != PhysiotherapyOrderDetail.States.Execution)
                {
                    this.tttextboxDescription.Text = this.GetFullCompletedAppointmentDescription(this._PhysiotherapyOrderDetail);
                }
                else
                {
                    this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._PhysiotherapyOrderDetail);
                }
            }
            else
            {
                this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._PhysiotherapyOrderDetail);
            }
            
            if(this._PhysiotherapyOrderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution)
            {
                if (this._PhysiotherapyOrderDetail.PrevState != null)
                {
                    if(this._PhysiotherapyOrderDetail.PrevState.StateDefID == PhysiotherapyOrderDetail.States.ApprovalForCancel)
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
            else if (this._PhysiotherapyOrderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.ApprovalForCancel)
            {
                if(this._PhysiotherapyOrderDetail.PrevState.PrevState != null)
                {
                    if (this._PhysiotherapyOrderDetail.PrevState.PrevState.StateDefID == PhysiotherapyOrderDetail.States.ApprovalForCancel)
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
            /*if(this._DialysisOrderDetail.CurrentStateDef.Status != StateStatusEnum.Cancelled)
            {
                this.labelReasonOfReject.Visible = false;
                this.ReasonOfReject.Visible = false;
            }*/
            
            //DP Gelistirme
            //PhysiotherapyOrder objesinin ProcedureDoctor u eskiden Fizyoterapistti, simdi istegi yapan doktor olarak set edildi.
            //_PhysiotherapyOrderDetail in ProcedureDoctor u da istegi yapan doktor olarak set edildi.
            //asagidaki kodda PhysiotherapyOrderDetail in fizyoterapist alani set edilecek. 
            
            //if (this._PhysiotherapyOrderDetail.OrderObject.ProcedureDoctor != null)
            //{
            //    this.ProcedureDoctor.SelectedObject = this._PhysiotherapyOrderDetail.OrderObject.ProcedureDoctor;
            //}
            
            if ( ((PhysiotherapyOrder)this._PhysiotherapyOrderDetail.OrderObject).ProcedureByUser  != null)
             {
                if (this._PhysiotherapyOrderDetail.ProcedureByUser == null)
                    this.Physiotherapist.SelectedObject = ((PhysiotherapyOrder)this._PhysiotherapyOrderDetail.OrderObject).ProcedureByUser;
             }
            
            if(((PhysiotherapyOrder)this._PhysiotherapyOrderDetail.OrderObject).PhysiotherapyRequest.ProcedureDoctor != null)
            {
                ResUser doctor = ((PhysiotherapyOrder)this._PhysiotherapyOrderDetail.OrderObject).PhysiotherapyRequest.ProcedureDoctor;
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
            
            if (this._PhysiotherapyOrderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution)
            {
                this._PhysiotherapyOrderDetail.ActionDate = Common.RecTime();
            }
            //this.cmdOK.Visible = false;
            
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["PhysiotherapyTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
            
//            if(this._PhysiotherapyOrderDetail.ProcedureSpeciality == null)
//            {
//                
//                if(this._PhysiotherapyOrderDetail.MasterResource.ResourceSpecialities.Count == 1)
//                {
//                    this.ProcedureSpeciality. this._PhysiotherapyOrderDetail.MasterResource.ResourceSpecialities[0].Speciality;
//                }
//            }
#endregion PhysiotherapyOrderDetailForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PhysiotherapyOrderDetailForm_PostScript
    base.PostScript(transDef);
            
            if (this._PhysiotherapyOrderDetail.ActionDate == null)
                throw new Exception(SystemMessage.GetMessage(1178));
            
            if(this._PhysiotherapyOrderDetail.ProcedureSpeciality == null)
                throw new Exception(SystemMessage.GetMessage(993));
#endregion PhysiotherapyOrderDetailForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region PhysiotherapyOrderDetailForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (transDef != null)
            {
                StringEntryForm rtfForm = new StringEntryForm();
                if (transDef.ToStateDefID == PhysiotherapyOrderDetail.States.ApprovalForCancel)
                {
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("İptal İstek Sebebi");
                    this.CancelRequestDescription.Text = this.CancelRequestDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
                else if (transDef.ToStateDefID == PhysiotherapyOrderDetail.States.Execution)
                {
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("Küre Devam İstek Sebebi");
                    this.DoctorReturnDescription.Text = this.DoctorReturnDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
            }
#endregion PhysiotherapyOrderDetailForm_ClientSidePostScript

        }

#region PhysiotherapyOrderDetailForm_Methods
        protected void FillInpatientLists(bool? ifCheckedInPatientsBed)
        {
            PhysiotherapyRequest phyRequest = ((PhysiotherapyOrder)this._PhysiotherapyOrderDetail.OrderObject).PhysiotherapyRequest;
            PhysiotherapyOrder phyOrder = ((PhysiotherapyOrder)this._PhysiotherapyOrderDetail.OrderObject);
            if(ifCheckedInPatientsBed == true)
            {
                Episode e = this._PhysiotherapyOrderDetail.Episode.Patient.InpatientEpisode;
                if(e != null)
                {
                    if(phyRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        phyRequest.InpatientBed = e.Bed;
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
                                    if(phyRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        phyRequest.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                    if(phyOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        phyOrder.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                    if(this._PhysiotherapyOrderDetail.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        this._PhysiotherapyOrderDetail.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                }
                            }
                        }
                    }
                    else
                    {
                        if(phyRequest.InpatientBed != null)
                        {
                            this.Bed.SelectedObject = phyRequest.InpatientBed;
                            this.Room.SelectedObject = phyRequest.InpatientBed.Room;
                            this.RoomGroup.SelectedObject = phyRequest.InpatientBed.Room.RoomGroup;
                            this.PhysicalStateClinic.SelectedObject = phyRequest.InpatientBed.Room.RoomGroup.Ward;
                        }
                    }
                }
                else
                {
                    if(phyRequest.InpatientBed != null)
                    {
                        this.Bed.SelectedObject = phyRequest.InpatientBed;
                        this.Room.SelectedObject = phyRequest.InpatientBed.Room;
                        this.RoomGroup.SelectedObject = phyRequest.InpatientBed.Room.RoomGroup;
                        this.PhysicalStateClinic.SelectedObject = phyRequest.InpatientBed.Room.RoomGroup.Ward;
                    }
                }
            }
        }
        
#endregion PhysiotherapyOrderDetailForm_Methods
    }
}