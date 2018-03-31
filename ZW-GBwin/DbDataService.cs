using DataHelper;
using Moon.Orm;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using ZW_GBwin.Model;

namespace ZW_GBwin
{
    public class DbDataService
    {
        DatabaseConfig dbConfig;
        string connectStr = "";

        string ApplicationStartPath = "";

        public DbDataService(string start)
        {
            dbConfig = new DatabaseConfig(start);
            connectStr = dbConfig.GetDataDbConnectStr();//获取数据库连接字符串
            ApplicationStartPath = start;
        }

        #region 播放资源管理

        /// <summary>
        /// Adds the one object for resource class.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="rid">The rid.</param>
        private void addOneObjectForResourceClass(Sqlite db, long rid)
        {
            if (db != null)
            {
                try
                {
                    var resourceClassEntity = db.GetEntity<ZWGB_ResourceClass>(ZWGB_ResourceClassSet.SelectAll().Where(ZWGB_ResourceClassSet.RID.Equal(rid)));
                    if (resourceClassEntity != null)
                    {
                        resourceClassEntity.ObjectCount++;
                        resourceClassEntity.WhereExpression = ZWGB_ResourceClassSet.RID.Equal(rid);
                        db.Update(resourceClassEntity);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Subtracts the one object for resource class.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="rid">The rid.</param>
        private void subtractOneObjectForResourceClass(Sqlite db, long rid)
        {
            try
            {
                var resourceClassEntity = db.GetEntity<ZWGB_ResourceClass>(ZWGB_ResourceClassSet.SelectAll().Where(ZWGB_ResourceClassSet.RID.Equal(rid)));
                if (resourceClassEntity != null)
                {
                    resourceClassEntity.ObjectCount = resourceClassEntity.ObjectCount > 0 ? --resourceClassEntity.ObjectCount : 0;
                    resourceClassEntity.WhereExpression = ZWGB_ResourceClassSet.RID.Equal(rid);
                    db.Update(resourceClassEntity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // public

        /// <summary>
        /// Gets the resources class.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet GetResourcesClass()
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var resourceClassSet = db.GetDataSet(ZWGB_ResourceClassSet.SelectAll().Where(ZWGB_ResourceClassSet.RID.BiggerThanOrEqual(0)));
                    if (resourceClassSet != null && resourceClassSet.Tables.Count > 0)
                    {
                        resourceClassSet.Tables[0].TableName = "Table0";
                    }
                    return resourceClassSet;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<ZWGB_ResourceClass> GetResourcesClassList()
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var resourceClass = db.GetEntities<ZWGB_ResourceClass>(ZWGB_ResourceClassSet.SelectAll().Where(ZWGB_ResourceClassSet.RID.BiggerThanOrEqual(0)));
                    return resourceClass;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Adds the resources class.
        /// </summary>
        /// <param name="classifyName">Name of the classify.</param>
        /// <param name="classAlias">The class alias.</param>
        /// <param name="storageLocation">The storage location.</param>
        /// <param name="objectCount">The object count.</param>
        /// <param name="isAbsolutePath">if set to <c>true</c> [is absolute path].</param>
        /// <param name="isShare">if set to <c>true</c> [is share].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddResourcesClass(string classifyName, string classAlias, string storageLocation, int objectCount, bool isAbsolutePath, bool isShare)
        {
            ZWGB_ResourceClass newClass = new ZWGB_ResourceClass();
            newClass.ClassAlias = classAlias;
            newClass.ClassifyName = classifyName;
            newClass.IsAbsolutePath = isAbsolutePath;
            newClass.IsShare = isShare;
            newClass.ObjectCount = objectCount;
            newClass.StorageLocation = storageLocation;
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    db.Add(newClass);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the resources for class.
        /// </summary>
        /// <param name="resourceslassId">The resourceslass identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetResourcesForClass(long resourceslassId)
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var resourcesSet = db.GetDataSet(ZWGB_ResourceFilesSet.SelectAll().Where(ZWGB_ResourceFilesSet.ResourceClass.Equal(resourceslassId)));
                    if (resourcesSet != null && resourcesSet.Tables.Count > 0)
                    {
                        resourcesSet.Tables[0].TableName = "Table0";
                    }
                    return resourcesSet;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<ResourceFile> GetResourcesListForClass(long resourceslassId, List<ResourceFile> fileList)
        {
            if (fileList == null)
            {
                fileList = new List<ResourceFile>();
            }
            else
            {
                fileList.Clear();
            }
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var resourcesSet = db.GetEntities<ZWGB_ResourceFiles>(ZWGB_ResourceFilesSet.SelectAll().Where(ZWGB_ResourceFilesSet.ResourceClass.Equal(resourceslassId)));

                    if (resourcesSet != null && resourcesSet.Count > 0)
                    {
                        foreach (ZWGB_ResourceFiles entity in resourcesSet)
                        {
                            ResourceFile file = new ResourceFile();
                            file.Describe = entity.Describe;
                            file.DurationTime = entity.DurationTime;
                            file.FileName = entity.FileName;
                            file.FileType = entity.FileType;
                            file.ImportDate = entity.ImportDate;
                            file.IsExist = entity.IsExist;
                            file.IsUsed = entity.IsUsed;
                            file.ResourceClass = entity.ResourceClass;
                            file.RID = entity.RID;
                            file.UsedCount = entity.UsedCount;
                            file.IsSelected = false;
                            fileList.Add(file);
                        }
                    }
                    return fileList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<ResourceFileIdentity> GetResourcesFileIdentityForClass(long resourceslassId)
        {
            List<ResourceFileIdentity> fileName = new List<ResourceFileIdentity>();
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var list = db.GetDictionaryList(ZWGB_ResourceFilesSet.Select(ZWGB_ResourceFilesSet.RID, ZWGB_ResourceFilesSet.FileName, ZWGB_ResourceFilesSet.IsExist).Where(ZWGB_ResourceFilesSet.ResourceClass.Equal(resourceslassId)));
                    if (list.Count > 0)
                    {
                        foreach (var one in list)
                        {
                            if (!one["FileName"].IsNull() && !one["RID"].IsNull())
                            {
                                ResourceFileIdentity oneFile = new ResourceFileIdentity();
                                oneFile.FileName = one["FileName"].To<string>();
                                oneFile.RID = one["RID"].To<long>();
                                if (!one["IsExist"].IsNull())
                                {
                                    oneFile.IsExist = one["IsExist"].To<bool>();
                                }
                                fileName.Add(oneFile);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return fileName;
        }

        /// <summary>
        /// Gets the resource class.
        /// </summary>
        /// <param name="rid">The rid.</param>
        /// <returns>SAPInfoResourceClass.</returns>
        public ZWGB_ResourceClass GetResourceClass(long rid)
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var resourceClassEntity = db.GetEntity<ZWGB_ResourceClass>(ZWGB_ResourceClassSet.SelectAll().Where(ZWGB_ResourceClassSet.RID.Equal(rid)));
                    return resourceClassEntity;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Updates the resource class.
        /// </summary>
        /// <param name="newResourceClass">The new resource class.</param>
        public void UpdateResourceClass(ZWGB_ResourceClass newResourceClass)
        {


        }

        /// <summary>
        /// Adds the one object for resource class.
        /// </summary>
        /// <param name="rid">The rid.</param>
        public void AddOneObjectForResourceClass(long rid)
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var resourceClassEntity = db.GetEntity<ZWGB_ResourceClass>(ZWGB_ResourceClassSet.SelectAll().Where(ZWGB_ResourceClassSet.RID.Equal(rid)));
                    if (resourceClassEntity != null)
                    {
                        resourceClassEntity.ObjectCount++;
                        resourceClassEntity.WhereExpression = ZWGB_ResourceClassSet.RID.Equal(rid);
                        db.Update(resourceClassEntity);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Subtracts the one object for resource class.
        /// </summary>
        /// <param name="rid">The rid.</param>
        public void SubtractOneObjectForResourceClass(long rid)
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var resourceClassEntity = db.GetEntity<ZWGB_ResourceClass>(ZWGB_ResourceClassSet.SelectAll().Where(ZWGB_ResourceClassSet.RID.Equal(rid)));
                    if (resourceClassEntity != null)
                    {
                        resourceClassEntity.ObjectCount = resourceClassEntity.ObjectCount > 0 ? --resourceClassEntity.ObjectCount : 0;
                        resourceClassEntity.WhereExpression = ZWGB_ResourceClassSet.RID.Equal(rid);
                        db.Update(resourceClassEntity);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Changes the resource class.
        /// </summary>
        /// <param name="rid">The rid.</param>
        /// <param name="oldClassId">The old class identifier.</param>
        /// <param name="newClassId">The new class identifier.</param>
        public void ChangeResourceClass(long rid, long oldClassId, long newClassId)
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    db.TransactionEnabled = true;
                    ZWGB_ResourceFiles resourceFiles = new ZWGB_ResourceFiles();
                    resourceFiles.RID = rid;
                    resourceFiles.ResourceClass = newClassId;
                    resourceFiles.WhereExpression = ZWGB_ResourceFilesSet.RID.Equal(rid);
                    db.Update(resourceFiles);
                    addOneObjectForResourceClass(db, newClassId);
                    subtractOneObjectForResourceClass(db, oldClassId);
                    db.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Deletes the resource.
        /// </summary>
        /// <param name="rid">The rid.</param>
        /// <param name="classId">The class identifier.</param>
        public void DelTheResource(long rid, long classId)
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    db.TransactionEnabled = true;
                    int iReturn = db.Remove<ZWGB_ResourceFilesSet>(ZWGB_ResourceFilesSet.RID.Equal(rid));
                    if (iReturn > 0)
                    {
                        subtractOneObjectForResourceClass(db, classId);
                    }
                    db.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Determines whether [is the resource exist] [the specified name].
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="classId">The class identifier.</param>
        /// <returns><c>true</c> if [is the resource exist] [the specified name]; otherwise, <c>false</c>.</returns>
        public bool IsTheResourceExist(string name, long classId)
        {
            bool isExist = false;
            using (var db = new Moon.Orm.Sqlite(connectStr))
            {
                try
                {
                    WhereExpression whereE = ZWGB_ResourceFilesSet.FileName.Equal(name).And(ZWGB_ResourceFilesSet.ResourceClass.Equal(classId));
                    isExist = db.Exist<ZWGB_ResourceFilesSet>(whereE);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return isExist;
        }

        public void TheResourceFileIsNotExist(long fileID)
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    ZWGB_ResourceFiles theEntity = new ZWGB_ResourceFiles();
                    theEntity.RID = fileID;

                    theEntity.IsExist = false;
                    theEntity.WhereExpression = ZWGB_ResourceFilesSet.RID.Equal(fileID);//条件
                    db.Update(theEntity);
                    //   db.ExecuteSqlWithNonQuery
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
        }

        public void TheResourceFilesIsNotExist(List<ResourceFileIdentity> files)
        {
            using (var db = new Sqlite(connectStr))
            {
                db.TransactionEnabled = true;
                try
                {
                    if (files == null || files.Count < 1)
                    {
                        return;
                    }
                    foreach (ResourceFileIdentity one in files)
                    {
                        ZWGB_ResourceFiles theEntity = new ZWGB_ResourceFiles();
                        theEntity.RID = one.RID;

                        theEntity.IsExist = one.IsExist;
                        theEntity.WhereExpression = ZWGB_ResourceFilesSet.RID.Equal(one.RID);//条件
                        db.Update(theEntity);
                    }
                    db.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Adds the resource.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="durationTime">The duration time.</param>
        /// <param name="classId">The class identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddResource(string name, string fileType, string durationTime, long classId)
        {
            bool isSucceed = false;
            ZWGB_ResourceFiles newResource = new ZWGB_ResourceFiles();
            newResource.FileName = name;
            newResource.FileType = fileType;
            newResource.ImportDate = DateTime.Now;
            newResource.IsExist = true;
            newResource.IsUsed = false;
            newResource.DurationTime = durationTime;
            newResource.ResourceClass = classId;
            newResource.UsedCount = 0;
            using (var db = new Moon.Orm.Sqlite(connectStr))
            {
                try
                {
                    db.TransactionEnabled = true;
                    db.Add(newResource);
                    addOneObjectForResourceClass(db, classId);
                    db.Transaction.Commit();
                    isSucceed = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return isSucceed;
        }

        /// <summary>
        /// Checks the files is exist.
        /// 检查文件数组中文件是否存在
        /// </summary>
        /// <param name="inList">The in list.</param>
        /// <remarks>SAP_SchoolSystem</remarks>
        public void CheckFilesIsExist(List<PlayFileProject> inList)
        {
            for (int i = 0; i < inList.Count; i++)
            {
                if (!inList[i].IsAbsolutePath)
                {
                    inList[i].FilePathName = ApplicationStartPath + inList[i].FilePathName;
                }
                if (File.Exists(inList[i].FilePathName))
                {
                    inList[i].IsExist = true;
                }
                else
                {
                    inList[i].IsExist = false;
                }
            }
        }

        public void CheckFileIsExist(PlayFileProject fileProject)
        {
            fileProject.FilePathName = ApplicationStartPath + fileProject.FilePathName;
            if (File.Exists(fileProject.FilePathName))
            {
                fileProject.IsExist = true;
            }
            else
            {
                fileProject.IsExist = false;
            }
        }

        /// <summary>
        /// Thes the play files reference number minus one.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="projectID">The project identifier.</param>
        private void thePlayFilesReferenceNumberMinusOne(Sqlite db, long projectID)
        {
            if (db != null)
            {
                try
                {
                    var resourceEntity = db.GetEntity<ZWGB_ResourceFiles>(ZWGB_ResourceFilesSet.SelectAll().Where(ZWGB_ResourceFilesSet.RID.Equal(projectID)));
                    if (resourceEntity != null)
                    {
                        resourceEntity.UsedCount = resourceEntity.UsedCount > 0 ? --resourceEntity.UsedCount : 0;
                        resourceEntity.IsUsed = resourceEntity.UsedCount > 0 ? true : false;
                        resourceEntity.WhereExpression = ZWGB_ResourceFilesSet.RID.Equal(projectID);
                        db.Update(resourceEntity);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        /// <summary>
        /// Thes the play files reference number add one.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="projectID">The project identifier.</param>
        private void thePlayFilesReferenceNumberAddOne(Sqlite db, long projectID)
        {
            if (db != null)
            {
                try
                {
                    var resourceEntity = db.GetEntity<ZWGB_ResourceFiles>(ZWGB_ResourceFilesSet.SelectAll().Where(ZWGB_ResourceFilesSet.RID.Equal(projectID)));
                    if (resourceEntity != null)
                    {
                        resourceEntity.UsedCount++;
                        resourceEntity.IsUsed = resourceEntity.UsedCount > 0 ? true : false;
                        resourceEntity.WhereExpression = ZWGB_ResourceFilesSet.RID.Equal(projectID);
                        db.Update(resourceEntity);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        #endregion


        #region 设备管理


        public bool AddDeviceInfo(deviceInfo devInfo)
        {
            bool isSucceed = false;
            if (devInfo == null)
            { return isSucceed; }

            ZWGB_TerminalDev oneDev = new ZWGB_TerminalDev();
            oneDev.AliasName = devInfo.AliasName;
            oneDev.DefaultVolume = devInfo.DefaultVolume;
            oneDev.DNS = devInfo.DNS;
            oneDev.Gateway = devInfo.Gateway;
            oneDev.HardwareVersion = devInfo.HardwareVersion;
            oneDev.IPV4 = devInfo.IPV4;
            oneDev.IPV6 = devInfo.IPV6;
            oneDev.IsDHCP = devInfo.IsDHCP;
            oneDev.IsMulticastTo = false;
            oneDev.IsOnLine = false;
            oneDev.MAC = devInfo.MAC;
            oneDev.ModeStr = devInfo.ModeStr;
            oneDev.MonitorStatus = devInfo.MonitorStatus;
            oneDev.SN = devInfo.SN;
            oneDev.FirmwareVersion = devInfo.SoftwareVersion;
            oneDev.TaskStatus = devInfo.TaskStatus;
            oneDev.Type = devInfo.Type;
            oneDev.SubnetMask = devInfo.SubnetMask;
            oneDev.AreaID = devInfo.AreaID;
            oneDev.Channals = devInfo.Channals;
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    db.Add(oneDev);

                    isSucceed = true;
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);//
                    throw ex;
                }
            }
            return isSucceed;
        }

        public void UpdateDeviceInfo(ZWGB_TerminalDev theDev)
        {
            if (theDev == null || String.IsNullOrEmpty(theDev.SN))
            {
                return;
            }
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    theDev.WhereExpression = ZWGB_TerminalDevSet.SN.Equal(theDev.SN);//条件
                    db.Update(theDev);
                    //   db.ExecuteSqlWithNonQuery
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }

        }

        public void UpdateDeviceInfo(deviceInfo theDev)
        {
            if (theDev == null || String.IsNullOrEmpty(theDev.SN))
            {
                return;
            }
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    ZWGB_TerminalDev en = new ZWGB_TerminalDev();
                    en.SN = theDev.SN;
                    en.IPV4 = theDev.IPV4;
                    en.AliasName = theDev.AliasName;
                    en.IsDHCP = theDev.IsDHCP;
                    en.FirmwareVersion = theDev.SoftwareVersion;
                    en.AreaID = theDev.AreaID;

                    en.WhereExpression = ZWGB_TerminalDevSet.SN.Equal(theDev.SN);//条件
                    db.Update(en);
                    //   db.ExecuteSqlWithNonQuery
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }

        }

        public List<deviceInfo> LoadAllStoredDevices()
        {
            List<deviceInfo> devList = new List<deviceInfo>();
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var theEntities = db.GetEntities<ZWGB_TerminalDev>(ZWGB_TerminalDevSet.SelectAll().Where(ZWGB_TerminalDevSet.SN.NotEqual("")));
                    foreach (var one in theEntities)
                    {
                        devList.Add(ZWGB_TerminalDevToDevInfo(one));
                    }

                    return devList;
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
        }

        public void DelDeviceInfo(string sn)
        {
            if (String.IsNullOrEmpty(sn))
            {
                return;
            }
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    db.Remove<ZWGB_TerminalDevSet>(ZWGB_TerminalDevSet.SN.Equal(sn));
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }

        }



        #endregion 设备管理


        #region 区域管理

        public List<ZWGB_Area> LoadAllArea()
        {
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    var theEntities = db.GetEntities<ZWGB_Area>(ZWGB_AreaSet.SelectAll().Where(ZWGB_AreaSet.AreaID.BiggerThanOrEqual(0)));

                    return theEntities;
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
        }

        public void UpdateAreaInfo(ZWGB_Area theArea)
        {
            if (theArea == null || theArea.AreaID < 2)
            {
                return;
            }
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    theArea.WhereExpression = ZWGB_AreaSet.AreaID.Equal(theArea.AreaID);//条件
                    db.Update(theArea);
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
        }

        public bool AddAreaInfo(ZWGB_Area areaInfo)
        {
            bool isSucceed = false;
            if (areaInfo == null)
            { return isSucceed; }

            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    db.Add(areaInfo);
                    isSucceed = true;
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);//
                    throw ex;
                }
            }
            return isSucceed;
        }

        public bool DelTheAreaInfo(Int64 areaID)
        {
            if (areaID < 2)
            {
                return false;
            }
            using (var db = new Sqlite(connectStr))
            {
                try
                {
                    return db.Remove<ZWGB_AreaSet>(ZWGB_AreaSet.AreaID.Equal(areaID)) > 0;
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
        }

        #endregion 区域管理


        public deviceInfo ZWGB_TerminalDevToDevInfo(ZWGB_TerminalDev dbDev)
        {
            deviceInfo oneInfo = new deviceInfo();
            oneInfo.AliasName = dbDev.AliasName;
            oneInfo.DefaultVolume = dbDev.DefaultVolume;
            oneInfo.DNS = dbDev.DNS;
            oneInfo.Gateway = dbDev.Gateway;
            oneInfo.HardwareVersion = dbDev.HardwareVersion;
            oneInfo.IPV4 = dbDev.IPV4;
            oneInfo.IPV6 = dbDev.IPV6;
            oneInfo.IsDHCP = dbDev.IsDHCP;
            oneInfo.IsMulticastTo = dbDev.IsMulticastTo;
            oneInfo.IsOnLine = dbDev.IsOnLine;
            oneInfo.MAC = dbDev.MAC;
            oneInfo.ModeStr = dbDev.ModeStr;
            oneInfo.MonitorStatus = dbDev.MonitorStatus;
            oneInfo.SN = dbDev.SN;
            oneInfo.SoftwareVersion = dbDev.FirmwareVersion;
            oneInfo.TaskStatus = dbDev.TaskStatus;
            oneInfo.TerminalID = dbDev.TerminalID;
            oneInfo.Type = dbDev.Type;
            oneInfo.SubnetMask = dbDev.SubnetMask;
            oneInfo.AreaID = dbDev.AreaID;
            oneInfo.Channals = dbDev.Channals;
            return oneInfo;
        }

        public ZWGB_TerminalDev DevInfoToZWGB_TerminalDev(deviceInfo devInfo)
        {
            ZWGB_TerminalDev oneDev = new ZWGB_TerminalDev();
            oneDev.AliasName = devInfo.AliasName;
            oneDev.DefaultVolume = devInfo.DefaultVolume;
            oneDev.DNS = devInfo.DNS;
            oneDev.Gateway = devInfo.Gateway;
            oneDev.HardwareVersion = devInfo.HardwareVersion;
            oneDev.IPV4 = devInfo.IPV4;
            oneDev.IPV6 = devInfo.IPV6;
            oneDev.IsDHCP = devInfo.IsDHCP;
            oneDev.IsMulticastTo = devInfo.IsMulticastTo;
            oneDev.IsOnLine = devInfo.IsOnLine;
            oneDev.MAC = devInfo.MAC;
            oneDev.ModeStr = devInfo.ModeStr;
            oneDev.MonitorStatus = devInfo.MonitorStatus;
            oneDev.SN = devInfo.SN;
            oneDev.FirmwareVersion = devInfo.SoftwareVersion;
            oneDev.TaskStatus = devInfo.TaskStatus;
            oneDev.TerminalID = devInfo.TerminalID;
            oneDev.Type = devInfo.Type;
            oneDev.SubnetMask = devInfo.SubnetMask;
            oneDev.AreaID = devInfo.AreaID;
            oneDev.Channals = devInfo.Channals;
            return oneDev;
        }



    }

    public class ResourceFile
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 RID
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public String FileName
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public String FileType
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ImportDate
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 ResourceClass
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public String Describe
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsExist
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsUsed
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 UsedCount
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public String DurationTime
        {
            set;
            get;
        }

        public Boolean IsSelected
        {
            set;
            get;
        }
    }

    public struct ResourceFileIdentity
    {
        public long RID;
        public string FileName;
        public bool IsExist;
    }

    /// <summary>
    /// Struct PlayFileProject
    /// 文件播放项目数据结构
    /// </summary>
    /// <remarks>SAP_SchoolSystem</remarks>
    public class PlayFileProject
    {
        /// <summary>
        /// The task identifier
        /// </summary>
        public int TaskId
        {
            set;
            get;
        }
        //任务ID
        /// <summary>
        /// The index
        /// </summary>
        public int Index
        {
            set;
            get;
        }

        public int LoadPlayIndex
        {
            set;
            get;
        }
        //序号
        /// <summary>
        /// The project identifier
        /// </summary>
        public int ProjectId
        {
            set;
            get;
        }
        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            set;
            get;
        }//
        /// <summary>
        /// The file path name
        /// </summary>
        public string FilePathName
        {
            set;
            get;
        }//路径文件名
        /// <summary>
        /// The is absolute path
        /// </summary>
        public bool IsAbsolutePath
        {
            set;
            get;
        }//是否是绝对路径
        /// <summary>
        /// The is exist
        /// </summary>
        public bool IsExist
        {
            set;
            get;
        }//是否存在
        /// <summary>
        /// The file type
        /// </summary>
        public string FileType
        {
            set;
            get;
        }//
        /// <summary>
        /// The span seconds
        /// </summary>
        public int SpanSeconds
        {
            set;
            get;
        }//时长秒

        public string SpanTimeStr
        {
            set;
            get;
        }

        /// <summary>
        /// The start volume
        /// </summary>
        public int StartVolume
        {
            set;
            get;
        }//
        /// <summary>
        /// The end volume
        /// </summary>
        public int EndVolume
        {
            set;
            get;
        }//
        /// <summary>
        /// The play user identifier
        /// </summary>
        public int PlayUserId
        {
            set;
            get;
        }//听众Id
        /// <summary>
        /// The play user name
        /// </summary>
        public string PlayUserName
        {
            set;
            get;
        }//听众
        /// <summary>
        /// The image index
        /// </summary>
        public int ImageIndex
        {
            set;
            get;
        }
        /// <summary>
        /// The display color
        /// </summary>
        public int DisplayColor
        {
            set;
            get;
        }

        public bool IsSelected
        {
            set;
            get;
        }//是否存在

        public PlayFileProject()
        {

        }

    }

}
