
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
    /// Paket Hizmet Tanımı
    /// </summary>
    public partial class PackageProcedureDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Paket Hizmet Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.PackageProcedureDefinition _PackageProcedureDefinition
        {
            get { return (TTObjectClasses.PackageProcedureDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel lblType;
        protected ITTLabel labelName;
        protected ITTTextBox Description;
        protected ITTTextBox Qref;
        protected ITTTextBox Code;
        protected ITTTextBox ID;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Name;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelCode;
        protected ITTLabel labelEnglishName;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelQref;
        protected ITTLabel labelDescription;
        protected ITTLabel labelID;
        protected ITTEnumComboBox Type;
        protected ITTCheckBox holidaysIncluded;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("a5bae31f-b378-41f8-a93c-1ab0661a6408"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("b7e1253b-f669-416d-9d35-0f49c1854dc2"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("f7c9791e-9c17-4f3a-9d4c-f0609d0ebd1b"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("4f51d1be-a1e8-4942-9f0e-2558e57011f8"));
            lblType = (ITTLabel)AddControl(new Guid("83781e2d-9b11-4538-af82-c921dc3eede3"));
            labelName = (ITTLabel)AddControl(new Guid("8f1dfbe2-7e14-4531-b130-1e26f5a2e01e"));
            Description = (ITTTextBox)AddControl(new Guid("a185fed9-1574-474b-a1e8-2f291eb574de"));
            Qref = (ITTTextBox)AddControl(new Guid("78a7b14f-f437-4e3d-8166-32edb8bd1f94"));
            Code = (ITTTextBox)AddControl(new Guid("aaeb78ac-9139-4bbd-9e6a-937ae4c9aac3"));
            ID = (ITTTextBox)AddControl(new Guid("875e56e3-8bc3-4fc1-a56a-e6ab3c7b8506"));
            EnglishName = (ITTTextBox)AddControl(new Guid("71fd5e17-1c98-4bc9-b726-f0ec660d8e47"));
            Name = (ITTTextBox)AddControl(new Guid("a23f3988-ff40-4cbb-ab26-fa83ea3a316a"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("37cbe948-9826-495b-812b-40668c28c43f"));
            labelCode = (ITTLabel)AddControl(new Guid("53e396f7-7252-4630-b5d3-431e28ae4d0b"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("12bc29df-e0c4-47ba-8235-5175e0d420e7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9d72e251-e1b9-4fa0-be41-5805686f3cdd"));
            IsActive = (ITTCheckBox)AddControl(new Guid("8a571b4f-2bff-48f1-8410-6200955ae9a8"));
            labelQref = (ITTLabel)AddControl(new Guid("bdb4d6c0-44df-40f9-9484-b06268de1cea"));
            labelDescription = (ITTLabel)AddControl(new Guid("bf45a323-adff-454a-9808-ce94e0149638"));
            labelID = (ITTLabel)AddControl(new Guid("8f9c069c-67e6-4127-9950-e5f47334fc01"));
            Type = (ITTEnumComboBox)AddControl(new Guid("8b5f24e3-870c-43d7-8c20-39928f6b6b94"));
            holidaysIncluded = (ITTCheckBox)AddControl(new Guid("39c0ed60-8c7e-437e-affe-a9c3a4c2eeb2"));
            base.InitializeControls();
        }

        public PackageProcedureDefinitionForm() : base("PACKAGEPROCEDUREDEFINITION", "PackageProcedureDefinitionForm")
        {
        }

        protected PackageProcedureDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}