
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
    public partial class TedaviRaporuKaydetTakipNoIleForm : BaseTedaviRaporuKaydetForm
    {
        protected TTObjectClasses.TedaviRaporuKaydetTakipNoIle _TedaviRaporuKaydetTakipNoIle
        {
            get { return (TTObjectClasses.TedaviRaporuKaydetTakipNoIle)_ttObject; }
        }

        protected ITTLabel labeltakipNoRaporDVO;
        protected ITTTextBox takipNoRaporDVO;
        override protected void InitializeControls()
        {
            labeltakipNoRaporDVO = (ITTLabel)AddControl(new Guid("e9ea5e9b-73ba-4c75-aa79-eb9e77955523"));
            takipNoRaporDVO = (ITTTextBox)AddControl(new Guid("c4732e00-a31d-4a48-8e6a-2e5afe29add9"));
            base.InitializeControls();
        }

        public TedaviRaporuKaydetTakipNoIleForm() : base("TEDAVIRAPORUKAYDETTAKIPNOILE", "TedaviRaporuKaydetTakipNoIleForm")
        {
        }

        protected TedaviRaporuKaydetTakipNoIleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}