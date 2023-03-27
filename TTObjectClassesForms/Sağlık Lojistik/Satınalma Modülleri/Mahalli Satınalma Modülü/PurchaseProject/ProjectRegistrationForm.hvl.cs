
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
    public partial class ProjectRegistrationForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabProjectDetails;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTEnumComboBox PurchaseMainType;
        protected ITTEnumComboBox ProcurementType;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage tabAsministrativeSpecification;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdListDemands;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage ServicesTab;
        protected ITTGrid ResourcesGrid;
        protected ITTListBoxColumn Resource;
        protected ITTTabPage ItemsTab;
        protected ITTGrid ItemsGrid;
        protected ITTListBoxColumn PurchaseItem2;
        protected ITTGroupBox ttgroupbox1;
        protected ITTButton cmdUncheckAll;
        protected ITTButton cmdCheckAll;
        protected ITTGrid ItemDetailsGrid;
        protected ITTCheckBoxColumn Include;
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
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e8f7f07c-02d8-4ea1-a746-3c7893983401"));
            tabProjectDetails = (ITTTabPage)AddControl(new Guid("0aa91e64-d743-4673-b3da-db60c4abc6f5"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("81445e6b-e391-47a4-ba63-4324f668d62d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("bb596467-83aa-472d-896e-702475c53602"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b4117547-a33c-4e84-a41f-479baeb19bc5"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("a63668b5-4236-47a1-abca-31e18db9ca09"));
            PurchaseMainType = (ITTEnumComboBox)AddControl(new Guid("bf2074ac-dde3-42b8-be04-fddd9ed94d1e"));
            ProcurementType = (ITTEnumComboBox)AddControl(new Guid("26b1dadf-5b84-4c94-a269-24e3d158e935"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3489eed8-fb56-4230-8f83-ff615af09247"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2f7613d5-fe93-4839-8fcc-7cf983dc2a42"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("de0b9d67-aea4-482e-82a1-fec5836ccd7c"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("20a32622-7282-439b-841b-78a46c3c299a"));
            tabAsministrativeSpecification = (ITTTabPage)AddControl(new Guid("c7f96d2f-116e-4fb6-ab16-1219c7d31134"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("4f60841a-adb7-4b10-bb74-eb8c23364ae7"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("eec20a04-d80b-4f9f-9c79-1917cca51021"));
            cmdListDemands = (ITTButton)AddControl(new Guid("3763241e-7496-4f21-9b09-4a1391a4e84a"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("be2502be-13b2-458b-a5d5-cedaed5e32a4"));
            ServicesTab = (ITTTabPage)AddControl(new Guid("747092b6-0133-4b5e-866e-0fea59352f33"));
            ResourcesGrid = (ITTGrid)AddControl(new Guid("5dea7178-c0c6-4f99-aabe-140df119947a"));
            Resource = (ITTListBoxColumn)AddControl(new Guid("16c5f91d-bc0a-47cd-a978-e451f0ed78d1"));
            ItemsTab = (ITTTabPage)AddControl(new Guid("8c7fdffa-7a5a-40bc-afec-a3958165dc5c"));
            ItemsGrid = (ITTGrid)AddControl(new Guid("d702d2fc-37ba-4929-aa6f-8f79129d0106"));
            PurchaseItem2 = (ITTListBoxColumn)AddControl(new Guid("f2aac0ce-469c-4a04-9cc7-6dda9d8c79ed"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("d6610148-1c9d-4c2a-89cb-7c710e9dfb4d"));
            cmdUncheckAll = (ITTButton)AddControl(new Guid("e031a5f0-cfbf-44c5-a764-439f1b1924f0"));
            cmdCheckAll = (ITTButton)AddControl(new Guid("39a2ae06-a673-4fc7-bf20-f4b914e30df3"));
            ItemDetailsGrid = (ITTGrid)AddControl(new Guid("d45fb737-79f2-42e1-aa0a-6cb1f62175d5"));
            Include = (ITTCheckBoxColumn)AddControl(new Guid("d4d99fbb-742b-4672-bf1e-98b7141c49b5"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("4f8ff2cd-2228-4e88-a6d3-7dd22291baab"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("86d93b5f-236c-4c53-83a9-64efdcca1b59"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("0fd1ee6a-57a6-441e-88cc-8f92817b9cf0"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("0766c819-6bd5-4c8f-932b-f9e00ad453a3"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("8fb453c6-a148-413a-83d2-e3f1abda3155"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("5b1b9c4b-35d8-47a9-9024-760f1c865126"));
            Isayf = (ITTRichTextBoxControlColumn)AddControl(new Guid("d17e27ea-56db-49f7-b984-35acc5c0b345"));
            Details = (ITTButtonColumn)AddControl(new Guid("21582b11-3bae-45c9-b76a-349c161ef875"));
            base.InitializeControls();
        }

        public ProjectRegistrationForm() : base("PURCHASEPROJECT", "ProjectRegistrationForm")
        {
        }

        protected ProjectRegistrationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}