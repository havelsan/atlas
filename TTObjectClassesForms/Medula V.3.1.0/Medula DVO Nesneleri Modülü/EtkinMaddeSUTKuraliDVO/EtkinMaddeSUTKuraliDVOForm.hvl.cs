
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
    public partial class EtkinMaddeSUTKuraliDVOForm : TTForm
    {
        protected TTObjectClasses.EtkinMaddeSUTKuraliDVO _EtkinMaddeSUTKuraliDVO
        {
            get { return (TTObjectClasses.EtkinMaddeSUTKuraliDVO)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage branslarTabpage;
        protected ITTGrid branslar;
        protected ITTTextBoxColumn bransKoduBransListDVO;
        protected ITTTextBoxColumn bransAdiBransListDVO;
        protected ITTTabPage teshislerTabpage;
        protected ITTGrid teshisler;
        protected ITTTextBoxColumn koduTeshisDVO;
        protected ITTTextBoxColumn adiTeshisDVO;
        protected ITTTabPage tesislerTabpage;
        protected ITTGrid tesisler;
        protected ITTTextBoxColumn tesisTesisStringDVO;
        protected ITTTabPage sertifikalarTabpage;
        protected ITTGrid sertifikalar;
        protected ITTTextBoxColumn sertifikaSertifikaStringDVO;
        protected ITTTextBox kuralID;
        protected ITTTextBox duzenlemeTuru;
        protected ITTTextBox bransKuralUygulama;
        protected ITTLabel labelkuralID;
        protected ITTLabel labelduzenlemeTuru;
        protected ITTLabel labelbransKuralUygulama;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("56a919f6-729e-463b-ab5c-59044a6508d0"));
            branslarTabpage = (ITTTabPage)AddControl(new Guid("05f188fd-e9e5-4ffe-8685-73b6546a635f"));
            branslar = (ITTGrid)AddControl(new Guid("720e9961-29b4-4e7f-b34f-406b125f71eb"));
            bransKoduBransListDVO = (ITTTextBoxColumn)AddControl(new Guid("bb7b82e3-3c38-42d1-a585-e32fde73a696"));
            bransAdiBransListDVO = (ITTTextBoxColumn)AddControl(new Guid("765fe140-4d05-416c-a9e4-3938f2beeb6e"));
            teshislerTabpage = (ITTTabPage)AddControl(new Guid("aa1919c5-19e8-48b3-a818-b68e4cbd6d22"));
            teshisler = (ITTGrid)AddControl(new Guid("8aa1e401-cf3c-4476-a2e6-104579c34e6d"));
            koduTeshisDVO = (ITTTextBoxColumn)AddControl(new Guid("b48cf282-cd02-4dc2-a860-ea3b36b8b4ca"));
            adiTeshisDVO = (ITTTextBoxColumn)AddControl(new Guid("c96e4dce-d2e3-47cb-9987-3211c9820e86"));
            tesislerTabpage = (ITTTabPage)AddControl(new Guid("5ea52da6-0cfe-437e-9ee7-9d55b68e0c5a"));
            tesisler = (ITTGrid)AddControl(new Guid("e6acf038-1988-4044-a4db-50062e31011c"));
            tesisTesisStringDVO = (ITTTextBoxColumn)AddControl(new Guid("851767b6-1d53-4765-bab7-857e89d29911"));
            sertifikalarTabpage = (ITTTabPage)AddControl(new Guid("9357ec22-3702-4b86-890a-19dfb012d85a"));
            sertifikalar = (ITTGrid)AddControl(new Guid("22b61af1-b968-42a3-8ed9-1bc622047ddd"));
            sertifikaSertifikaStringDVO = (ITTTextBoxColumn)AddControl(new Guid("1458ef2e-7895-4565-985b-59a25aaad5a9"));
            kuralID = (ITTTextBox)AddControl(new Guid("1957a1e5-f917-430f-8424-91293c0046fa"));
            duzenlemeTuru = (ITTTextBox)AddControl(new Guid("0e727cd8-a7c0-49aa-9727-0f37b69c8884"));
            bransKuralUygulama = (ITTTextBox)AddControl(new Guid("fcd1182b-b0db-416a-9a75-8b90ed24c231"));
            labelkuralID = (ITTLabel)AddControl(new Guid("09fe38d1-7ed1-4925-b82b-64a21b3a8b3f"));
            labelduzenlemeTuru = (ITTLabel)AddControl(new Guid("676663ec-c323-436d-8081-5fffb6364d11"));
            labelbransKuralUygulama = (ITTLabel)AddControl(new Guid("c8ef8a4d-ec96-4427-8153-9ac5513a6072"));
            base.InitializeControls();
        }

        public EtkinMaddeSUTKuraliDVOForm() : base("ETKINMADDESUTKURALIDVO", "EtkinMaddeSUTKuraliDVOForm")
        {
        }

        protected EtkinMaddeSUTKuraliDVOForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}