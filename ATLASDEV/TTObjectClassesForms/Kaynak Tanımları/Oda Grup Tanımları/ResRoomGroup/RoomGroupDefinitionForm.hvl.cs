
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
    /// Oda Grubu Tanımı
    /// </summary>
    public partial class RoomGroupDefinitionForm : TTForm
    {
    /// <summary>
    /// Oda Grup
    /// </summary>
        protected TTObjectClasses.ResRoomGroup _ResRoomGroup
        {
            get { return (TTObjectClasses.ResRoomGroup)_ttObject; }
        }

        protected ITTLabel labelWard;
        protected ITTObjectListBox Ward;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelWard = (ITTLabel)AddControl(new Guid("52724c14-9caa-4b34-9b25-9f85882ca29f"));
            Ward = (ITTObjectListBox)AddControl(new Guid("487f29f3-5835-4e54-9378-81f5699168c7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3df7e3b4-c48f-434d-869c-37a682c31bec"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c37ea41c-80a2-4c04-b4dc-4a6e11e09da0"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("b21a993b-50a3-4c59-9f72-9b5054c7da64"));
            Location = (ITTTextBox)AddControl(new Guid("1410e3b2-63c1-4064-afda-929e60bc1af4"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("fade3f90-b89b-47f5-a799-fdf3b7458a4c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("10424e71-bb1f-468a-a0b7-9a6136745ec5"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("2d570a11-a64f-4c7a-a230-2984871dceaf"));
            labelStore = (ITTLabel)AddControl(new Guid("72679f2a-f87f-4b26-b2ad-00209f532f76"));
            Store = (ITTObjectListBox)AddControl(new Guid("a9fe5496-5fb6-4c3f-9730-e2dea8e3d328"));
            labelLocation = (ITTLabel)AddControl(new Guid("cc0290b3-5fd7-4bf6-be76-1d81178c8ba0"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("4e197c54-681c-45d8-9e5b-b84fa0d8af7e"));
            base.InitializeControls();
        }

        public RoomGroupDefinitionForm() : base("RESROOMGROUP", "RoomGroupDefinitionForm")
        {
        }

        protected RoomGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}