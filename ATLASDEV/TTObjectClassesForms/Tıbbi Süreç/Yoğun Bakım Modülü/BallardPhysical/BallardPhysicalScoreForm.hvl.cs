
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
    public partial class BallardPhysicalScoreForm : BaseMultipleDataEntryForm
    {
        protected TTObjectClasses.BallardPhysical _BallardPhysical
        {
            get { return (TTObjectClasses.BallardPhysical)_ttObject; }
        }

        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelTotalScore;
        protected ITTTextBox TotalScore;
        protected ITTLabel labelSkin;
        protected ITTEnumComboBox Skin;
        protected ITTLabel labelPlantarLines;
        protected ITTEnumComboBox PlantarLines;
        protected ITTLabel labelMaleGenitalia;
        protected ITTEnumComboBox MaleGenitalia;
        protected ITTLabel labelLanugo;
        protected ITTEnumComboBox Lanugo;
        protected ITTLabel labelFemaleGenitalia;
        protected ITTEnumComboBox FemaleGenitalia;
        protected ITTLabel labelEar;
        protected ITTEnumComboBox Ear;
        protected ITTLabel labelBreast;
        protected ITTEnumComboBox Breast;
        override protected void InitializeControls()
        {
            labelEntryDate = (ITTLabel)AddControl(new Guid("758cd0ca-98a6-47de-a60b-b8050bc54641"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("a7449b1c-9901-429c-95f1-187d0c4b4c83"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("90ca39a3-9c91-4b3d-b417-a7c7ef71e396"));
            TotalScore = (ITTTextBox)AddControl(new Guid("ea2cf2a3-72e3-4473-a98d-5b6915d0a36c"));
            labelSkin = (ITTLabel)AddControl(new Guid("68266ff4-0d63-4894-9070-5762da50bfa2"));
            Skin = (ITTEnumComboBox)AddControl(new Guid("08325988-44d7-47fe-859b-e2e47d6aaa20"));
            labelPlantarLines = (ITTLabel)AddControl(new Guid("ba4875a0-bc49-4a78-a21e-b6945d4bbf9f"));
            PlantarLines = (ITTEnumComboBox)AddControl(new Guid("24a6de27-c464-4a23-9407-d64685a9203d"));
            labelMaleGenitalia = (ITTLabel)AddControl(new Guid("2f8db786-a105-4af1-b267-0e706e9ce406"));
            MaleGenitalia = (ITTEnumComboBox)AddControl(new Guid("7344841a-3764-41a6-9a20-98787d500f3e"));
            labelLanugo = (ITTLabel)AddControl(new Guid("b5581be0-5c35-4563-89f4-3c0bde8586c4"));
            Lanugo = (ITTEnumComboBox)AddControl(new Guid("4e276ada-a9da-4592-a088-867d056f4460"));
            labelFemaleGenitalia = (ITTLabel)AddControl(new Guid("6fcfdfbb-2cf0-49ba-bb2d-085f9006165c"));
            FemaleGenitalia = (ITTEnumComboBox)AddControl(new Guid("0ad786a3-abe3-4196-9865-126a6469186d"));
            labelEar = (ITTLabel)AddControl(new Guid("8e2d721d-7287-4ca0-8113-95932b21a5c6"));
            Ear = (ITTEnumComboBox)AddControl(new Guid("1465e5bb-39c4-409a-a2fb-c66782f66933"));
            labelBreast = (ITTLabel)AddControl(new Guid("e7148018-aafb-4b57-9336-66d80a0c1926"));
            Breast = (ITTEnumComboBox)AddControl(new Guid("93d5d94c-5f7b-426e-a390-857a3ba6fd2a"));
            base.InitializeControls();
        }

        public BallardPhysicalScoreForm() : base("BALLARDPHYSICAL", "BallardPhysicalScoreForm")
        {
        }

        protected BallardPhysicalScoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}