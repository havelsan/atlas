
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
    /// Paket Tanımı
    /// </summary>
    public partial class PackageDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Paket Tanımlama
    /// </summary>
        protected TTObjectClasses.PackageDefinition _PackageDefinition
        {
            get { return (TTObjectClasses.PackageDefinition)_ttObject; }
        }

        protected ITTTextBox ID;
        protected ITTTextBox Name;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelID;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GRIDDetailProcedure;
        protected ITTListBoxColumn PROCEDUREGROUP;
        protected ITTEnumComboBoxColumn PInclusive;
        protected ITTListBoxColumn PPricingList;
        protected ITTListDefComboBoxColumn PPricingListMultiplier;
        protected ITTListBoxColumn PSecondPricingList;
        protected ITTListDefComboBoxColumn PSecondPricingListMultiplier;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GRIDMaterialDetail;
        protected ITTListBoxColumn MaterialGrup;
        protected ITTEnumComboBoxColumn MInclusive;
        protected ITTListBoxColumn MPricingList;
        protected ITTTextBox Code;
        protected ITTLabel labelDayLimit;
        protected ITTObjectListBox BEDCLASS;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage3;
        protected ITTGrid GRIDPackageExceptionProcedures;
        protected ITTListBoxColumn PROCEDURENAME;
        protected ITTEnumComboBoxColumn PEXCINCLUSIVE;
        protected ITTTextBoxColumn PEXCAMOUNT;
        protected ITTListBoxColumn PEXCPRICINGLIST;
        protected ITTTabPage tttabpage4;
        protected ITTGrid GRIDPackageExceptionMaterials;
        protected ITTListBoxColumn MATERIALNAME;
        protected ITTEnumComboBoxColumn MEXCINCLUSIVE;
        protected ITTTextBoxColumn MEXCAMOUNT;
        protected ITTListBoxColumn MEXCPRICINGLIST;
        protected ITTTextBox DayLimit;
        protected ITTLabel labelProcedureDefinition;
        protected ITTObjectListBox ProcedureDefinition;
        protected ITTLabel labelCode;
        protected ITTLabel labelName;
        protected ITTCheckBox UsePackageRulesForPricing;
        override protected void InitializeControls()
        {
            ID = (ITTTextBox)AddControl(new Guid("16211ea5-69e2-433a-bd1f-4bfa8113869d"));
            Name = (ITTTextBox)AddControl(new Guid("a9050d07-765f-42c6-8701-5e539c33f19c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("80e2aa0a-1884-4b85-a29f-23df9e4cc06d"));
            labelID = (ITTLabel)AddControl(new Guid("85c94584-03e2-4a29-9694-2e291161bf6f"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e6d5eb86-667d-4cb4-9e5e-683027abbf33"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("7f30644e-a505-4846-81b9-68e876c964b3"));
            GRIDDetailProcedure = (ITTGrid)AddControl(new Guid("b4904f29-4c34-459c-b987-4523175e89ec"));
            PROCEDUREGROUP = (ITTListBoxColumn)AddControl(new Guid("f0f4b37f-9782-4eab-8a83-1e2cc5d6a3aa"));
            PInclusive = (ITTEnumComboBoxColumn)AddControl(new Guid("f79ece73-dba1-41af-987f-6dcc30348433"));
            PPricingList = (ITTListBoxColumn)AddControl(new Guid("fa4bd9df-3e2a-4c0c-9ab1-0dd5f0193b2b"));
            PPricingListMultiplier = (ITTListDefComboBoxColumn)AddControl(new Guid("fdbb2c0f-4959-4091-ba6f-849f8eaf505a"));
            PSecondPricingList = (ITTListBoxColumn)AddControl(new Guid("e493011c-7fd5-4127-8c0f-b846ea8cf2e7"));
            PSecondPricingListMultiplier = (ITTListDefComboBoxColumn)AddControl(new Guid("a53b1ff5-24b2-4484-bed2-c5c2473c329f"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("c24e2494-9a2c-4798-bbe7-129236bf0388"));
            GRIDMaterialDetail = (ITTGrid)AddControl(new Guid("5cac0a32-99bf-4f09-a17c-a6666387c27f"));
            MaterialGrup = (ITTListBoxColumn)AddControl(new Guid("903943b0-85b2-4240-8e74-18d438d6a546"));
            MInclusive = (ITTEnumComboBoxColumn)AddControl(new Guid("a3e07736-3c74-4210-ae80-b9e650df1e34"));
            MPricingList = (ITTListBoxColumn)AddControl(new Guid("39cae62c-b22c-406b-b8cd-5cfcf7e09a1c"));
            Code = (ITTTextBox)AddControl(new Guid("aff8d1b1-ca70-40e2-b689-8ec1a287f03a"));
            labelDayLimit = (ITTLabel)AddControl(new Guid("b88981eb-1a64-4b89-a756-7f60af73c3ba"));
            BEDCLASS = (ITTObjectListBox)AddControl(new Guid("b079a100-ce58-4dcb-ad17-8c24394b6fa6"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("1e588fc3-727e-4e63-b556-9a637eb17974"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("bd5560c0-6a9a-46bf-83fd-0c7c3db54848"));
            GRIDPackageExceptionProcedures = (ITTGrid)AddControl(new Guid("a44c0b28-4732-4a59-96ae-57dc206554c1"));
            PROCEDURENAME = (ITTListBoxColumn)AddControl(new Guid("bf084f97-1515-4500-a0d5-025be83ffbf1"));
            PEXCINCLUSIVE = (ITTEnumComboBoxColumn)AddControl(new Guid("d9026695-efa9-4a60-a982-5eb6baaa91d9"));
            PEXCAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("90b51ebb-fdf1-47a1-9974-2cf474675c76"));
            PEXCPRICINGLIST = (ITTListBoxColumn)AddControl(new Guid("f767e99e-b3f1-4b75-ae09-04c4d61bdce7"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("771ae86c-e0e9-4e50-916d-fd0650e5c0f2"));
            GRIDPackageExceptionMaterials = (ITTGrid)AddControl(new Guid("a2e63210-4d3e-4d5c-92ba-444680d96a99"));
            MATERIALNAME = (ITTListBoxColumn)AddControl(new Guid("9ef36783-6a95-45bd-a885-79d774741de1"));
            MEXCINCLUSIVE = (ITTEnumComboBoxColumn)AddControl(new Guid("59681584-c394-47fe-9eec-b469cc35fbe4"));
            MEXCAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("b4408ae6-3c16-4b91-aecb-15754713329d"));
            MEXCPRICINGLIST = (ITTListBoxColumn)AddControl(new Guid("dfce0e93-6da8-47af-8a1e-2e0d3a90e9d7"));
            DayLimit = (ITTTextBox)AddControl(new Guid("6408765b-5372-42c0-bfcf-a3425bb59754"));
            labelProcedureDefinition = (ITTLabel)AddControl(new Guid("4f47b2bc-db96-4bcf-b8ee-dde048d4e9e9"));
            ProcedureDefinition = (ITTObjectListBox)AddControl(new Guid("8c89af4f-9513-42c9-9282-de0bcac6593a"));
            labelCode = (ITTLabel)AddControl(new Guid("9e0d8694-3383-44b2-a025-ee37d90ab4d0"));
            labelName = (ITTLabel)AddControl(new Guid("41839906-bae7-439d-9875-f52b37c6453c"));
            UsePackageRulesForPricing = (ITTCheckBox)AddControl(new Guid("5f03d4b6-eed4-4de1-bb13-91301c31b3d5"));
            base.InitializeControls();
        }

        public PackageDefinitionForm() : base("PACKAGEDEFINITION", "PackageDefinitionForm")
        {
        }

        protected PackageDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}