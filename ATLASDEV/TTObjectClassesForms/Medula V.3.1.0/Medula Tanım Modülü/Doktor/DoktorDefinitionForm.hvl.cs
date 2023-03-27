
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
    /// Doktor Tanımlama
    /// </summary>
    public partial class DoktorDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Doktor
    /// </summary>
        protected TTObjectClasses.Doktor _Doktor
        {
            get { return (TTObjectClasses.Doktor)_ttObject; }
        }

        protected ITTLabel labelSaglikTesisi;
        protected ITTObjectListBox SaglikTesisi;
        protected ITTLabel labelBrans;
        protected ITTObjectListBox Brans;
        protected ITTLabel labeldrTescilNo;
        protected ITTTextBox drTescilNo;
        protected ITTTextBox drSoyadi;
        protected ITTTextBox drDiplomaNo;
        protected ITTTextBox drAdi;
        protected ITTLabel labeldrSoyadi;
        protected ITTLabel labeldrDiplomaNo;
        protected ITTLabel labeldrAdi;
        override protected void InitializeControls()
        {
            labelSaglikTesisi = (ITTLabel)AddControl(new Guid("38acf7b9-4913-4536-a7eb-1fde09a8af6a"));
            SaglikTesisi = (ITTObjectListBox)AddControl(new Guid("e954ae1d-9acf-459c-9302-5232fbdcea32"));
            labelBrans = (ITTLabel)AddControl(new Guid("d13217ff-2a82-45e7-af4c-d6c8d84d25a0"));
            Brans = (ITTObjectListBox)AddControl(new Guid("60b0aad8-be37-411c-9af4-419e39a7e93b"));
            labeldrTescilNo = (ITTLabel)AddControl(new Guid("b1356d59-8f17-4e7d-b651-56635d80bbc1"));
            drTescilNo = (ITTTextBox)AddControl(new Guid("c63c456b-536d-4115-b198-24b357d5ab01"));
            drSoyadi = (ITTTextBox)AddControl(new Guid("dcaaeb13-bb35-404c-8e50-60cd5a03bee5"));
            drDiplomaNo = (ITTTextBox)AddControl(new Guid("57ebaed6-369d-4002-8147-3d6ee6334b94"));
            drAdi = (ITTTextBox)AddControl(new Guid("a906607a-1888-48a9-8e49-610006bc0889"));
            labeldrSoyadi = (ITTLabel)AddControl(new Guid("ea2d0927-c1ee-4054-8f65-c8f88dfa397f"));
            labeldrDiplomaNo = (ITTLabel)AddControl(new Guid("f5361182-752b-41fa-86dd-1526dbc8d9ec"));
            labeldrAdi = (ITTLabel)AddControl(new Guid("0c8f540a-a156-49b0-b4dc-bbaa9689d351"));
            base.InitializeControls();
        }

        public DoktorDefinitionForm() : base("DOKTOR", "DoktorDefinitionForm")
        {
        }

        protected DoktorDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}