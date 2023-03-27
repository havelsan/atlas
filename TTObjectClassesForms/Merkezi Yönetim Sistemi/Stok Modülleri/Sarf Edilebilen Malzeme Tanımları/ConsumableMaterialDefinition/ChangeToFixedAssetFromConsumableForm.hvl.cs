
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
    public partial class ChangeToFixedAssetFromConsumableForm : TTForm
    {
    /// <summary>
    /// Sarf Edilebilen Malzeme Tanımları
    /// </summary>
        protected TTObjectClasses.ConsumableMaterialDefinition _ConsumableMaterialDefinition
        {
            get { return (TTObjectClasses.ConsumableMaterialDefinition)_ttObject; }
        }

        protected ITTCheckBox NeedCalibration;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox txtMaintenancePeriod;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTTextBox txtMaintenanceTime;
        protected ITTCheckBox isCalibrator;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox txtCalibrationTime;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel5;
        protected ITTTextBox txtCalibrationPeriod;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            NeedCalibration = (ITTCheckBox)AddControl(new Guid("15c5f290-5e02-44ea-84a6-a8e471555538"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("a382ed61-df42-4515-b223-c90b6e96116d"));
            txtMaintenancePeriod = (ITTTextBox)AddControl(new Guid("f6b9e4e3-ba46-4c84-99d6-ba6893f58e4f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9a50e750-f945-4b2c-870d-0574cac0751f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7db615df-26db-4fcb-b20b-858cfc3705b2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c959f737-211d-4607-919a-d866e6bfdb69"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("160db579-6963-4667-934a-b13c4646746d"));
            txtMaintenanceTime = (ITTTextBox)AddControl(new Guid("f21c4586-0043-4dae-879f-293f0e2b0bbb"));
            isCalibrator = (ITTCheckBox)AddControl(new Guid("77a848ca-10a5-4b11-8e49-2164949c77a8"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("e2d3f375-416b-44fe-bf83-edbf6fade7c6"));
            txtCalibrationTime = (ITTTextBox)AddControl(new Guid("9feff5b8-ca2b-4a08-b90b-24bace874b3a"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("d4c14de6-5d44-4828-bf16-15632c80b40e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("54e34e9d-d7c5-4b1d-8ebf-78fed3850156"));
            txtCalibrationPeriod = (ITTTextBox)AddControl(new Guid("a6c363d8-8fdf-40d8-9435-7b7d16ba6071"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("9b31abd1-4d5b-4cf9-9a71-2693acd072b9"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e02b2cb3-a743-4a92-bc11-c95e0dace54d"));
            base.InitializeControls();
        }

        public ChangeToFixedAssetFromConsumableForm() : base("CONSUMABLEMATERIALDEFINITION", "ChangeToFixedAssetFromConsumableForm")
        {
        }

        protected ChangeToFixedAssetFromConsumableForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}