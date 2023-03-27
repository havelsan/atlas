
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
    public partial class HdApproval1Form : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTEnumComboBox PurchaseMainType;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox1;
        protected ITTEnumComboBox ProcurementType;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTLabel ttlabel1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ItemDetailsGrid;
        protected ITTTextBoxColumn OrderNO;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTRichTextBoxControlColumn Isayf;
        protected ITTButtonColumn Details;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("b4c8b3ba-9034-49dc-9b50-ce07ff8d96e6"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("5ddcb76a-d822-4a58-a05b-4f7d80cdcafc"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("4e1e0177-1c49-4c34-8ec5-3605699f99a1"));
            PurchaseMainType = (ITTEnumComboBox)AddControl(new Guid("08c679e6-371b-4061-b45e-49357150aeff"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("03fc0d7f-a8ab-4afe-b76b-0375f0498cbf"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4c2ce4d1-ab1a-403a-bd2e-6d4336e7ba92"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("68d187e7-89fa-48b2-912a-040c1389108a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("37e46e48-10ba-494e-8256-bb2cf2cc1689"));
            ProcurementType = (ITTEnumComboBox)AddControl(new Guid("f80eb8d3-01e7-4cf1-ab97-8505903e6874"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("fa7e1b58-de47-4c30-852f-7c5013f445a3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("45d966e8-69ed-414c-a057-7ac4f735d49c"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("8bf4ed86-a069-4dc7-9a58-4535369cb8d5"));
            ItemDetailsGrid = (ITTGrid)AddControl(new Guid("6a8b1f85-ce8f-4f6c-9b92-ece3bf7d61e4"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("e4433b94-8b42-4c4c-bbbf-7bf2fcaee732"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("a5c52be0-d159-4d46-a808-d4e76115e8c5"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("e6406dd6-d71b-4682-94a0-da63c9badb91"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("dfda0432-81ef-4b68-b247-8e106b8680ed"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("0ae6f0b4-8655-46b3-aea5-cb3363d9f06d"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("a0765bd4-572b-46e8-bc99-7948ce9ae134"));
            Isayf = (ITTRichTextBoxControlColumn)AddControl(new Guid("945d1d27-803f-4874-a45b-87dcae93b9d7"));
            Details = (ITTButtonColumn)AddControl(new Guid("94ddc758-6a65-4633-85b7-27be5004c079"));
            base.InitializeControls();
        }

        public HdApproval1Form() : base("PURCHASEPROJECT", "HdApproval1Form")
        {
        }

        protected HdApproval1Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}