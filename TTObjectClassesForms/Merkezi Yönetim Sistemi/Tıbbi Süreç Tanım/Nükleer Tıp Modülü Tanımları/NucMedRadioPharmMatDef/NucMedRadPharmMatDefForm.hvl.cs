
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
    /// Radyofarmasötik Sarf  Tanımımları
    /// </summary>
    public partial class NucMedRadPharmMatDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.NucMedRadioPharmMatDef _NucMedRadioPharmMatDef
        {
            get { return (TTObjectClasses.NucMedRadioPharmMatDef)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ProductionInfoTabPage;
        protected ITTGrid MaterialBarcodeLevels;
        protected ITTListBoxColumn Producer;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Name2;
        protected ITTTextBoxColumn PackageAmount;
        protected ITTTextBoxColumn LicenceNO;
        protected ITTDateTimePickerColumn LicenceDate;
        protected ITTEnumComboBoxColumn LicencingOrganization;
        protected ITTTabPage MaterialVatRateTabPage;
        protected ITTGrid MaterialVatRates;
        protected ITTTextBoxColumn VatRate;
        protected ITTDateTimePickerColumn StartDate;
        protected ITTDateTimePickerColumn EndDate;
        protected ITTTabPage PictureTabPage;
        protected ITTPictureBoxControl ttpictureboxcontrol1;
        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTObjectListBox StockCard;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelStockCard;
        protected ITTLabel labelCode;
        protected ITTCheckBox IsActive;
        protected ITTObjectListBox MaterialTree;
        protected ITTLabel labelMaterialTree;
        protected ITTLabel labelName;
        protected ITTCheckBox Chargable;
        protected ITTCheckBox AllowToGivePatient;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("7ddb301d-ad5c-45eb-a5e2-8f5c5e09f6cc"));
            ProductionInfoTabPage = (ITTTabPage)AddControl(new Guid("bcca2ed5-7f02-49f5-9629-03e0adc92d3c"));
            MaterialBarcodeLevels = (ITTGrid)AddControl(new Guid("7650f2a7-3ba3-4dd7-8dc4-d127991fa57c"));
            Producer = (ITTListBoxColumn)AddControl(new Guid("33a059fe-d469-4d36-a6be-69b9d1eac692"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("2afce068-eb47-4609-9e33-b40428cc92f0"));
            Name2 = (ITTTextBoxColumn)AddControl(new Guid("c92fa40e-02d9-4e98-9b3d-4f3ea57dbcb4"));
            PackageAmount = (ITTTextBoxColumn)AddControl(new Guid("3b300832-d1fb-4d3e-9d97-332ff65c50e8"));
            LicenceNO = (ITTTextBoxColumn)AddControl(new Guid("5cfa74dc-2a8c-4d68-936d-23eba230e152"));
            LicenceDate = (ITTDateTimePickerColumn)AddControl(new Guid("bf990987-2454-4227-a998-f00a797eea52"));
            LicencingOrganization = (ITTEnumComboBoxColumn)AddControl(new Guid("8f4cf52f-0ec9-4e98-8a09-a7e0df31ca67"));
            MaterialVatRateTabPage = (ITTTabPage)AddControl(new Guid("9f6a7f32-152a-4f41-bcfe-9c4164c043ee"));
            MaterialVatRates = (ITTGrid)AddControl(new Guid("c9fdce39-c909-4f16-89af-dc840766a5a4"));
            VatRate = (ITTTextBoxColumn)AddControl(new Guid("aa5bd3f9-221f-4c54-9698-f41e3ad3a527"));
            StartDate = (ITTDateTimePickerColumn)AddControl(new Guid("163f1cd1-c4f5-45bd-9579-35c03b34b605"));
            EndDate = (ITTDateTimePickerColumn)AddControl(new Guid("08ca77e4-12a5-4d1c-abb4-08af42027ce4"));
            PictureTabPage = (ITTTabPage)AddControl(new Guid("464ec2f4-5754-4306-b8a2-efd7063f9a1f"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("2db3913f-6b70-48db-bb43-0ffec3943ee1"));
            Code = (ITTTextBox)AddControl(new Guid("4575a44d-0f73-4b58-828c-fbddd609d555"));
            Name = (ITTTextBox)AddControl(new Guid("6fe4e11b-9846-4ec4-92ea-cebd3bcb7a49"));
            EnglishName = (ITTTextBox)AddControl(new Guid("eeef940b-dd41-4d11-8061-8da2c0f0ddf2"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("a78ef7b3-e0a5-4f69-8c15-3d8d4d4117aa"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d6d9080b-edfa-4be0-af6e-8a4f58cc87a7"));
            labelStockCard = (ITTLabel)AddControl(new Guid("01303dca-9a67-4199-b73f-74ff79ae488a"));
            labelCode = (ITTLabel)AddControl(new Guid("08d9e0ec-dabd-44e9-98f2-66afb934dcdb"));
            IsActive = (ITTCheckBox)AddControl(new Guid("4ab7adc7-033a-4cfa-a001-c8250c9cce74"));
            MaterialTree = (ITTObjectListBox)AddControl(new Guid("2a3a1fa1-da58-427d-9de1-a842f943bdce"));
            labelMaterialTree = (ITTLabel)AddControl(new Guid("2b2f97e1-c488-4e26-a366-b0a31aa160c1"));
            labelName = (ITTLabel)AddControl(new Guid("1827a98e-724c-4f65-b23f-a96a1477a634"));
            Chargable = (ITTCheckBox)AddControl(new Guid("286d8db3-d459-44f9-a75b-c1d5d71250ce"));
            AllowToGivePatient = (ITTCheckBox)AddControl(new Guid("ee4a9340-4324-41a0-b479-87043a0f65aa"));
            base.InitializeControls();
        }

        public NucMedRadPharmMatDefForm() : base("NUCMEDRADIOPHARMMATDEF", "NucMedRadPharmMatDefForm")
        {
        }

        protected NucMedRadPharmMatDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}