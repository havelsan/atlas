
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
    public partial class PoliclinicRoomDefinitionForm : TTForm
    {
    /// <summary>
    /// Poliklinik Oda Tanımları
    /// </summary>
        protected TTObjectClasses.ResPoliclinicRoom _ResPoliclinicRoom
        {
            get { return (TTObjectClasses.ResPoliclinicRoom)_ttObject; }
        }

        protected ITTLabel lblPoliclinic;
        protected ITTObjectListBox Policlinic;
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
            lblPoliclinic = (ITTLabel)AddControl(new Guid("ac15e452-e586-46df-a988-f12ee5f7e374"));
            Policlinic = (ITTObjectListBox)AddControl(new Guid("cd370619-8ca4-4995-b696-95322119e57f"));
            labelQref = (ITTLabel)AddControl(new Guid("39394bc9-6243-4420-bcc3-5085376d97b4"));
            Qref = (ITTTextBox)AddControl(new Guid("09c0ec3d-348d-4e6f-84c4-0a412a3b1515"));
            Name = (ITTTextBox)AddControl(new Guid("7d820c51-e069-41e1-a61a-88992f0bf920"));
            Location = (ITTTextBox)AddControl(new Guid("eaf339d8-7ea5-411a-b255-50512326d2d8"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("207c8f5e-f81d-4a94-b72d-552f7b79bf7b"));
            labelName = (ITTLabel)AddControl(new Guid("e40c57c7-b531-40e1-953c-8a74499f1c7a"));
            Active = (ITTCheckBox)AddControl(new Guid("3edf6208-d3b6-4f32-9c1a-478b97a297c5"));
            labelLocation = (ITTLabel)AddControl(new Guid("18083a7a-671d-4327-bde8-05f38d2daa40"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("c196d182-a5de-4f98-8738-66a803f3f108"));
            base.InitializeControls();
        }

        public PoliclinicRoomDefinitionForm() : base("RESPOLICLINICROOM", "PoliclinicRoomDefinitionForm")
        {
        }

        protected PoliclinicRoomDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}