
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
    /// Kayıt Silme Belgesi - Yok Edilen Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class BasePresDeleteRecordDocumentDestroyableForm : BaseDeleteRecordDocumentDestroyableForm
    {
    /// <summary>
    /// Kayıt Silme Belgesi - Yok Edilen Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresDeleteRecordDocumentDestroyable _PresDeleteRecordDocumentDestroyable
        {
            get { return (TTObjectClasses.PresDeleteRecordDocumentDestroyable)_ttObject; }
        }

        protected ITTTabPage PrescriptionTabPage;
        protected ITTGrid PresDeleteRecordDocumentDestroyableOutMaterials;
        protected ITTListBoxColumn MaterialPresDeleteRecordDocumentDestroyableMaterialOut;
        protected ITTTextBoxColumn PresBarcode;
        protected ITTTextBoxColumn PresDistributionType;
        protected ITTTextBoxColumn PresInheld;
        protected ITTTextBoxColumn AmountPresDeleteRecordDocumentDestroyableMaterialOut;
        protected ITTTextBoxColumn PresUnitPrice;
        protected ITTTextBoxColumn PresPrice;
        protected ITTDateTimePickerColumn StartDatePresDeleteRecordDocumentDestroyableMaterialOut;
        protected ITTEnumComboBoxColumn AuthorityClassPresDeleteRecordDocumentDestroyableMaterialOut;
        protected ITTEnumComboBoxColumn DeleteRecordReasonPresDeleteRecordDocumentDestroyableMaterialOut;
        protected ITTListBoxColumn StockLevelTypePresDeleteRecordDocumentDestroyableMaterialOut;
        protected ITTTextBoxColumn OpinionsPresDeleteRecordDocumentDestroyableMaterialOut;
        protected ITTTextBoxColumn DestroyLocationPresDeleteRecordDocumentDestroyableMaterialOut;
        override protected void InitializeControls()
        {
            PrescriptionTabPage = (ITTTabPage)AddControl(new Guid("814a1c6c-02fb-4934-9bce-f40640934812"));
            PresDeleteRecordDocumentDestroyableOutMaterials = (ITTGrid)AddControl(new Guid("6f857153-728c-46d3-b1eb-00e0d1dbcbc8"));
            MaterialPresDeleteRecordDocumentDestroyableMaterialOut = (ITTListBoxColumn)AddControl(new Guid("0408d43b-3eea-49a0-8335-0e71037b5098"));
            PresBarcode = (ITTTextBoxColumn)AddControl(new Guid("f22d0a0e-4593-4128-a5e5-ea1b1499a5d7"));
            PresDistributionType = (ITTTextBoxColumn)AddControl(new Guid("7d41f264-13d0-416e-89ca-c63cac1ae7b8"));
            PresInheld = (ITTTextBoxColumn)AddControl(new Guid("6b709752-9349-4177-ab04-067b563098c8"));
            AmountPresDeleteRecordDocumentDestroyableMaterialOut = (ITTTextBoxColumn)AddControl(new Guid("070ab81b-85b2-407b-8153-b189683ea59d"));
            PresUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("ddfd6ab8-633d-4ef5-b89e-95fcbd82d7e8"));
            PresPrice = (ITTTextBoxColumn)AddControl(new Guid("ffe39208-9165-41d0-80fe-50469f8aa0b4"));
            StartDatePresDeleteRecordDocumentDestroyableMaterialOut = (ITTDateTimePickerColumn)AddControl(new Guid("494fe7f9-8101-47fd-9dbb-623b3bf04e58"));
            AuthorityClassPresDeleteRecordDocumentDestroyableMaterialOut = (ITTEnumComboBoxColumn)AddControl(new Guid("6ab9ce4b-cc84-4e72-8e96-37e04db28985"));
            DeleteRecordReasonPresDeleteRecordDocumentDestroyableMaterialOut = (ITTEnumComboBoxColumn)AddControl(new Guid("d2db7b21-e9ef-4498-8780-a8ff33703ddf"));
            StockLevelTypePresDeleteRecordDocumentDestroyableMaterialOut = (ITTListBoxColumn)AddControl(new Guid("d8303602-95ae-41f3-803a-70725ad8efc3"));
            OpinionsPresDeleteRecordDocumentDestroyableMaterialOut = (ITTTextBoxColumn)AddControl(new Guid("12e18439-653c-46e1-b89f-362ff0ae76cf"));
            DestroyLocationPresDeleteRecordDocumentDestroyableMaterialOut = (ITTTextBoxColumn)AddControl(new Guid("83eb2ba1-5ff9-4bd6-b776-9a36275e5aae"));
            base.InitializeControls();
        }

        public BasePresDeleteRecordDocumentDestroyableForm() : base("PRESDELETERECORDDOCUMENTDESTROYABLE", "BasePresDeleteRecordDocumentDestroyableForm")
        {
        }

        protected BasePresDeleteRecordDocumentDestroyableForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}