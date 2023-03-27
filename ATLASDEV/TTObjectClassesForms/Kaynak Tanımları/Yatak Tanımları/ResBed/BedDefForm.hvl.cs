
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
    /// <summary>
    /// Yatak Tanımlama
    /// </summary>
    public partial class BedDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Yatak
    /// </summary>
        protected TTObjectClasses.ResBed _ResBed
        {
            get { return (TTObjectClasses.ResBed)_ttObject; }
        }

        protected ITTLabel labelOrder;
        protected ITTTextBox Order;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTCheckBox ttcheckbox2;
        protected ITTCheckBox IsVentilator;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox Room;
        protected ITTLabel labelBedProcedure;
        protected ITTObjectListBox BedProcedure;
        protected ITTLabel labelWardResRoomGroup;
        protected ITTObjectListBox WardResRoomGroup;
        protected ITTLabel labelRoomGroupResRoom;
        protected ITTObjectListBox RoomGroupResRoom;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelOrder = (ITTLabel)AddControl(new Guid("de19a1ab-7d51-4aec-b6d5-98e38c3969a1"));
            Order = (ITTTextBox)AddControl(new Guid("c99eded5-3f2f-41dc-9543-63bb0f11edcd"));
            Qref = (ITTTextBox)AddControl(new Guid("e21786f1-07ac-4988-8f2f-147717869ffe"));
            Name = (ITTTextBox)AddControl(new Guid("8e852be5-5f50-4a4a-ac59-bd26238b0f91"));
            Location = (ITTTextBox)AddControl(new Guid("2e892ac2-7249-4232-86d7-e82e40eadda2"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("1c630e66-8a4e-497d-88c9-ead580a319ac"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("379c42c1-41df-4923-aea4-02ba924857af"));
            IsVentilator = (ITTCheckBox)AddControl(new Guid("4d569e0f-c543-4ca4-9925-5cada20e0d05"));
            labelRoom = (ITTLabel)AddControl(new Guid("33aba74b-22b6-43a4-8b1f-1c7523d7a433"));
            Room = (ITTObjectListBox)AddControl(new Guid("dcc5715b-6002-4371-a6de-5cdd7b41b802"));
            labelBedProcedure = (ITTLabel)AddControl(new Guid("087adc52-7c15-444e-9a53-901e646ce02e"));
            BedProcedure = (ITTObjectListBox)AddControl(new Guid("073983f7-55f4-4336-9f26-2fbcefc495ae"));
            labelWardResRoomGroup = (ITTLabel)AddControl(new Guid("d360f56a-fcc0-46bd-9938-e2d1b6d18f7a"));
            WardResRoomGroup = (ITTObjectListBox)AddControl(new Guid("8bc7be81-2a4d-42bb-a786-c5cd27804bb5"));
            labelRoomGroupResRoom = (ITTLabel)AddControl(new Guid("7c2356a3-3237-4605-a69a-ed8fb70c2509"));
            RoomGroupResRoom = (ITTObjectListBox)AddControl(new Guid("ee101f56-5ee4-49b3-b4de-982d4e0568b3"));
            labelQref = (ITTLabel)AddControl(new Guid("aef26e97-72f0-4e69-8157-0e5b30c53ed1"));
            labelName = (ITTLabel)AddControl(new Guid("08d79f37-4e25-4939-b8c0-ef6911436e84"));
            labelLocation = (ITTLabel)AddControl(new Guid("2c87814a-418a-48a8-a860-0224cb94f6e2"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("51707345-7b7d-4b0c-84db-82bf3f00e61c"));
            base.InitializeControls();
        }

        public BedDefForm() : base("RESBED", "BedDefForm")
        {
        }

        protected BedDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}