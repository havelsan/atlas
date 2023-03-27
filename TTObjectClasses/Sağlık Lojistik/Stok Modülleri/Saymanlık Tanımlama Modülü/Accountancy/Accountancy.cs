
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
    /// <summary>
    /// Saymanlık Tanımları
    /// </summary>
    public  partial class Accountancy : TerminologyManagerDef, IAccountancy
    {
        public partial class GetAccountancyList_Class : TTReportNqlObject 
        {
        }

        #region Methods

        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion

        #region IAccountancy Members

        IMilitaryUnit IAccountancy.GetAccountancyMilitaryUnit()
        {
            return (IMilitaryUnit)AccountancyMilitaryUnit;
        }

        string IAccountancy.GetAccountancyNO()
        {
            return AccountancyNO;
        }

        string IAccountancy.GetName()
        {
            return Name;
        }

        #endregion


        public static Guid XXXXXX11TuketimSaymanligiAccountancyObjectID
        {
            get { return new Guid("d50a4979-27d8-42d0-9b1f-654911fff61e"); }
        }

        private static Accountancy _XXXXXX11TuketimSaymanligi;
        public static Accountancy XXXXXX11TuketimSaymanligi
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX11TuketimSaymanligiAccountancyObjectID, out _XXXXXX11TuketimSaymanligi);
                return _XXXXXX11TuketimSaymanligi;
            }
        }

        public static Guid XXXXXX11AnaMalzemeSaymanligiAccountancyObjectID
        {
            get { return new Guid("21dabaa8-b7e6-4095-89e8-ef94b7013d39"); }
        }

        private static Accountancy _XXXXXX11AnaMalzemeSaymanligi;
        public static Accountancy XXXXXX11AnaMalzemeSaymanligi
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX11AnaMalzemeSaymanligiAccountancyObjectID, out _XXXXXX11AnaMalzemeSaymanligi);
                return _XXXXXX11AnaMalzemeSaymanligi;
            }
        }

        public static Guid XXXXXX11HEKSaymanligiAccountancyObjectID
        {
            get { return new Guid("984d58ca-862c-456e-aad7-3ad630108200"); }
        }

        private static Accountancy _XXXXXX11HEKSaymanligi;
        public static Accountancy XXXXXX11HEKSaymanligi
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX11HEKSaymanligiAccountancyObjectID, out _XXXXXX11HEKSaymanligi);
                return _XXXXXX11HEKSaymanligi;
            }
        }

        public static Guid XXXXXXTuketimSaymanligiAccountancyObjectID
        {
            get { return new Guid("86280008-cf08-4b68-a1ba-dba912a607e2"); }
        }

        private static Accountancy _XXXXXXTuketimSaymanligi;
        public static Accountancy XXXXXXTuketimSaymanligi
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXXTuketimSaymanligiAccountancyObjectID, out _XXXXXXTuketimSaymanligi);
                return _XXXXXXTuketimSaymanligi;
            }
        }

        
        public static Guid XXXXXX04TuketimSaymanligiAccountancyObjectID
        {
            get { return new Guid("d0582f59-699f-46d1-becf-ba228495fa7a"); }
        }

        private static Accountancy _XXXXXX04TuketimSaymanligi;
        public static Accountancy XXXXXX04TuketimSaymanligi
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX04TuketimSaymanligiAccountancyObjectID, out _XXXXXX04TuketimSaymanligi);
                return _XXXXXX04TuketimSaymanligi;
            }
        }

        public static Guid XXXXXX02XXXXXXAccountancyObjectID
        {
            get { return new Guid("6cb4fee1-2360-43d3-9a68-c2bb8d8feaa0"); }
        }

        private static Accountancy _XXXXXX02XXXXXX;
        public static Accountancy XXXXXX02XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX02XXXXXXAccountancyObjectID, out _XXXXXX02XXXXXX);
                return _XXXXXX02XXXXXX;
            }
        }

        public static Guid XXXXXX05XXXXXXAccountancyObjectID
        {
            get { return new Guid("9b7c67da-69eb-4984-a642-2d33615dd840"); }
        }

        private static Accountancy _XXXXXX05XXXXXX;
        public static Accountancy XXXXXX05XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX05XXXXXXAccountancyObjectID, out _XXXXXX05XXXXXX);
                return _XXXXXX05XXXXXX;
            }
        }

        public static Guid XXXXXX07XXXXXXAccountancyObjectID
        {
            get { return new Guid("2f1759d9-fa0c-4645-bc46-7caa27e53755"); }
        }

        private static Accountancy _XXXXXX07XXXXXX;
        public static Accountancy XXXXXX07XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX07XXXXXXAccountancyObjectID, out _XXXXXX07XXXXXX);
                return _XXXXXX07XXXXXX;
            }
        }
        
        public static Guid XXXXXX44XXXXXXAccountancyObjectID
        {
            get { return new Guid("33c3d8c4-a6f3-4770-885a-e3e5fc2eaeef"); }
        }

        private static Accountancy _XXXXXX44XXXXXX;
        public static Accountancy XXXXXX44XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX44XXXXXXAccountancyObjectID, out _XXXXXX44XXXXXX);
                return _XXXXXX44XXXXXX;
            }
        }

        public static Guid XXXXXX1XXXXXXAccountancyObjectID
        {
            get { return new Guid("a9eed4cd-e0c2-4da3-b551-01579533f3b3"); }
        }

        private static Accountancy _XXXXXX1XXXXXX;
        public static Accountancy XXXXXX1XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX1XXXXXXAccountancyObjectID, out _XXXXXX1XXXXXX);
                return _XXXXXX1XXXXXX;
            }
        }

        public static Guid XXXXXXXXXXXXAccountancyObjectID
        {
            get { return new Guid("8621bc74-685b-4bd0-93a3-90cb2b1fac9c"); }
        }

        private static Accountancy _XXXXXXXXXXXX;
        public static Accountancy XXXXXXXXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXXXXXXXXAccountancyObjectID, out _XXXXXXXXXXXX);
                return _XXXXXXXXXXXX;
            }
        }

        public static Guid XXXXXX35XXXXXXAccountancyObjectID
        {
            get { return new Guid("95218e1b-4bbb-4333-999c-4064af375702"); }
        }

        private static Accountancy _XXXXXX35XXXXXX;
        public static Accountancy XXXXXX35XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX35XXXXXXAccountancyObjectID, out _XXXXXX35XXXXXX);
                return _XXXXXX35XXXXXX;
            }
        }

        public static Guid XXXXXX25XXXXXXAccountancyObjectID
        {
            get { return new Guid("257512d3-b508-461d-a9ba-e8ccca7d7d3c"); }
        }

        private static Accountancy _XXXXXX25XXXXXX;
        public static Accountancy XXXXXX25XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX25XXXXXXAccountancyObjectID, out _XXXXXX25XXXXXX);
                return _XXXXXX25XXXXXX;
            }
        }

        public static Guid XXXXXX03XXXXXXAccountancyObjectID
        {
            get { return new Guid("162594b7-ced7-4c2a-a527-45ffe03cecec"); }
        }

        private static Accountancy _XXXXXX03XXXXXX;
        public static Accountancy XXXXXX03XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX03XXXXXXAccountancyObjectID, out _XXXXXX03XXXXXX);
                return _XXXXXX03XXXXXX;
            }
        }

        public static Guid XXXXXX10AccountancyObjectID
        {
            get { return new Guid("50fc8765-3660-48fa-a2bb-48ddd47b178b"); }
        }

        private static Accountancy _XXXXXX10;
        public static Accountancy XXXXXX10
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX10AccountancyObjectID, out _XXXXXX10);
                return _XXXXXX10;
            }
        }

        public static Guid XXXXXX12AccountancyObjectID
        {
            get { return new Guid("e46da328-0ba2-49e7-b817-0f8ae22644ac"); }
        }

        private static Accountancy _XXXXXX12;
        public static Accountancy XXXXXX12
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX12AccountancyObjectID, out _XXXXXX12);
                return _XXXXXX12;
            }
        }

        public static Guid XXXXXX26XXXXXXAccountancyObjectID
        {
            get { return new Guid("b5153725-ff5d-407a-ba83-d4492aa02dce"); }
        }

        private static Accountancy _XXXXXX26XXXXXX;
        public static Accountancy XXXXXX26XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX26XXXXXXAccountancyObjectID, out _XXXXXX26XXXXXX);
                return _XXXXXX26XXXXXX;
            }
        }

        public static Guid XXXXXX08XXXXXXAccountancyObjectID
        {
            get { return new Guid("f2bbef0d-9c34-4198-a2b6-acb91a56abf8"); }
        }

        private static Accountancy _XXXXXX08XXXXXX;
        public static Accountancy XXXXXX08XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX08XXXXXXAccountancyObjectID, out _XXXXXX08XXXXXX);
                return _XXXXXX08XXXXXX;
            }
        }

        public static Guid XXXXXX09XXXXXXAccountancyObjectID
        {
            get { return new Guid("d2691ff0-2e9a-4482-8a05-0328097da0b3"); }
        }

        private static Accountancy _XXXXXX09XXXXXX;
        public static Accountancy XXXXXX09XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX09XXXXXXAccountancyObjectID, out _XXXXXX09XXXXXX);
                return _XXXXXX09XXXXXX;
            }
        }

        public static Guid XXXXXX06XXXXXXAccountancyObjectID
        {
            get { return new Guid("31bf05f3-d754-4614-9ba5-b18bcf45e4b2"); }
        }

        private static Accountancy _XXXXXX06XXXXXX;
        public static Accountancy XXXXXX06XXXXXX
        {
            get
            {
                _XXXXXXAccountancies.TryGetValue(XXXXXX06XXXXXXAccountancyObjectID, out _XXXXXX06XXXXXX);
                return _XXXXXX06XXXXXX;
            }
        }

        private static Dictionary<Guid, Accountancy> _XXXXXXAccountancies;
        public static Dictionary<Guid, Accountancy> XXXXXXAccountancies
        {
            get { return _XXXXXXAccountancies; }
        }

        static Accountancy()
        {
            List<Guid> objectIDs = new List<Guid>();
            objectIDs.Add(XXXXXX11TuketimSaymanligiAccountancyObjectID);
            objectIDs.Add(XXXXXX11AnaMalzemeSaymanligiAccountancyObjectID);
            objectIDs.Add(XXXXXX11HEKSaymanligiAccountancyObjectID);
            objectIDs.Add(XXXXXXTuketimSaymanligiAccountancyObjectID);
            objectIDs.Add(XXXXXX04TuketimSaymanligiAccountancyObjectID);
            objectIDs.Add(XXXXXX02XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX05XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX07XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX35XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX25XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX03XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX10AccountancyObjectID);
            objectIDs.Add(XXXXXX12AccountancyObjectID);
            objectIDs.Add(XXXXXX26XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX08XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX09XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX06XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX44XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXX1XXXXXXAccountancyObjectID);
            objectIDs.Add(XXXXXXXXXXXXAccountancyObjectID);

            _XXXXXXAccountancies = new Dictionary<Guid, Accountancy>();
            TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
            foreach (Accountancy accountancy in Accountancy.GetAccountancies(readOnlyObjectContext, objectIDs))
                _XXXXXXAccountancies.Add(accountancy.ObjectID, accountancy);
            
        }

        public override string ToString()
        {
            return AccountancyCode + " - " + Name;
        }

        /// <summary>
        /// Açık hesap dönemi varsa geri döndürür. Birden fazla varsa ve hiç yoksa null döner.
        /// </summary>
        /// <returns>AccountingTerm</returns>
        public AccountingTerm GetOpenAccountingTerm()
        {
            IList accountingTerms = AccountingTerms.Select("STATUS = " + (int)AccountingTermStatusEnum.Open);
            if (Convert.ToBoolean(accountingTerms.Count))
                return (AccountingTerm)accountingTerms[0];
            else
                return null;
        }

        /// <summary>
        /// Yarı açık hesap dönemi varsa geri döndürür. Birden fazla varsa ve hiç yoksa null döner.
        /// </summary>
        /// <returns>AccountingTerm</returns>
        public AccountingTerm GetHalfOpenAccountingTerm()
        {
            IList accountingTerms = AccountingTerms.Select("STATUS = " + (int)AccountingTermStatusEnum.HalfOpen);
            if (Convert.ToBoolean(accountingTerms.Count))
                return (AccountingTerm)accountingTerms[0];
            else
                return null;
        }

        /// <summary>
        /// Bir önceki hesap dönemi varsa geri döndürür. Birden fazla varsa ve hiç yoksa null döner.
        /// </summary>
        /// <returns>AccountingTerm</returns>
        public AccountingTerm GetPreviousAccountingTerm(DateTime date)
        {
            IList accountingTerms = AccountingTerms.Select("ENDDATE ='" + date + "' AND STATUS = " + (int)AccountingTermStatusEnum.Close);
            if (Convert.ToBoolean(accountingTerms.Count))
                return (AccountingTerm)accountingTerms[0];
            else
                return null;
        }
        
        public static List<Accountancy> GetAllXXXXXXAccountancies()
        {
            List<Accountancy> retList = new List<Accountancy>();
            TTObjectContext context = new TTObjectContext(true);
            IBindingList militaryUnits = context.QueryObjects(typeof(MilitaryUnit).Name, "ISSUPPORTED = 1");
            foreach(MilitaryUnit mu in militaryUnits)
            {
                Sites site = mu.Site;
                if (site.IP == "83.1.1.31" || site.Name.ToUpper() == "LOCALHOST")
                    continue;

                IBindingList accountancies = context.QueryObjects(typeof(Accountancy).Name, "ACCOUNTANCYMILITARYUNIT = ' " + mu.ObjectID.ToString() + "'");
                foreach(Accountancy acc in accountancies)
                {
                    retList.Add(acc);

                }
            }
            
            return retList;
        }


        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.AccountancyInfo;
        }
        
#endregion Methods

    }
}