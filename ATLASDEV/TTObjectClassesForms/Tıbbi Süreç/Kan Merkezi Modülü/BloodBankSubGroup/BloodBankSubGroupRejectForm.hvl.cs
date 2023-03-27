
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
    /// Kan Bankası Alt Grup Test Red Ekranı
    /// </summary>
    public partial class BloodBankSubGroupRejectForm : EpisodeActionForm
    {
    /// <summary>
    /// Alt Grup
    /// </summary>
        protected TTObjectClasses.BloodBankSubGroup _BloodBankSubGroup
        {
            get { return (TTObjectClasses.BloodBankSubGroup)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistbox1;
        protected ITTTextBoxColumn tttextbox1;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox texbox1289;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("9a7e89ad-71ae-444c-bc37-0b961eee638d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("bbb921a2-6dfe-4040-8320-0ee67a69526c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("40560bce-8452-48b2-bae0-242dd84ce76c"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("37ae8896-c55a-4517-a484-780c95deca43"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("a66bec6e-4e87-4b39-978d-2542ecca8ec3"));
            ttlistbox1 = (ITTListBoxColumn)AddControl(new Guid("40a9376a-3b30-40dc-88ea-64e66d004e15"));
            tttextbox1 = (ITTTextBoxColumn)AddControl(new Guid("ad1d8009-b302-4ee9-9c8a-fdc841b2b397"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("dd61da0c-3426-4cf6-9193-5ec6b8048303"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("0b07255f-88d2-47c3-8464-89fe35948bb0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("48258cb6-ce10-4e27-9015-8c7951bfe0fe"));
            texbox1289 = (ITTTextBox)AddControl(new Guid("d0586d63-66bb-44ef-8532-c0d49807d9d7"));
            base.InitializeControls();
        }

        public BloodBankSubGroupRejectForm() : base("BLOODBANKSUBGROUP", "BloodBankSubGroupRejectForm")
        {
        }

        protected BloodBankSubGroupRejectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}