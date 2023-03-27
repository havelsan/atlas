
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
    /// Son Kontrol
    /// </summary>
    public partial class LastControlForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTButton cmdSIIB;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel2;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTabPage tttabpage3;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount2;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTabPage tttabpage4;
        protected ITTRichTextBoxControl TTRichTextBoxUserControl;
        protected ITTTabPage tttabpage5;
        protected ITTGrid UserMaintenances;
        protected ITTListBoxColumn ttlistboxcolumn4;
        protected ITTCheckBoxColumn Checked;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTabPage tttabpage6;
        protected ITTGrid UnitMaintenances;
        protected ITTListBoxColumn Parameter;
        protected ITTCheckBoxColumn UnitChecked;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox3;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelResponsibleResource;
        protected ITTObjectListBox FixedAsset;
        protected ITTEnumComboBox RepairPlace;
        protected ITTObjectListBox FromResource;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker EndDate;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelEndDate;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ToResource;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelToResource;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelStartDate;
        override protected void InitializeControls()
        {
            cmdSIIB = (ITTButton)AddControl(new Guid("e05105ec-61b7-4a3b-a45a-ac9333cfc557"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("66b6a48a-436e-4629-a1f5-86361bb79171"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("1ae8d0be-953f-4296-937f-d36911323c0f"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("4adb22df-fac8-450b-af1b-6959df80ced2"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("b2d8e5c4-171d-466e-90b5-f7e5a2aaf765"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f2cdd456-9432-469b-82e9-ed3f9b4fb7e6"));
            Description = (ITTTextBox)AddControl(new Guid("153e42fa-ee88-427a-ac32-e18b505614cf"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("d3ea0e28-2cf3-403a-bb29-c175bdff3810"));
            labelDescription = (ITTLabel)AddControl(new Guid("cc70ed67-1975-4123-91e7-94d28c7f1a51"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("81e2389b-205f-4fa2-a0c7-8ecde9e45c6b"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("30d8c06f-948d-435f-b47f-8a4e379bec76"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("972e7559-119f-45e4-ab52-fc2a56f80217"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("65d35107-3080-4d2a-a22e-96ea55f89efe"));
            Material = (ITTListBoxColumn)AddControl(new Guid("f7c9e5c8-38f7-4529-9188-075f8ae18abf"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("aa73db3f-8049-4715-baa7-afb2db9f302d"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("7e60cc52-d67c-4b98-9c20-910b3a347cd0"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6a4134a1-08a4-4d9f-9550-3fa8538065c3"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("520512aa-eacf-446f-a9a5-fd29499a8786"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("ee8004e5-ddde-4ea2-b085-dc5e6188f557"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("9d7b45c4-22c4-4cfd-b46d-66508ef2fe14"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("5b824683-0550-46d5-b67b-6c2b7031d783"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("4032c030-658d-4096-ab73-47996637351c"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("e49d5fd7-2b8a-48fd-b27c-f99cf0c0f8c8"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("a187b4a5-457b-4e8b-81d6-ccc229750f8a"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("d4a4053f-ae73-4e89-a66c-b5a8253b0433"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("24bdce60-fd53-4e27-851f-9a571f410b8a"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("3291e636-6a04-4901-b8ed-6de06da6bd0b"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("16f38111-74fe-4423-ac02-454cc5f12982"));
            TTRichTextBoxUserControl = (ITTRichTextBoxControl)AddControl(new Guid("1abc99ad-ae76-47b2-8f3d-69cef19b7808"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("c9e1ec8e-6297-4228-9a6b-94f003c280e4"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("909a6b4b-29c7-486c-9d33-0c8933f0a86f"));
            ttlistboxcolumn4 = (ITTListBoxColumn)AddControl(new Guid("868190e8-9c58-4504-b849-c56bdf523c5a"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("1cb1787d-cb27-43e5-a02d-e48b0eb63320"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("f9ae52a5-818e-4376-be72-e6bb7e606593"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("53dbdee1-2870-499d-8457-89b00f1fc4aa"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("9e230225-1daa-4ef1-890a-bcaaebcf05ae"));
            Parameter = (ITTListBoxColumn)AddControl(new Guid("e8e409bc-fcbd-43c0-bda3-9abd1046de10"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("62ae40c3-824a-4619-9c61-a49eda9eba7d"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("e96ac644-2094-4666-9855-24a438d7c0c1"));
            RequestNO = (ITTTextBox)AddControl(new Guid("972553ac-3de9-446e-8ad7-96eb07cdfc4e"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("4b65f197-87ec-4870-b0f9-d6d1cd0070f9"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("b3dcf0e6-446c-4088-a52d-afc798b8278f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("3997044f-656e-46db-ba75-1c53dfea405f"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("83d76d82-b3ba-4690-82bb-8d40b3ba1618"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("749dc2a3-00db-4312-979b-015a0d6d13b9"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("5c8dfbae-99c6-46b4-abc8-12e483d8e420"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("c61a0cc5-a983-4823-ad88-1f955f88f512"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("f1f0a98f-573c-4583-bbaa-27d93025c3b6"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("ac6bb875-fbd7-4e48-8edd-3db7095ad233"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("99c552da-12b7-48e9-a472-40b4c2740092"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("f0aa51d6-803a-4e6f-b4de-40ea553a6331"));
            labelEndDate = (ITTLabel)AddControl(new Guid("54964498-ef96-420b-b210-62704638f8ae"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("41a5a6df-4b8e-43c9-bbb0-68373e4d2c6f"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("16d14e44-dabd-4c3c-8950-85f4ebf6e906"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("d0d2f011-8d97-4b24-ac93-95f39a185ced"));
            labelToResource = (ITTLabel)AddControl(new Guid("958b396f-30a5-40eb-a546-ab2581fc2ac3"));
            labelFromResource = (ITTLabel)AddControl(new Guid("d6962796-2a2d-49b8-a17d-af4c23510b1f"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("1ee40197-830c-4659-8ee3-bb7fabdcf3ff"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("8cebda23-02a3-4269-8158-bc060bf7c7d4"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("89305ada-ee12-4a57-bffb-cb4bc5465cbe"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("2262627f-4911-4d26-a698-df95e4721e8a"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("7ddbc613-518e-4d6f-9f0c-e5ba25bc4b65"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("6426b024-def0-4688-b5d8-ef4edc041158"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("c12e67e3-76ad-4c4c-b93e-fcb67d97c174"));
            labelStartDate = (ITTLabel)AddControl(new Guid("64f6e6fc-f289-450b-b405-fccba52196d1"));
            base.InitializeControls();
        }

        public LastControlForm() : base("REPAIR", "LastControlForm")
        {
        }

        protected LastControlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}