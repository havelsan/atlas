
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
    /// Seyyar Ekip Talebi
    /// </summary>
    public partial class TeamRequestForm : RUL_BaseForm
    {
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
        protected TTObjectClasses.ReferToUpperLevel _ReferToUpperLevel
        {
            get { return (TTObjectClasses.ReferToUpperLevel)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox BreakDown;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox ReferTypeCombobox;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelBreakDown;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromMilitaryUnit;
        protected ITTObjectListBox Stage;
        protected ITTLabel ttlabel61;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTLabel ttlabel66;
        protected ITTLabel labelToMilitaryUnit1;
        protected ITTLabel labelFromMilitaryUnit1;
        protected ITTObjectListBox ToMilitaryUnit;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("3d6dee85-20b3-4366-a019-c4a151c7f191"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("9fe66bf2-22e7-46cb-b7e1-10301f1e9a62"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2a16ab0a-bbb3-4721-9a10-1fc398222095"));
            RequestNO = (ITTTextBox)AddControl(new Guid("2b547cb0-d068-44ce-96de-df6132238b7b"));
            BreakDown = (ITTTextBox)AddControl(new Guid("fe4c7d9a-c260-4fb0-9f30-2b1c72dd900c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("4551c80a-2173-4695-9af9-ed68cc4f839c"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("9d606d46-4b92-4d91-8347-ac3e69e9e9e6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5ccddaf0-c1eb-4e5c-86b8-5bcc3b56c141"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("fb676168-626f-48d5-89e4-5e983447d040"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("f2bb0a84-6605-464a-ac3d-b8a9689759ad"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("555cc206-7f55-4f8a-8e1e-42e23f744ad7"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0f5c1090-762a-4fbb-837e-8d8899997a7f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e3b3a3ed-8951-4f62-bcd4-1b872404211c"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("91e1afb0-b4e8-4652-b2db-30dfd63c6e07"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("13393b2f-3144-44c4-9f7d-064496560728"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("f57b8333-146e-4f3b-b340-9b0c8d6e6882"));
            Stage = (ITTObjectListBox)AddControl(new Guid("11dc69ae-66d6-46d3-96d3-f4b5a3d15417"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("9ff238bf-78ab-41d6-9679-451f9224eb57"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("d8ab3632-d6a2-4ed1-bda2-fd47f37d0ded"));
            ttlabel66 = (ITTLabel)AddControl(new Guid("c85d660b-784e-4d99-8ba3-371ed1707f59"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("7a5c09d9-a959-4349-9583-fe8aa58f5d56"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("553f1893-d7fc-4b6b-9995-87da9a89eb78"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("3909b4c3-6b64-4860-aed4-3018b4472f87"));
            base.InitializeControls();
        }

        public TeamRequestForm() : base("REFERTOUPPERLEVEL", "TeamRequestForm")
        {
        }

        protected TeamRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}