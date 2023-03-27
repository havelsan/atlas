
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
    /// Kan Bankası Alt Grup Test İstek Ekranı
    /// </summary>
    public partial class BloodBankSubGroupRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Alt Grup
    /// </summary>
        protected TTObjectClasses.BloodBankSubGroup _BloodBankSubGroup
        {
            get { return (TTObjectClasses.BloodBankSubGroup)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("741f39c4-f897-4e5b-a696-2c17c0db0575"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("44f075f7-762f-42be-8c02-09414f6765dd"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a15bbfa0-a94e-4cc3-b17f-21dbbd57ea48"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("7401defe-fe17-4870-b579-7bb2b10f13fd"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("f8c74b2e-4641-4592-a6af-02cba510c8bb"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("8615fb5f-4cfb-4683-a695-aec37d730304"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("a4194f36-b760-4bee-b9a6-f177216f2c1e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("155a7608-b8b6-4e5b-9cc2-cc38f5e243e3"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("7bb87068-92fc-47d7-8fda-fab25ac7d014"));
            base.InitializeControls();
        }

        public BloodBankSubGroupRequestForm() : base("BLOODBANKSUBGROUP", "BloodBankSubGroupRequestForm")
        {
        }

        protected BloodBankSubGroupRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}