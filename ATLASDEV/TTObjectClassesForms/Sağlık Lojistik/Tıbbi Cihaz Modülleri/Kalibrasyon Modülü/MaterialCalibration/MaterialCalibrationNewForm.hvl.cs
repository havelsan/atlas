
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
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
    public partial class MaterialCalibrationNewForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialCalibration _MaterialCalibration
        {
            get { return (TTObjectClasses.MaterialCalibration)_ttObject; }
        }

        protected ITTTextBox RequestNO;
        protected ITTTextBox Description;
        protected ITTLabel CalibrationStatusLabel;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("0e4a9068-32f7-4063-8831-1b3e3b33cc74"));
            Description = (ITTTextBox)AddControl(new Guid("1c1f7da7-c7e7-4363-b44e-425a06cfc485"));
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("6c45759d-fba1-4ab2-9aa8-c5d448c88738"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("71b102a7-f046-4ac2-91f9-3f5142c63fb1"));
            labelDescription = (ITTLabel)AddControl(new Guid("00701d1a-77e5-4582-8d3b-bb282cce3eae"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("482ee5fd-a23c-4b4c-aa77-a0f3932fddd0"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("851dbbef-79b6-4435-a746-e156f915436b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d8780347-7ff5-449b-a49b-39ea744271be"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("9a14a845-8ef9-4ee9-84be-494a5b93deb9"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("3e8c8869-093b-40f0-8b54-00c5a9aba599"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("b2dd0383-4753-4023-93b5-3647993c2bad"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("ee752577-b0f0-4c11-aa37-2ddb96791c1b"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3db22415-dcee-4e50-9110-e8a2f66b27b1"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("263100f6-4b7b-4f63-a82f-1dd2f7e8e4ae"));
            base.InitializeControls();
        }

        public MaterialCalibrationNewForm() : base("MATERIALCALIBRATION", "MaterialCalibrationNewForm")
        {
        }

        protected MaterialCalibrationNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}