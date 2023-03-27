
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
    /// Ana Depo Dağıtım Tamamlandı
    /// </summary>
    public partial class MainStoreDistDocComplatedForm : BaseMainStoreDistributionDocForm
    {
    /// <summary>
    /// Ana Depo Dağıtım Belgesi
    /// </summary>
        protected TTObjectClasses.MainStoreDistributionDoc _MainStoreDistributionDoc
        {
            get { return (TTObjectClasses.MainStoreDistributionDoc)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogs;
        protected ITTGrid ttgrid3;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTTextBoxColumn tttextboxcolumn13;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn4;
        protected ITTTextBoxColumn tttextboxcolumn14;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn5;
        protected ITTTextBoxColumn tttextboxcolumn15;
        protected ITTTextBoxColumn tttextboxcolumn16;
        protected ITTTextBoxColumn tttextboxcolumn17;
        override protected void InitializeControls()
        {
            DocumentRecordLogs = (ITTTabPage)AddControl(new Guid("b316aa0d-c2d4-456e-8b14-487ef3c4d3fc"));
            ttgrid3 = (ITTGrid)AddControl(new Guid("d0770e13-02af-4c77-9a0d-d9493fbf73f9"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("2d4a62aa-2af9-455e-a760-522648028b7f"));
            tttextboxcolumn13 = (ITTTextBoxColumn)AddControl(new Guid("5d6b2f97-3a31-4170-be93-a200f431cfef"));
            ttenumcomboboxcolumn4 = (ITTEnumComboBoxColumn)AddControl(new Guid("730258bc-ac25-4258-a384-2a4df90842fe"));
            tttextboxcolumn14 = (ITTTextBoxColumn)AddControl(new Guid("c78b8aa5-d2b2-495f-b390-3a9313100f56"));
            ttenumcomboboxcolumn5 = (ITTEnumComboBoxColumn)AddControl(new Guid("71e82cbc-834c-408d-a8ff-5f940215ab6f"));
            tttextboxcolumn15 = (ITTTextBoxColumn)AddControl(new Guid("164f288c-f6e3-45db-8016-8b2dced791ff"));
            tttextboxcolumn16 = (ITTTextBoxColumn)AddControl(new Guid("d42cda7e-5dce-4df0-9942-0c10962c97bf"));
            tttextboxcolumn17 = (ITTTextBoxColumn)AddControl(new Guid("cd61fd7f-dabe-43d6-b046-f163898bf3e4"));
            base.InitializeControls();
        }

        public MainStoreDistDocComplatedForm() : base("MAINSTOREDISTRIBUTIONDOC", "MainStoreDistDocComplatedForm")
        {
        }

        protected MainStoreDistDocComplatedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}