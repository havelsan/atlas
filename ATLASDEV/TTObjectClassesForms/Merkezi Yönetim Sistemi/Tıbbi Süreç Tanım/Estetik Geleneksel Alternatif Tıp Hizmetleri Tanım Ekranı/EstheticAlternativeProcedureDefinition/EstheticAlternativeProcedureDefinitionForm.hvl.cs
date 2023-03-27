
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
    /// Estetik, Geleneksel, Alternatif Tıp Hizmetleri Tanım Ekranı
    /// </summary>
    public partial class EstheticAlternativeProcedureDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Estetik, Geleneksel, Alternatif Tıp Hizmetleri Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.EstheticAlternativeProcedureDefinition _EstheticAlternativeProcedureDefinition
        {
            get { return (TTObjectClasses.EstheticAlternativeProcedureDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTTextBox Description;
        protected ITTTextBox ID;
        protected ITTTextBox Qref;
        protected ITTLabel labelName;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTLabel labelQref;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelCode;
        protected ITTLabel labelID;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("65702a75-fbb7-4f48-b9a2-2bab8d435476"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("194d028e-786f-43b1-9227-c5738ce5a357"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("49c37c53-2e21-49b4-a867-5e853f99eafd"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("93353027-39ed-4992-8809-dc92ecb68f3d"));
            Code = (ITTTextBox)AddControl(new Guid("1c2074df-a4e2-4b80-a94d-140b867a155e"));
            Name = (ITTTextBox)AddControl(new Guid("e1114795-b386-4eae-833e-70d0cd20707e"));
            Description = (ITTTextBox)AddControl(new Guid("085d5c85-2ca8-4a5b-bb25-388f53e90e83"));
            ID = (ITTTextBox)AddControl(new Guid("fc4b6af9-3948-4b1c-8a55-4764eb267da5"));
            Qref = (ITTTextBox)AddControl(new Guid("f28a327a-6a2c-448e-a675-2cf55038ffa8"));
            labelName = (ITTLabel)AddControl(new Guid("d38804c7-05d4-4d44-b970-21204566c467"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("28ebab6b-a527-4b44-b8e7-55554d6c47b7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d63f1d9d-97cc-49c1-9fc8-1cbda4db2402"));
            labelDescription = (ITTLabel)AddControl(new Guid("38ec377f-c857-462e-99ae-918501ea7e37"));
            labelQref = (ITTLabel)AddControl(new Guid("fadb6bc6-6c34-4149-9328-54eea5acc51b"));
            IsActive = (ITTCheckBox)AddControl(new Guid("284482a0-5a3b-46da-b67f-01fab7c76e43"));
            labelCode = (ITTLabel)AddControl(new Guid("5d52ead4-a0fa-45a2-9840-fbb860637df1"));
            labelID = (ITTLabel)AddControl(new Guid("2a6b54ab-3c8b-4d0a-9388-c3f075010584"));
            base.InitializeControls();
        }

        public EstheticAlternativeProcedureDefinitionForm() : base("ESTHETICALTERNATIVEPROCEDUREDEFINITION", "EstheticAlternativeProcedureDefinitionForm")
        {
        }

        protected EstheticAlternativeProcedureDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}