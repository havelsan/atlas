
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
    /// İptal
    /// </summary>
    public partial class CancelledForm_Maintenance : MaintenanceBaseForm
    {
    /// <summary>
    /// Bakım
    /// </summary>
        protected TTObjectClasses.Maintenance _Maintenance
        {
            get { return (TTObjectClasses.Maintenance)_ttObject; }
        }

        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelRequestNO;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelToResource;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelRequestDate;
        protected ITTTextBox RequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel labelFromResource;
        override protected void InitializeControls()
        {
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("0c968d02-a84e-4810-80a0-31d83a536cb4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("97a96358-ebb3-4480-aca6-95bab78477ac"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("d83071a6-78a8-42b8-8e4e-f2b65cd85509"));
            labelStartDate = (ITTLabel)AddControl(new Guid("d9c414bf-1fd4-45ce-a471-63c9f54d8e76"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("567a906a-587f-4edb-bcf0-63be892b82b5"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("adffdb4a-035a-4e43-b56e-3ad7db8cca60"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("4d87ff93-008c-4a88-9761-9da4f54026c8"));
            labelToResource = (ITTLabel)AddControl(new Guid("b8a60379-ba90-4a2e-9639-11c66b552cfd"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("bd269238-cd67-415d-828a-2fbdfb4ff4fd"));
            labelEndDate = (ITTLabel)AddControl(new Guid("7c49f067-0d0e-48fe-af56-5570e073e8e3"));
            labelDescription = (ITTLabel)AddControl(new Guid("54afd8c4-3339-4e83-aae8-d55da978064f"));
            Description = (ITTTextBox)AddControl(new Guid("f6b9be02-a525-4d35-9714-fe8336e45e7f"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("bf0665a1-fb6b-45f0-af29-3473bdb2b4ec"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("d7d67b4e-5caf-4090-af11-36af6e6f3088"));
            RequestNO = (ITTTextBox)AddControl(new Guid("2777266c-b0d8-4ffe-9cde-a99141fd2749"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("0b873b85-1a25-4931-b66d-9108fff554b4"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("92ffd141-5d2a-4930-afb8-0933b86deb87"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("0c02b0a8-4874-4a26-a16c-c0ead30e71af"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("2818f891-2e6a-4b24-b460-9b725f7e8e3c"));
            labelFromResource = (ITTLabel)AddControl(new Guid("1cc45cb5-ba0c-4226-9c92-1cfcd06e97f2"));
            base.InitializeControls();
        }

        public CancelledForm_Maintenance() : base("MAINTENANCE", "CancelledForm_Maintenance")
        {
        }

        protected CancelledForm_Maintenance(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}