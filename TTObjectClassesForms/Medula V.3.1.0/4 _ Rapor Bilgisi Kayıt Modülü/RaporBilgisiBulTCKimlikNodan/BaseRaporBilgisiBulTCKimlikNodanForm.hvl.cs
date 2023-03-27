
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
    public partial class BaseRaporBilgisiBulTCKimlikNodanForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Rapor Bilgisi Bul TC Kimlik Numarasından
    /// </summary>
        protected TTObjectClasses.RaporBilgisiBulTCKimlikNodan _RaporBilgisiBulTCKimlikNodan
        {
            get { return (TTObjectClasses.RaporBilgisiBulTCKimlikNodan)_ttObject; }
        }

        protected ITTLabel labelturuRaporOkuTCKimlikNodanDVO;
        protected ITTListDefComboBox turuRaporOkuTCKimlikNodanDVO;
        protected ITTLabel labeltckimlikNoRaporOkuTCKimlikNodanDVO;
        protected ITTTextBox tckimlikNoRaporOkuTCKimlikNodanDVO;
        protected ITTValueListBox kullaniciTesisKoduBaseMedulaRaporObject;
        protected ITTLabel labelkullaniciTesisKoduBaseMedulaRaporObject;
        override protected void InitializeControls()
        {
            labelturuRaporOkuTCKimlikNodanDVO = (ITTLabel)AddControl(new Guid("dd6075af-a3c9-465d-8b9f-780121b2be0b"));
            turuRaporOkuTCKimlikNodanDVO = (ITTListDefComboBox)AddControl(new Guid("d3eceee0-b07f-41a0-bedd-22c585dbe1e1"));
            labeltckimlikNoRaporOkuTCKimlikNodanDVO = (ITTLabel)AddControl(new Guid("f6addec0-e0d3-4852-8811-b95029545677"));
            tckimlikNoRaporOkuTCKimlikNodanDVO = (ITTTextBox)AddControl(new Guid("2b923b9a-4d48-4fed-880a-0a86966662dc"));
            kullaniciTesisKoduBaseMedulaRaporObject = (ITTValueListBox)AddControl(new Guid("eecee604-d5d3-4556-bf8b-1c7c9bf12c4b"));
            labelkullaniciTesisKoduBaseMedulaRaporObject = (ITTLabel)AddControl(new Guid("167fadb0-7ab8-49c0-85ab-00293452d669"));
            base.InitializeControls();
        }

        public BaseRaporBilgisiBulTCKimlikNodanForm() : base("RAPORBILGISIBULTCKIMLIKNODAN", "BaseRaporBilgisiBulTCKimlikNodanForm")
        {
        }

        protected BaseRaporBilgisiBulTCKimlikNodanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}