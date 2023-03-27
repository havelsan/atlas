
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
    public partial class IlacRaporDuzeltForm : BaseIlacRaporDuzeltForm
    {
    /// <summary>
    /// Ilaç Raporu Düzelt
    /// </summary>
        protected TTObjectClasses.IlacRaporDuzelt _IlacRaporDuzelt
        {
            get { return (TTObjectClasses.IlacRaporDuzelt)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage duzeltmeBilgisiTabpage;
        protected ITTTextBox duzeltmeBilgisiIlacRaporDuzeltDVO;
        protected ITTTabPage etkinMaddelerTabpage;
        protected ITTGrid raporEtkinMaddelerRaporEtkinMaddeDVO;
        protected ITTListBoxColumn etkinMaddeKoduRaporEtkinMaddeDVO;
        protected ITTTextBoxColumn kullanimDoz1RaporEtkinMaddeDVO;
        protected ITTTextBoxColumn kullanimDoz2RaporEtkinMaddeDVO;
        protected ITTListDefComboBoxColumn kullanimDozBirimRaporEtkinMaddeDVO;
        protected ITTTextBoxColumn kullanimPeriyotRaporEtkinMaddeDVO;
        protected ITTListDefComboBoxColumn kullanimPeriyotBirimRaporEtkinMaddeDVO;
        protected ITTTabPage tanilarTabpage;
        protected ITTGrid tanilarTaniBilgisi_RaporDVO;
        protected ITTListBoxColumn taniKoduTaniBilgisi_RaporDVO;
        protected ITTTextBox raporNoIlacRaporDuzeltDVO;
        protected ITTLabel labelraporTarihiDateTimeIlacRaporDuzeltDVO;
        protected ITTDateTimePicker raporTarihiDateTimeIlacRaporDuzeltDVO;
        protected ITTLabel labelduzeltmeTarihiDateTimeIlacRaporDuzeltDVO;
        protected ITTDateTimePicker duzeltmeTarihiDateTimeIlacRaporDuzeltDVO;
        protected ITTLabel labeltesisKoduIlacRaporDuzeltDVO;
        protected ITTValueListBox tesisKoduIlacRaporDuzeltDVO;
        protected ITTLabel labelraporTuruIlacRaporDuzeltDVO;
        protected ITTListDefComboBox raporTuruIlacRaporDuzeltDVO;
        protected ITTLabel labelraporNoIlacRaporDuzeltDVO;
        protected ITTLabel labeldrTescilNoIlacRaporDuzeltDVO;
        protected ITTValueListBox drTescilNoIlacRaporDuzeltDVO;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("af354013-6e20-4c9d-af4a-78241a676d09"));
            duzeltmeBilgisiTabpage = (ITTTabPage)AddControl(new Guid("f6201cb9-ba6f-4888-bdea-e83fe543280f"));
            duzeltmeBilgisiIlacRaporDuzeltDVO = (ITTTextBox)AddControl(new Guid("1fbf02a1-47b8-451a-a670-9930fc4c9862"));
            etkinMaddelerTabpage = (ITTTabPage)AddControl(new Guid("a2b91b9b-6dde-4a31-9158-73c09da0b5a7"));
            raporEtkinMaddelerRaporEtkinMaddeDVO = (ITTGrid)AddControl(new Guid("647eb51d-51ed-478b-bccf-49aa758bfb5e"));
            etkinMaddeKoduRaporEtkinMaddeDVO = (ITTListBoxColumn)AddControl(new Guid("02b0eb92-f8b1-4bac-8c81-b4e10937f7d1"));
            kullanimDoz1RaporEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("db1f5718-5bc9-4782-b670-1bb89649ba69"));
            kullanimDoz2RaporEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("64c1ca61-ee70-4696-a261-77e82c827962"));
            kullanimDozBirimRaporEtkinMaddeDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("6b6bda89-ca83-406a-a0b2-0e344f738afa"));
            kullanimPeriyotRaporEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("a4f80c4b-e9fd-4fb6-b7e5-a5e76f4c3cc5"));
            kullanimPeriyotBirimRaporEtkinMaddeDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("b6b7cb76-6462-4142-be2d-ad432bcd073a"));
            tanilarTabpage = (ITTTabPage)AddControl(new Guid("6a4ce2ba-d1ba-469e-b86e-e30081969ffa"));
            tanilarTaniBilgisi_RaporDVO = (ITTGrid)AddControl(new Guid("4f9e4e5f-8276-4017-a6c6-fdc8e580805a"));
            taniKoduTaniBilgisi_RaporDVO = (ITTListBoxColumn)AddControl(new Guid("704b5d6d-7107-4cdb-9c31-f6e652840b6e"));
            raporNoIlacRaporDuzeltDVO = (ITTTextBox)AddControl(new Guid("675c417d-37f3-4441-9271-9a9a608dd68b"));
            labelraporTarihiDateTimeIlacRaporDuzeltDVO = (ITTLabel)AddControl(new Guid("07cc54c7-9803-44ad-9042-a54288d8e89b"));
            raporTarihiDateTimeIlacRaporDuzeltDVO = (ITTDateTimePicker)AddControl(new Guid("c8605bff-a551-449c-95a9-ca23c53ed9a8"));
            labelduzeltmeTarihiDateTimeIlacRaporDuzeltDVO = (ITTLabel)AddControl(new Guid("54e7b0d3-8c82-49ab-8f7b-3fbeb9724379"));
            duzeltmeTarihiDateTimeIlacRaporDuzeltDVO = (ITTDateTimePicker)AddControl(new Guid("b6e7b32b-b5fe-4742-9e4e-8a875d31e2f7"));
            labeltesisKoduIlacRaporDuzeltDVO = (ITTLabel)AddControl(new Guid("01e7fc07-1e28-40fc-8643-b68e8838100e"));
            tesisKoduIlacRaporDuzeltDVO = (ITTValueListBox)AddControl(new Guid("50b44d38-34fe-4bed-9e00-5b4c11ff0b3a"));
            labelraporTuruIlacRaporDuzeltDVO = (ITTLabel)AddControl(new Guid("d84e5106-99b5-41ef-b029-35248cdf2cba"));
            raporTuruIlacRaporDuzeltDVO = (ITTListDefComboBox)AddControl(new Guid("11a9865e-e933-4639-b9af-42a8cdc995ec"));
            labelraporNoIlacRaporDuzeltDVO = (ITTLabel)AddControl(new Guid("ea1792d8-f56b-477c-bd8c-fab54c2e3dab"));
            labeldrTescilNoIlacRaporDuzeltDVO = (ITTLabel)AddControl(new Guid("ae574700-be8e-434c-8c10-b6ce1439013f"));
            drTescilNoIlacRaporDuzeltDVO = (ITTValueListBox)AddControl(new Guid("5c3f1c83-3ba8-42bf-b957-a3fae5e42c97"));
            base.InitializeControls();
        }

        public IlacRaporDuzeltForm() : base("ILACRAPORDUZELT", "IlacRaporDuzeltForm")
        {
        }

        protected IlacRaporDuzeltForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}