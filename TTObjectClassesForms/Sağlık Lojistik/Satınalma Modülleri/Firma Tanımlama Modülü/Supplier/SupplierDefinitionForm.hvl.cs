
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
    /// Tedarikçi Tanımı
    /// </summary>
    public partial class SupplierDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Tedarikçi tanımlama modülü için ana sınıftır
    /// </summary>
        protected TTObjectClasses.Supplier _Supplier
        {
            get { return (TTObjectClasses.Supplier)_ttObject; }
        }

        protected ITTLabel labelSupplierNumber;
        protected ITTTextBox SupplierNumber;
        protected ITTTextBox GLNNo;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Name;
        protected ITTTextBox Note;
        protected ITTTextBox Telephone;
        protected ITTTextBox Code;
        protected ITTTextBox Fax;
        protected ITTTextBox Address;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox4;
        protected ITTLabel labelProgress;
        protected ITTButton ttTedarikceUpdate;
        protected ITTLabel labelActivityType;
        protected ITTEnumComboBox ActivityType;
        protected ITTLabel labelGLNNo;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox Type;
        protected ITTLabel labelFax;
        protected ITTLabel labelType;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        protected ITTLabel labelTelephone;
        protected ITTLabel labelAddress;
        protected ITTLabel labelNote;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            labelSupplierNumber = (ITTLabel)AddControl(new Guid("8f8fcf6d-0be1-420e-90c2-a624193664f8"));
            SupplierNumber = (ITTTextBox)AddControl(new Guid("69c305e0-7eb6-4a6d-8ffc-3005a3c6fe12"));
            GLNNo = (ITTTextBox)AddControl(new Guid("552454d8-a54d-495d-b89b-2c80b05a8046"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("e03bbeb0-08ae-40d8-9fa8-6c622494350e"));
            Name = (ITTTextBox)AddControl(new Guid("e0c94970-ad69-4778-9bb1-11fcceb78b75"));
            Note = (ITTTextBox)AddControl(new Guid("01c369fb-ab40-48a0-ae41-3156b90b25c1"));
            Telephone = (ITTTextBox)AddControl(new Guid("4352728f-6750-4b9e-8b6c-387942702ea2"));
            Code = (ITTTextBox)AddControl(new Guid("cd7b50d7-a017-420b-83af-537238900795"));
            Fax = (ITTTextBox)AddControl(new Guid("6c2572c5-d927-4fe4-91e5-64a76b4c956b"));
            Address = (ITTTextBox)AddControl(new Guid("d8e163fe-40c7-402f-9ec6-9deed7727416"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("172c75ea-1473-463f-b840-8f496a06bf5b"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("d343ea1b-8d7b-4b12-b2e7-7f32c236af0a"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("ec575615-ab4b-437f-9cd6-12c6a6077265"));
            labelProgress = (ITTLabel)AddControl(new Guid("5851d00e-cac7-4f87-aba0-e9dfb60fb001"));
            ttTedarikceUpdate = (ITTButton)AddControl(new Guid("1ff0493b-8406-47cf-8798-bc35d2b931d8"));
            labelActivityType = (ITTLabel)AddControl(new Guid("49a4702b-63cc-4bb5-86e2-9acf675b301b"));
            ActivityType = (ITTEnumComboBox)AddControl(new Guid("1d75ec07-706e-4e7f-87b2-26ee813949a6"));
            labelGLNNo = (ITTLabel)AddControl(new Guid("927bdab4-7274-4084-98f9-7b5e91fb87a0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d9809929-43f8-48d3-a88b-5b2e0d3944f9"));
            Type = (ITTEnumComboBox)AddControl(new Guid("34f5a5bb-2db6-4cac-beb8-4dff5840b007"));
            labelFax = (ITTLabel)AddControl(new Guid("79830195-953a-4edb-afb0-5145208d6062"));
            labelType = (ITTLabel)AddControl(new Guid("c74981a7-6ec6-4817-af95-8d0f38dc4965"));
            labelName = (ITTLabel)AddControl(new Guid("4cd075de-257d-4611-8035-8e343222299a"));
            labelCode = (ITTLabel)AddControl(new Guid("3ec589cb-3b8e-468d-aa1b-96357f40c0b1"));
            labelTelephone = (ITTLabel)AddControl(new Guid("83178059-e617-4d7a-827e-96c6ca1c7f14"));
            labelAddress = (ITTLabel)AddControl(new Guid("0e320546-edad-41be-9bc9-b87ccf616a03"));
            labelNote = (ITTLabel)AddControl(new Guid("72512f6a-3190-4a9a-a327-f660ce749060"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("361c3d07-e61e-4dfc-b26b-36e7acade0bd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f9a5e667-17fd-484d-9792-bba504b59acd"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("24230226-eba7-401d-9cdc-58ed4307f58e"));
            base.InitializeControls();
        }

        public SupplierDefinitionForm() : base("SUPPLIER", "SupplierDefinitionForm")
        {
        }

        protected SupplierDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}