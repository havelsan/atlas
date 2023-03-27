
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
    /// Takip Ara Cevap
    /// </summary>
    public partial class TakipAraCevapForm : BaseTakipAraForm
    {
    /// <summary>
    /// Takip Ara
    /// </summary>
        protected TTObjectClasses.TakipAra _TakipAra
        {
            get { return (TTObjectClasses.TakipAra)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid takiplerTakipDVO;
        protected ITTListBoxColumn bransKoduTakipDVO;
        protected ITTTextBoxColumn donorTCKimlikNoTakipDVO;
        protected ITTTextBoxColumn faturaTeslimNoTakipDVO;
        protected ITTTextBoxColumn hastaBasvuruNoTakipDVO;
        protected ITTTextBoxColumn ilkTakipNoTakipDVO;
        protected ITTTextBoxColumn kayitTarihiTakipDVO;
        protected ITTListDefComboBoxColumn provizyonTipiTakipDVO;
        protected ITTListDefComboBoxColumn sevkDurumuTakipDVO;
        protected ITTListDefComboBoxColumn takipDurumuTakipDVO;
        protected ITTTextBoxColumn takipNoTakipDVO;
        protected ITTTextBoxColumn takipTarihiTakipDVO;
        protected ITTListDefComboBoxColumn takipTipiTakipDVO;
        protected ITTListDefComboBoxColumn tedaviTipiTakipDVO;
        protected ITTListDefComboBoxColumn tedaviTuruTakipDVO;
        protected ITTListBoxColumn tesisKoduTakipDVO;
        protected ITTTextBoxColumn yeniDoganCocukSiraNoTakipDVO;
        protected ITTTextBoxColumn yeniDoganDogumTarihiTakipDVO;
        protected ITTTextBoxColumn sonucKoduTakipDVO;
        protected ITTTextBoxColumn sonucMesajiTakipDVO;
        protected ITTDateTimePickerColumn CreationDateTakipDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("bc886947-196a-4437-9e3b-a2f743103be2"));
            takiplerTakipDVO = (ITTGrid)AddControl(new Guid("f05ab634-eefd-43d2-b84b-6396ab448374"));
            bransKoduTakipDVO = (ITTListBoxColumn)AddControl(new Guid("990f325a-be32-41c5-8ad0-cd096bca0b17"));
            donorTCKimlikNoTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("6c21325d-fb24-4b98-b52a-bac8095c1d05"));
            faturaTeslimNoTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("59be1748-d014-4479-ad32-c712b6a7ac20"));
            hastaBasvuruNoTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("d51aa20f-b4e6-4dca-873e-cc3d6cee1b70"));
            ilkTakipNoTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("de3b519f-af7a-48bd-be47-c4e289cf85a4"));
            kayitTarihiTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("ba62b3b6-f100-417e-b767-841ee2dc62d7"));
            provizyonTipiTakipDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("a92d16e7-bf9c-4e40-9e90-04fa8cd0ab18"));
            sevkDurumuTakipDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("1df23569-02bd-4383-b935-2f8c531ac14c"));
            takipDurumuTakipDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("c8cfa35d-e9af-4be0-b5af-0d2bee7f0b67"));
            takipNoTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("c00b9bee-ba8e-418d-b8c8-e5ac05e64bc3"));
            takipTarihiTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("3fd731c1-d5fa-46cf-985c-88a972effc93"));
            takipTipiTakipDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("c034b1dd-7f91-4108-a5f3-f8aee79fa2c9"));
            tedaviTipiTakipDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("6ae0fcb0-b24a-428f-b88a-4951f5d45bb9"));
            tedaviTuruTakipDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("8f3cd3d9-2ee6-48dc-9817-e5807e8a8d69"));
            tesisKoduTakipDVO = (ITTListBoxColumn)AddControl(new Guid("8b74677a-bc24-4056-8ece-09cd708b48f3"));
            yeniDoganCocukSiraNoTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("7790e5ca-896c-493d-a4f0-ef13d84d1115"));
            yeniDoganDogumTarihiTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("cdc4fde9-3244-4f2b-a3c8-896ac95c9ba5"));
            sonucKoduTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("88927a92-9424-42d5-a3b5-23ba6670bc6c"));
            sonucMesajiTakipDVO = (ITTTextBoxColumn)AddControl(new Guid("6afa3e81-14b9-436f-847e-5350dd5f4b17"));
            CreationDateTakipDVO = (ITTDateTimePickerColumn)AddControl(new Guid("56358585-752c-477e-bd86-53aa90e88eb6"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("c62251bc-1f20-4e1d-94eb-f191183f7801"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("4620992f-4968-4010-a5cd-ef462ac68fd9"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("eec3fadb-fe51-4453-bf03-36c0b5382c65"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("bd9b9fdd-4b17-4e4d-9513-a39c1f8465b3"));
            base.InitializeControls();
        }

        public TakipAraCevapForm() : base("TAKIPARA", "TakipAraCevapForm")
        {
        }

        protected TakipAraCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}