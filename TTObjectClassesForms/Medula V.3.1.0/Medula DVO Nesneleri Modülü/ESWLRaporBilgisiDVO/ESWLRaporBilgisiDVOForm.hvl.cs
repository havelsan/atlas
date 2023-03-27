
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
    public partial class ESWLRaporBilgisiDVOForm : BaseMedulaObjectForm
    {
        protected TTObjectClasses.ESWLRaporBilgisiDVO _ESWLRaporBilgisiDVO
        {
            get { return (TTObjectClasses.ESWLRaporBilgisiDVO)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid eswlRaporuTasBilgileri;
        protected ITTTextBoxColumn tasBoyutuESWLTasBilgisiDVO;
        protected ITTListDefComboBoxColumn tasLokalizasyonKoduESWLTasBilgisiDVO;
        protected ITTLabel labeleswlRaporuTasSayisi;
        protected ITTTextBox eswlRaporuTasSayisi;
        protected ITTTextBox eswlRaporuSeansSayisi;
        protected ITTLabel labeleswlRaporuSeansSayisi;
        protected ITTLabel labelbutKodu;
        protected ITTValueListBox butKodu;
        protected ITTLabel labelbobrekBilgisi;
        protected ITTListDefComboBox bobrekBilgisi;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("5118fb2c-9b2c-4604-8fa8-1dc76db893d1"));
            eswlRaporuTasBilgileri = (ITTGrid)AddControl(new Guid("4581d2ca-df38-412e-b5eb-0e0b438145ae"));
            tasBoyutuESWLTasBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("0f627a20-efca-43cf-8846-613a10075be4"));
            tasLokalizasyonKoduESWLTasBilgisiDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("0b4af049-4259-4319-861d-4f2accf576f6"));
            labeleswlRaporuTasSayisi = (ITTLabel)AddControl(new Guid("af2c067d-1316-4fdb-b836-edd00fb88fe2"));
            eswlRaporuTasSayisi = (ITTTextBox)AddControl(new Guid("e051fd3b-5be3-4487-af28-da5b0b514e9e"));
            eswlRaporuSeansSayisi = (ITTTextBox)AddControl(new Guid("338f5af8-d6bf-49cd-a3e8-60c5957bdc1d"));
            labeleswlRaporuSeansSayisi = (ITTLabel)AddControl(new Guid("09c5ed48-afe4-4047-b2e7-212d42813ba2"));
            labelbutKodu = (ITTLabel)AddControl(new Guid("a795b841-8af8-4d35-bf16-0fe6c2dc36a8"));
            butKodu = (ITTValueListBox)AddControl(new Guid("3f6b05fb-19f8-4041-a44c-434f51df6bda"));
            labelbobrekBilgisi = (ITTLabel)AddControl(new Guid("1715c5b0-6614-4738-acf9-47f0cdc0ce82"));
            bobrekBilgisi = (ITTListDefComboBox)AddControl(new Guid("1729b2fe-ea3c-4291-a67d-660299fe5b70"));
            base.InitializeControls();
        }

        public ESWLRaporBilgisiDVOForm() : base("ESWLRAPORBILGISIDVO", "ESWLRaporBilgisiDVOForm")
        {
        }

        protected ESWLRaporBilgisiDVOForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}