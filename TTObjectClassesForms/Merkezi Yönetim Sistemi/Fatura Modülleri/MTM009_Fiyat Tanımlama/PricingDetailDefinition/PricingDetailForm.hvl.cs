
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
    /// Fiyat Tanımı
    /// </summary>
    public partial class PricingDetailForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Fiyat  Tanımlama
    /// </summary>
        protected TTObjectClasses.PricingDetailDefinition _PricingDetailDefinition
        {
            get { return (TTObjectClasses.PricingDetailDefinition)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox OUTPATIENTDISCOUNTPERCENT;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTTextBox INPATIENTDISCOUNTPERCENT;
        protected ITTTextBox Description;
        protected ITTTextBox EXTERNALCODE;
        protected ITTTextBox PRICE;
        protected ITTTextBox POINT;
        protected ITTLabel TTLABEL6;
        protected ITTValueListBox PRICELIST;
        protected ITTLabel TTLABEL4;
        protected ITTLabel TTLABEL5;
        protected ITTLabel TTLABEL1;
        protected ITTLabel TTLABEL7;
        protected ITTLabel TTLABEL3;
        protected ITTValueListBox CURRENCYTYPE;
        protected ITTDateTimePicker DATESTART;
        protected ITTLabel TTLABEL2;
        protected ITTDateTimePicker DATEEND;
        protected ITTLabel TTLABEL8;
        protected ITTValueListBox PRICEGROUP;
        protected ITTLabel POINTLABEL;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTTextBox tttextbox2;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("73acf944-7806-48d5-b3db-35b3c522b963"));
            OUTPATIENTDISCOUNTPERCENT = (ITTTextBox)AddControl(new Guid("5c1be818-a8f0-441c-92e7-dc37d1c11e09"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("412259ff-2556-48eb-b41e-4c2d98fcaf96"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("0ddf2853-74e2-4a5a-993e-3aab8fb55c03"));
            INPATIENTDISCOUNTPERCENT = (ITTTextBox)AddControl(new Guid("8421cfc9-f7b0-491b-9b10-d26c202ca952"));
            Description = (ITTTextBox)AddControl(new Guid("546ad4fe-28d1-4cb0-bdbc-15b5f21016da"));
            EXTERNALCODE = (ITTTextBox)AddControl(new Guid("f0cb67e7-c794-4e5f-a087-4acbf12e26be"));
            PRICE = (ITTTextBox)AddControl(new Guid("8c851bfc-537d-4c8e-8976-a0cda31f86db"));
            POINT = (ITTTextBox)AddControl(new Guid("e64bd5d4-a24e-4468-b24d-0d93ff0465b3"));
            TTLABEL6 = (ITTLabel)AddControl(new Guid("d2824626-87bd-420f-9f2c-0f6d72f13f45"));
            PRICELIST = (ITTValueListBox)AddControl(new Guid("de398d8a-84f3-4ea5-a24d-18c5f03f0274"));
            TTLABEL4 = (ITTLabel)AddControl(new Guid("ae469c15-eafb-4176-a482-287a5adc617e"));
            TTLABEL5 = (ITTLabel)AddControl(new Guid("dc64da5d-0f79-46fa-b397-2a9af269c38f"));
            TTLABEL1 = (ITTLabel)AddControl(new Guid("2b23492a-a470-42ad-b999-3c66cf45cd7e"));
            TTLABEL7 = (ITTLabel)AddControl(new Guid("40222ddc-c611-4a30-b22d-4d3c51720190"));
            TTLABEL3 = (ITTLabel)AddControl(new Guid("d3b5905f-a717-457b-85c6-618dd5e86148"));
            CURRENCYTYPE = (ITTValueListBox)AddControl(new Guid("70525a2d-1354-474e-a613-620c32fdc8cb"));
            DATESTART = (ITTDateTimePicker)AddControl(new Guid("666afa3b-3199-4f55-8716-79e9f686b6da"));
            TTLABEL2 = (ITTLabel)AddControl(new Guid("3f216a8e-fda8-4a91-b6c8-a4a05a9f0d94"));
            DATEEND = (ITTDateTimePicker)AddControl(new Guid("4aba03d0-cd4e-415b-86fe-c6d9b22a1cf2"));
            TTLABEL8 = (ITTLabel)AddControl(new Guid("6ffe816c-5217-4ef2-80b2-cefc93ad6552"));
            PRICEGROUP = (ITTValueListBox)AddControl(new Guid("7127ffac-51ab-401a-bf60-d7fe9e3ae68b"));
            POINTLABEL = (ITTLabel)AddControl(new Guid("c62ccde2-1e37-4ca8-a33e-f72d63a2e763"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("60e1364f-abf9-4933-b687-dc37303c19e5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("01b401af-7d21-4836-91f7-5eb123e81598"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("c570a647-3e55-4437-840c-8d4d075fd8cf"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("7301e722-14b7-427c-85f5-5703ab51a5a9"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("2f55b0cd-a2c7-41c1-b674-74069eb6330d"));
            base.InitializeControls();
        }

        public PricingDetailForm() : base("PRICINGDETAILDEFINITION", "PricingDetailForm")
        {
        }

        protected PricingDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}