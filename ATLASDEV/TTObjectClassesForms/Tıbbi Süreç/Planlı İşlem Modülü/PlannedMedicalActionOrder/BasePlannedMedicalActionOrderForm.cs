
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
    public partial class BasePlannedMedicalActionOrderForm : EpisodeActionForm
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
#region BasePlannedMedicalActionOrderForm_PreScript
    base.PreScript();
            FillInpatientLists(this._PlannedMedicalActionOrder.PlannedMedicalActionRequest.InPatientsBed);
#endregion BasePlannedMedicalActionOrderForm_PreScript

            }
            
#region BasePlannedMedicalActionOrderForm_Methods
        protected void FillInpatientLists(bool? ifCheckedInPatientsBed)
        {
            if(ifCheckedInPatientsBed == true)
            {
                PlannedMedicalActionRequest pmaRequest = this._PlannedMedicalActionOrder.PlannedMedicalActionRequest;
                Episode e = this._PlannedMedicalActionOrder.Episode.Patient.InpatientEpisode;
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
                                    if(this._PlannedMedicalActionOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        this._PlannedMedicalActionOrder.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
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
        
#endregion BasePlannedMedicalActionOrderForm_Methods
    }
}