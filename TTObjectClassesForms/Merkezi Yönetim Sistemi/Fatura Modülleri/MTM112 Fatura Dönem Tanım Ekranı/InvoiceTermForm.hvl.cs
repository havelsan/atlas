
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
    public partial class InvoiceTermForm : TTUnboundForm
    {
        protected ITTPanel pnlInvoiceCollections;
        protected ITTGrid gridInvoiceCollection;
        protected ITTTextBoxColumn No;
        protected ITTTextBoxColumn Name;
        protected ITTTextBoxColumn Date;
        protected ITTTextBoxColumn State;
        protected ITTTextBoxColumn Capacity;
        protected ITTTextBoxColumn TotalPrice;
        protected ITTTextBoxColumn ServicePrice;
        protected ITTTextBoxColumn MedicinePrice;
        protected ITTTextBoxColumn ConsumptionPrice;
        protected ITTPanel txt;
        protected ITTLabel ttlabel7;
        protected ITTTextBox txtConsumptionPrice;
        protected ITTLabel lblConsumptionPrixce;
        protected ITTTextBox txtLastStateUser;
        protected ITTLabel ttlabel8;
        protected ITTLabel lblLastSateUser;
        protected ITTTextBox txtTotalPrice;
        protected ITTLabel ttlabel5;
        protected ITTLabel lbl;
        protected ITTLabel ttlabel6;
        protected ITTLabel lblInvoiceCount;
        protected ITTTextBox txtInvoiceCount;
        protected ITTTextBox txtMedicinePrice;
        protected ITTLabel ttlabel4;
        protected ITTLabel lblMedicinePrice;
        protected ITTLabel ttlabel2;
        protected ITTTextBox txtServicePrice;
        protected ITTLabel lblServicePrice;
        protected ITTPanel pnlList;
        protected ITTButton btnCloseTerm;
        protected ITTButton btnLockTerm;
        protected ITTButton btnCancelTerm;
        protected ITTButton btnAdd;
        protected ITTGrid gridTerms;
        protected ITTTextBoxColumn TermName;
        protected ITTTextBoxColumn TermStartDate;
        protected ITTTextBoxColumn TermEndDate;
        protected ITTTextBoxColumn TermLastState;
        protected ITTTextBoxColumn TermLastStateDate;
        protected ITTTextBoxColumn ObjectId;
        override protected void InitializeControls()
        {
            pnlInvoiceCollections = (ITTPanel)AddControl(new Guid("08be40cf-a727-4205-8e9c-02fc64c91d5a"));
            gridInvoiceCollection = (ITTGrid)AddControl(new Guid("920c03bd-acb0-4f43-8391-1f67fbee5b0f"));
            No = (ITTTextBoxColumn)AddControl(new Guid("b02e422a-1b10-4fe8-9f69-9eb8ecf6e0e4"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("d6b45ef9-5849-4450-8249-82d1cdf61ffc"));
            Date = (ITTTextBoxColumn)AddControl(new Guid("2e5da0e2-a077-4bb6-a33d-a5b9fcadecda"));
            State = (ITTTextBoxColumn)AddControl(new Guid("56262d22-dd2d-4bbe-b54c-15b517a06ebb"));
            Capacity = (ITTTextBoxColumn)AddControl(new Guid("c8570fd6-8108-4db4-8fb5-2588f6e91788"));
            TotalPrice = (ITTTextBoxColumn)AddControl(new Guid("3ea65aec-7f44-4120-89d5-cbd737ca4192"));
            ServicePrice = (ITTTextBoxColumn)AddControl(new Guid("49b42f88-3b4d-4622-bff5-d5bba9fbce61"));
            MedicinePrice = (ITTTextBoxColumn)AddControl(new Guid("ce54adfa-ac11-4c42-b93a-2a9fbe2b9a0b"));
            ConsumptionPrice = (ITTTextBoxColumn)AddControl(new Guid("2a2c633c-a877-4386-98c9-855852cec68e"));
            txt = (ITTPanel)AddControl(new Guid("c93c48b8-2162-4662-b33a-1a8358262a79"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("24e30054-cd88-4f23-8b25-8a2d7bfbfc34"));
            txtConsumptionPrice = (ITTTextBox)AddControl(new Guid("8be7aac2-d2ff-4c89-aa05-373a2d2720a8"));
            lblConsumptionPrixce = (ITTLabel)AddControl(new Guid("7fabebcf-824e-4989-81e4-0423af831d3b"));
            txtLastStateUser = (ITTTextBox)AddControl(new Guid("5cb8f95f-f7ae-4df4-bfd3-0b3d1731e920"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("d3226f02-a3ad-4938-8a6d-a86c0f381230"));
            lblLastSateUser = (ITTLabel)AddControl(new Guid("df395a16-3b90-4f00-95ca-1f7f00a8824e"));
            txtTotalPrice = (ITTTextBox)AddControl(new Guid("115492d9-3e40-4b32-b82f-1bc399612b74"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("08984300-fb3a-4d17-a8d9-0086d2b068d9"));
            lbl = (ITTLabel)AddControl(new Guid("18a8c1b0-3b2c-4c7f-bf9f-97fb6a38491f"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e553ea70-dff1-453c-9ba7-b62ea6a681fc"));
            lblInvoiceCount = (ITTLabel)AddControl(new Guid("89669567-2d9a-486a-a384-a92f1ae27fed"));
            txtInvoiceCount = (ITTTextBox)AddControl(new Guid("6fd8c646-52e6-4214-9b49-625663648a8f"));
            txtMedicinePrice = (ITTTextBox)AddControl(new Guid("73aa0bd6-c1fc-47c0-bad0-ec283becfed1"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("595227e7-7c42-4e46-8a06-70d623d710b7"));
            lblMedicinePrice = (ITTLabel)AddControl(new Guid("b3ef67b5-c76e-4af8-ad6c-d230c46fb7a1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5c17fdfa-9de3-4f38-bcc0-0097db93b93a"));
            txtServicePrice = (ITTTextBox)AddControl(new Guid("1780c309-e551-41a0-bfd4-f971fa1cfd00"));
            lblServicePrice = (ITTLabel)AddControl(new Guid("a2360b37-d383-4da7-98cf-bef97d9c9bd9"));
            pnlList = (ITTPanel)AddControl(new Guid("373bf5db-af39-4440-8b4d-685cd411c33e"));
            btnCloseTerm = (ITTButton)AddControl(new Guid("1256341e-bfba-419c-9a5e-8a0803304de9"));
            btnLockTerm = (ITTButton)AddControl(new Guid("21374bb0-f400-414e-a517-a1023febf822"));
            btnCancelTerm = (ITTButton)AddControl(new Guid("2422700b-8531-40c1-a2f7-c6650a7ae6d9"));
            btnAdd = (ITTButton)AddControl(new Guid("a03134a2-ba11-48c7-b6b9-4d51e5d1ff5e"));
            gridTerms = (ITTGrid)AddControl(new Guid("192c8689-fd37-4454-8f5d-ab9c4514a13d"));
            TermName = (ITTTextBoxColumn)AddControl(new Guid("c5e24d47-2df4-4d20-a3a4-4876e68a0aa2"));
            TermStartDate = (ITTTextBoxColumn)AddControl(new Guid("7103a7f1-78c4-4e82-acfe-3f202a8b3529"));
            TermEndDate = (ITTTextBoxColumn)AddControl(new Guid("8d87e9ad-bc91-46ee-a9d4-44e96d5e81fb"));
            TermLastState = (ITTTextBoxColumn)AddControl(new Guid("64280dd8-951f-4a89-904f-de9f8d333779"));
            TermLastStateDate = (ITTTextBoxColumn)AddControl(new Guid("8a517700-651e-418a-a94f-c89fe5ab1f6b"));
            ObjectId = (ITTTextBoxColumn)AddControl(new Guid("5bd26f45-20e0-448d-88ba-78c85d0fc8da"));
            base.InitializeControls();
        }

        public InvoiceTermForm() : base("InvoiceTermForm")
        {
        }

        protected InvoiceTermForm(string formDefName) : base(formDefName)
        {
        }
    }
}