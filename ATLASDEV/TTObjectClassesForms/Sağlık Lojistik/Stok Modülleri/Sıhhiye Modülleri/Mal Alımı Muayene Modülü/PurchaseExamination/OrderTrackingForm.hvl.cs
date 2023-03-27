
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
    /// Sipariş İzleme Formu
    /// </summary>
    public partial class OrderTrackingForm : TTForm
    {
    /// <summary>
    /// Geçici Kabul ve Mal Alım Muayene için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseExamination _PurchaseExamination
        {
            get { return (TTObjectClasses.PurchaseExamination)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid FirmsGrid;
        protected ITTListBoxColumn Supplier;
        protected ITTTextBoxColumn GUID;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid AvailableItemsGrid;
        protected ITTCheckBoxColumn clmCheck;
        protected ITTListBoxColumn clmPurchaseItem;
        protected ITTListBoxColumn clmMaterial;
        protected ITTTextBoxColumn clmOrderAmount;
        protected ITTTextBoxColumn clmOrderDate;
        protected ITTTextBoxColumn clmDueDate;
        protected ITTTextBoxColumn clmGUID;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("21cb3f7b-454e-4689-9bc4-66f933e6a7a9"));
            FirmsGrid = (ITTGrid)AddControl(new Guid("0226ff43-88a6-4638-b604-9c91bbffc515"));
            Supplier = (ITTListBoxColumn)AddControl(new Guid("ba13d71d-b2ea-4acd-8f79-13a021e04bc4"));
            GUID = (ITTTextBoxColumn)AddControl(new Guid("2295f4c0-de10-40fe-829b-0f8a597d12f6"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("d0ea07ad-98ec-46e9-a8f7-d1aaa305cb3f"));
            AvailableItemsGrid = (ITTGrid)AddControl(new Guid("a8117817-7abd-4166-923a-0f5cb1419d69"));
            clmCheck = (ITTCheckBoxColumn)AddControl(new Guid("96d4e4af-ddaa-40e6-8a84-e45583774125"));
            clmPurchaseItem = (ITTListBoxColumn)AddControl(new Guid("5e902975-561f-467d-9798-e65ec5d3417d"));
            clmMaterial = (ITTListBoxColumn)AddControl(new Guid("7eb93bd2-8e19-4ac8-90f4-3214096115b5"));
            clmOrderAmount = (ITTTextBoxColumn)AddControl(new Guid("0d7ce21f-b815-4a41-86b5-61686ca23707"));
            clmOrderDate = (ITTTextBoxColumn)AddControl(new Guid("29b52bf3-fa59-4b3a-9357-f77f1129b9ae"));
            clmDueDate = (ITTTextBoxColumn)AddControl(new Guid("e25c3e99-0a3e-4e5d-851d-dfb319c66338"));
            clmGUID = (ITTTextBoxColumn)AddControl(new Guid("c6a6bd6b-473d-4bbe-9b30-67c701624d6e"));
            base.InitializeControls();
        }

        public OrderTrackingForm() : base("PURCHASEEXAMINATION", "OrderTrackingForm")
        {
        }

        protected OrderTrackingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}