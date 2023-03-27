
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
    public partial class ArgeProjectOwnerForm : ArgeProjectAcdComApprovalForm
    {
    /// <summary>
    /// Proje Başvuru Formu
    /// </summary>
        protected TTObjectClasses.ArgeProject _ArgeProject
        {
            get { return (TTObjectClasses.ArgeProject)_ttObject; }
        }

        protected ITTTabPage tttabpage25;
        protected ITTGrid AdditionalTimeDemand;
        protected ITTTextBoxColumn ExtraDurationAdditionalTimeDemand;
        protected ITTEnumComboBoxColumn DurationTypeAdditionalTimeDemand;
        protected ITTTextBoxColumn CommentAdditionalTimeDemand;
        protected ITTStateComboBoxColumn datagridviewcolumn3;
        protected ITTTabPage tttabpage28;
        protected ITTGrid Documents;
        protected ITTTextBoxColumn TitleProjectDocument;
        protected ITTButton btnAddDocument;
        protected ITTTabPage tttabpage29;
        protected ITTLabel labelProjectSummary;
        protected ITTTextBox ProjectSummary;
        protected ITTListBoxColumn ExchangeType;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTabPage tttabpage5;
        protected ITTGrid ConsumableMaterials;
        protected ITTListBoxColumn MaterialConsumableMaterialDetail;
        protected ITTListBoxColumn StoreConsumableMaterialDetail;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTTextBoxColumn AmountConsumableMaterialDetail;
        protected ITTTabPage tttabpage24;
        protected ITTGrid ProjectReport;
        protected ITTDateTimePickerColumn ReportDateProjectProgressReport;
        protected ITTTextBoxColumn ReportNoProjectProgressReport;
        protected ITTTextBoxColumn ReportTextProjectProgressReport;
        protected ITTStateComboBoxColumn ttstatecomboboxcolumn1;
        protected ITTTabPage tttabpage26;
        protected ITTGrid Reservation;
        protected ITTListBoxColumn LabaratoryPlanLabaratoryReservation;
        override protected void InitializeControls()
        {
            tttabpage25 = (ITTTabPage)AddControl(new Guid("33734831-26e7-46e6-9a35-f6d3a5bb5e34"));
            AdditionalTimeDemand = (ITTGrid)AddControl(new Guid("4de3b88c-f2a1-49aa-8a2f-2e802effae43"));
            ExtraDurationAdditionalTimeDemand = (ITTTextBoxColumn)AddControl(new Guid("48ee14e3-cc31-4735-bf63-eb10ac14eaa3"));
            DurationTypeAdditionalTimeDemand = (ITTEnumComboBoxColumn)AddControl(new Guid("c5643745-0a48-45a6-bf9d-59f200743c14"));
            CommentAdditionalTimeDemand = (ITTTextBoxColumn)AddControl(new Guid("c9e11581-df5e-4897-b6d2-18c6a831ddb5"));
            datagridviewcolumn3 = (ITTStateComboBoxColumn)AddControl(new Guid("f48fdf39-bccb-473c-9d36-d01a59e51c32"));
            tttabpage28 = (ITTTabPage)AddControl(new Guid("dcdb9c28-0069-41c7-bee4-e0f355dc8182"));
            Documents = (ITTGrid)AddControl(new Guid("ff998bf7-840f-46e6-b7da-71aa86dd484e"));
            TitleProjectDocument = (ITTTextBoxColumn)AddControl(new Guid("d981d9ce-2488-409d-b719-89774f5fc7ad"));
            btnAddDocument = (ITTButton)AddControl(new Guid("d93400d3-c8ed-42b1-8915-c7f2973a1056"));
            tttabpage29 = (ITTTabPage)AddControl(new Guid("331c71f5-cd79-48d0-aa7f-38e492e985bb"));
            labelProjectSummary = (ITTLabel)AddControl(new Guid("c17c315c-be91-453a-bd4a-77f091300a75"));
            ProjectSummary = (ITTTextBox)AddControl(new Guid("bb8f45bb-28fe-49d0-8830-11b3d9f9b6b1"));
            ExchangeType = (ITTListBoxColumn)AddControl(new Guid("27067041-5838-4a94-8856-624f42ddcd86"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("ba94658a-f6c9-4920-8f4a-9af84d789e90"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("bb2b016d-355e-4bba-9945-7cb1f97dd138"));
            ConsumableMaterials = (ITTGrid)AddControl(new Guid("55ed0c2e-e80d-4de1-ae18-e2e3cbcdee86"));
            MaterialConsumableMaterialDetail = (ITTListBoxColumn)AddControl(new Guid("32c7a102-4a3e-4147-8e01-35037da2dc99"));
            StoreConsumableMaterialDetail = (ITTListBoxColumn)AddControl(new Guid("77ce1307-f6ab-4764-8209-b69a7fc245f2"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("61cd94ef-288e-49b1-b9cf-648fe8af63c4"));
            AmountConsumableMaterialDetail = (ITTTextBoxColumn)AddControl(new Guid("3faee3a3-cd66-4893-9c78-9eecf5cc2a8f"));
            tttabpage24 = (ITTTabPage)AddControl(new Guid("1855509b-ee40-4f80-89e7-66aa1a200a72"));
            ProjectReport = (ITTGrid)AddControl(new Guid("b4635d0a-2203-467c-9c73-cf1c5c877120"));
            ReportDateProjectProgressReport = (ITTDateTimePickerColumn)AddControl(new Guid("59fd100b-3b1a-4872-9aea-d16d14f7b253"));
            ReportNoProjectProgressReport = (ITTTextBoxColumn)AddControl(new Guid("129b24cd-bcc8-4488-807e-eaf729a92ff1"));
            ReportTextProjectProgressReport = (ITTTextBoxColumn)AddControl(new Guid("e05aa4db-74b8-4eae-b7f6-373e4c7c8cf1"));
            ttstatecomboboxcolumn1 = (ITTStateComboBoxColumn)AddControl(new Guid("2d4a9769-9d0a-43d1-b4db-c5064ea4e97c"));
            tttabpage26 = (ITTTabPage)AddControl(new Guid("443f1e3d-3380-4e80-830c-4178daf99c0a"));
            Reservation = (ITTGrid)AddControl(new Guid("f201ea16-f41e-44a7-bf9b-dbfcdbb4d6c4"));
            LabaratoryPlanLabaratoryReservation = (ITTListBoxColumn)AddControl(new Guid("fbb48164-153c-4018-b1da-48230c6ad603"));
            base.InitializeControls();
        }

        public ArgeProjectOwnerForm() : base("ARGEPROJECT", "ArgeProjectOwnerForm")
        {
        }

        protected ArgeProjectOwnerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}