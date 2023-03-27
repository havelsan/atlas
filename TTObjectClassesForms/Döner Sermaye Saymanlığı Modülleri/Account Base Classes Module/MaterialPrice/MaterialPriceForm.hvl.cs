
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
    /// Malzeme Fiyat Eşleştirme
    /// </summary>
    public partial class MaterialPriceForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Malzeme Fiyat Eşleştirme Tanımı
    /// </summary>
        protected TTObjectClasses.MaterialPrice _MaterialPrice
        {
            get { return (TTObjectClasses.MaterialPrice)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel7;
        protected ITTTextBox PRICE;
        protected ITTDateTimePicker ENDDATE;
        protected ITTDateTimePicker STARTDATE;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTTextBox PRICELISTGROUP;
        protected ITTTextBox PRICELIST;
        protected ITTObjectListBox PricingDetailDefinitionList;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox Material;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("e5d98c5b-c4b1-475f-8bb2-d30179a32033"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("bb840a80-9ed7-4b90-b88c-93d51733c456"));
            PRICE = (ITTTextBox)AddControl(new Guid("66313849-4d57-4392-9aea-9917078a9559"));
            ENDDATE = (ITTDateTimePicker)AddControl(new Guid("41cea916-b898-4536-9481-9f334c9132f2"));
            STARTDATE = (ITTDateTimePicker)AddControl(new Guid("aeaaa728-80f9-494f-b7b8-4d26d10ab95e"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("672caeb0-cb6b-4a57-8f53-15c0f208f73b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("063a81f6-68d4-4dcd-b786-b00b1941e76f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("00a30e6a-a3e4-49ec-b25c-90dd837a0874"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d711ec16-801b-4536-aa12-cf934b667d26"));
            PRICELISTGROUP = (ITTTextBox)AddControl(new Guid("fff7503f-02ca-43e0-aea6-a0f704ddb649"));
            PRICELIST = (ITTTextBox)AddControl(new Guid("91251cfe-82de-42c3-94d5-3edbecc089b5"));
            PricingDetailDefinitionList = (ITTObjectListBox)AddControl(new Guid("61380814-2630-4fe6-ac76-1e2e5188e8f0"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4fd49d8b-33ba-4424-8a87-4fa50062bfd3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6ca13184-9aa6-4aab-84ab-ea06cdbc0500"));
            Material = (ITTObjectListBox)AddControl(new Guid("b1e244ac-0f8a-487d-ab64-9a61446bdaff"));
            base.InitializeControls();
        }

        public MaterialPriceForm() : base("MATERIALPRICE", "MaterialPriceForm")
        {
        }

        protected MaterialPriceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}