
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
    /// Kalibrasyon
    /// </summary>
    public partial class CalibrationNewForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
        protected TTObjectClasses.Calibration _Calibration
        {
            get { return (TTObjectClasses.Calibration)_ttObject; }
        }

        protected ITTLabel CalibrationStatusLabel;
        protected ITTLabel ttlabel4;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox objFixedAssetMaterial;
        protected ITTTextBox RequestNO;
        protected ITTTextBox Description;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("f4897eed-24f6-4f0d-922a-2e1e13e94186"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3a9cc167-7778-45fe-91aa-fcc22cc44af0"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("8403024e-5485-4abd-93bb-930951766c1e"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("3406a7cc-4dcb-44ab-874c-d1aa34ab6d39"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("5f9052c5-25c9-40d0-a773-c545f048b128"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6cfce271-ea2d-4950-9982-4042a84c4724"));
            objFixedAssetMaterial = (ITTObjectListBox)AddControl(new Guid("e67a703d-c471-4342-9a7b-5def7cf76c24"));
            RequestNO = (ITTTextBox)AddControl(new Guid("89bac76b-d9c9-4bff-8b21-b819883d33b0"));
            Description = (ITTTextBox)AddControl(new Guid("efdc8915-4764-4e2c-b987-315c91a18a06"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("d8605bae-8176-4aa1-9c1f-6e9ff0103ca2"));
            labelDescription = (ITTLabel)AddControl(new Guid("1d77ad27-2548-4af8-a3e7-4c6547566a87"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("a2cd8eec-6452-4724-a1b8-80945494304e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e2968b8a-7231-43fd-88c7-e9516c3d9804"));
            base.InitializeControls();
        }

        public CalibrationNewForm() : base("CALIBRATION", "CalibrationNewForm")
        {
        }

        protected CalibrationNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}