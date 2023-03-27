
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
    public partial class SurgeryProcedureForm : TTForm
    {
    /// <summary>
    /// Ameliyat Kategorisi
    /// </summary>
        protected TTObjectClasses.SurgeryProcedure _SurgeryProcedure
        {
            get { return (TTObjectClasses.SurgeryProcedure)_ttObject; }
        }

        protected ITTGrid SurgeryResponsibleDoctors;
        protected ITTTextBoxColumn RankingNumberSurgeryResponsibleDoctor;
        protected ITTListBoxColumn ResponsibleDoctorSurgeryResponsibleDoctor;
        protected ITTCheckBox IsScoliosisSurgery;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelRabsonGroup;
        protected ITTEnumComboBox RabsonGroup;
        protected ITTLabel labelDepartment;
        protected ITTObjectListBox Department;
        protected ITTButton EuroScoreButton;
        protected ITTLabel labelProcedureObject;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelAyniFarkliKesi;
        protected ITTObjectListBox AyniFarkliKesi;
        protected ITTLabel labelSutPoint;
        protected ITTTextBox SutPoint;
        protected ITTTextBox GilPoint;
        protected ITTLabel labelPosition;
        protected ITTEnumComboBox Position;
        protected ITTLabel labelDescriptionOfProcedureObject;
        protected ITTRichTextBoxControl DescriptionOfProcedureObject;
        protected ITTLabel lableGilPoint;
        protected ITTLabel lableResponsibleDoctor;
        override protected void InitializeControls()
        {
            SurgeryResponsibleDoctors = (ITTGrid)AddControl(new Guid("3b704644-c94d-4842-b156-23fa08195926"));
            RankingNumberSurgeryResponsibleDoctor = (ITTTextBoxColumn)AddControl(new Guid("650c6260-0370-49c2-938c-068d4e47e662"));
            ResponsibleDoctorSurgeryResponsibleDoctor = (ITTListBoxColumn)AddControl(new Guid("baedfd8c-745b-4150-a5ff-90c19118b002"));
            IsScoliosisSurgery = (ITTCheckBox)AddControl(new Guid("26b89e6e-7068-45b1-85bb-2e9fde68110a"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("662050e5-e63d-483c-be44-a9b1c16f02a7"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("10608af5-a1e3-4675-bdcb-6946f2a69b3d"));
            labelRabsonGroup = (ITTLabel)AddControl(new Guid("b8db347a-78d3-4629-b6a7-5e28422f3423"));
            RabsonGroup = (ITTEnumComboBox)AddControl(new Guid("c43b64fe-a5b2-4cf2-89cc-383234b35150"));
            labelDepartment = (ITTLabel)AddControl(new Guid("17d032d7-99e5-4a21-8206-92e85fff8b8d"));
            Department = (ITTObjectListBox)AddControl(new Guid("4f9926df-8d1e-4a1b-8b16-a4b7b5c3686b"));
            EuroScoreButton = (ITTButton)AddControl(new Guid("038b218b-6392-489e-9bd2-94902ebb45ef"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("e7bcf0da-087d-4a0c-bef0-a92dbf9f9019"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("b2763ebf-0b84-4593-8631-41b107b97144"));
            labelAyniFarkliKesi = (ITTLabel)AddControl(new Guid("0ca75a7c-3264-4d49-9b5a-cfba7832e3d4"));
            AyniFarkliKesi = (ITTObjectListBox)AddControl(new Guid("bbf5f8bf-1ca3-46ae-8205-eba5d9830eb2"));
            labelSutPoint = (ITTLabel)AddControl(new Guid("ee1ab035-8e80-44ec-84d1-1ec26c169907"));
            SutPoint = (ITTTextBox)AddControl(new Guid("df183cfb-494f-49cb-a8ae-4ab19efd630d"));
            GilPoint = (ITTTextBox)AddControl(new Guid("f39a4ffd-1e58-492a-9d03-857038799e4d"));
            labelPosition = (ITTLabel)AddControl(new Guid("4b8895a6-d818-4df5-a053-d067e5f7e7c6"));
            Position = (ITTEnumComboBox)AddControl(new Guid("47c86ce7-f0f1-4327-b713-7fa9b00985bb"));
            labelDescriptionOfProcedureObject = (ITTLabel)AddControl(new Guid("1dcc4aa5-bfde-41e3-b111-f6b864fd992a"));
            DescriptionOfProcedureObject = (ITTRichTextBoxControl)AddControl(new Guid("b68489df-99cc-4e17-899a-441f40df85fc"));
            lableGilPoint = (ITTLabel)AddControl(new Guid("9fe6a0ce-3655-419c-b76b-2774f3fc07d3"));
            lableResponsibleDoctor = (ITTLabel)AddControl(new Guid("f2a3f805-7a51-4bca-973d-c4e172050607"));
            base.InitializeControls();
        }

        public SurgeryProcedureForm() : base("SURGERYPROCEDURE", "SurgeryProcedureForm")
        {
        }

        protected SurgeryProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}