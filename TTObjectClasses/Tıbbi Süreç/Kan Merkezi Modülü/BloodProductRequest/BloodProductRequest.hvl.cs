
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
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodProductRequest")] 

    /// <summary>
    /// Kan Ürünü İstek
    /// </summary>
    public  partial class BloodProductRequest : EpisodeActionWithDiagnosis
    {
        public class BloodProductRequestList : TTObjectCollection<BloodProductRequest> { }
                    
        public class ChildBloodProductRequestCollection : TTObject.TTChildObjectCollection<BloodProductRequest>
        {
            public ChildBloodProductRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodProductRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid BloodProductReady { get { return new Guid("0947ee6d-b131-4a55-9bd0-19b3862c0c3d"); } }
            public static Guid BloodProductDestruction { get { return new Guid("d48c806d-5e26-4bd4-92f4-1bb8c0bb679e"); } }
            public static Guid CrossMatch { get { return new Guid("3c232ace-c698-4c3c-ac2d-20eeaf7b5e69"); } }
            public static Guid BloodProductPreparation { get { return new Guid("b5813037-57ac-4012-8fb3-2b3b5ae5d00d"); } }
            public static Guid BloodProductRequest { get { return new Guid("91d194a3-3acf-4936-b176-751907af3522"); } }
            public static Guid BloodProductGivingBack { get { return new Guid("0bfcd0d7-a753-48c4-a189-5af5fb22f387"); } }
            public static Guid GivingBackToStock { get { return new Guid("ffd8ee9d-d54c-4ac6-b952-3398b263a516"); } }
            public static Guid BloodProductSupply { get { return new Guid("e4126df5-934e-4018-9690-52e6e7504cc1"); } }
            public static Guid Completed { get { return new Guid("95e6e995-b215-4c4f-8f4f-aa43a7c56d82"); } }
            public static Guid DoctorApprove { get { return new Guid("9b458b04-e407-4e5f-b35b-7c4d48caf347"); } }
            public static Guid BloodProductDelivery { get { return new Guid("97f2a1b0-f4a2-4fb5-8353-6a2d5768e29d"); } }
            public static Guid BloodProductUsage { get { return new Guid("0f94b476-4096-49f0-9ff6-ca81a1552d61"); } }
            public static Guid Reject { get { return new Guid("33e724c8-3e30-4e59-8bc6-c2c02b1f23c1"); } }
        }

        public static BindingList<BloodProductRequest> GetBloodProductRequestByExternalID(TTObjectContext objectContext, string EXTERNALID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODPRODUCTREQUEST"].QueryDefs["GetBloodProductRequestByExternalID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALID", EXTERNALID);

            return ((ITTQuery)objectContext).QueryObjects<BloodProductRequest>(queryDef, paramList);
        }

    /// <summary>
    /// Kan Grubu
    /// </summary>
        public string BloodGroup
        {
            get { return (string)this["BLOODGROUP"]; }
            set { this["BLOODGROUP"] = value; }
        }

    /// <summary>
    /// Gereksinim Tarihi
    /// </summary>
        public DateTime? RequirementDate
        {
            get { return (DateTime?)this["REQUIREMENTDATE"]; }
            set { this["REQUIREMENTDATE"] = value; }
        }

    /// <summary>
    /// Kan Grubu Notu
    /// </summary>
        public string BloodGroupNote
        {
            get { return (string)this["BLOODGROUPNOTE"]; }
            set { this["BLOODGROUPNOTE"] = value; }
        }

    /// <summary>
    /// Transfüzyon
    /// </summary>
        public bool? IsTransfused
        {
            get { return (bool?)this["ISTRANSFUSED"]; }
            set { this["ISTRANSFUSED"] = value; }
        }

    /// <summary>
    /// IstekŞekli
    /// </summary>
        public bool? Requestshape
        {
            get { return (bool?)this["REQUESTSHAPE"]; }
            set { this["REQUESTSHAPE"] = value; }
        }

    /// <summary>
    /// KanUrunuTeslimAlan
    /// </summary>
        public string BloodProductToTakeDelivery
        {
            get { return (string)this["BLOODPRODUCTTOTAKEDELIVERY"]; }
            set { this["BLOODPRODUCTTOTAKEDELIVERY"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Gebelik
    /// </summary>
        public bool? IsPregnancy
        {
            get { return (bool?)this["ISPREGNANCY"]; }
            set { this["ISPREGNANCY"] = value; }
        }

    /// <summary>
    /// Ameliyat
    /// </summary>
        public bool? IsSurgery
        {
            get { return (bool?)this["ISSURGERY"]; }
            set { this["ISSURGERY"] = value; }
        }

    /// <summary>
    /// Hb Yükseltme
    /// </summary>
        public bool? IsHB
        {
            get { return (bool?)this["ISHB"]; }
            set { this["ISHB"] = value; }
        }

    /// <summary>
    /// Diğer
    /// </summary>
        public bool? IsOtherReason
        {
            get { return (bool?)this["ISOTHERREASON"]; }
            set { this["ISOTHERREASON"] = value; }
        }

    /// <summary>
    /// Hazırlanacak
    /// </summary>
        public bool? IsPrepared
        {
            get { return (bool?)this["ISPREPARED"]; }
            set { this["ISPREPARED"] = value; }
        }

    /// <summary>
    /// Bloke Edilecek
    /// </summary>
        public bool? IsBlock
        {
            get { return (bool?)this["ISBLOCK"]; }
            set { this["ISBLOCK"] = value; }
        }

    /// <summary>
    /// Transfüzyon Tarihi
    /// </summary>
        public DateTime? TransfusedDate
        {
            get { return (DateTime?)this["TRANSFUSEDDATE"]; }
            set { this["TRANSFUSEDDATE"] = value; }
        }

    /// <summary>
    /// Gebelik Tarihi
    /// </summary>
        public DateTime? PregnancyDate
        {
            get { return (DateTime?)this["PREGNANCYDATE"]; }
            set { this["PREGNANCYDATE"] = value; }
        }

    /// <summary>
    /// Normal Cross
    /// </summary>
        public bool? IsNormalCross
        {
            get { return (bool?)this["ISNORMALCROSS"]; }
            set { this["ISNORMALCROSS"] = value; }
        }

    /// <summary>
    /// Cross Yapılmadan
    /// </summary>
        public bool? IsWithoutCross
        {
            get { return (bool?)this["ISWITHOUTCROSS"]; }
            set { this["ISWITHOUTCROSS"] = value; }
        }

    /// <summary>
    /// Acil Cross
    /// </summary>
        public bool? IsUrgentCross
        {
            get { return (bool?)this["ISURGENTCROSS"]; }
            set { this["ISURGENTCROSS"] = value; }
        }

    /// <summary>
    /// Testler olmadan
    /// </summary>
        public bool? IsWithoutTests
        {
            get { return (bool?)this["ISWITHOUTTESTS"]; }
            set { this["ISWITHOUTTESTS"] = value; }
        }

    /// <summary>
    /// Testlerle birlikte
    /// </summary>
        public bool? IsWithTests
        {
            get { return (bool?)this["ISWITHTESTS"]; }
            set { this["ISWITHTESTS"] = value; }
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? IsUrgent
        {
            get { return (bool?)this["ISURGENT"]; }
            set { this["ISURGENT"] = value; }
        }

    /// <summary>
    /// Kan bankası sisteminden yapılan İstemID
    /// </summary>
        public string BloodBankRequestExternalID
        {
            get { return (string)this["BLOODBANKREQUESTEXTERNALID"]; }
            set { this["BLOODBANKREQUESTEXTERNALID"] = value; }
        }

    /// <summary>
    /// İsteyen Doktor
    /// </summary>
        public ResUser RequestDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTDOCTOR"); }
            set { this["REQUESTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _BloodProducts = new BloodBankBloodProducts.ChildBloodBankBloodProductsCollection(_SubactionProcedures, "BloodProducts");
        }

        private BloodBankBloodProducts.ChildBloodBankBloodProductsCollection _BloodProducts = null;
        public BloodBankBloodProducts.ChildBloodBankBloodProductsCollection BloodProducts
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _BloodProducts;
            }            
        }

        protected BloodProductRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodProductRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodProductRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodProductRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodProductRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODPRODUCTREQUEST", dataRow) { }
        protected BloodProductRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODPRODUCTREQUEST", dataRow, isImported) { }
        public BloodProductRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodProductRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodProductRequest() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}