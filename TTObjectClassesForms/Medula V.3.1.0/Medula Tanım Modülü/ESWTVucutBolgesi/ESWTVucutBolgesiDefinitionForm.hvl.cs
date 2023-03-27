
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
    public partial class ESWTVucutBolgesiDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.ESWTVucutBolgesi _ESWTVucutBolgesi
        {
            get { return (TTObjectClasses.ESWTVucutBolgesi)_ttObject; }
        }

        protected ITTLabel labeleswtVucutBolgesiAdi;
        protected ITTTextBox eswtVucutBolgesiAdi;
        protected ITTLabel labeleswtVucutBolgesiKodu;
        protected ITTTextBox eswtVucutBolgesiKodu;
        override protected void InitializeControls()
        {
            labeleswtVucutBolgesiAdi = (ITTLabel)AddControl(new Guid("5991e811-b1ae-471f-a462-cd583fd3b74d"));
            eswtVucutBolgesiAdi = (ITTTextBox)AddControl(new Guid("c38f5f6b-67f9-415d-8d52-ade97b1bd416"));
            labeleswtVucutBolgesiKodu = (ITTLabel)AddControl(new Guid("3c7f448b-40f0-4b5c-8349-aa0542d2fa4c"));
            eswtVucutBolgesiKodu = (ITTTextBox)AddControl(new Guid("d2e92947-82f2-4b12-9996-ce49a1278317"));
            base.InitializeControls();
        }

        public ESWTVucutBolgesiDefinitionForm() : base("ESWTVUCUTBOLGESI", "ESWTVucutBolgesiDefinitionForm")
        {
        }

        protected ESWTVucutBolgesiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}