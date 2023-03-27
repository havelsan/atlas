
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
    /// El Senedei Sarf İmal İhtishal Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresInfirmaryDocumentForm : TTForm
    {
    /// <summary>
    /// El Senedi Sarf İmal İstihsal Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresInfirmaryDocument _PresInfirmaryDocument
        {
            get { return (TTObjectClasses.PresInfirmaryDocument)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PrescriptionMaterialTabPage;
        protected ITTGrid PresInfirmaryDocumentOutMaterials;
        protected ITTListBoxColumn MaterialPresInfirmaryDocMatOut;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn AmountPresInfirmaryDocMatOut;
        protected ITTTextBox STOCKACTIONID;
        protected ITTTextBox Description;
        protected ITTObjectListBox Store;
        protected ITTLabel LABELDESCRIPTION;
        protected ITTLabel LABELSTOCKACTIONID;
        protected ITTDateTimePicker TRANSACTIONDATE;
        protected ITTLabel LABELTRANSACTIONDATE;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel ttlabel2;
        protected ITTLabel LABELSTORE;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("1bec0f81-5ee1-458a-bfe9-aff36bc9fda5"));
            PrescriptionMaterialTabPage = (ITTTabPage)AddControl(new Guid("d4935707-a0be-4151-bd3d-9de56748cadb"));
            PresInfirmaryDocumentOutMaterials = (ITTGrid)AddControl(new Guid("2aafb84a-147f-4ec9-a62b-b544e82945a7"));
            MaterialPresInfirmaryDocMatOut = (ITTListBoxColumn)AddControl(new Guid("4761cb44-2b60-4549-b57f-b27e1710d246"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("90cd5a55-e158-4eab-a111-1439e626f7a2"));
            AmountPresInfirmaryDocMatOut = (ITTTextBoxColumn)AddControl(new Guid("4995b262-72bc-45f9-b4df-a8dbb9fd7985"));
            STOCKACTIONID = (ITTTextBox)AddControl(new Guid("3011f89e-7b44-44bb-9e6a-f0a422b6292a"));
            Description = (ITTTextBox)AddControl(new Guid("a29d3727-0117-4a0c-9b0f-583a3ae0a02c"));
            Store = (ITTObjectListBox)AddControl(new Guid("8734ec1b-56f7-4be9-9a93-ba0a35892724"));
            LABELDESCRIPTION = (ITTLabel)AddControl(new Guid("dcad4e3a-2534-4791-b54e-8ccddfa60d2e"));
            LABELSTOCKACTIONID = (ITTLabel)AddControl(new Guid("2f8fee9d-5beb-4d4d-9be8-18f0045b42d6"));
            TRANSACTIONDATE = (ITTDateTimePicker)AddControl(new Guid("8eb5205d-4db3-4382-a0a9-2e97efb6d4c3"));
            LABELTRANSACTIONDATE = (ITTLabel)AddControl(new Guid("700955e3-dda2-43be-99e6-e688433acc7b"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("e9006ad6-418c-404a-9231-d2336d5f7009"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c9a39b68-d764-47b3-890f-21e2f8008f8a"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("51fac04d-8096-4d99-829d-3ec1c15a3e9a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3960e8d4-94b7-4bd4-8c45-8b3c75342981"));
            LABELSTORE = (ITTLabel)AddControl(new Guid("a64ba4f5-3c0e-4003-adab-743d6245bc57"));
            base.InitializeControls();
        }

        public PresInfirmaryDocumentForm() : base("PRESINFIRMARYDOCUMENT", "PresInfirmaryDocumentForm")
        {
        }

        protected PresInfirmaryDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}