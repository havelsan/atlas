
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
    public partial class DogumRaporuKaydetTakipNoIleForm : BaseDogumRaporuKaydetForm
    {
        protected TTObjectClasses.DogumRaporuKaydetTakipNoIle _DogumRaporuKaydetTakipNoIle
        {
            get { return (TTObjectClasses.DogumRaporuKaydetTakipNoIle)_ttObject; }
        }

        protected ITTTextBox takipNoRaporDVO;
        protected ITTLabel labeltakipNoRaporDVO;
        override protected void InitializeControls()
        {
            takipNoRaporDVO = (ITTTextBox)AddControl(new Guid("0ef3a9ae-0e5d-4685-a1c6-2c79ac97fe03"));
            labeltakipNoRaporDVO = (ITTLabel)AddControl(new Guid("6de6acd2-19d9-4204-a2fb-652641a2eec7"));
            base.InitializeControls();
        }

        public DogumRaporuKaydetTakipNoIleForm() : base("DOGUMRAPORUKAYDETTAKIPNOILE", "DogumRaporuKaydetTakipNoIleForm")
        {
        }

        protected DogumRaporuKaydetTakipNoIleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}