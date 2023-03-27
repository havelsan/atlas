
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
    /// BaseTakipAraForm
    /// </summary>
    public partial class BaseTakipAraForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Takip Ara
    /// </summary>
        protected TTObjectClasses.TakipAra _TakipAra
        {
            get { return (TTObjectClasses.TakipAra)_ttObject; }
        }

        protected ITTLabel labelbitisTarihiDateTimeTakipAraGirisDVO;
        protected ITTDateTimePicker bitisTarihiDateTimeTakipAraGirisDVO;
        protected ITTLabel labelbaslangicTarihiDateTimeTakipAraGirisDVO;
        protected ITTDateTimePicker baslangicTarihiDateTimeTakipAraGirisDVO;
        protected ITTLabel labelsevkDurumuTakipAraGirisDVO;
        protected ITTListDefComboBox sevkDurumuTakipAraGirisDVO;
        protected ITTLabel labelsaglikTesisKoduTakipAraGirisDVO;
        protected ITTValueListBox saglikTesisKoduTakipAraGirisDVO;
        protected ITTLabel labelhastaTCKTakipAraGirisDVO;
        protected ITTTextBox hastaTCKTakipAraGirisDVO;
        protected ITTTextBox bitisTarihiTakipAraGirisDVO;
        protected ITTTextBox baslangicTarihiTakipAraGirisDVO;
        override protected void InitializeControls()
        {
            labelbitisTarihiDateTimeTakipAraGirisDVO = (ITTLabel)AddControl(new Guid("bae86e50-198a-4b2c-826d-efe6da9f6056"));
            bitisTarihiDateTimeTakipAraGirisDVO = (ITTDateTimePicker)AddControl(new Guid("cb4c86da-09a9-4920-b449-2e0669604fc8"));
            labelbaslangicTarihiDateTimeTakipAraGirisDVO = (ITTLabel)AddControl(new Guid("50b22f82-9e3d-48f6-ba50-f0fe280b7597"));
            baslangicTarihiDateTimeTakipAraGirisDVO = (ITTDateTimePicker)AddControl(new Guid("749ec772-03db-4c79-8ab7-23efa01f7b51"));
            labelsevkDurumuTakipAraGirisDVO = (ITTLabel)AddControl(new Guid("1aa3624c-a7c5-4b69-8deb-c941dfc5b89a"));
            sevkDurumuTakipAraGirisDVO = (ITTListDefComboBox)AddControl(new Guid("eec5b298-c428-4dae-8657-d96d3d147287"));
            labelsaglikTesisKoduTakipAraGirisDVO = (ITTLabel)AddControl(new Guid("961e459d-0af2-4478-a2e3-9754916f4eca"));
            saglikTesisKoduTakipAraGirisDVO = (ITTValueListBox)AddControl(new Guid("a210ae3b-a5e2-464a-b9ec-b8ef08de69eb"));
            labelhastaTCKTakipAraGirisDVO = (ITTLabel)AddControl(new Guid("96bdc53f-53e3-418e-affd-a32486509d68"));
            hastaTCKTakipAraGirisDVO = (ITTTextBox)AddControl(new Guid("3b86d85f-beb7-47d1-b0ea-bdba6a0adec5"));
            bitisTarihiTakipAraGirisDVO = (ITTTextBox)AddControl(new Guid("16cc0535-d21e-4096-b4a2-ad465118a7c0"));
            baslangicTarihiTakipAraGirisDVO = (ITTTextBox)AddControl(new Guid("6703abe4-2dd0-459d-9883-e6ec4cc9f9c0"));
            base.InitializeControls();
        }

        public BaseTakipAraForm() : base("TAKIPARA", "BaseTakipAraForm")
        {
        }

        protected BaseTakipAraForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}