
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
    /// Son Kullanma Tarihi Güncelleme
    /// </summary>
    public partial class ExpirationDateCorrectionNewForm : BaseDataCorrectionForm
    {
    /// <summary>
    /// Son Kullanma Tarihi Güncelleme
    /// </summary>
        protected TTObjectClasses.ExpirationDateCorrectionAction _ExpirationDateCorrectionAction
        {
            get { return (TTObjectClasses.ExpirationDateCorrectionAction)_ttObject; }
        }

        protected ITTCheckBox expirationDate_ttcheckbox;
        protected ITTLabel labelOldExpirationDate;
        protected ITTDateTimePicker OldExpirationDate;
        protected ITTGrid FirstInStockActions;
        protected ITTTextBoxColumn StockActionID;
        protected ITTTextBoxColumn Description;
        protected ITTDateTimePickerColumn ExpaDate;
        protected ITTCheckBoxColumn SelectedStockActionFirstInStockAction;
        protected ITTButton cmdGetRestAmountTrx;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelNewExpirationDate;
        protected ITTDateTimePicker NewExpirationDate;
        override protected void InitializeControls()
        {
            expirationDate_ttcheckbox = (ITTCheckBox)AddControl(new Guid("826de3de-2803-4fb8-a092-0b9d896686c8"));
            labelOldExpirationDate = (ITTLabel)AddControl(new Guid("64f0f10b-bf51-4fa8-98ab-f7c8a558375f"));
            OldExpirationDate = (ITTDateTimePicker)AddControl(new Guid("cbb2593e-d95c-4024-b790-f93a005dffd1"));
            FirstInStockActions = (ITTGrid)AddControl(new Guid("b7802248-1b9f-4359-8304-87a2d584e164"));
            StockActionID = (ITTTextBoxColumn)AddControl(new Guid("d536067a-1dd7-4a69-bc4f-2e2478a43c78"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("700db87d-e680-444b-b568-9cab3e800e01"));
            ExpaDate = (ITTDateTimePickerColumn)AddControl(new Guid("ee77e341-0b28-4184-b0c5-e3272f1f6c63"));
            SelectedStockActionFirstInStockAction = (ITTCheckBoxColumn)AddControl(new Guid("bc924844-a610-4ea9-a5a4-cb36716695c0"));
            cmdGetRestAmountTrx = (ITTButton)AddControl(new Guid("fbf5395d-f86b-4c66-9502-32aca753557c"));
            labelMaterial = (ITTLabel)AddControl(new Guid("9b5e7722-7312-4b30-bab2-c4f2fd02e138"));
            Material = (ITTObjectListBox)AddControl(new Guid("803043d2-1093-408f-ba30-2d315c9df6f3"));
            labelNewExpirationDate = (ITTLabel)AddControl(new Guid("1bf34c3e-c838-4c4a-a719-0b66aef82983"));
            NewExpirationDate = (ITTDateTimePicker)AddControl(new Guid("7730b3f7-7791-4975-996b-c1e01acad957"));
            base.InitializeControls();
        }

        public ExpirationDateCorrectionNewForm() : base("EXPIRATIONDATECORRECTIONACTION", "ExpirationDateCorrectionNewForm")
        {
        }

        protected ExpirationDateCorrectionNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}