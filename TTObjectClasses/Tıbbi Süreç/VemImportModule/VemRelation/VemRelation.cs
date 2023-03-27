
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
    /// Vem Aktarımlarının Ara Tablosu
    /// </summary>
    public partial class VemRelation : TTObject
    {
        public static T Converter<T>(object value)
        {
            T defaultValue = default(T);

            if (value != DBNull.Value)
            {
                try
                {
                    Type type = typeof(T);
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        defaultValue = (T)Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
                    }
                    else
                    {
                        defaultValue = (T)Convert.ChangeType(value, typeof(T));
                    }
                }
                catch
                {
                    defaultValue = default(T);
                }
            }
            return defaultValue;
        }

        public enum HospitalEnum : int
        {
            Undefined = 0,
            GazilerFtr = 1,
            VemToGazilerFtr = 2,
            VemPursaklar = 3
        }

        public static void ClearCache()
        {
            lock (_vemRelationCacheLock)
            {
                _vemRelationCache = null;
            }
        }

        private static object _vemRelationCacheLock = new object();
        private static object _vemRelationCacheLock2 = new object();
        private static Dictionary<string, List<VemRelation>> _vemRelationCache;
        public static Dictionary<string, List<VemRelation>> VemRelationCache
        {
            get
            {
                if (_vemRelationCache == null)
                {
                    lock (_vemRelationCacheLock)
                    {
                        _vemRelationCache = new Dictionary<string, List<VemRelation>>();
                        BindingList<VemRelation> vemRelationList = VemRelation.GetAll(new TTObjectContext(true));
                        foreach (VemRelation vem in vemRelationList)
                        {
                            List<VemRelation> tempList = null;
                            _vemRelationCache.TryGetValue(vem.getCacheID(), out tempList);
                            if (tempList == null)
                            {
                                tempList = new List<VemRelation>();
                                tempList.Add(vem);
                                _vemRelationCache.Add(vem.getCacheID(), tempList);
                            }
                            else
                            {
                                tempList.Add(vem);
                                _vemRelationCache[vem.getCacheID()] = tempList;
                            }
                        }
                    }
                }
                return _vemRelationCache;
            }
        }
         
        public VemRelation(TTObjectContext objectContext, string VemObjectID, Guid HvlObjectID, HospitalEnum HospitalID, string VemTableName, bool usingCache = true) : this(objectContext, (DataRow)null)
        {
            this.VemObjectID = VemObjectID;
            this.HvlObjectID = HvlObjectID;
            VemID = (int)HospitalID;
            this.VemTableName = VemTableName;
            if(usingCache)
                AddVemRelationToCache(this);

        }

        public string getCacheID()
        {
            return getCacheID(VemID.Value, VemObjectID, VemTableName);
        }

        public static string getCacheID(HospitalEnum HospitalID, string VemObjectID, string VemTableName)
        {
            return getCacheID((int)HospitalID, VemObjectID, VemTableName);
        }

        private static string getCacheID(int HospitalID, string VemObjectID, string VemTableName)
        {
            return HospitalID + "_" + VemTableName + "_" + VemObjectID;
        }

        public static List<VemRelation> GetVemRelations(HospitalEnum HospitalID, string VemObjectID, string VemTableName)
        {
            string cacheID = getCacheID(HospitalID, VemObjectID, VemTableName);
            List<VemRelation> tempList = null;
            lock (_vemRelationCacheLock2)
            {
                VemRelationCache.TryGetValue(cacheID, out tempList);
            }
            return tempList;
        }
        public static BindingList<VemRelation> GetVemRelationsFromDB(TTObjectContext objectContext, HospitalEnum HospitalID, string VemObjectID, string VemTableName)
        {
            BindingList<VemRelation> vemRelationList = VemRelation.GetByVemProperties(objectContext, (int)HospitalID, VemObjectID, VemTableName);
            return vemRelationList;
        }

        public static void AddVemRelationToCache(VemRelation vem)
        {
            if (!ExistInCache(vem))
            {
                List<VemRelation> tempList = null;
                lock (_vemRelationCacheLock2)
                {
                    if (VemRelationCache.TryGetValue(vem.getCacheID(), out tempList) == false)
                    {
                        tempList = new List<VemRelation>();
                        VemRelationCache.Add(vem.getCacheID(), tempList);
                    }
                    tempList.Add((VemRelation)vem.Clone(true));  //Başka contextteki VemRelation cache'e eklenirse memory leak oluyor.
                }
            }
        }

        private static bool ExistInCache(VemRelation vem)
        {
            List<VemRelation> tempList = null;
            lock (_vemRelationCacheLock2)
            {
                VemRelationCache.TryGetValue(vem.getCacheID(), out tempList);
                if (tempList == null)
                    return false;
                else
                {
                    foreach (VemRelation vemTemp in tempList)
                    {
                        if (vem.HvlObjectID.Value == vemTemp.HvlObjectID.Value)
                            return true;
                    }
                }
                return false;
            }
        }

        public static T GetHVLObject<T>(TTObjectContext objectContext, HospitalEnum HospitalID, string VemObjectID, string VemTableName) where T : TTObject
        {
            List<VemRelation> vemRelationList = VemRelation.GetVemRelations(HospitalID, VemObjectID, VemTableName);
            if (vemRelationList == null)
                return default(T);

            T retval = null;
            foreach (VemRelation vemRelation in vemRelationList)
            {
                var o = objectContext.GetObject<T>(vemRelation.HvlObjectID.Value, false);
                if ( o != null)
                {
                    retval = o;
                    break;
                }
            }
            return retval;
        }


        public static T GetHVLObjectFromDB<T>(TTObjectContext objectContext, HospitalEnum HospitalID, string VemObjectID, string VemTableName) where T : TTObject
        {
            BindingList<VemRelation> vemRelationList = VemRelation.GetByVemProperties(objectContext,(int)HospitalID, VemObjectID, VemTableName);
            if (vemRelationList == null)
                return default(T);

            T retval = null;
            foreach (VemRelation vemRelation in vemRelationList)
            {
                var o = objectContext.GetObject<T>(vemRelation.HvlObjectID.Value, false);
                if (o != null)
                {
                    retval = o;
                    break;
                }
            }
            return retval;
        }

        public static bool ExistsFromDB(TTObjectContext objectContext, HospitalEnum HospitalID, string VemObjectID, string VemTableName, Guid? HVLObjectID = null)
        {
            BindingList<VemRelation> relationList = VemRelation.GetByVemProperties(objectContext, (int)HospitalID, VemObjectID, VemTableName);
            bool Exist = false;
            if (relationList == null || relationList.Count == 0)
            {
                return Exist;
            }
            else if (HVLObjectID == null)
            {
                return true;
            }
            else
            {
                // Multiple Existing
                foreach (VemRelation vem in relationList)
                {
                    if (vem.HvlObjectID == HVLObjectID)
                        Exist = true;
                }
                return Exist;
            }
        }


        public static bool Exists(HospitalEnum HospitalID, string VemObjectID, string VemTableName, Guid? HVLObjectID = null)
        {
            if (HVLObjectID == null)
            {
                string cacheID = getCacheID(HospitalID, VemObjectID, VemTableName);
                lock (_vemRelationCacheLock2)
                {
                    return VemRelationCache.ContainsKey(cacheID);
                }
            }
            else
            {
                // Multiple Existing
                List<VemRelation> vemReleations = GetVemRelations(HospitalID, VemObjectID, VemTableName);

                bool Exist = false;
                if (vemReleations == null)
                    return Exist;

                foreach (VemRelation vem in vemReleations)
                {
                    if (vem.HvlObjectID == HVLObjectID)
                        Exist = true;
                }

                return Exist;
            }
        }
    }
}