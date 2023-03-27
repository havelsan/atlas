
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
    /// Ek Uygulama Hizmet Tanımları
    /// </summary>
    public partial class AdditionalApplicationDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.AdditionalApplicationDefinition _AdditionalApplicationDefinition
        {
            get { return (TTObjectClasses.AdditionalApplicationDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox ID;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTLabel labelID;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTCheckBox Chargable;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("b41ed86e-1362-41d9-8277-9b3dcfdce991"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("25a2d6ac-a96d-4cf7-a0bb-9d0eb50f1a1f"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("7256e0e1-9c62-4ac8-9d3b-1522ae6892e0"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("503b0538-17bb-4d45-8cdc-50fd71b6e0eb"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("fffb9ea2-93ec-4960-8342-134090ee4f0b"));
            labelQref = (ITTLabel)AddControl(new Guid("16155954-4475-4684-b345-0f1544e9179a"));
            Qref = (ITTTextBox)AddControl(new Guid("7abf6d80-14a0-469d-99a7-22bfa29b5eb3"));
            Name = (ITTTextBox)AddControl(new Guid("9fc50416-0f69-420d-9481-1247b0102324"));
            ID = (ITTTextBox)AddControl(new Guid("dbc242c7-eb71-4ec3-ab43-f15d24b8c4a5"));
            EnglishName = (ITTTextBox)AddControl(new Guid("721f26c3-e84d-46e5-aca8-0b138cbce0ac"));
            Description = (ITTTextBox)AddControl(new Guid("0014d1a3-c117-4f4d-99f6-266bedd37c63"));
            Code = (ITTTextBox)AddControl(new Guid("3cc38c24-cabf-4e18-9411-ec03eb46e2e2"));
            labelName = (ITTLabel)AddControl(new Guid("2414ae9d-281a-4a19-bc07-a8bfe3222433"));
            labelID = (ITTLabel)AddControl(new Guid("d1f8072e-cc90-4d82-8a9b-cb6570a1ace9"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("d5854f13-6640-49ca-b4bf-96300880d294"));
            labelDescription = (ITTLabel)AddControl(new Guid("0739cd2b-2566-41c3-a96a-9daafdae9c60"));
            labelCode = (ITTLabel)AddControl(new Guid("748f1cc8-5b54-4fe6-b2e3-37eebc7d21ab"));
            Chargable = (ITTCheckBox)AddControl(new Guid("c29b69fd-6542-414d-bf4b-5e09979ee800"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e0aaf7be-2342-423b-ab2b-f44302045837"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e601edb5-b615-4ef0-b5e5-1419e86596c0"));
            IsActive = (ITTCheckBox)AddControl(new Guid("222c4fef-58ce-48bf-b133-f5e2cb7aa5fc"));
            base.InitializeControls();
        }

        public AdditionalApplicationDefinitionForm() : base("ADDITIONALAPPLICATIONDEFINITION", "AdditionalApplicationDefinitionForm")
        {
        }

        protected AdditionalApplicationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}