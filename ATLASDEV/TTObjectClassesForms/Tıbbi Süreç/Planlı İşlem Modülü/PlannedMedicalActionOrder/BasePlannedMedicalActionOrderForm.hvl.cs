
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class BasePlannedMedicalActionOrderForm : EpisodeActionForm
    {
    /// <summary>
    /// Planlı Tıbbi İşlem Emri
    /// </summary>
        protected TTObjectClasses.PlannedMedicalActionOrder _PlannedMedicalActionOrder
        {
            get { return (TTObjectClasses.PlannedMedicalActionOrder)_ttObject; }
        }

        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTObjectListBox Room;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox Bed;
        protected ITTLabel labelBed;
        protected ITTCheckBox chkInPatientBed;
        override protected void InitializeControls()
        {
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("65fb72e4-78dc-419a-b205-4b4ab11d1587"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("ffcb5c8c-a123-4e56-bd45-c4964fc92c28"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("6a46b629-01cc-49fa-b813-d556640d501b"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("b683819b-79b8-40dd-9c1f-3824c9e69549"));
            Room = (ITTObjectListBox)AddControl(new Guid("ee69c10a-741c-45cf-95f0-05c820fb32fc"));
            labelRoom = (ITTLabel)AddControl(new Guid("abc199fb-9e15-4d43-acf5-625c3e61e0ce"));
            Bed = (ITTObjectListBox)AddControl(new Guid("80b0d17b-03c6-4f62-8203-a061b9eec6f5"));
            labelBed = (ITTLabel)AddControl(new Guid("d611fe9a-3172-4511-b4ea-4403814fb85f"));
            chkInPatientBed = (ITTCheckBox)AddControl(new Guid("7602bf9e-5834-4107-bd21-fb1b80669280"));
            base.InitializeControls();
        }

        public BasePlannedMedicalActionOrderForm() : base("PLANNEDMEDICALACTIONORDER", "BasePlannedMedicalActionOrderForm")
        {
        }

        protected BasePlannedMedicalActionOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}