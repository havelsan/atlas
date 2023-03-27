
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
    /// Order Şablon Tanım Ekranı
    /// </summary>
    public partial class OrderTemplateDefForm : TTForm
    {
    /// <summary>
    /// Order Şablon Tanımlama
    /// </summary>
        protected TTObjectClasses.OrderTemplateDefinition _OrderTemplateDefinition
        {
            get { return (TTObjectClasses.OrderTemplateDefinition)_ttObject; }
        }

        protected ITTGrid OrderTemplateDetails;
        protected ITTListBoxColumn MaterialOrderTemplateDetail;
        protected ITTTextBoxColumn DoseAmountOrderTemplateDetail;
        protected ITTEnumComboBoxColumn DrugUsageTypeOrderTemplateDetail;
        protected ITTEnumComboBoxColumn DrugOrderTypeOrderTemplateDetail;
        protected ITTTextBoxColumn DescriptionOrderTemplateDetail;
        protected ITTLabel labelOrderTemplateStatus;
        protected ITTEnumComboBox OrderTemplateStatus;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            OrderTemplateDetails = (ITTGrid)AddControl(new Guid("f7d7f24f-e2ba-4862-86f9-0f3ce939111f"));
            MaterialOrderTemplateDetail = (ITTListBoxColumn)AddControl(new Guid("63902af4-3a38-40c7-aa1b-ae77c116d0f9"));
            DoseAmountOrderTemplateDetail = (ITTTextBoxColumn)AddControl(new Guid("dd695b7f-cf1e-43c3-b330-bc5f697c2b86"));
            DrugUsageTypeOrderTemplateDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("805285f7-3bf4-403b-b2f6-ecd5ce1d42cb"));
            DrugOrderTypeOrderTemplateDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("a7d0368a-c502-46a2-9872-295ef94aa5f3"));
            DescriptionOrderTemplateDetail = (ITTTextBoxColumn)AddControl(new Guid("54a46b4f-2823-4687-91cf-fb27d7d5ad42"));
            labelOrderTemplateStatus = (ITTLabel)AddControl(new Guid("330a2b86-2143-4276-b858-ff19e6c1ee9a"));
            OrderTemplateStatus = (ITTEnumComboBox)AddControl(new Guid("6be278ce-d5f9-49ea-bc78-fbdb540fe069"));
            labelName = (ITTLabel)AddControl(new Guid("3ee024a1-5f33-4950-bde5-e572fb90b10f"));
            Name = (ITTTextBox)AddControl(new Guid("1741bebc-219c-4af1-9b74-8025c8da560f"));
            base.InitializeControls();
        }

        public OrderTemplateDefForm() : base("ORDERTEMPLATEDEFINITION", "OrderTemplateDefForm")
        {
        }

        protected OrderTemplateDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}