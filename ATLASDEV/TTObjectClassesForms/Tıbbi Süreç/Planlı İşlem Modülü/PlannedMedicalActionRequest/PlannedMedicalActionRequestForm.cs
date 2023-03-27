
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
    public partial class PlannedMedicalActionRequestForm : EpisodeActionForm
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
#region PlannedMedicalActionRequestForm_PreScript
    base.PreScript();
            
            if (this._PlannedMedicalActionRequest.CurrentStateDefID == PlannedMedicalActionRequest.States.Request)
            {
                this.labelProtocolNo.Visible = false;
                this.ProtocolNo.Visible = false;
            }
            else
            {
                this.labelProtocolNo.Visible = true;
                this.ProtocolNo.Visible = true;
            }
            
            this.SetProcedureDoctorAsCurrentResource();
            //this.cmdOK.Visible = false;
            
            if(this._PlannedMedicalActionRequest.Episode.Patient.InpatientEpisode == null && this._PlannedMedicalActionRequest.InPatientsBed == false)
            {
                this.chkInPatientBed.Visible = false;
                this.labelPhysicalStateClinic.Visible = false;
                this.PhysicalStateClinic.Visible = false;
                this.labelRoomGroup.Visible = false;
                this.RoomGroup.Visible = false;
                this.labelRoom.Visible = false;
                this.Room.Visible = false;
                this.labelBed.Visible = false;
                this.Bed.Visible = false;
            }
            else
            {
                this.chkInPatientBed.Visible = true;
                this.labelPhysicalStateClinic.Visible = true;
                this.PhysicalStateClinic.Visible = true;
                this.labelRoomGroup.Visible = true;
                this.RoomGroup.Visible = true;
                this.labelRoom.Visible = true;
                this.Room.Visible = true;
                this.labelBed.Visible = true;
                this.Bed.Visible = true;
            }
            this.FillInpatientLists(this.chkInPatientBed.Value);
           
            //Klinik Bulgular
            Episode episode = this._PlannedMedicalActionRequest.Episode;           
            String conResultAndOffers = "";
            Guid EPISODE = new Guid();
                 EPISODE = this._PlannedMedicalActionRequest.Episode.ObjectID;
                 string CODE = "1800";
           int consultationCount = 1;                
           TTObjectContext ctx = new TTObjectContext(true);
           IBindingList specialityList = SpecialityDefinition.GetSpecialityByCode(ctx,CODE);
           IBindingList consultationList = ConsultationProcedure.GetConsultationProcedureByEpisode(ctx,EPISODE);

            string klinikBulgular = "";
            if(episode.Complaint != null)
                klinikBulgular += "ŞİKAYETİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.Complaint.ToString()) + "\r\n";
            if(episode.PatientHistory != null)
                klinikBulgular += "HİKAYESİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.PatientHistory.ToString()) + "\r\n";
            if(episode.PhysicalExamination != null)
                klinikBulgular += "FİZİK MUAYENE : " + TTObjectClasses.Common.GetTextOfRTFString(episode.PhysicalExamination.ToString())+ "\r\n";
            if(episode.ExaminationSummary != null)
                klinikBulgular += "MUAYENE ÖZETİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.ExaminationSummary.ToString())+ "\r\n";

            
            foreach(ConsultationProcedure consultation in consultationList)
            {
               string scode = "";
               string speCode = "";
               if(consultation.Consultation.ConsultationResultAndOffers != null)
               {
                   conResultAndOffers = Convert.ToString(consultation.Consultation.ConsultationResultAndOffers);
                   if(consultationCount ==1 )
                   {
                        klinikBulgular += "KOSÜLTASYON SONUÇ VE ÖNERİLERİ : ";  
                        consultationCount ++;
                   }
               
              
                    foreach (ResourceSpecialityGrid resSpeciality in consultation.Consultation.MasterResource.ResourceSpecialities)
                    {
                   
                        foreach (SpecialityDefinition specialityDef in specialityList)
                        {
                            if(specialityDef.Name != null)
                             speCode = (specialityDef.Name).ToString();
                        }
                   
                        if(resSpeciality.Speciality != null)
                            scode = (resSpeciality.Speciality).ToString();
                        if(speCode.Equals(scode))
                            klinikBulgular += TTObjectClasses.Common.GetTextOfRTFString(conResultAndOffers)+ "\r\n";
                   
                    }
               }
            }
            //ClinicFindings.Text = klinikBulgular;
             if(klinikBulgular != null && klinikBulgular != "")
                this.ClinicInfoRTF.Text  = klinikBulgular;
#endregion PlannedMedicalActionRequestForm_PreScript

            }
            
#region PlannedMedicalActionRequestForm_Methods
        protected void FillInpatientLists(bool? ifCheckedInPatientsBed)
        {
            if(ifCheckedInPatientsBed == true)
            {
                Episode e = this._PlannedMedicalActionRequest.Episode.Patient.InpatientEpisode;
                if(e != null)
                {
                    this.Bed.SelectedObject = e.Bed;
                    if(e.Bed != null)
                    {
                        if(this._PlannedMedicalActionRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            this._PlannedMedicalActionRequest.InpatientBed = e.Bed;
                        this.Room.SelectedObject = e.Bed.Room;
                        if(e.Bed.Room != null)
                        {
                            this.RoomGroup.SelectedObject = e.Bed.Room.RoomGroup;
                            if(e.Bed.Room.RoomGroup != null)
                            {
                                this.PhysicalStateClinic.SelectedObject = e.Bed.Room.RoomGroup.Ward;
                                if(e.Bed.Room.RoomGroup.Ward !=null)
                                {
                                    if(this._PlannedMedicalActionRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        this._PlannedMedicalActionRequest.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                }
                            }
                        }
                    }
                    else
                    {
                        if(this._PlannedMedicalActionRequest.InpatientBed != null)
                        {
                            this.Bed.SelectedObject = this._PlannedMedicalActionRequest.InpatientBed;
                            this.Room.SelectedObject = this._PlannedMedicalActionRequest.InpatientBed.Room;
                            this.RoomGroup.SelectedObject = this._PlannedMedicalActionRequest.InpatientBed.Room.RoomGroup;
                            this.PhysicalStateClinic.SelectedObject = this._PlannedMedicalActionRequest.InpatientBed.Room.RoomGroup.Ward;
                        }
                    }
                }
                else
                {
                    if(this._PlannedMedicalActionRequest.InpatientBed != null)
                    {
                        this.Bed.SelectedObject = this._PlannedMedicalActionRequest.InpatientBed;
                        this.Room.SelectedObject = this._PlannedMedicalActionRequest.InpatientBed.Room;
                        this.RoomGroup.SelectedObject = this._PlannedMedicalActionRequest.InpatientBed.Room.RoomGroup;
                        this.PhysicalStateClinic.SelectedObject = this._PlannedMedicalActionRequest.InpatientBed.Room.RoomGroup.Ward;
                    }
                }
            }
            else
            {
                this.Bed.SelectedObject = null;
                this.Room.SelectedObject = null;
                this.RoomGroup.SelectedObject = null;
                this.PhysicalStateClinic.SelectedObject = null;
                this._PlannedMedicalActionRequest.SecondaryMasterResource = null;
                this._PlannedMedicalActionRequest.InpatientBed = null;
                
            }
        }
        
#endregion PlannedMedicalActionRequestForm_Methods
    }
}