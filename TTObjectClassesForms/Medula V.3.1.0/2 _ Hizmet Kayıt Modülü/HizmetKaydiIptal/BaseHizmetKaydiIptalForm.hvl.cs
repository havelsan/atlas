
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
    /// BaseHizmetKaydiIptalForm
    /// </summary>
    public partial class BaseHizmetKaydiIptalForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Hizmet Kaydı İptal
    /// </summary>
        protected TTObjectClasses.HizmetKaydiIptal _HizmetKaydiIptal
        {
            get { return (TTObjectClasses.HizmetKaydiIptal)_ttObject; }
        }

        protected ITTValueListBox saglikTesisKoduHizmetIptalGirisDVO;
        protected ITTLabel labeltakipNoHizmetIptalGirisDVO;
        protected ITTTextBox takipNoHizmetIptalGirisDVO;
        protected ITTLabel labelsaglikTesisKoduHizmetIptalGirisDVO;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage islemSiraNumaralariTabpage;
        protected ITTGrid islemSiraNumarasiDVOsIslemSiraNoDVO;
        protected ITTTextBoxColumn islemSiraNoIslemSiraNoDVO;
        override protected void InitializeControls()
        {
            saglikTesisKoduHizmetIptalGirisDVO = (ITTValueListBox)AddControl(new Guid("bfb035cb-6742-439f-9863-38ef57b0a3f8"));
            labeltakipNoHizmetIptalGirisDVO = (ITTLabel)AddControl(new Guid("60669c29-906e-4dd4-82b7-a5391c6b91e2"));
            takipNoHizmetIptalGirisDVO = (ITTTextBox)AddControl(new Guid("f0ab1ba6-30c2-4e4e-96fb-87f8c5193aa0"));
            labelsaglikTesisKoduHizmetIptalGirisDVO = (ITTLabel)AddControl(new Guid("69f02eec-5ff9-4004-9b77-48f5f77ec326"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a117da5c-888e-48d3-a8c9-33f4a2883ea1"));
            islemSiraNumaralariTabpage = (ITTTabPage)AddControl(new Guid("4ec9f67f-bdf6-4a55-bd7d-cd87abd4df4b"));
            islemSiraNumarasiDVOsIslemSiraNoDVO = (ITTGrid)AddControl(new Guid("8d17369c-566a-41fd-aaf7-d6705de5198d"));
            islemSiraNoIslemSiraNoDVO = (ITTTextBoxColumn)AddControl(new Guid("e991d6a1-7f02-4971-a63e-955b29104ac3"));
            base.InitializeControls();
        }

        public BaseHizmetKaydiIptalForm() : base("HIZMETKAYDIIPTAL", "BaseHizmetKaydiIptalForm")
        {
        }

        protected BaseHizmetKaydiIptalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}