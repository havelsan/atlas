using Infrastructure.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTStorageManager.Security;

namespace Core.Services
{
    public class DefinitionService
    {
        private readonly ObjectMapperService _objectMapper;
        public DefinitionService(ObjectMapperService objectMapper)
        {
            _objectMapper = objectMapper;
        }

        public T GetObject<T>(Guid objectID) where T : TTObject
        {
            using (TTObjectContext context = new TTObjectContext(true))
            {
                return (T)context.GetObject(objectID, typeof(T));
            }
        }

        public TTObject GetObject(Guid objectID, string objectDefName, bool readOnly = true)
        {
            using (TTObjectContext context = new TTObjectContext(readOnly))
            {
                return context.GetObject(objectID, objectDefName);
            }
        }

        public TTObject CreateObject(string objectDefName)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                return context.CreateObject(objectDefName);
            }
        }

        public TTObject CreateObject(string objectDefName, Guid? objectID)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                if (objectID.HasValue)
                    return context.CreateObject(objectDefName, objectID.Value);
                return context.CreateObject(objectDefName);
            }
        }

        public void Insert(TTObject ttObject)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                var targetType = ttObject.GetType();
                var newObject = context.CreateObject(ttObject.ObjectDef.Name, ttObject.ObjectID);
                var result = _objectMapper.Map(ttObject, newObject);
                context.Save();
            }
        }

        public void Update(TTObject ttObject)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                var targetType = ttObject.GetType();
                var newObject = context.GetObject(ttObject.ObjectID, ttObject.ObjectDef.Name);
                var result = _objectMapper.Map(ttObject, newObject);
                context.Save();
            }
        }

        public TTObjectDef GetObjectDefFromID(Guid objectDefId)
        {
            var objectDef = TTObjectDefManager.Instance.ObjectDefs[objectDefId];
            return objectDef;
        }

        public TTObjectDef GetObjectDefFromName(string name)
        {
            var objectDef = TTObjectDefManager.Instance.ObjectDefs[name];
            return objectDef;
        }

        public TTListDef GetListDefFromID(Guid listDefId)
        {
            var listDef = TTObjectDefManager.Instance.ListDefs[listDefId];
            return listDef;
        }

        public TTListDef GetListDefFromName(string name)
        {
            var listDef = TTObjectDefManager.Instance.ListDefs[name];
            return listDef;
        }

        public TTReportDef GetReportDefFromID(Guid reportDefId)
        {
            var reportDef = TTObjectDefManager.Instance.ReportDefs[reportDefId];
            return reportDef;
        }

        public TTReportDef GetReportDefFromName(string name)
        {
            var reportDef = TTObjectDefManager.Instance.ReportDefs[name];
            return reportDef;
        }

        public TTDataType GetDataTypeFromID(Guid dataTypeId)
        {
            var dataType = TTObjectDefManager.Instance.DataTypes[dataTypeId];
            return dataType;
        }

        public TTDataType GetDataTypeFromName(string name)
        {
            var dataType = TTObjectDefManager.Instance.DataTypes[name];
            return dataType;
        }

        public TTRole GetRoleFromID(Guid dataTypeId)
        {
            var roleDef = TTObjectDefManager.Instance.Roles[dataTypeId];
            return roleDef;
        }

        public TTRole GetRoleFromName(string name)
        {
            var roleDef = TTObjectDefManager.Instance.Roles[name];
            return roleDef;
        }
    }
}