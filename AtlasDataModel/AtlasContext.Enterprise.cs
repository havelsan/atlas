using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasDataModel
{
    public partial class AtlasContextEnterprise
    {
        #region DbSet Properties
        public virtual DbSet<AtlasModel.Enterprise.TTAssemblyDef> TTAssemblyDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTAttributeDef> TTAttributeDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTAttributeParameterDef> TTAttributeParameterDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTBinaryData> TTBinaryData { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTFolderDef> TTFolderDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTFormDef> TTFormDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTFormFieldDef> TTFormFieldDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTFormFieldEventDef> TTFormFieldEventDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTInterfaceDef> TTInterfaceDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTInterfaceMemberDef> TTInterfaceMemberDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTListColumnDef> TTListColumnDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTListDef> TTListDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTListPropertyDef> TTListPropertyDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTModuleDef> TTModuleDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectCodedPropertyDef> TTObjectCodedPropertyDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectDef> TTObjectDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectDefBase> TTObjectDefBase { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectPropertyDef> TTObjectPropertyDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectRelationDef> TTObjectRelationDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectRelationSubtypeDef> TTObjectRelationSubtypeDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectState> TTObjectState { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectStateDef> TTObjectStateDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectStateReportDef> TTObjectStateReportDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTObjectStateTransitionDef> TTObjectStateTransitionDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTPasswordHistory> TTPasswordHistory { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTPermission> TTPermission { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTPermissionDef> TTPermissionDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTPermissionParameterDef> TTPermissionParameterDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTPropertyPropagationDef> TTPropertyPropagationDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTQueryDef> TTQueryDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTQueryParameterDef> TTQueryParameterDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTRelationPropagationDef> TTRelationPropagationDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTRemoteMethodDef> TTRemoteMethodDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTRemoteMethodParamDef> TTRemoteMethodParamDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTReportDef> TTReportDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTRightDef> TTRightDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTRole> TTRole { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTRoleMember> TTRoleMember { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTRoleTransfer> TTRoleTransfer { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTSequence> TTSequence { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTUser> TTUser { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTUserRole> TTUserRole { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTWebMethodDef> TTWebMethodDef { get; set; }
        public virtual DbSet<AtlasModel.Enterprise.TTWebMethodParamDef> TTWebMethodParamDef { get; set; }
        #endregion

        private void ApplyEntityConfigurationsForEnterprise(ModelBuilder modelBuilder)
        {

            #region Entity Configurations
            #endregion Entity Configurations
        }
    }
}
