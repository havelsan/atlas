
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
    /// Oda Tanımı
    /// </summary>
    public partial class RoomDefinitionForm : TTForm
    {
    /// <summary>
    /// Oda
    /// </summary>
        protected TTObjectClasses.ResRoom _ResRoom
        {
            get { return (TTObjectClasses.ResRoom)_ttObject; }
        }

        protected ITTLabel labelRoomGroup;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelRoomGroup = (ITTLabel)AddControl(new Guid("38d006b3-e5f8-46c5-a656-cc44e20b02ff"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("313bc091-0cc3-49c6-a5be-4d4b17020f1f"));
            labelQref = (ITTLabel)AddControl(new Guid("36d5b5f9-34a5-40c9-8b7d-33275b024b2f"));
            Qref = (ITTTextBox)AddControl(new Guid("335cc8b9-6155-4eb3-b125-79fd9a72b7da"));
            Name = (ITTTextBox)AddControl(new Guid("f3179522-4d16-47c9-8760-588f16b3380e"));
            Location = (ITTTextBox)AddControl(new Guid("dcffd056-c65f-4b91-8023-668dcbfa9a03"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("6e9aeb0b-6e7c-4ee8-9a07-54f33fe0e4b3"));
            labelName = (ITTLabel)AddControl(new Guid("acdf4110-9372-4599-813b-2a5d9f1e0d7b"));
            Active = (ITTCheckBox)AddControl(new Guid("3c3fe028-19c5-4927-afb4-9be1644947b8"));
            labelLocation = (ITTLabel)AddControl(new Guid("5690251a-55f4-4c67-ae79-9d582c4e733b"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("93673657-916b-4015-a50e-7d873758f102"));
            base.InitializeControls();
        }

        public RoomDefinitionForm() : base("RESROOM", "RoomDefinitionForm")
        {
        }

        protected RoomDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}