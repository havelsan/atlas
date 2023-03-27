
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
    public partial class MedulaBarkodSutEslesmeSorguIslemleri : TTUnboundForm
    {
        protected ITTTabControl tabcontrolBarkodSutEslesme;
        protected ITTTabPage tabpageBarkodSutEslesme;
        protected ITTLabel lblFirma;
        protected ITTLabel lblMalzeme;
        protected ITTTextBox txtFirmaTanimlayiciNo;
        protected ITTButton btnFirmaBul;
        protected ITTObjectListBox listBoxMalzeme;
        protected ITTButton btnMalzemeBul;
        protected ITTTabControl tabcontrolEslesmeler;
        protected ITTTabPage tabpageEslesmeler;
        protected ITTGrid gridEslesmeler;
        protected ITTTextBoxColumn barkod;
        protected ITTTextBoxColumn firmaTanimlayiciNo;
        protected ITTTextBoxColumn sutKodu;
        protected ITTTextBoxColumn baslangicTarihi;
        protected ITTTextBoxColumn bitisTarihi;
        protected ITTTextBox txtSutKodu;
        protected ITTLabel lblSutKodu;
        protected ITTObjectListBox listBoxFirma;
        protected ITTLabel lblFirmaNo;
        protected ITTTextBox txtBarkod;
        protected ITTLabel lblBarkod;
        protected ITTTextBox txtSonucMesaji;
        protected ITTDateTimePicker dtpTarih;
        protected ITTLabel lblSonucMesaji;
        protected ITTLabel lblTarih;
        protected ITTLabel lblSonucKodu;
        protected ITTButton btnSorgula;
        protected ITTTextBox txtSonucKodu;
        override protected void InitializeControls()
        {
            tabcontrolBarkodSutEslesme = (ITTTabControl)AddControl(new Guid("0fdef380-849f-4429-9957-dea04e5e50b8"));
            tabpageBarkodSutEslesme = (ITTTabPage)AddControl(new Guid("9ad78f74-80da-40c0-89a6-f3aa37ebca6e"));
            lblFirma = (ITTLabel)AddControl(new Guid("5a3b61dd-7e3c-43a4-a325-4423b3dfbbfa"));
            lblMalzeme = (ITTLabel)AddControl(new Guid("abc7da5a-13c1-4727-ad9d-3bf14e31e66c"));
            txtFirmaTanimlayiciNo = (ITTTextBox)AddControl(new Guid("b5827ac8-cdbb-49f8-9c60-783b0861d38c"));
            btnFirmaBul = (ITTButton)AddControl(new Guid("06e12648-9390-4a9f-b457-e50fc541cee2"));
            listBoxMalzeme = (ITTObjectListBox)AddControl(new Guid("01b62ee6-9aeb-484e-b6d9-e9b4538c5cf4"));
            btnMalzemeBul = (ITTButton)AddControl(new Guid("74d1c880-62f5-43e7-b457-c81f934c3976"));
            tabcontrolEslesmeler = (ITTTabControl)AddControl(new Guid("fde7c86e-7d82-421a-86a6-8a66d8d7e3d7"));
            tabpageEslesmeler = (ITTTabPage)AddControl(new Guid("7ed9e3c3-a2ee-440c-ac54-942cc842b311"));
            gridEslesmeler = (ITTGrid)AddControl(new Guid("9be19f65-b881-4e76-b04d-1b87e9f60d87"));
            barkod = (ITTTextBoxColumn)AddControl(new Guid("f0059f51-5c7e-4fe8-a29b-2df282bd37cc"));
            firmaTanimlayiciNo = (ITTTextBoxColumn)AddControl(new Guid("a85e701d-3919-41df-8931-1620fe6a4db8"));
            sutKodu = (ITTTextBoxColumn)AddControl(new Guid("8d2e8366-9c1f-4cc3-be0e-aec32a1fbc4c"));
            baslangicTarihi = (ITTTextBoxColumn)AddControl(new Guid("7d543d3b-3e68-4c7b-ae5b-51e47cfd86fd"));
            bitisTarihi = (ITTTextBoxColumn)AddControl(new Guid("14f7b15b-f1c9-42e6-91e7-8c57343bf5e9"));
            txtSutKodu = (ITTTextBox)AddControl(new Guid("8b75c12a-d1f2-4f15-8bb3-424fe404c115"));
            lblSutKodu = (ITTLabel)AddControl(new Guid("7fbcd067-0dd0-4229-83b2-f0966fd8e0a3"));
            listBoxFirma = (ITTObjectListBox)AddControl(new Guid("8a1cb7ba-49d1-4e70-97c8-20a0a7fe41af"));
            lblFirmaNo = (ITTLabel)AddControl(new Guid("d9d1a95b-3326-408d-9beb-e64a58c2e8d7"));
            txtBarkod = (ITTTextBox)AddControl(new Guid("3734f32f-fc2e-4a06-aeb3-5ed2e2f17fbd"));
            lblBarkod = (ITTLabel)AddControl(new Guid("8d0e4f82-6089-4ed2-bc0c-438ae0dfc05b"));
            txtSonucMesaji = (ITTTextBox)AddControl(new Guid("feabc779-a98e-4157-b6c7-9f028e98bcc4"));
            dtpTarih = (ITTDateTimePicker)AddControl(new Guid("65e63c15-0ddd-4f43-853e-ca41554737ca"));
            lblSonucMesaji = (ITTLabel)AddControl(new Guid("eb941134-a09c-467e-881d-9bbe191c571a"));
            lblTarih = (ITTLabel)AddControl(new Guid("809cb6c7-657e-4fe7-aca5-dea3c11a8372"));
            lblSonucKodu = (ITTLabel)AddControl(new Guid("d57e11b1-80c7-429b-b7d1-07fb68a35c71"));
            btnSorgula = (ITTButton)AddControl(new Guid("7e620456-4c6b-4b84-a4b5-76f94af965f2"));
            txtSonucKodu = (ITTTextBox)AddControl(new Guid("5ddb9faa-c6a0-4a4b-9c09-bbd27b9992fa"));
            base.InitializeControls();
        }

        public MedulaBarkodSutEslesmeSorguIslemleri() : base("MedulaBarkodSutEslesmeSorguIslemleri")
        {
        }

        protected MedulaBarkodSutEslesmeSorguIslemleri(string formDefName) : base(formDefName)
        {
        }
    }
}