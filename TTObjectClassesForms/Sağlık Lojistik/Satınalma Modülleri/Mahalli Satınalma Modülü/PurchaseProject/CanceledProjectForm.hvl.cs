
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
    /// İptal Edilmiş İhale Bilgileri
    /// </summary>
    public partial class CanceledProjectForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        protected ITTLabel labelConfirmNO;
        protected ITTEnumComboBox AnnounceTypeandCount;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelConfirmDate;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTTextBox ActAttribute;
        protected ITTTextBox ActDefine;
        protected ITTTextBox ConfirmNO;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker ConfirmDate;
        protected ITTLabel ttlabel5;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PurchaseType;
        protected ITTLabel ttlabel10;
        protected ITTEnumComboBox EvaluationType;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("6a05419f-4ca0-4688-8041-8c60d2b4bf56"));
            labelConfirmNO = (ITTLabel)AddControl(new Guid("c8e0572c-cd5a-4825-bf65-01d1f87c2972"));
            AnnounceTypeandCount = (ITTEnumComboBox)AddControl(new Guid("6d0dc402-cd14-4d1b-8fdb-08fca7d18521"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6703d969-802c-4ee7-899c-0e1ce8ab1e2a"));
            labelConfirmDate = (ITTLabel)AddControl(new Guid("b4ac2f63-c0a2-4be9-a27e-26f0c64ba94c"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("59621257-371c-4352-9555-3cb95c1f1b19"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("7a2f149f-717a-49c9-9ed7-44c7cee1ccd0"));
            ActAttribute = (ITTTextBox)AddControl(new Guid("8f537c2f-69b6-4088-8149-ae928dce42aa"));
            ActDefine = (ITTTextBox)AddControl(new Guid("52c4ab8f-736c-4911-ade0-b5ccb62f4402"));
            ConfirmNO = (ITTTextBox)AddControl(new Guid("6ab3c3f0-5f27-48bc-a8f5-e6978ba5f715"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("fc6ae1f9-187a-4d95-ad38-3f4b021e4534"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("fb09fdaf-a340-4404-8f2e-5043c92b6383"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("54710497-7d2a-476e-af76-66a9564dc6e6"));
            ConfirmDate = (ITTDateTimePicker)AddControl(new Guid("679665a6-3ae8-44f1-9d48-66aaac323171"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a13c8f69-711a-4629-a5ab-8706986dcadc"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("7fb0fb9d-f816-4bb1-a3c4-a7d2b101d41e"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("53a26948-8efa-4a0f-9283-6acf1b598525"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("396890de-32ec-4dc8-8fad-4381b8956c3c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("99af61ca-6918-4134-878c-564c54717c43"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cac16dfc-74d0-4db6-bd5a-a9b865f68888"));
            PurchaseType = (ITTObjectListBox)AddControl(new Guid("93e255f7-cda7-4e74-9043-d4653e0b9220"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("91775e2e-dbb4-44ec-b78f-e6faa267be5b"));
            EvaluationType = (ITTEnumComboBox)AddControl(new Guid("a2a93c7f-5053-4910-be13-f2b95b06c7d7"));
            base.InitializeControls();
        }

        public CanceledProjectForm() : base("PURCHASEPROJECT", "CanceledProjectForm")
        {
        }

        protected CanceledProjectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}