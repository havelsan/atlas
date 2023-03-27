
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
    public partial class InvoiceInclusionMasterForm : TTDefinitionForm
    {
    /// <summary>
    /// Fatura Dahillik Tanımları
    /// </summary>
        protected TTObjectClasses.InvoiceInclusionMaster _InvoiceInclusionMaster
        {
            get { return (TTObjectClasses.InvoiceInclusionMaster)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTLabel lblDescription;
        protected ITTButton btnUnCheckAllBranch;
        protected ITTButton btnCheckAllBranch;
        protected ITTLabel labelLastDate;
        protected ITTDateTimePicker LastDate;
        protected ITTLabel labelFirstDate;
        protected ITTDateTimePicker FirstDate;
        protected ITTGrid IIMNQLProcedureMaterials;
        protected ITTListBoxColumn InvoiceInclusionNQLIIMNQLProcedureMaterial;
        protected ITTListBoxColumn ProcedureDefinitionIIMNQLProcedureMaterial;
        protected ITTEnumComboBoxColumn Result;
        protected ITTGrid IIMDetails;
        protected ITTCheckBoxColumn CheckedIIMDetail;
        protected ITTEnumComboBoxColumn IIMDetailType;
        protected ITTTextBoxColumn Value;
        protected ITTTextBoxColumn Code;
        protected ITTGrid IIMProtocols;
        protected ITTCheckBoxColumn CheckedIIMProtocol;
        protected ITTTextBoxColumn ProtocolName;
        protected ITTGrid IIMSpecialities;
        protected ITTCheckBoxColumn CheckedIIMBransRelation;
        protected ITTTextBoxColumn BransCode;
        protected ITTTextBoxColumn BransName;
        protected ITTLabel labelName;
        protected ITTButton btnCheckBulletinBranch;
        protected ITTButton btnCheckUnBulletinBranch;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("837d1502-35c4-4a42-b703-0a39b8b6d05c"));
            Name = (ITTTextBox)AddControl(new Guid("95e2ddd4-b370-4832-8ba5-17438d797821"));
            lblDescription = (ITTLabel)AddControl(new Guid("9b567b1f-bf9a-4412-a255-74ddd2e3893a"));
            btnUnCheckAllBranch = (ITTButton)AddControl(new Guid("447ea3ca-fd47-40e6-8d06-8390949f0779"));
            btnCheckAllBranch = (ITTButton)AddControl(new Guid("629a671b-8778-4431-b7ba-22bd89622a1a"));
            labelLastDate = (ITTLabel)AddControl(new Guid("53fd75eb-9074-4e45-b460-301f31557b17"));
            LastDate = (ITTDateTimePicker)AddControl(new Guid("81ce9411-4cae-4af0-933f-300a52b6ecd7"));
            labelFirstDate = (ITTLabel)AddControl(new Guid("a425e6d9-fe92-4afc-bcba-04ec93a01202"));
            FirstDate = (ITTDateTimePicker)AddControl(new Guid("b8717b88-1aea-47da-8aeb-a0d3490efd09"));
            IIMNQLProcedureMaterials = (ITTGrid)AddControl(new Guid("2aede285-8004-4fe0-8937-d730a36ba7a3"));
            InvoiceInclusionNQLIIMNQLProcedureMaterial = (ITTListBoxColumn)AddControl(new Guid("f5333bec-9919-4b38-b489-917bdc09c62a"));
            ProcedureDefinitionIIMNQLProcedureMaterial = (ITTListBoxColumn)AddControl(new Guid("6b308484-9293-4d91-93de-bf158476177d"));
            Result = (ITTEnumComboBoxColumn)AddControl(new Guid("a5fbe95b-fa0f-45bc-91f6-b0f6fa216199"));
            IIMDetails = (ITTGrid)AddControl(new Guid("26817db7-99db-464b-8c71-74dba673a596"));
            CheckedIIMDetail = (ITTCheckBoxColumn)AddControl(new Guid("ae0fdb00-8de4-4a37-b489-9f6be4cb9480"));
            IIMDetailType = (ITTEnumComboBoxColumn)AddControl(new Guid("23c841e5-46a7-49d8-95b6-f4ba1329446d"));
            Value = (ITTTextBoxColumn)AddControl(new Guid("874dd681-06f3-4fd8-aad1-4b5657e3f207"));
            Code = (ITTTextBoxColumn)AddControl(new Guid("a13df16e-3700-4cef-b0ee-f81db8a4d83d"));
            IIMProtocols = (ITTGrid)AddControl(new Guid("fdddfda2-a3a8-4b87-a8cc-2c6553185b4e"));
            CheckedIIMProtocol = (ITTCheckBoxColumn)AddControl(new Guid("5993c33a-4134-43cb-8953-a13d1712fbe9"));
            ProtocolName = (ITTTextBoxColumn)AddControl(new Guid("ee261ceb-9540-47a9-bb6f-7901e0557fce"));
            IIMSpecialities = (ITTGrid)AddControl(new Guid("eb62945a-5b12-4e34-b1c3-31e104aaceae"));
            CheckedIIMBransRelation = (ITTCheckBoxColumn)AddControl(new Guid("0f387a4c-6521-4586-9a8a-3206388985c0"));
            BransCode = (ITTTextBoxColumn)AddControl(new Guid("db49e9fb-3504-48db-b0ae-867134e8aca1"));
            BransName = (ITTTextBoxColumn)AddControl(new Guid("161fcd30-8fb6-4e15-9a42-6b26c9bf319f"));
            labelName = (ITTLabel)AddControl(new Guid("0e1e8163-ce05-42d5-a415-609b030914b1"));
            btnCheckBulletinBranch = (ITTButton)AddControl(new Guid("db8291de-af62-4cb8-a5e7-55b8c55bc1be"));
            btnCheckUnBulletinBranch = (ITTButton)AddControl(new Guid("21884e95-9645-4655-8434-d1844ab456ed"));
            base.InitializeControls();
        }

        public InvoiceInclusionMasterForm() : base("INVOICEINCLUSIONMASTER", "InvoiceInclusionMasterForm")
        {
        }

        protected InvoiceInclusionMasterForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}