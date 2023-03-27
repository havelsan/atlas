
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
    /// Diyaliz Uygulamaları
    /// </summary>
    public partial class DialysisOrderDetailForm : SubactionProcedureFlowableForm
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
#region DialysisOrderDetailForm_PreScript
    base.PreScript();
            this.FillInpatientLists(((DialysisOrder)this._DialysisOrderDetail.OrderObject).DialysisRequest.InPatientsBed);
            int index = 0;
            
            this.tttextboxDescription.Text = string.Empty;
            //TODO:pnlControls!
            //TextBox pDescriptionBox = (TextBox)this.pnlControls.Controls["tttextboxDescription"];
            //pDescriptionBox.ScrollBars= ScrollBars.Vertical;

            if (this._DialysisOrderDetail.GetStateHistory().Count > 1)
            {
                index = this._DialysisOrderDetail.GetStateHistory().Count-1;
                if(this._DialysisOrderDetail.GetStateHistory()[index].IsUndo == true || this._DialysisOrderDetail.CurrentStateDefID != DialysisOrderDetail.States.Execution)
                {
                    this.tttextboxDescription.Text = this.GetFullCompletedAppointmentDescription(this._DialysisOrderDetail);
                }
                else
                {
                    this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._DialysisOrderDetail);
                }
            }
            else
            {
                this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._DialysisOrderDetail);
            }
            
            if(this._DialysisOrderDetail.CurrentStateDefID == DialysisOrderDetail.States.Execution)
            {
                if (this._DialysisOrderDetail.PrevState != null)
                {
                    if(this._DialysisOrderDetail.PrevState.StateDefID == DialysisOrderDetail.States.ApprovalForCancel)
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
            else if (this._DialysisOrderDetail.CurrentStateDefID == DialysisOrderDetail.States.ApprovalForCancel)
            {
                if(this._DialysisOrderDetail.PrevState.PrevState != null)
                {
                    if (this._DialysisOrderDetail.PrevState.PrevState.StateDefID == DialysisOrderDetail.States.ApprovalForCancel)
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
            //DialysisOrder objesinin ProcedureDoctor u eskiden Hemsireydi, simdi istegi yapan doktor olarak set edildi.
            //DialysisOrderDetail in ProcedureDoctor u da istegi yapan doktor olarak set edildi.
            //asagidaki kodda DialysisOrderDetail in hemsire alani set edilecek. 
            
            //if (this._DialysisOrderDetail.OrderObject.ProcedureDoctor != null)
            //{
            //    this.ProcedureDoctor.SelectedObject = this._DialysisOrderDetail.OrderObject.ProcedureDoctor;
            //}
            
            
             if (this._DialysisOrderDetail.OrderObject.ProcedureByUser != null)
            {
                 if (this._DialysisOrderDetail.ProcedureByUser == null)
                    this.Nurse.SelectedObject = this._DialysisOrderDetail.OrderObject.ProcedureByUser;
            }
  
            
            if(((DialysisOrder)this._DialysisOrderDetail.OrderObject).DialysisRequest.ProcedureDoctor != null)
            {
                ResUser doctor = ((DialysisOrder)this._DialysisOrderDetail.OrderObject).DialysisRequest.ProcedureDoctor;
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
            
            if (this._DialysisOrderDetail.CurrentStateDefID == DialysisOrderDetail.States.Execution)
            {
                this._DialysisOrderDetail.ActionDate = Common.RecTime();
            }
            
            //this.cmdOK.Visible = false;
            
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["DialysisTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
            
            // SGK'lı hasta ise ProvisionRequest nesnesi yaratılır.
            TTObjectContext readOnlyContext = _DialysisOrderDetail.ObjectContext;
            if (SubEpisode.IsSGKSubEpisode(_DialysisOrderDetail.SubEpisode))
            {
                ProvisionRequest _provisionRequest = new ProvisionRequest(readOnlyContext);
                this._DialysisOrderDetail.ProvisionRequest = _provisionRequest;
            }
#endregion DialysisOrderDetailForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DialysisOrderDetailForm_PostScript
    base.PostScript(transDef);
#endregion DialysisOrderDetailForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region DialysisOrderDetailForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (transDef != null)
            {
                StringEntryForm rtfForm = new StringEntryForm();
                if(transDef.ToStateDefID == DialysisOrderDetail.States.ApprovalForCancel)
                {
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("İptal İstek Sebebi");
                    this.CancelRequestDescription.Text = this.CancelRequestDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
                else if (transDef.ToStateDefID == DialysisOrderDetail.States.Execution)
                {
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("Küre Devam İstek Sebebi");
                    this.DoctorReturnDescription.Text = this.DoctorReturnDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
                
                if (this._DialysisOrderDetail.ActionDate == null)
                    throw new Exception(SystemMessage.GetMessage(1178));
                
                if (this._DialysisOrderDetail.ProcedureSpeciality == null)
                    throw new Exception(SystemMessage.GetMessage(993));
            }
#endregion DialysisOrderDetailForm_ClientSidePostScript

        }

#region DialysisOrderDetailForm_Methods
        protected void FillInpatientLists(bool? ifCheckedInPatientsBed)
        {
            DialysisRequest diaRequest = ((DialysisOrder)this._DialysisOrderDetail.OrderObject).DialysisRequest;
            DialysisOrder diaOrder = ((DialysisOrder)this._DialysisOrderDetail.OrderObject);
            if(ifCheckedInPatientsBed == true)
            {
                Episode e = this._DialysisOrderDetail.Episode.Patient.InpatientEpisode;
                if(e != null)
                {
                    if(diaRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        diaRequest.InpatientBed = e.Bed;
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
                                    if(diaRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        diaRequest.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                    if(diaOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        diaOrder.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                    if(this._DialysisOrderDetail.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        this._DialysisOrderDetail.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                }
                            }
                        }
                    }
                    else
                    {
                        if(diaRequest.InpatientBed != null)
                        {
                            this.Bed.SelectedObject = diaRequest.InpatientBed;
                            this.Room.SelectedObject = diaRequest.InpatientBed.Room;
                            this.RoomGroup.SelectedObject = diaRequest.InpatientBed.Room.RoomGroup;
                            this.PhysicalStateClinic.SelectedObject = diaRequest.InpatientBed.Room.RoomGroup.Ward;
                        }
                    }
                }
                else
                {
                    if(diaRequest.InpatientBed != null)
                    {
                        this.Bed.SelectedObject = diaRequest.InpatientBed;
                        this.Room.SelectedObject = diaRequest.InpatientBed.Room;
                        this.RoomGroup.SelectedObject = diaRequest.InpatientBed.Room.RoomGroup;
                        this.PhysicalStateClinic.SelectedObject = diaRequest.InpatientBed.Room.RoomGroup.Ward;
                    }
                }
            }
        }
        
#endregion DialysisOrderDetailForm_Methods
    }
}