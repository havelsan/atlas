
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
    public partial class ESWTRaporBilgisiDVOForm : BaseMedulaObjectForm
    {
        protected TTObjectClasses.ESWTRaporBilgisiDVO _ESWTRaporBilgisiDVO
        {
            get { return (TTObjectClasses.ESWTRaporBilgisiDVO)_ttObject; }
        }

        protected ITTListDefComboBox eswtVucutBolgesiKodu;
        protected ITTLabel labeleswtVucutBolgesiKodu;
        protected ITTTextBox seansSayi;
        protected ITTTextBox seansGun;
        protected ITTLabel labelseansSayi;
        protected ITTLabel labelseansGun;
        protected ITTLabel labelbutKodu;
        protected ITTValueListBox butKodu;
        override protected void InitializeControls()
        {
            eswtVucutBolgesiKodu = (ITTListDefComboBox)AddControl(new Guid("151d9e86-d27e-4a42-81b1-27be55ce5619"));
            labeleswtVucutBolgesiKodu = (ITTLabel)AddControl(new Guid("075ae778-92a2-49bb-9a00-e121534a56b7"));
            seansSayi = (ITTTextBox)AddControl(new Guid("3a9fc8cb-dd57-4d38-83c0-61d8c672de73"));
            seansGun = (ITTTextBox)AddControl(new Guid("e3c6d177-c961-4047-b8d1-f7049bbc2168"));
            labelseansSayi = (ITTLabel)AddControl(new Guid("0565bf08-956a-4362-b0f8-9ecfac4825bb"));
            labelseansGun = (ITTLabel)AddControl(new Guid("f1f37446-34bb-4a08-8018-d938decf3a3f"));
            labelbutKodu = (ITTLabel)AddControl(new Guid("4b7991fd-99dd-4e25-8354-68a9b9cf1e64"));
            butKodu = (ITTValueListBox)AddControl(new Guid("30d5bf2e-8d36-497f-a13d-7ecd9d7b2d53"));
            base.InitializeControls();
        }

        public ESWTRaporBilgisiDVOForm() : base("ESWTRAPORBILGISIDVO", "ESWTRaporBilgisiDVOForm")
        {
        }

        protected ESWTRaporBilgisiDVOForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}