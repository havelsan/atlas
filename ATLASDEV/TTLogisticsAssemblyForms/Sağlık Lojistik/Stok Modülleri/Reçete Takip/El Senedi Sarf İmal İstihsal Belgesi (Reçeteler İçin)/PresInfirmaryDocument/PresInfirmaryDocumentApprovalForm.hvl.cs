
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
    /// El Senedi Sarf İmal İhtihsal Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresInfirmaryDocumentApprovalForm : TTForm
    {
    /// <summary>
    /// El Senedi Sarf İmal İstihsal Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresInfirmaryDocument _PresInfirmaryDocument
        {
            get { return (TTObjectClasses.PresInfirmaryDocument)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTTextBox STOCKACTIONID;
        protected ITTLabel LABELSTOCKACTIONID;
        protected ITTDateTimePicker TRANSACTIONDATE;
        protected ITTLabel LABELTRANSACTIONDATE;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox Store;
        protected ITTLabel LABELSTORE;
        protected ITTLabel LABELDESCRIPTION;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PrescriptionMaterialTabPage;
        protected ITTGrid PresInfirmaryDocumentOutMaterials;
        protected ITTListBoxColumn MaterialPresInfirmaryDocMatOut;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn AmountPresInfirmaryDocMatOut;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("e5b85452-f03a-4065-9434-89ca57638a6d"));
            STOCKACTIONID = (ITTTextBox)AddControl(new Guid("0da684b6-cc2a-4f82-a753-221331340ef5"));
            LABELSTOCKACTIONID = (ITTLabel)AddControl(new Guid("a45c3d41-8db7-4673-b0d8-7b5cdeb03063"));
            TRANSACTIONDATE = (ITTDateTimePicker)AddControl(new Guid("f4912692-7689-41eb-85b8-41fc285e9eaf"));
            LABELTRANSACTIONDATE = (ITTLabel)AddControl(new Guid("9007802e-dfd9-4ece-aa54-63af0e502ca1"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("5d0f1d8a-71ce-4fd8-98b2-5d436855e58e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c07e165b-ab04-4928-b289-bc75f68c75b7"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("64019a1c-5df3-4927-b2b1-7a34cd6abac0"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("db3901e0-77c7-40c4-a5f4-b45a599ef1e4"));
            Store = (ITTObjectListBox)AddControl(new Guid("c7760e96-5542-464a-9af2-27f90eaa0c40"));
            LABELSTORE = (ITTLabel)AddControl(new Guid("65b55dec-3eb9-4b5e-b05d-c94917c10bf8"));
            LABELDESCRIPTION = (ITTLabel)AddControl(new Guid("e7ee5ff8-d28b-4c3b-b9c9-c79c6107b770"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6e40ce30-6442-4b0a-a47b-f3b9189dda85"));
            PrescriptionMaterialTabPage = (ITTTabPage)AddControl(new Guid("b9b219c4-edf8-4f8d-9dff-c3581de72d30"));
            PresInfirmaryDocumentOutMaterials = (ITTGrid)AddControl(new Guid("955af5bd-529a-4ce8-ae17-059752e2c928"));
            MaterialPresInfirmaryDocMatOut = (ITTListBoxColumn)AddControl(new Guid("5193ed91-4e2b-4c35-bdb6-1f8e936e98bd"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("0fd3b841-5d66-42e9-ad8a-a377b787586c"));
            AmountPresInfirmaryDocMatOut = (ITTTextBoxColumn)AddControl(new Guid("57164611-91b1-4eac-8274-922221f6737e"));
            base.InitializeControls();
        }

        public PresInfirmaryDocumentApprovalForm() : base("PRESINFIRMARYDOCUMENT", "PresInfirmaryDocumentApprovalForm")
        {
        }

        protected PresInfirmaryDocumentApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}