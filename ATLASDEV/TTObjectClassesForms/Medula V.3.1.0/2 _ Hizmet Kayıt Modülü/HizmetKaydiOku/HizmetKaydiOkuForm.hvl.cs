
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
    /// Hizmet Kaydı Oku
    /// </summary>
    public partial class HizmetKaydiOkuForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Hizmet Kaydı Oku
    /// </summary>
        protected TTObjectClasses.HizmetKaydiOku _HizmetKaydiOku
        {
            get { return (TTObjectClasses.HizmetKaydiOku)_ttObject; }
        }

        protected ITTValueListBox saglikTesisKoduHizmetOkuGirisDVO;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage islemSiraNumaralariTabpage;
        protected ITTGrid islemSiraNumarasiDVOsIslemSiraNoDVO;
        protected ITTTextBoxColumn islemSiraNoIslemSiraNoDVO;
        protected ITTTabPage hizmetSunucuRefNolariTabpage;
        protected ITTGrid hizmetSunucuRefNoDVOsHizmetSunucuRefNoDVO;
        protected ITTTextBoxColumn hizmetSunucuRefNoHizmetSunucuRefNoDVO;
        protected ITTTextBox takipNoHizmetOkuGirisDVO;
        protected ITTLabel labeltakipNoHizmetOkuGirisDVO;
        protected ITTLabel labelsaglikTesisKoduHizmetOkuGirisDVO;
        override protected void InitializeControls()
        {
            saglikTesisKoduHizmetOkuGirisDVO = (ITTValueListBox)AddControl(new Guid("0c8997be-1a58-469b-b467-53847c89e2d0"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("5562187f-06a7-42c4-b3e6-15fbae3fbfaa"));
            islemSiraNumaralariTabpage = (ITTTabPage)AddControl(new Guid("df7e8807-8683-4df8-b39e-6fe0106ab0bc"));
            islemSiraNumarasiDVOsIslemSiraNoDVO = (ITTGrid)AddControl(new Guid("5e22e531-60ff-41b5-8847-1883f756fb5d"));
            islemSiraNoIslemSiraNoDVO = (ITTTextBoxColumn)AddControl(new Guid("c110a73d-87da-4689-8084-b982db0b507b"));
            hizmetSunucuRefNolariTabpage = (ITTTabPage)AddControl(new Guid("987de393-4311-4595-8ab3-ae03596d832c"));
            hizmetSunucuRefNoDVOsHizmetSunucuRefNoDVO = (ITTGrid)AddControl(new Guid("3da68a23-294f-469d-b50f-d9e68af3550d"));
            hizmetSunucuRefNoHizmetSunucuRefNoDVO = (ITTTextBoxColumn)AddControl(new Guid("8bf518d4-1ead-4817-a399-dd8cd23ba987"));
            takipNoHizmetOkuGirisDVO = (ITTTextBox)AddControl(new Guid("d274f5ec-6feb-4abd-9176-a246d2d1c9ce"));
            labeltakipNoHizmetOkuGirisDVO = (ITTLabel)AddControl(new Guid("31aa8446-02f2-4d99-9447-bb68e9c73f82"));
            labelsaglikTesisKoduHizmetOkuGirisDVO = (ITTLabel)AddControl(new Guid("5d4a8eb3-9c57-49cb-9adb-2ee3f3a3a215"));
            base.InitializeControls();
        }

        public HizmetKaydiOkuForm() : base("HIZMETKAYDIOKU", "HizmetKaydiOkuForm")
        {
        }

        protected HizmetKaydiOkuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}