
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
    public partial class FTRRaporBilgisiDVOForm : BaseMedulaObjectForm
    {
        protected TTObjectClasses.FTRRaporBilgisiDVO _FTRRaporBilgisiDVO
        {
            get { return (TTObjectClasses.FTRRaporBilgisiDVO)_ttObject; }
        }

        protected ITTListDefComboBox ftrVucutBolgesiKodu;
        protected ITTLabel labeltedaviTuru;
        protected ITTListDefComboBox tedaviTuru;
        protected ITTLabel labelseansSayi;
        protected ITTTextBox seansSayi;
        protected ITTTextBox seansGun;
        protected ITTLabel labelseansGun;
        protected ITTLabel labelftrVucutBolgesiKodu;
        protected ITTLabel labelbutKodu;
        protected ITTValueListBox butKodu;
        override protected void InitializeControls()
        {
            ftrVucutBolgesiKodu = (ITTListDefComboBox)AddControl(new Guid("7f15e787-b104-4575-8b19-0d44ef60ff31"));
            labeltedaviTuru = (ITTLabel)AddControl(new Guid("9d80d34c-8629-4e72-8f4c-c9e0322e27d0"));
            tedaviTuru = (ITTListDefComboBox)AddControl(new Guid("218b6e1f-2647-4d26-9e7d-8e1b130425e7"));
            labelseansSayi = (ITTLabel)AddControl(new Guid("8c4d3203-4b6b-4479-bb52-c9edfa0290a7"));
            seansSayi = (ITTTextBox)AddControl(new Guid("d18071a4-96a0-4d85-ba58-1db0ad91ab32"));
            seansGun = (ITTTextBox)AddControl(new Guid("a3bcf865-4928-4d7d-b635-5f4a5b2be093"));
            labelseansGun = (ITTLabel)AddControl(new Guid("127558b1-c0c1-4b67-ab1c-1eb84a602f4f"));
            labelftrVucutBolgesiKodu = (ITTLabel)AddControl(new Guid("75f1a6ec-9d83-4c70-9d3c-3eca22d7a139"));
            labelbutKodu = (ITTLabel)AddControl(new Guid("d847a6a3-4fc7-4e21-9a4a-11d07815d62a"));
            butKodu = (ITTValueListBox)AddControl(new Guid("1ebfd1f2-82af-4b03-a7df-e309c7c2d844"));
            base.InitializeControls();
        }

        public FTRRaporBilgisiDVOForm() : base("FTRRAPORBILGISIDVO", "FTRRaporBilgisiDVOForm")
        {
        }

        protected FTRRaporBilgisiDVOForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}