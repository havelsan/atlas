
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
    /// Kefil Bilgileri
    /// </summary>
    public partial class DebentureGuarantorForm : TTForm
    {
    /// <summary>
    /// Kefil Bilgisi
    /// </summary>
        protected TTObjectClasses.DebentureGuarantor _DebentureGuarantor
        {
            get { return (TTObjectClasses.DebentureGuarantor)_ttObject; }
        }

        protected ITTTextBox VILLAGEOFREGISTRY;
        protected ITTTextBox FATHERNAME;
        protected ITTTextBox NAME;
        protected ITTMaskedTextBox WORKPHONE;
        protected ITTMaskedTextBox HOMEPHONE;
        protected ITTMaskedTextBox UNIQUEREFNO;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTTextBox FAMILYORDERNO;
        protected ITTTextBox PAGENO;
        protected ITTTextBox VOLUMENO;
        protected ITTObjectListBox TOWNOFREGISTRY;
        protected ITTObjectListBox CITYOFREGISTRY;
        protected ITTObjectListBox CITYOFBIRTH;
        protected ITTDateTimePicker BIRTHDATE;
        protected ITTTextBox HOMEADDRESS;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel20;
        protected ITTLabel ttlabel21;
        protected ITTLabel ttlabel22;
        protected ITTTextBox WORKADDRESS;
        protected ITTLabel ttlabel30;
        protected ITTLabel ttlabel32;
        override protected void InitializeControls()
        {
            VILLAGEOFREGISTRY = (ITTTextBox)AddControl(new Guid("fe75570d-6db2-4eb7-acea-e6f09767fb17"));
            FATHERNAME = (ITTTextBox)AddControl(new Guid("c35ce40c-26cf-4436-8ac5-b7863030ed86"));
            NAME = (ITTTextBox)AddControl(new Guid("ed315459-fb1a-440f-8871-77cdf24254ea"));
            WORKPHONE = (ITTMaskedTextBox)AddControl(new Guid("4222c51d-b835-4f8b-95d4-bb5fa686f15a"));
            HOMEPHONE = (ITTMaskedTextBox)AddControl(new Guid("d3cac3fa-eafc-4f11-9cc2-c8f817e61aca"));
            UNIQUEREFNO = (ITTMaskedTextBox)AddControl(new Guid("2152d4ea-fe76-405e-a24f-d9bed3eb59d1"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("d4153c16-77d1-46d7-810a-15cfae2ecc7e"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("5eae5aa0-37a9-49b6-90b2-ed63a0949da0"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("8a86f515-0843-4af4-8074-98579c671aaa"));
            FAMILYORDERNO = (ITTTextBox)AddControl(new Guid("2c199259-ab32-445b-b784-610a5981cfb4"));
            PAGENO = (ITTTextBox)AddControl(new Guid("b478d189-d402-460b-9054-5eb44e186698"));
            VOLUMENO = (ITTTextBox)AddControl(new Guid("06b50320-b68e-4d1f-8e5d-d0dd1ef80dce"));
            TOWNOFREGISTRY = (ITTObjectListBox)AddControl(new Guid("dae7a266-a857-40c2-88cf-ab6c622fa874"));
            CITYOFREGISTRY = (ITTObjectListBox)AddControl(new Guid("80e7aca5-150c-47f1-baca-034a5a141891"));
            CITYOFBIRTH = (ITTObjectListBox)AddControl(new Guid("b311a40a-f294-40ca-9f4f-b4b1561f4dbd"));
            BIRTHDATE = (ITTDateTimePicker)AddControl(new Guid("97260c93-d683-4965-8f9a-7ccbe0eef219"));
            HOMEADDRESS = (ITTTextBox)AddControl(new Guid("ef51779a-2503-4188-8959-4b355217236c"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("a2f954fb-3577-404d-960c-0e2b00f031e2"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("a1d86998-15ed-4889-9a6c-f95565d63947"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("dfce17fc-cdd3-4734-8844-5a27e952173b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("8619cf9e-95a6-483c-8d06-dee20b8ab924"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bd95daed-bf70-46c0-86db-44b34135864b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cd94d110-2ca2-48dc-8cbf-4736b9ae1620"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("aa12d61d-8d77-41fd-a4a2-139c21175aa1"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("07eaa52f-66e9-461a-8b19-d7de2adaa5bd"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("0392451d-4f11-46c0-a4fe-539d0cdf3c34"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("1e6e4260-5935-4c11-9bdb-c14e6a0b2883"));
            WORKADDRESS = (ITTTextBox)AddControl(new Guid("32e5427f-2087-4fdd-a774-8f53620d7c2f"));
            ttlabel30 = (ITTLabel)AddControl(new Guid("c51eea36-7fc2-45eb-99eb-43d710eaed0d"));
            ttlabel32 = (ITTLabel)AddControl(new Guid("36021664-a546-40e1-8376-6e7ae3c03740"));
            base.InitializeControls();
        }

        public DebentureGuarantorForm() : base("DEBENTUREGUARANTOR", "DebentureGuarantorForm")
        {
        }

        protected DebentureGuarantorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}