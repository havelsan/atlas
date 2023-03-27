
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
    /// Hizmet Fiyat Eşleştirme
    /// </summary>
    public partial class ProcedurePriceForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hizmet Fiyat Eşleştirme Tanımı
    /// </summary>
        protected TTObjectClasses.ProcedurePriceDefinition _ProcedurePriceDefinition
        {
            get { return (TTObjectClasses.ProcedurePriceDefinition)_ttObject; }
        }

        protected ITTTextBox PRICECOEFFICIENT;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel7;
        protected ITTTextBox PRICE;
        protected ITTDateTimePicker STARTDATE;
        protected ITTDateTimePicker ENDDATE;
        protected ITTLabel ttlabel6;
        protected ITTTextBox PRICELISTGROUP;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTTextBox PRICELIST;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox PricingDetailDefinitionList;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ProcedureDefinition;
        protected ITTLabel ttlabel8;
        override protected void InitializeControls()
        {
            PRICECOEFFICIENT = (ITTTextBox)AddControl(new Guid("028edeb7-7d95-47f5-a454-3ea8995e92ee"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("d53c592a-5680-4837-abfc-7efa98ec368e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1ebb172a-3e13-447e-8fa1-599239969255"));
            PRICE = (ITTTextBox)AddControl(new Guid("05c0cd70-bdb9-4695-a578-857e6208c45c"));
            STARTDATE = (ITTDateTimePicker)AddControl(new Guid("e1c5db1c-1dce-45ff-b8ea-a09cb6b621d4"));
            ENDDATE = (ITTDateTimePicker)AddControl(new Guid("28a88007-603a-47ba-a4ae-11aee1880e80"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("bb567285-471d-441d-8c3b-838a930a0ee2"));
            PRICELISTGROUP = (ITTTextBox)AddControl(new Guid("0fcf0032-f0bb-43f6-a4ec-c7cebee4745b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a12bf386-4997-45cc-98d0-e4eed8823a42"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a83c8251-6146-48bf-92b8-3edaa7f6bbe1"));
            PRICELIST = (ITTTextBox)AddControl(new Guid("97194bbe-d767-4217-90a4-3236263d3c98"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("37671e4c-7360-49bc-8ace-731bf41d9e5d"));
            PricingDetailDefinitionList = (ITTObjectListBox)AddControl(new Guid("de7ac79f-ed14-4468-bd87-4db95b93460c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("aa56d9af-3e4a-4d2d-83cd-d151348e6ca6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a463645d-8ee5-4081-af5f-e451efef24a0"));
            ProcedureDefinition = (ITTObjectListBox)AddControl(new Guid("7d77dc8b-f4e1-43f5-a67f-89155705804f"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("0c1051c7-0cb9-43f7-bcc3-0dde74611b91"));
            base.InitializeControls();
        }

        public ProcedurePriceForm() : base("PROCEDUREPRICEDEFINITION", "ProcedurePriceForm")
        {
        }

        protected ProcedurePriceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}