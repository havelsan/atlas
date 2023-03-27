
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
    public partial class OrneklenmisTakiplerCevapForm : BaseOrneklenmisTakiplerForm
    {
    /// <summary>
    /// Örneklenmiş Takipler
    /// </summary>
        protected TTObjectClasses.OrneklenmisTakipler _OrneklenmisTakipler
        {
            get { return (TTObjectClasses.OrneklenmisTakipler)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTGrid takiplerTakipNoDVO;
        protected ITTTextBoxColumn takipNoTakipNoDVO;
        protected ITTDateTimePickerColumn CreationDateTakipNoDVO;
        protected ITTLabel labeltesisKoduOrneklenmisTakiplerCevapDVO;
        protected ITTTextBox sonucMesaji;
        protected ITTTextBox tesisKoduOrneklenmisTakiplerCevapDVO;
        protected ITTLabel labelsonucMesaji;
        protected ITTLabel labelTakipler;
        protected ITTTextBox sonucKodu;
        protected ITTLabel labelsonucKodu;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("64d11903-95ef-46a7-b6c0-456ee4e42bbe"));
            takiplerTakipNoDVO = (ITTGrid)AddControl(new Guid("fce127a2-25d3-4512-b01d-0b2feed4870b"));
            takipNoTakipNoDVO = (ITTTextBoxColumn)AddControl(new Guid("bc9c2523-b3e3-4920-a2fc-e6c161f7d964"));
            CreationDateTakipNoDVO = (ITTDateTimePickerColumn)AddControl(new Guid("bd169b13-81b0-47ec-896b-ce08e5dda94e"));
            labeltesisKoduOrneklenmisTakiplerCevapDVO = (ITTLabel)AddControl(new Guid("3320f351-0d93-47ad-8326-e8583e5be833"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("40fb2f53-bc72-463b-bc45-2b7f2766edf3"));
            tesisKoduOrneklenmisTakiplerCevapDVO = (ITTTextBox)AddControl(new Guid("319729e4-06fa-4224-b330-60af10df7381"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("9f1cb2e2-84c3-4701-bd31-d559f1e0839d"));
            labelTakipler = (ITTLabel)AddControl(new Guid("c3885f9c-0395-43e5-ade4-408cc6f58dca"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("15eedfef-e974-4fb9-a08a-b3590e2b4e2e"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("bf8f380b-0cf4-4d0b-8cf3-65ba871618dd"));
            base.InitializeControls();
        }

        public OrneklenmisTakiplerCevapForm() : base("ORNEKLENMISTAKIPLER", "OrneklenmisTakiplerCevapForm")
        {
        }

        protected OrneklenmisTakiplerCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}