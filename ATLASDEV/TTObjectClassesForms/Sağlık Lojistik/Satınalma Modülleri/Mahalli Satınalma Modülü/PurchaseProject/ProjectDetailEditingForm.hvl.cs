
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
    public partial class ProjectDetailEditingForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTButton cmdExclude;
        protected ITTButton cmdAdd;
        protected ITTLabel ttlabel1;
        protected ITTGrid DetailsGrid2;
        protected ITTCheckBoxColumn Selected2;
        protected ITTListBoxColumn PItem2;
        protected ITTTextBoxColumn Amount2;
        protected ITTButtonColumn Delete2;
        protected ITTGrid AvailableProjectsGrid;
        protected ITTTextBoxColumn ProjectNo;
        protected ITTTextBoxColumn ProjectGuid;
        protected ITTGrid DetailsGrid;
        protected ITTCheckBoxColumn Selected;
        protected ITTListBoxColumn PItem;
        protected ITTTextBoxColumn Amount;
        override protected void InitializeControls()
        {
            cmdExclude = (ITTButton)AddControl(new Guid("f913ac72-f353-4983-a108-442502a4d874"));
            cmdAdd = (ITTButton)AddControl(new Guid("146d02fb-ae5d-46b8-9891-62fbae24454a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("76168baf-c7e0-4ea2-b9ec-c3c9d67654c9"));
            DetailsGrid2 = (ITTGrid)AddControl(new Guid("84a892a6-d235-4821-a859-66d37b43729d"));
            Selected2 = (ITTCheckBoxColumn)AddControl(new Guid("4d74cb67-f6f2-4c89-9ed5-685ab2d87666"));
            PItem2 = (ITTListBoxColumn)AddControl(new Guid("0a5f0ab7-9896-4b1f-a7c3-f7cc410c60e3"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("84a78af3-b7e1-408e-8b99-894f496f6447"));
            Delete2 = (ITTButtonColumn)AddControl(new Guid("44837206-c123-4844-98c3-6ca3b16551de"));
            AvailableProjectsGrid = (ITTGrid)AddControl(new Guid("6ef8f4a0-02cb-4130-a4f9-b7fdae9b5787"));
            ProjectNo = (ITTTextBoxColumn)AddControl(new Guid("68f9f7a0-1eda-40df-be02-0f3ce4ded2fe"));
            ProjectGuid = (ITTTextBoxColumn)AddControl(new Guid("deb85a6b-15c9-4d62-988f-a03cba180640"));
            DetailsGrid = (ITTGrid)AddControl(new Guid("83142673-b24e-4df5-bce2-44b1c2db53ee"));
            Selected = (ITTCheckBoxColumn)AddControl(new Guid("087729d4-6989-49e8-94b0-802eede97a87"));
            PItem = (ITTListBoxColumn)AddControl(new Guid("41b93e35-67bf-4a23-aab4-5d1c7d68dd83"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b2afde79-1375-4f5e-802c-44a9cde86ca4"));
            base.InitializeControls();
        }

        public ProjectDetailEditingForm() : base("PURCHASEPROJECT", "ProjectDetailEditingForm")
        {
        }

        protected ProjectDetailEditingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}