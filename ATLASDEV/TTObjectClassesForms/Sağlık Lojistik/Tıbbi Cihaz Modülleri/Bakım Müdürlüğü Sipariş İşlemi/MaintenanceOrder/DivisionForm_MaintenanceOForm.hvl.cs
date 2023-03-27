
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
    /// Sipariş Açma
    /// </summary>
    public partial class DivisionForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel5;
        protected ITTMaskedTextBox RequestNO;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox OrderNO;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox ManufacturingAmount;
        protected ITTTextBox SpecialWorkAmount;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox OrderTypeList;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker CheckDate;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelOrderNO;
        protected ITTLabel labelID;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker OrderDate;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox DivisionSection;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ResDivision;
        protected ITTLabel labelResDivision;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelManufacturingAmount;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTLabel labelSpecialWorkAmount;
        protected ITTObjectListBox MilitaryUnit;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("72d078cb-77ac-4fc7-b91d-8377890f5ba0"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("e30be0eb-f2a3-4fa9-b199-3a4fcb454f8d"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("2032283b-2275-47ed-90c2-ff35bed9d5fa"));
            RequestNO = (ITTMaskedTextBox)AddControl(new Guid("6d13940c-f5d3-4d9a-bcfa-cbcaac9af806"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("bc436a1b-e3f9-49fb-8089-d040eb98f4a7"));
            OrderNO = (ITTTextBox)AddControl(new Guid("d9bae883-0e6d-453b-a883-50bd95d519c2"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("c9832d7c-7c76-43ae-aac9-e94941c910bd"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("437d1a92-ed23-404f-a62a-57654caa022e"));
            SpecialWorkAmount = (ITTTextBox)AddControl(new Guid("1c421edb-77e7-4f38-a354-8dc0302750db"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5edbd9b3-0394-4e5b-8da0-05b7f490d147"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("eaa25223-5a0b-4e26-bd3f-092344181795"));
            labelOrderName = (ITTLabel)AddControl(new Guid("1fc7bc16-9516-4315-9029-2dbcb4289530"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c3a83445-4352-48a6-8acd-425993d24025"));
            CheckDate = (ITTDateTimePicker)AddControl(new Guid("1508c846-887b-4ef0-835d-445770fce4fa"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("77659085-46ee-455c-9e17-5dadedee5c25"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("4ed4b7dd-bd21-4449-99c1-62cf3fff1c74"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("fe1c7b91-cfdf-4224-8c6b-805a04ee58a1"));
            labelID = (ITTLabel)AddControl(new Guid("5d6d0c5f-36ea-4623-bac0-81b135f025d6"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("7f3b921c-70b8-4464-82ed-87ad986968e3"));
            labelFromResource = (ITTLabel)AddControl(new Guid("6352441f-8606-410b-9466-9029703bca1f"));
            OrderDate = (ITTDateTimePicker)AddControl(new Guid("a79981ae-f5e1-4e86-82e0-9884e9c61788"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("931b01b1-c5b8-46e0-90cd-9b977eb66132"));
            labelActionDate = (ITTLabel)AddControl(new Guid("90bb936f-08b9-4881-abfe-be18670d5bca"));
            DivisionSection = (ITTObjectListBox)AddControl(new Guid("29136325-a808-4017-a614-754cc626c851"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1102ea20-d54e-4a90-b0f7-3c89077ee0f5"));
            ResDivision = (ITTObjectListBox)AddControl(new Guid("91b7cb96-e799-4b8c-8267-32462a9538b2"));
            labelResDivision = (ITTLabel)AddControl(new Guid("8fef9a31-a0a0-4c2f-908a-ad3697ca4112"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("3aa0780c-be50-4af7-8a6b-565e72ad3b1f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cb6a49ed-89a6-4cf9-9a18-3b7203c8ad05"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("6319f13d-dabb-48f3-86bc-f045ecbf98e7"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("a9fa84ef-8f89-450a-b29d-39f981cd52e5"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("3eb456dc-649f-47c8-970f-7102aeac5691"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("cf06ad4b-2c08-4848-b022-c0c2bfff9f39"));
            labelSpecialWorkAmount = (ITTLabel)AddControl(new Guid("f47ceb44-e8bf-42db-b69e-9c551f4af827"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("3adc1bdd-8da1-498f-9c9a-dda64fa26561"));
            base.InitializeControls();
        }

        public DivisionForm_MaintenanceO() : base("MAINTENANCEORDER", "DivisionForm_MaintenanceO")
        {
        }

        protected DivisionForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}