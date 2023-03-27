
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
    public partial class BasePhysiotherapyOrderForm : EpisodeActionForm
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
#region BasePhysiotherapyOrderForm_PreScript
    base.PreScript();
            FillInpatientLists(this._PhysiotherapyOrder.PhysiotherapyRequest.InPatientsBed);
            //Klinik Bulgular
            Episode episode = this._PhysiotherapyOrder.Episode;
            String conResultAndOffers = "";
         
            int consultationCount = 1;
            TTObjectContext ctx = new TTObjectContext(true);
            
            IBindingList specialityList = SpecialityDefinition.GetSpecialityByCode(ctx, "1800");
            IBindingList consultationList = ConsultationProcedure.GetConsultationProcedureByEpisode(ctx, episode.ObjectID);


            string klinikBulgular = String.Empty;
            if (episode.Complaint != null)
                klinikBulgular += "ŞİKAYETİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.Complaint.ToString()) + "\r\n";
            if (episode.PatientHistory != null)
                klinikBulgular += "HİKAYESİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.PatientHistory.ToString()) + "\r\n";
            if (episode.PhysicalExamination != null)
                klinikBulgular += "FİZİK MUAYENE : " + TTObjectClasses.Common.GetTextOfRTFString(episode.PhysicalExamination.ToString()) + "\r\n";
            if (episode.ExaminationSummary != null)
                klinikBulgular += "MUAYENE ÖZETİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.ExaminationSummary.ToString()) + "\r\n";


            foreach (ConsultationProcedure consultation in consultationList)
            {
                string scode = "";
                string speCode = "";
                if (consultation.Consultation.ConsultationResultAndOffers != null)
                {
                    conResultAndOffers = Convert.ToString(consultation.Consultation.ConsultationResultAndOffers);
                    if (consultationCount == 1)
                    {
                        klinikBulgular += "KOSÜLTASYON SONUÇ VE ÖNERİLERİ : ";
                        consultationCount++;
                    }


                    foreach (ResourceSpecialityGrid resSpeciality in consultation.Consultation.MasterResource.ResourceSpecialities)
                    {

                        foreach (SpecialityDefinition specialityDef in specialityList)
                        {
                            if (specialityDef.Name != null)
                                speCode = (specialityDef.Name).ToString();
                        }

                        if (resSpeciality.Speciality != null)
                            scode = (resSpeciality.Speciality).ToString();
                        if (speCode.Equals(scode))
                            klinikBulgular += TTObjectClasses.Common.GetTextOfRTFString(conResultAndOffers) + "\r\n";

                    }
                }
            }
            if (klinikBulgular != null && klinikBulgular != "")
                this.ClinicInformationRTFPhysiotherapyRequest.Text = klinikBulgular;
#endregion BasePhysiotherapyOrderForm_PreScript

            }
            
#region BasePhysiotherapyOrderForm_Methods
        protected void FillInpatientLists(bool? ifCheckedInPatientsBed)
        {
            if (ifCheckedInPatientsBed == true)
            {
                PhysiotherapyRequest phyRequest = this._PhysiotherapyOrder.PhysiotherapyRequest;
                Episode e = this._PhysiotherapyOrder.Episode.Patient.InpatientEpisode;
                if (e != null)
                {
                    if (phyRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        phyRequest.InpatientBed = e.Bed;
                    this.Bed.SelectedObject = e.Bed;
                    if (e.Bed != null)
                    {
                        this.Room.SelectedObject = e.Bed.Room;
                        if (e.Bed.Room != null)
                        {
                            this.RoomGroup.SelectedObject = e.Bed.Room.RoomGroup;
                            if (e.Bed.Room.RoomGroup != null)
                            {
                                this.PhysicalStateClinic.SelectedObject = e.Bed.Room.RoomGroup.Ward;
                                if (e.Bed.Room.RoomGroup.Ward != null)
                                {
                                    if (phyRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        phyRequest.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                    if (this._PhysiotherapyOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        this._PhysiotherapyOrder.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (phyRequest.InpatientBed != null)
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
                    if (phyRequest.InpatientBed != null)
                    {
                        this.Bed.SelectedObject = phyRequest.InpatientBed;
                        this.Room.SelectedObject = phyRequest.InpatientBed.Room;
                        this.RoomGroup.SelectedObject = phyRequest.InpatientBed.Room.RoomGroup;
                        this.PhysicalStateClinic.SelectedObject = phyRequest.InpatientBed.Room.RoomGroup.Ward;
                    }
                }
            }
        }
        
#endregion BasePhysiotherapyOrderForm_Methods
    }
}