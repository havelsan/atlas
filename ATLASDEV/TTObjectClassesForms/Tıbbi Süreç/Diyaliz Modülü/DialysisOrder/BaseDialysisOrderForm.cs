
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
    public partial class BaseDialysisOrderForm : EpisodeActionForm
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
#region BaseDialysisOrderForm_PreScript
    base.PreScript();
            this.FillInpatientLists(this._DialysisOrder.DialysisRequest.InPatientsBed);
#endregion BaseDialysisOrderForm_PreScript

            }
            
#region BaseDialysisOrderForm_Methods
        protected void FillInpatientLists(bool? ifCheckedInPatientsBed)
        {
            if(ifCheckedInPatientsBed == true)
            {
                DialysisRequest diaRequest = this._DialysisOrder.DialysisRequest;
                Episode e = this._DialysisOrder.Episode.Patient.InpatientEpisode;
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
                                    if(this._DialysisOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        this._DialysisOrder.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
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
        
#endregion BaseDialysisOrderForm_Methods
    }
}