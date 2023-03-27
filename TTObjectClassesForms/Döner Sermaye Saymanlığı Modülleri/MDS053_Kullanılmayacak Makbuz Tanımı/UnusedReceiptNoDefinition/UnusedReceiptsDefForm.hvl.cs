
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
    /// Kullanılmayacak Makbuz Tanımı
    /// </summary>
    public partial class UnusedReceiptsDefForm : TTDefinitionForm
    {
        protected TTObjectClasses.UnusedReceiptNoDefinition _UnusedReceiptNoDefinition
        {
            get { return (TTObjectClasses.UnusedReceiptNoDefinition)_ttObject; }
        }

        protected ITTLabel lblUnsuedReceipteStartNo;
        protected ITTTextBox txtUnusedReceiptEndNo;
        protected ITTTextBox txtUnusedReceiptStartNo;
        protected ITTTextBox txtDescrition;
        protected ITTTextBox txtReceiptStartNo;
        protected ITTTextBox txtCurrentReceiptNo;
        protected ITTTextBox txtReceiptSeriesNo;
        protected ITTTextBox txtReceiptEndNo;
        protected ITTTextBox txtCashOfficeOrderNo;
        protected ITTLabel lblDescription;
        protected ITTObjectListBox lstBoxReceiptCashOfficeListDef;
        protected ITTLabel lblCashOffices;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            lblUnsuedReceipteStartNo = (ITTLabel)AddControl(new Guid("2e8d45ae-1499-467e-a58b-0c4fffd2e0e0"));
            txtUnusedReceiptEndNo = (ITTTextBox)AddControl(new Guid("4dfced6f-a9b0-44cb-bae0-6d369bae811c"));
            txtUnusedReceiptStartNo = (ITTTextBox)AddControl(new Guid("8045caad-5a69-46ff-bef0-68811556cb71"));
            txtDescrition = (ITTTextBox)AddControl(new Guid("4ff55b60-f85f-4de6-8911-058f0a01e44d"));
            txtReceiptStartNo = (ITTTextBox)AddControl(new Guid("6f3353b4-dba2-4a5c-b4a3-ab39dcda7c27"));
            txtCurrentReceiptNo = (ITTTextBox)AddControl(new Guid("6b51ffa9-0284-4b3b-8c41-8f0e69b0fd0f"));
            txtReceiptSeriesNo = (ITTTextBox)AddControl(new Guid("9d9651de-16c9-495f-83fb-718e79a1ac86"));
            txtReceiptEndNo = (ITTTextBox)AddControl(new Guid("9f2f4acb-7375-4aee-9062-041606a5fcaa"));
            txtCashOfficeOrderNo = (ITTTextBox)AddControl(new Guid("c3742556-9caf-4e26-a3f7-cf6b75031498"));
            lblDescription = (ITTLabel)AddControl(new Guid("7688790a-824e-4101-8d79-32086c91cd7a"));
            lstBoxReceiptCashOfficeListDef = (ITTObjectListBox)AddControl(new Guid("c4a64446-4c1f-4f1f-b32f-d3d78a282b31"));
            lblCashOffices = (ITTLabel)AddControl(new Guid("ef04b48b-b07c-417c-bc24-117674866d3a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("bd52eea3-7f71-474b-9acb-d92915e5be8d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e782c89f-d9cd-45f6-a7e2-de85abfce60c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e3d2ff70-3d46-4dd3-be3e-ff30cb32953a"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9d8de098-aa41-45ef-b135-58e6aa6a1eab"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("e26058bf-71a6-47d6-9d85-0a4b546b56af"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5bed2976-f085-4480-bd63-031b4e12780a"));
            base.InitializeControls();
        }

        public UnusedReceiptsDefForm() : base("UNUSEDRECEIPTNODEFINITION", "UnusedReceiptsDefForm")
        {
        }

        protected UnusedReceiptsDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}