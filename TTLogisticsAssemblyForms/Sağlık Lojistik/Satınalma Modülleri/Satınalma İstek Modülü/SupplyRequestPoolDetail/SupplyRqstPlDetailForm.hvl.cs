
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
    public partial class SupplyRqstPlDetailForm : TTForm
    {
    /// <summary>
    /// Tedarik Talepleri Havuz Detayı
    /// </summary>
        protected TTObjectClasses.SupplyRequestPoolDetail _SupplyRequestPoolDetail
        {
            get { return (TTObjectClasses.SupplyRequestPoolDetail)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid SupplyRequestDetails;
        protected ITTListBoxColumn MaterialSupplyRequestDetail;
        protected ITTListBoxColumn BaseMaterialGroupSupplyRequestDetail;
        protected ITTListBoxColumn DistributionTypeSupplyRequestDetail;
        protected ITTTextBoxColumn RequestAmountSupplyRequestDetail;
        protected ITTTextBoxColumn PurchaseAmountSupplyRequestDetail;
        protected ITTTextBoxColumn DetailDescriptionSupplyRequestDetail;
        protected ITTEnumComboBoxColumn SupplyRequestStatusSupplyRequestDetail;
        protected ITTListBoxColumn RequestedStore;
        protected ITTCheckBoxColumn IsImmediateMat;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("fecd860d-1d44-4187-aa97-b687ef93fbd8"));
            SupplyRequestDetails = (ITTGrid)AddControl(new Guid("48c20e20-bade-42af-a9a7-baaf8c7b21da"));
            MaterialSupplyRequestDetail = (ITTListBoxColumn)AddControl(new Guid("279f9a0e-7ff3-4e4c-aae7-51d4ab04a892"));
            BaseMaterialGroupSupplyRequestDetail = (ITTListBoxColumn)AddControl(new Guid("22a8c502-f2d2-4013-bba4-be7f1825e5b9"));
            DistributionTypeSupplyRequestDetail = (ITTListBoxColumn)AddControl(new Guid("c2308dec-93bd-45af-9511-01d439fc230b"));
            RequestAmountSupplyRequestDetail = (ITTTextBoxColumn)AddControl(new Guid("30755337-cd28-4ce6-a171-d962e55207a2"));
            PurchaseAmountSupplyRequestDetail = (ITTTextBoxColumn)AddControl(new Guid("563f7aa1-eb87-4e74-929f-118434ca8fde"));
            DetailDescriptionSupplyRequestDetail = (ITTTextBoxColumn)AddControl(new Guid("381a45a5-5c2e-4ab7-9570-49af0b4e2a5a"));
            SupplyRequestStatusSupplyRequestDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("b8ffd759-e311-4e92-8925-59988f01a54f"));
            RequestedStore = (ITTListBoxColumn)AddControl(new Guid("4b90bd64-4f17-491c-abb2-2229a2fb45ea"));
            IsImmediateMat = (ITTCheckBoxColumn)AddControl(new Guid("11148b87-6118-4ba0-94ae-a2d5392a1723"));
            base.InitializeControls();
        }

        public SupplyRqstPlDetailForm() : base("SUPPLYREQUESTPOOLDETAIL", "SupplyRqstPlDetailForm")
        {
        }

        protected SupplyRqstPlDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}