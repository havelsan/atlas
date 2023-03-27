
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
    public partial class BaseKesintiYapilmisIslemlerForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.KesintiYapilmisIslemler _KesintiYapilmisIslemler
        {
            get { return (TTObjectClasses.KesintiYapilmisIslemler)_ttObject; }
        }

        protected ITTLabel labelevrakRefNoEvrakKesintiGirisDVO;
        protected ITTTextBox evrakRefNoEvrakKesintiGirisDVO;
        protected ITTLabel labelsaglikTesisKodu;
        protected ITTValueListBox saglikTesisKodu;
        override protected void InitializeControls()
        {
            labelevrakRefNoEvrakKesintiGirisDVO = (ITTLabel)AddControl(new Guid("157be72f-cf9e-4b24-8520-94373207d921"));
            evrakRefNoEvrakKesintiGirisDVO = (ITTTextBox)AddControl(new Guid("2390e1e0-8b83-49c6-83b4-eaaed547db1d"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("7e5e6e5d-6a7f-4e55-9727-1241ff393c33"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("19d90487-fac8-4c2e-a6d6-1ef106d8a988"));
            base.InitializeControls();
        }

        public BaseKesintiYapilmisIslemlerForm() : base("KESINTIYAPILMISISLEMLER", "BaseKesintiYapilmisIslemlerForm")
        {
        }

        protected BaseKesintiYapilmisIslemlerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}