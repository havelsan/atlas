
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
    public partial class AnalikIsgoremezlikRaporuKaydetTakipNoIleForm : BaseAnalikIsgoremezlikRaporuKaydetForm
    {
        protected TTObjectClasses.AnalikIsgoremezlikRaporuKaydetTakipNoIle _AnalikIsgoremezlikRaporuKaydetTakipNoIle
        {
            get { return (TTObjectClasses.AnalikIsgoremezlikRaporuKaydetTakipNoIle)_ttObject; }
        }

        protected ITTTextBox takipNoRaporDVO;
        protected ITTLabel labeltakipNoRaporDVO;
        override protected void InitializeControls()
        {
            takipNoRaporDVO = (ITTTextBox)AddControl(new Guid("403adf2b-3f3a-4f3f-9d97-80ccf31d99c1"));
            labeltakipNoRaporDVO = (ITTLabel)AddControl(new Guid("7d3c7622-4b01-4d8d-a200-c8a4e68d3862"));
            base.InitializeControls();
        }

        public AnalikIsgoremezlikRaporuKaydetTakipNoIleForm() : base("ANALIKISGOREMEZLIKRAPORUKAYDETTAKIPNOILE", "AnalikIsgoremezlikRaporuKaydetTakipNoIleForm")
        {
        }

        protected AnalikIsgoremezlikRaporuKaydetTakipNoIleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}