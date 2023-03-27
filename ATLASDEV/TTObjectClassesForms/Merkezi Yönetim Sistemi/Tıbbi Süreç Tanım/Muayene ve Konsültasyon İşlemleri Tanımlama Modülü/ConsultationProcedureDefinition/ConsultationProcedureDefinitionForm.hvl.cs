
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
    /// Muayene ve Konsültasyon İşlemleri Tanımlama Modülü
    /// </summary>
    public partial class ConsultationProcedureDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Muayene ve Konsültasyon İşlemleri Tanımlama
    /// </summary>
        protected TTObjectClasses.ConsultationProcedureDefinition _ConsultationProcedureDefinition
        {
            get { return (TTObjectClasses.ConsultationProcedureDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("764ca196-2ba0-4231-97ed-4a26bf39876a"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("c53aff69-75f7-4e4a-ba24-b0dd9ea61c80"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("a70274d4-1e2c-4ad3-9a40-8c9c9682b3b2"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("f2368666-617c-47b8-8a5b-77d03ec5a68b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5c5b81d1-4ca4-4818-a48c-0e5393351642"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("d2fa0a44-fb29-483d-b693-26f634f391f8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c951004f-43af-4fb9-bb7c-62aeed203f2f"));
            labelQref = (ITTLabel)AddControl(new Guid("4055fe13-ca80-4718-bf98-9779ea5d7b1b"));
            Qref = (ITTTextBox)AddControl(new Guid("38302c61-6703-4050-a4b3-fcfea67756d2"));
            Name = (ITTTextBox)AddControl(new Guid("b7fce8b3-6dc0-495e-87b8-9cf60fc9a669"));
            EnglishName = (ITTTextBox)AddControl(new Guid("e51c8e57-7a53-4038-9761-0c1ccbe41468"));
            Description = (ITTTextBox)AddControl(new Guid("5b2cd282-e251-44d0-b254-4811c939747a"));
            Code = (ITTTextBox)AddControl(new Guid("27c61103-5e76-49f3-ac7b-16698cd9f684"));
            labelName = (ITTLabel)AddControl(new Guid("59248688-a49a-40e1-aa79-d20e749330af"));
            IsActive = (ITTCheckBox)AddControl(new Guid("c575fed2-febb-43cf-ab8b-926169a43cb3"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("a188e8ef-e403-48e7-9971-f728c2a0b070"));
            labelDescription = (ITTLabel)AddControl(new Guid("5dffdffc-a198-4061-b2c5-2d36af3723d3"));
            labelCode = (ITTLabel)AddControl(new Guid("409d43a1-6f48-4c9a-b9f7-1fe8acc6b601"));
            base.InitializeControls();
        }

        public ConsultationProcedureDefinitionForm() : base("CONSULTATIONPROCEDUREDEFINITION", "ConsultationProcedureDefinitionForm")
        {
        }

        protected ConsultationProcedureDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}