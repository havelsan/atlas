
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
    public partial class RCLogisticBureauForm : TTForm
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
        protected ITTLabel ttlabel2;
        protected ITTLabel labelDemandType;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox1;
        protected ITTEnumComboBox DemandType;
        protected ITTEnumComboBox ProcurementType;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTLabel ttlabel1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid PurchaseProjectDetailsGrid;
        protected ITTTextBoxColumn OrderNO;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTRichTextBoxControlColumn Isayf;
        protected ITTButtonColumn Details;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("f82e4a71-c282-485e-979a-103b44a69e59"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("1b30a658-3da9-4a1b-b215-63e33265d732"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("13a14377-e7f1-4fba-a55e-24bfd9e24ef5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e36dc334-9bc1-4b91-ac55-858f17c0f6b0"));
            labelDemandType = (ITTLabel)AddControl(new Guid("11f3651e-afc7-4c2a-a257-6ebb43be5c4f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6a52b43e-a58f-4fee-9e60-d11d72e8902f"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f21d5fdb-db6f-4333-a277-d19031db931b"));
            DemandType = (ITTEnumComboBox)AddControl(new Guid("9b13e6c3-6201-4738-a763-6d7d3683d014"));
            ProcurementType = (ITTEnumComboBox)AddControl(new Guid("96512ad0-4404-4a6c-b8c9-9655a416458e"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("45a210cb-d720-4956-aa7d-06b02041dc18"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7f9e4b75-54a0-43f8-96de-56d8cf9e6804"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("63023e80-cbc2-4df2-a962-8258ebe739ef"));
            PurchaseProjectDetailsGrid = (ITTGrid)AddControl(new Guid("319c7800-a35b-4476-8ff5-321868401c66"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("227c8250-8346-4086-acc6-eeedc7c57d3c"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("617198e0-eba1-43bd-a297-821558cbffb8"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("0c2329e0-2ddc-4988-ae09-33a9135f8a53"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("89536018-1b20-4e1b-a31f-d118934f59f3"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("732655a1-90db-4453-b3ae-49c4b79efbd8"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("dc6a3626-8c72-49b2-af1b-4fe9b437daea"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("f5d17332-4647-478d-90a1-f3ddce7024c6"));
            Isayf = (ITTRichTextBoxControlColumn)AddControl(new Guid("2d830680-c1c5-4c32-8dba-9d593dc21712"));
            Details = (ITTButtonColumn)AddControl(new Guid("eee9c792-2b48-40c6-8b7f-676e73fe032a"));
            base.InitializeControls();
        }

        public RCLogisticBureauForm() : base("PURCHASEPROJECT", "RCLogisticBureauForm")
        {
        }

        protected RCLogisticBureauForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}