
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
    public partial class BaseRaporBilgisiBulRaporTakipNodanForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Rapor Bilgisi Bul Rapor Takip Numarasından
    /// </summary>
        protected TTObjectClasses.RaporBilgisiBulRaporTakipNodan _RaporBilgisiBulRaporTakipNodan
        {
            get { return (TTObjectClasses.RaporBilgisiBulRaporTakipNodan)_ttObject; }
        }

        protected ITTLabel labelraporTakipNoRaporOkuRaporTakipNodanDVO;
        protected ITTTextBox raporTakipNoRaporOkuRaporTakipNodanDVO;
        protected ITTValueListBox kullaniciTesisKoduBaseMedulaRaporObject;
        protected ITTLabel labelkullaniciTesisKoduBaseMedulaRaporObject;
        override protected void InitializeControls()
        {
            labelraporTakipNoRaporOkuRaporTakipNodanDVO = (ITTLabel)AddControl(new Guid("c682251b-ac96-427e-a404-a2096b8cd506"));
            raporTakipNoRaporOkuRaporTakipNodanDVO = (ITTTextBox)AddControl(new Guid("13572fe2-dd11-46ca-9952-e06b9fe39971"));
            kullaniciTesisKoduBaseMedulaRaporObject = (ITTValueListBox)AddControl(new Guid("00f97594-c5b6-4aa7-b879-f7c7a764b7be"));
            labelkullaniciTesisKoduBaseMedulaRaporObject = (ITTLabel)AddControl(new Guid("37e10df0-b54f-450d-b916-03d1b1f33cbc"));
            base.InitializeControls();
        }

        public BaseRaporBilgisiBulRaporTakipNodanForm() : base("RAPORBILGISIBULRAPORTAKIPNODAN", "BaseRaporBilgisiBulRaporTakipNodanForm")
        {
        }

        protected BaseRaporBilgisiBulRaporTakipNodanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}