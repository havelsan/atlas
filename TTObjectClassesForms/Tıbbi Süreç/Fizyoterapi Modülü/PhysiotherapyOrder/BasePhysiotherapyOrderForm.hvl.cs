
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
    public partial class BasePhysiotherapyOrderForm : EpisodeActionForm
    {
    /// <summary>
    /// F.T.R. Emrinin Veridiği Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder
        {
            get { return (TTObjectClasses.PhysiotherapyOrder)_ttObject; }
        }

        protected ITTLabel labelClinicInformationRTFPhysiotherapyRequest;
        protected ITTRichTextBoxControl ClinicInformationRTFPhysiotherapyRequest;
        protected ITTCheckBox chkInPatientBed;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTObjectListBox Room;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox Bed;
        protected ITTLabel labelBed;
        override protected void InitializeControls()
        {
            labelClinicInformationRTFPhysiotherapyRequest = (ITTLabel)AddControl(new Guid("2839ab32-ec17-4563-8ab2-92e53bc4fde3"));
            ClinicInformationRTFPhysiotherapyRequest = (ITTRichTextBoxControl)AddControl(new Guid("2c7c4b38-97c4-43db-a5f5-dc889d553633"));
            chkInPatientBed = (ITTCheckBox)AddControl(new Guid("47705bf9-caaf-4088-b9ba-6c9825d14447"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("d69b904e-4b25-4c20-9719-d7532aff9b79"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("8ee14181-7bef-4ede-8008-61378df358a7"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("8acb4a89-dbed-4c70-9649-0c10f3dce59a"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("2129b405-9393-464f-8a7a-95695e13e72f"));
            Room = (ITTObjectListBox)AddControl(new Guid("76e38729-71bd-473b-8592-b73f38e0f01f"));
            labelRoom = (ITTLabel)AddControl(new Guid("9b4b5588-f6a0-4f11-92a5-39b824a62c28"));
            Bed = (ITTObjectListBox)AddControl(new Guid("de804d8b-6ad5-42f0-9056-516e2347e846"));
            labelBed = (ITTLabel)AddControl(new Guid("2e899f0d-b3f0-4db0-97a5-ec9eb33e4ba1"));
            base.InitializeControls();
        }

        public BasePhysiotherapyOrderForm() : base("PHYSIOTHERAPYORDER", "BasePhysiotherapyOrderForm")
        {
        }

        protected BasePhysiotherapyOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}