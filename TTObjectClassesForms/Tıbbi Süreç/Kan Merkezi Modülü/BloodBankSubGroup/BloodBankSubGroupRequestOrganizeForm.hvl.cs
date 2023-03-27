
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
    /// Kan Bankası Alt Grup Test İstek Düzenleme Ekranı
    /// </summary>
    public partial class BloodBankSubGroupRequestOrganizeForm : EpisodeActionForm
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
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("b425aeb9-fa8a-4f3a-85d3-d3ce4c3cd956"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("e075662e-ead4-46f8-a8be-869cac564386"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("243a82fa-78b2-4223-a84a-17c36e557d27"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("71aeb97b-6a44-4b80-8cca-3a449505d236"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("23d172e0-c71d-4ffc-8295-4574b8b2ac87"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e9190a7b-2111-40a1-b8f6-6d1773729d9c"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("bb7c7e59-ac44-4fb8-9963-a6d3ca68da81"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("2d3525f6-1bf3-4c14-a820-40f83baec012"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("fb566a49-081c-4d26-8928-4d5c12e66751"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("d0fd51c4-c856-4033-bb5a-122e1803a755"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("798702d5-8f23-47db-8ddd-8bd921b5df27"));
            base.InitializeControls();
        }

        public BloodBankSubGroupRequestOrganizeForm() : base("BLOODBANKSUBGROUP", "BloodBankSubGroupRequestOrganizeForm")
        {
        }

        protected BloodBankSubGroupRequestOrganizeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}