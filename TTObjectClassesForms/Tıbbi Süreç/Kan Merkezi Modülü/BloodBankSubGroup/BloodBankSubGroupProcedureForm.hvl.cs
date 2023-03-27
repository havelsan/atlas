
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
    /// Kan Bankası Alt Grup Test Prosedür Ekranı
    /// </summary>
    public partial class BloodBankSubGroupProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Alt Grup
    /// </summary>
        protected TTObjectClasses.BloodBankSubGroup _BloodBankSubGroup
        {
            get { return (TTObjectClasses.BloodBankSubGroup)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox3;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistbox1;
        protected ITTTextBoxColumn tttextbox1;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox texbox1289;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("51dda81f-9e40-485d-bff4-03acd1175d5a"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("83d9a7e0-8b79-4cf2-b54d-2ffe031219ac"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("7c748e9c-bd68-49c4-ae0a-5afc8867fed2"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("0ed0e407-e1db-49e0-a77e-8fac77a38402"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("4400e984-b91c-410b-b42c-563cc0b0aed8"));
            ttlistbox1 = (ITTListBoxColumn)AddControl(new Guid("33bba009-53b9-40cd-b86b-19323216036c"));
            tttextbox1 = (ITTTextBoxColumn)AddControl(new Guid("d0c06c88-8033-4f60-a25f-c7f9c2963db5"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("87bfa8cc-71c1-4af6-b152-92d3f717d1fb"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("a9cb3d7d-6c16-497f-a373-c7ab432e6033"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("040f6365-8738-4b6a-9f74-d0994af424f2"));
            texbox1289 = (ITTTextBox)AddControl(new Guid("946a1f5f-a20b-4009-a41c-f2c4c56627d0"));
            base.InitializeControls();
        }

        public BloodBankSubGroupProcedureForm() : base("BLOODBANKSUBGROUP", "BloodBankSubGroupProcedureForm")
        {
        }

        protected BloodBankSubGroupProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}