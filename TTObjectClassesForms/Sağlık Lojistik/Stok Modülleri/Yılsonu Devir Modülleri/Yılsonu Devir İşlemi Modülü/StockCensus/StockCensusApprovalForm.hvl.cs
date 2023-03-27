
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
    /// Yıl Sonu Devir
    /// </summary>
    public partial class StockCensusApprovalForm : TTForm
    {
    /// <summary>
    /// Yılsonu Devir İşlemi
    /// </summary>
        protected TTObjectClasses.StockCensus _StockCensus
        {
            get { return (TTObjectClasses.StockCensus)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox MaterialCensus;
        protected ITTTextBox OldMaterialCensus;
        protected ITTTextBox NewMaterialCensus;
        protected ITTTextBox TotalCardAmount;
        protected ITTTextBox NormalCardAmount;
        protected ITTTextBox NewCardAmount;
        protected ITTTextBox ZeroCensus;
        protected ITTTextBox OldZeroCensus;
        protected ITTTextBox NewZeroCensus;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker label333;
        protected ITTLabel TTLabel2;
        protected ITTLabel TTLabel1;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox AccountingTerm;
        protected ITTObjectListBox CardDrawer;
        protected ITTObjectListBox Store;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage3;
        protected ITTGrid StockCensusDetails;
        protected ITTTextBoxColumn NatoStockNo;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn StockCard;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn BeforeOrderNo;
        protected ITTTextBoxColumn OrderNo;
        protected ITTTextBoxColumn YearCensus;
        protected ITTTextBoxColumn TotalIn;
        protected ITTTextBoxColumn TotalInPrice;
        protected ITTTextBoxColumn TotalOut;
        protected ITTTextBoxColumn TotalOutPrice;
        protected ITTTextBoxColumn Inheld;
        protected ITTTextBoxColumn Used;
        protected ITTTextBoxColumn Consigned;
        protected ITTTextBoxColumn TotalInheld;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("7e2c0da1-683e-419e-926a-51e77f0f1815"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("9fb8cbc7-b36a-49e4-b4f7-6fbb56c0346b"));
            MaterialCensus = (ITTTextBox)AddControl(new Guid("93775b2b-776c-495c-90de-25e28cede4bf"));
            OldMaterialCensus = (ITTTextBox)AddControl(new Guid("0e91493d-56f8-4488-80d7-23d5a8d75d7b"));
            NewMaterialCensus = (ITTTextBox)AddControl(new Guid("63cced8a-e8d1-4848-a539-b2a00e0dc4f8"));
            TotalCardAmount = (ITTTextBox)AddControl(new Guid("7ba643be-c4e3-407d-9470-3163b4b737eb"));
            NormalCardAmount = (ITTTextBox)AddControl(new Guid("e47ea820-8ee5-474f-b837-a1c171ac1af9"));
            NewCardAmount = (ITTTextBox)AddControl(new Guid("d8a86687-89f3-47c4-94bf-3d7609369b90"));
            ZeroCensus = (ITTTextBox)AddControl(new Guid("0929efed-d0b1-4d61-9019-4b0f327dc76e"));
            OldZeroCensus = (ITTTextBox)AddControl(new Guid("bf6d3fdf-f1c5-4463-853c-7080bee61f42"));
            NewZeroCensus = (ITTTextBox)AddControl(new Guid("d9431b4d-732a-4dcb-ab9d-a2cb62e543a0"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("edca4053-68a4-401e-966e-5c3b7b3ddfec"));
            label333 = (ITTDateTimePicker)AddControl(new Guid("f9e92de7-57ed-4f31-9139-ef582ca64a9a"));
            TTLabel2 = (ITTLabel)AddControl(new Guid("c993499e-c089-4662-8ea9-74071496a4e6"));
            TTLabel1 = (ITTLabel)AddControl(new Guid("dd825e16-ddd4-404e-bfae-9af420e984a0"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a60e16e7-0d3d-4de6-bc9e-5ea054bfb3da"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("793d0ff2-9270-4524-a2e2-116dd5511c9b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("5e193873-b159-4b71-9ef4-92548ff82f30"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("6bf5bb6f-5b4c-4790-9d8c-58cecf04e1bb"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("b278dab1-2fb5-43c5-8224-146e5e501a2f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("27bec208-0ce8-4389-8f1f-016419b3e4ba"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("ef9f755c-a43e-42f3-bb37-463d28900dda"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("411288b9-055c-47f4-8461-c4aa9b0d92b6"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("251a2a46-1629-4ffb-bf2e-d8007a365a3e"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("04c6bf4f-90cc-4cef-9a75-a748b5542f38"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("352be2d2-ada9-4871-8e9e-c0d2e6d37ef0"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("063331cb-813d-40da-8b45-00a58582a5c3"));
            AccountingTerm = (ITTObjectListBox)AddControl(new Guid("60f28c16-366f-4736-be7a-a14a9eadeb95"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("b4ba95ae-0061-46c8-809c-3d37e795d95f"));
            Store = (ITTObjectListBox)AddControl(new Guid("ce5bbb1e-8ad7-4f08-aa6a-ba3f3e28ebc9"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("52013a9f-ee09-4413-a27c-26519181ba6c"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("0cd734cc-4333-4b5a-a9e9-f8c2b0a4a903"));
            StockCensusDetails = (ITTGrid)AddControl(new Guid("a43838c8-058e-4b87-8f62-d06f1d7899f4"));
            NatoStockNo = (ITTTextBoxColumn)AddControl(new Guid("9c62e361-be3e-4427-ae91-2d40113f2d9a"));
            Material = (ITTListBoxColumn)AddControl(new Guid("0c76d304-b726-43d8-9b48-bfe5206bab95"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("9401fa4f-e6f7-42d4-a02d-c15a96c16ffd"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("2d68fe13-26e7-4f65-bd79-59fe30a7eeb8"));
            BeforeOrderNo = (ITTTextBoxColumn)AddControl(new Guid("df7e9115-d866-4553-be64-978f25aeb065"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("4a3bde5c-95d0-411f-9e8f-b547c08f8581"));
            YearCensus = (ITTTextBoxColumn)AddControl(new Guid("1d2cf1c7-a2c5-4c8a-9b79-e6daf50317f9"));
            TotalIn = (ITTTextBoxColumn)AddControl(new Guid("74f31ff6-4617-4b9e-8ea7-652cbae51d3e"));
            TotalInPrice = (ITTTextBoxColumn)AddControl(new Guid("18bdcd00-21f0-4de1-9b5a-0bcd891d43a0"));
            TotalOut = (ITTTextBoxColumn)AddControl(new Guid("196cc45d-8d48-4763-918f-413cee16ff6b"));
            TotalOutPrice = (ITTTextBoxColumn)AddControl(new Guid("a21f3a89-8006-415e-9792-58eb1307069d"));
            Inheld = (ITTTextBoxColumn)AddControl(new Guid("a1724627-33e9-4af1-9bf2-c0a7ed2d2898"));
            Used = (ITTTextBoxColumn)AddControl(new Guid("8addb8a3-738b-401e-a1ef-2bfcdfbbdd7f"));
            Consigned = (ITTTextBoxColumn)AddControl(new Guid("7204255e-a307-42b4-9a3a-f24b83f9ad55"));
            TotalInheld = (ITTTextBoxColumn)AddControl(new Guid("c61224de-fbd1-42b4-b679-5bdc92823711"));
            base.InitializeControls();
        }

        public StockCensusApprovalForm() : base("STOCKCENSUS", "StockCensusApprovalForm")
        {
        }

        protected StockCensusApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}