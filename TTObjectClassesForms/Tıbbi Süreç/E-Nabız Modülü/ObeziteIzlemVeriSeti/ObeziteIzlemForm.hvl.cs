
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
    public partial class ObeziteIzlemForm : TTForm
    {
        protected TTObjectClasses.ObeziteIzlemVeriSeti _ObeziteIzlemVeriSeti
        {
            get { return (TTObjectClasses.ObeziteIzlemVeriSeti)_ttObject; }
        }

        protected ITTLabel labelSKRSPsikolojikTedavi;
        protected ITTObjectListBox SKRSPsikolojikTedavi;
        protected ITTLabel labelSKRSObeziteIlacTedavisi;
        protected ITTObjectListBox SKRSObeziteIlacTedavisi;
        protected ITTLabel labelOdemVarligi;
        protected ITTObjectListBox OdemVarligi;
        protected ITTLabel labelDiyetTibbiBeslenmeTedavisi;
        protected ITTObjectListBox DiyetTibbiBeslenmeTedavisi;
        protected ITTGrid ObeziteEkHastalik;
        protected ITTListBoxColumn SKRSICDObeziteEkHastalik;
        protected ITTGrid ObeziteEgzersiz;
        protected ITTListBoxColumn SKRSEgzersizObeziteEgzersiz;
        protected ITTLabel labelKilo;
        protected ITTTextBox Kilo;
        protected ITTTextBox Boy;
        protected ITTTextBox KalcaCevresi;
        protected ITTTextBox BelCevresi;
        protected ITTLabel labelBoy;
        protected ITTLabel labelKalcaCevresi;
        protected ITTLabel labelIlkTaniTarihi;
        protected ITTDateTimePicker IlkTaniTarihi;
        protected ITTLabel labelBelCevresi;
        override protected void InitializeControls()
        {
            labelSKRSPsikolojikTedavi = (ITTLabel)AddControl(new Guid("90e8a800-bbac-4c1b-b0a2-669ae8fdaaae"));
            SKRSPsikolojikTedavi = (ITTObjectListBox)AddControl(new Guid("701518c7-1976-487f-8f11-94f4a23652c3"));
            labelSKRSObeziteIlacTedavisi = (ITTLabel)AddControl(new Guid("17a8bac5-e82b-48d3-92f9-3c58cb57f786"));
            SKRSObeziteIlacTedavisi = (ITTObjectListBox)AddControl(new Guid("4063df49-ff5a-4551-83d2-6d41612797f0"));
            labelOdemVarligi = (ITTLabel)AddControl(new Guid("abef3a53-dc3d-4761-adc5-943c788e28b2"));
            OdemVarligi = (ITTObjectListBox)AddControl(new Guid("2397cfeb-e769-4667-8d16-c25262e2aad1"));
            labelDiyetTibbiBeslenmeTedavisi = (ITTLabel)AddControl(new Guid("c19192b3-e80b-4bdb-864c-31801ab513ff"));
            DiyetTibbiBeslenmeTedavisi = (ITTObjectListBox)AddControl(new Guid("dfc90db2-9733-4bc7-91df-078247fc4121"));
            ObeziteEkHastalik = (ITTGrid)AddControl(new Guid("936e503d-4bd5-4f90-b443-6ed657c68291"));
            SKRSICDObeziteEkHastalik = (ITTListBoxColumn)AddControl(new Guid("91d1e3ca-3540-418c-8340-778045d2680b"));
            ObeziteEgzersiz = (ITTGrid)AddControl(new Guid("56d7fe51-fb8b-463f-a8e9-96441e005f02"));
            SKRSEgzersizObeziteEgzersiz = (ITTListBoxColumn)AddControl(new Guid("5a1f63be-3f0d-4814-9f05-78c91a812d37"));
            labelKilo = (ITTLabel)AddControl(new Guid("65ce7399-d218-4fc7-a79a-e9d7cd7ce874"));
            Kilo = (ITTTextBox)AddControl(new Guid("008f6cae-f2f1-4659-8577-9d8bc688faba"));
            Boy = (ITTTextBox)AddControl(new Guid("83e0ec2d-c743-4e08-8a6c-9f8ceb4d78ca"));
            KalcaCevresi = (ITTTextBox)AddControl(new Guid("f28d26df-3eb5-43d3-9438-add88812e0f4"));
            BelCevresi = (ITTTextBox)AddControl(new Guid("3ed7dac6-6694-4a99-8915-47ebca9d4ce0"));
            labelBoy = (ITTLabel)AddControl(new Guid("fda71829-d30d-4cbf-b1b0-c79c0d368420"));
            labelKalcaCevresi = (ITTLabel)AddControl(new Guid("c769bb96-f91f-4a8d-8197-5f1be439e526"));
            labelIlkTaniTarihi = (ITTLabel)AddControl(new Guid("9a445d17-257a-4c00-ac67-b74765c9169e"));
            IlkTaniTarihi = (ITTDateTimePicker)AddControl(new Guid("5931a53a-8ae3-4f58-bd07-6160a95d2cff"));
            labelBelCevresi = (ITTLabel)AddControl(new Guid("0789a734-4faf-4be5-88dd-e34196ed0633"));
            base.InitializeControls();
        }

        public ObeziteIzlemForm() : base("OBEZITEIZLEMVERISETI", "ObeziteIzlemForm")
        {
        }

        protected ObeziteIzlemForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}