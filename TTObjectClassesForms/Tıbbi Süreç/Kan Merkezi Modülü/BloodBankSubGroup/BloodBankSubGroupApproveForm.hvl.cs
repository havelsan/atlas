
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
    /// Kan Bankası Alt Grup Test Onay Ekranı
    /// </summary>
    public partial class BloodBankSubGroupApproveForm : EpisodeActionForm
    {
    /// <summary>
    /// Alt Grup
    /// </summary>
        protected TTObjectClasses.BloodBankSubGroup _BloodBankSubGroup
        {
            get { return (TTObjectClasses.BloodBankSubGroup)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistbox1;
        protected ITTTextBoxColumn tttexbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("859d3083-14ee-4db6-9c35-0d539218f6de"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("330c7b99-6da9-4089-b2cc-a0f10532a8ea"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("ebb567ff-b9c9-4b5f-aec1-543325736546"));
            ttlistbox1 = (ITTListBoxColumn)AddControl(new Guid("73bdb8df-04b4-49b6-9435-5be906e8f37a"));
            tttexbox1 = (ITTTextBoxColumn)AddControl(new Guid("690df083-8659-473e-9a4c-b7b4714d851a"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("9faefdbe-02a1-47b9-b259-4812b3557605"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a01d4026-d891-48a6-bef6-7a5983be2ed0"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1aef841d-8ba9-4889-8583-9a078c8d2b85"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("cee49617-7c9c-44a2-a074-a81e2b39e8b5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("61fee98d-3bf5-4a2a-8fdb-e6813b0bbb90"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0878244b-9c5f-487d-9720-f20ae131fd4b"));
            base.InitializeControls();
        }

        public BloodBankSubGroupApproveForm() : base("BLOODBANKSUBGROUP", "BloodBankSubGroupApproveForm")
        {
        }

        protected BloodBankSubGroupApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}