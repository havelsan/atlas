
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
    public partial class BaseDialysisOrderForm : EpisodeActionForm
    {
    /// <summary>
    /// Diyaliz Emrinin Verildiği Nesnedir.
    /// </summary>
        protected TTObjectClasses.DialysisOrder _DialysisOrder
        {
            get { return (TTObjectClasses.DialysisOrder)_ttObject; }
        }

        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTCheckBox chkInPatientBed;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTObjectListBox Room;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox Bed;
        protected ITTLabel labelBed;
        override protected void InitializeControls()
        {
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("ad918e40-41a9-44ae-ab2a-f7a805335106"));
            chkInPatientBed = (ITTCheckBox)AddControl(new Guid("86be8aee-83f8-40ac-8d5e-b0b3f2cb418d"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("dc486da1-ace1-4832-9211-868eaf4cc470"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("944287d8-8aaa-4765-a344-fc2abb15a889"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("393775d5-afb6-4715-8620-995c299f4366"));
            Room = (ITTObjectListBox)AddControl(new Guid("cd1ae5ee-ac5a-4de7-9f20-ec29f8c2d4bc"));
            labelRoom = (ITTLabel)AddControl(new Guid("34f0ff69-cf03-4917-812d-1a3c9123b399"));
            Bed = (ITTObjectListBox)AddControl(new Guid("ba5caf5f-bdc6-44b7-885f-b40979df0b28"));
            labelBed = (ITTLabel)AddControl(new Guid("1302a038-ab16-4541-9b37-24b075d2aa69"));
            base.InitializeControls();
        }

        public BaseDialysisOrderForm() : base("DIALYSISORDER", "BaseDialysisOrderForm")
        {
        }

        protected BaseDialysisOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}