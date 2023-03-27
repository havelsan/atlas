
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
    /// Vakabaşı Hizmet Tanımı
    /// </summary>
    public partial class BulletinProcedureDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Vakabaşı Hizmet Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.BulletinProcedureDefinition _BulletinProcedureDefinition
        {
            get { return (TTObjectClasses.BulletinProcedureDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTTextBox Description;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox ID;
        protected ITTTextBox Qref;
        protected ITTLabel labelName;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelEnglishName;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTLabel labelQref;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelCode;
        protected ITTLabel labelID;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("35fa4cf3-36ea-4d2c-b6f4-8a647250b4cb"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("030be816-0c3f-4a45-9042-1d696d49c262"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("a1437406-5902-469a-9910-b512a129aad5"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("056e7b8f-f0ce-4818-9870-e98d68e98b07"));
            Description = (ITTTextBox)AddControl(new Guid("d17cd837-ff19-4e17-b61d-bf40a1b056c3"));
            EnglishName = (ITTTextBox)AddControl(new Guid("2274afd1-8fc3-49fd-9435-34d0b4edeb75"));
            Name = (ITTTextBox)AddControl(new Guid("956bf8bd-b532-47d3-9f84-68be0e95d5bf"));
            Code = (ITTTextBox)AddControl(new Guid("8cb973d0-3cf8-4811-a2eb-9cb9ac062173"));
            ID = (ITTTextBox)AddControl(new Guid("6b85b496-9b8a-439d-833d-cbbd1f30a180"));
            Qref = (ITTTextBox)AddControl(new Guid("5ac1b771-0fe0-4b12-99e7-29693c0b9561"));
            labelName = (ITTLabel)AddControl(new Guid("568bdeb5-a9ce-47d6-bf83-a1ad5470e6d5"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("8bbcd8cb-9c4f-4afd-9c69-db113e258e8a"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("6a192fe5-f7e7-4f50-8718-89c5e5c659ce"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9caa90e5-f572-4c94-b325-6660a7a1166c"));
            labelDescription = (ITTLabel)AddControl(new Guid("551dce57-c0de-4bcd-90af-c3756f4a627d"));
            labelQref = (ITTLabel)AddControl(new Guid("29d671da-9f47-472f-bd63-8be328adeaf6"));
            IsActive = (ITTCheckBox)AddControl(new Guid("827b354c-1a87-42b4-8a8e-776989e33331"));
            labelCode = (ITTLabel)AddControl(new Guid("8c5f8958-fbc6-4af3-a6f3-9606eb12fb74"));
            labelID = (ITTLabel)AddControl(new Guid("4e8d138d-b2b1-4a2a-bce3-c0e68c0dcc73"));
            base.InitializeControls();
        }

        public BulletinProcedureDefinitionForm() : base("BULLETINPROCEDUREDEFINITION", "BulletinProcedureDefinitionForm")
        {
        }

        protected BulletinProcedureDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}