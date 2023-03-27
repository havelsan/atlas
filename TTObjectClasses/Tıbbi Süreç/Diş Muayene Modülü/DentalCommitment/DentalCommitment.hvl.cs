
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalCommitment")] 

    /// <summary>
    /// Diş Taahhüt İşlemlerinin Tutulduğu Nesnedir
    /// </summary>
    public  partial class DentalCommitment : TTObject
    {
        public class DentalCommitmentList : TTObjectCollection<DentalCommitment> { }
                    
        public class ChildDentalCommitmentCollection : TTObject.TTChildObjectCollection<DentalCommitment>
        {
            public ChildDentalCommitmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalCommitmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<DentalCommitment> GetOldDentalCommitments(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALCOMMITMENT"].QueryDefs["GetOldDentalCommitments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<DentalCommitment>(queryDef, paramList);
        }

    /// <summary>
    /// Taahhüt Numarası
    /// </summary>
        public string CommitmentNo
        {
            get { return (string)this["COMMITMENTNO"]; }
            set { this["COMMITMENTNO"] = value; }
        }

    /// <summary>
    /// Takip No
    /// </summary>
        public string CommitmentProtocolNo
        {
            get { return (string)this["COMMITMENTPROTOCOLNO"]; }
            set { this["COMMITMENTPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string CommitmentResultCode
        {
            get { return (string)this["COMMITMENTRESULTCODE"]; }
            set { this["COMMITMENTRESULTCODE"] = value; }
        }

    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string CommitmentResultMessage
        {
            get { return (string)this["COMMITMENTRESULTMESSAGE"]; }
            set { this["COMMITMENTRESULTMESSAGE"] = value; }
        }

        public DateTime? SendDate
        {
            get { return (DateTime?)this["SENDDATE"]; }
            set { this["SENDDATE"] = value; }
        }

    /// <summary>
    /// Posta Kodu
    /// </summary>
        public string PostCode
        {
            get { return (string)this["POSTCODE"]; }
            set { this["POSTCODE"] = value; }
        }

    /// <summary>
    /// Cadde-Sokak Adı
    /// </summary>
        public string StreetName
        {
            get { return (string)this["STREETNAME"]; }
            set { this["STREETNAME"] = value; }
        }

    /// <summary>
    /// Dış Kapı No
    /// </summary>
        public string OuterDoorNo
        {
            get { return (string)this["OUTERDOORNO"]; }
            set { this["OUTERDOORNO"] = value; }
        }

    /// <summary>
    /// Telefon No
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

    /// <summary>
    /// E-Posta
    /// </summary>
        public string EMail
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

    /// <summary>
    /// Taahhüt Alanın Adı
    /// </summary>
        public string CommitmentTakenByName
        {
            get { return (string)this["COMMITMENTTAKENBYNAME"]; }
            set { this["COMMITMENTTAKENBYNAME"] = value; }
        }

    /// <summary>
    /// Taahhüt Alanın Soyadı
    /// </summary>
        public string CommitmentTakenBySurname
        {
            get { return (string)this["COMMITMENTTAKENBYSURNAME"]; }
            set { this["COMMITMENTTAKENBYSURNAME"] = value; }
        }

    /// <summary>
    /// İç Kapı No
    /// </summary>
        public string InnerDoorNo
        {
            get { return (string)this["INNERDOORNO"]; }
            set { this["INNERDOORNO"] = value; }
        }

    /// <summary>
    /// İl
    /// </summary>
        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TownDefinitions Town
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("TOWN"); }
            set { this["TOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDentalExaminationCollection()
        {
            _DentalExamination = new DentalExamination.ChildDentalExaminationCollection(this, new Guid("fb83bf36-f221-4365-ac3f-b232f931c9af"));
            ((ITTChildObjectCollection)_DentalExamination).GetChildren();
        }

        protected DentalExamination.ChildDentalExaminationCollection _DentalExamination = null;
        public DentalExamination.ChildDentalExaminationCollection DentalExamination
        {
            get
            {
                if (_DentalExamination == null)
                    CreateDentalExaminationCollection();
                return _DentalExamination;
            }
        }

        virtual protected void CreateDentalCommitmentProstethisesCollection()
        {
            _DentalCommitmentProstethises = new DentalCommitmentProsthesis.ChildDentalCommitmentProsthesisCollection(this, new Guid("8b84d993-3816-4ee1-9f52-420c882e21fc"));
            ((ITTChildObjectCollection)_DentalCommitmentProstethises).GetChildren();
        }

        protected DentalCommitmentProsthesis.ChildDentalCommitmentProsthesisCollection _DentalCommitmentProstethises = null;
        public DentalCommitmentProsthesis.ChildDentalCommitmentProsthesisCollection DentalCommitmentProstethises
        {
            get
            {
                if (_DentalCommitmentProstethises == null)
                    CreateDentalCommitmentProstethisesCollection();
                return _DentalCommitmentProstethises;
            }
        }

        protected DentalCommitment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalCommitment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalCommitment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalCommitment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalCommitment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALCOMMITMENT", dataRow) { }
        protected DentalCommitment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALCOMMITMENT", dataRow, isImported) { }
        public DentalCommitment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalCommitment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalCommitment() : base() { }

    }
}