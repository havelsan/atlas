
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
    /// Yatak İşlemleri Medula Bilgileri
    /// </summary>
    public partial class BaseBedProcedureForm : TTForm
    {
        protected TTObjectClasses.BaseBedProcedure _BaseBedProcedure
        {
            get { return (TTObjectClasses.BaseBedProcedure)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MedulaBilgileri;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTObjectListBox TTListBoxOzelDurum;
        protected ITTLabel labelDrAnesteziTescilNo;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        protected ITTLabel labelAciklama;
        protected ITTTextBox DrAnesteziTescilNo;
        protected ITTLabel labelOzelDurum;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("00df1d69-930d-412d-8095-c9de4561e964"));
            MedulaBilgileri = (ITTTabPage)AddControl(new Guid("b6763603-eba0-422b-b4f0-259f2387feea"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("732f02fd-a191-4c64-9050-82f9a7306a64"));
            TTListBoxOzelDurum = (ITTObjectListBox)AddControl(new Guid("f900bfaa-1129-4706-adc0-6647942069be"));
            labelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("db8af3ae-923e-4786-ac00-74263c97e5cb"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("c6f9b8c4-21b1-4fd3-b570-6369418811a1"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("e05608fd-2698-49c2-b689-59622b0f74d2"));
            labelAciklama = (ITTLabel)AddControl(new Guid("daeba650-4779-45b2-9dee-41b1e783bf7c"));
            DrAnesteziTescilNo = (ITTTextBox)AddControl(new Guid("1a8eabad-287b-4a64-b2d7-57e5f315260a"));
            labelOzelDurum = (ITTLabel)AddControl(new Guid("335e9f1d-ade2-4bc3-b884-34490db83296"));
            base.InitializeControls();
        }

        public BaseBedProcedureForm() : base("BASEBEDPROCEDURE", "BaseBedProcedureForm")
        {
        }

        protected BaseBedProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}