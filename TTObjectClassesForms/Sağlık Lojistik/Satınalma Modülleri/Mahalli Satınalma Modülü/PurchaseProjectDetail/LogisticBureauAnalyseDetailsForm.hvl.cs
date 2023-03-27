
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
    /// Lojistik İnceleme
    /// </summary>
    public partial class LogisticBureauAnalyseDetails : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfına Bağlı Her Detayın/Kalemin Bağlı Olduğu Sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseProjectDetail _PurchaseProjectDetail
        {
            get { return (TTObjectClasses.PurchaseProjectDetail)_ttObject; }
        }

        protected ITTButton cmdRefresh;
        protected ITTLabel RestAmount;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel2;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid ApproveDetailsGrid;
        protected ITTEnumComboBoxColumn ApproveType;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn Accountancy;
        protected ITTTextBoxColumn Description;
        protected ITTTextBox ApprovedAmount;
        protected ITTTextBox DemandedAmount;
        protected ITTTextBox CancelledAmount;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel4;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid StocksGrid;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn Amount2;
        protected ITTTextBoxColumn SurplusNeed;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            cmdRefresh = (ITTButton)AddControl(new Guid("1c23eb7c-452f-4f6b-bf85-50f55cc20848"));
            RestAmount = (ITTLabel)AddControl(new Guid("1c106ec1-2bcd-4306-97a2-681b9c9eeac4"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b6527a1b-29de-4dbe-bc20-edd62e4c082b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4e648091-8022-42a8-bd39-0d1019e89b65"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("362f9d18-5bfc-43ad-aff9-20e086590cf4"));
            ApproveDetailsGrid = (ITTGrid)AddControl(new Guid("1c798153-d7f4-4801-a0e6-43e23e395504"));
            ApproveType = (ITTEnumComboBoxColumn)AddControl(new Guid("231c1851-4fc1-4bde-9186-021e6b5ea7f6"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("1bb4ba96-a76c-4914-b9ec-da36dbd3d09c"));
            Accountancy = (ITTListBoxColumn)AddControl(new Guid("8a02ce01-d2d0-43fc-912f-f3985b9a8d4c"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("e30d0383-a0fb-4893-b3dd-a4572424dc33"));
            ApprovedAmount = (ITTTextBox)AddControl(new Guid("882f1189-a807-43bd-80ca-40a6102a9ada"));
            DemandedAmount = (ITTTextBox)AddControl(new Guid("cfde013c-b4d5-439d-a0da-833fff10eafc"));
            CancelledAmount = (ITTTextBox)AddControl(new Guid("47400135-80fe-40cd-9cde-b5279ab2262f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("af38a25d-27f5-4fb2-8456-715fca5ee8d3"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("904e5eda-5c79-42a6-a6f8-83fa5f85f99c"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("da1b651e-063d-4ac7-970c-d585a681bea2"));
            StocksGrid = (ITTGrid)AddControl(new Guid("01752cf2-9cd7-4bba-8e01-90e7af85628f"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("379392c9-a5fa-4a1e-9c72-596030100086"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("6c7a28aa-f173-4cab-8dbc-f2277bcca6bc"));
            SurplusNeed = (ITTTextBoxColumn)AddControl(new Guid("fd59de9c-9767-4754-8751-67f95a01c68e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("474503b8-b048-49ce-8a0b-d911201c8120"));
            base.InitializeControls();
        }

        public LogisticBureauAnalyseDetails() : base("PURCHASEPROJECTDETAIL", "LogisticBureauAnalyseDetails")
        {
        }

        protected LogisticBureauAnalyseDetails(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}