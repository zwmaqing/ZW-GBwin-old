// ***********************************************************************
// Assembly         : SQLiteDataModel1
// Author           : zw_maqing
// Created          : 02-13-2015
//
// Last Modified By : zw_maqing
// Last Modified On : 04-06-2015
// ***********************************************************************
// <copyright file="DatabaseConfig.cs" company="ZhiweiTech">
//     Copyright (c) ZhiweiTech. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Moon.Orm;
using System.Threading;
using DataHelper;
using ZW_GBwin.Model;

/// <summary>
/// The SQLiteDbModel namespace.
/// </summary>
namespace ZW_GBwin
{
    /// <summary>
    /// Class DatabaseSQLiteConfig.
    /// </summary>
    public class DatabaseConfig
    {

        #region 基础字段

        /// <summary>
        /// The application start path
        /// </summary>
        private string appStartPath;

        /// <summary>
        /// The data database connect string
        /// </summary>
        private string dataDbConnectStr = "";//.

        /// <summary>
        /// The system database connect password
        /// </summary>
        private const string sysDbConnectPassword = "4EDA73E1A871F58B";//ConnectPassword.

        /// <summary>
        /// The system database connect string
        /// </summary>
        private string sysDbConnectStr = "";//.

        AutoResetEvent waitHandler = new AutoResetEvent(false);//false 即非终止，未触发。


        # endregion 基础字段

        # region 基础属性

        /// <summary>
        /// Gets the data database version string.
        /// </summary>
        /// <value>The data database version string.</value>
        public string DataDbVersionStr
        {
            get
            {
                return getDataDbCurrentVersionStr();
            }
        }

        /// <summary>
        /// Gets the data database version number.
        /// </summary>
        /// <value>The data database version number.</value>
        public Double DataDbVersionNumber
        {
            get
            {
                return getDataDbCurrentVersion();
            }
        }

        /// <summary>
        /// Gets the system database version string.
        /// </summary>
        /// <value>The system database version string.</value>
        public string SysDbVersionStr
        {
            get
            {
                return getConfigDbCurrentVersionStr();
            }
        }

        /// <summary>
        /// Gets the system database version number.
        /// </summary>
        /// <value>The system database version number.</value>
        public Double SysDbVersionNumber
        {
            get
            {
                return getConfigDbCurrentVersion();
            }
        }


        # endregion 基础属性

        # region 基础私有方法

        /// <summary>
        /// Gets the data database data source.
        /// </summary>
        /// <returns>System.String.</returns>
        private string getDataDbDataSource()
        {
            string returnStr = "";
            try
            {
                // returnStr = EncryptAndDecrypt.DESDecrypt(dataDbDataSource, "%D*E4@m,");
                returnStr = appStartPath + @"\Data\" + "SAPSCHOOLDB2.db";
            }
            catch (Exception ex)
            {
                Moon.Orm.Util.LogUtil.Exception(ex);
            }
            return returnStr;
        }

        /// <summary>
        /// Gets the system database data source.
        /// </summary>
        /// <returns>System.String.</returns>
        private string getSysDbDataSource()
        {
            string returnStr = "";
            try
            {
                //returnStr = EncryptAndDecrypt.DESDecrypt(sysDbDataSource, "#Z/n4@x;");
                returnStr = appStartPath + @"\Data\" + "SAPSCHOOLCONFIG.db";
            }
            catch (Exception ex)
            {
                Moon.Orm.Util.LogUtil.Exception(ex);
            }
            return returnStr;
        }

        /// <summary>
        /// Gets the system database data pass.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string getSysDbDataPass()
        {
            string returnStr = "";
            try
            {
                returnStr = EncryptAndDecrypt.DESDecrypt(sysDbConnectPassword, "#Z/n4@x;");
            }
            catch (Exception ex)
            {
                Moon.Orm.Util.LogUtil.Exception(ex);
            }
            return returnStr;
        }

        /// <summary>
        /// Gets the data database current version.
        /// </summary>
        /// <returns>Double.</returns>
        private Double getDataDbCurrentVersion()
        {
            Double version = 0;
            using (var db = new Sqlite(dataDbConnectStr))
            {
                try
                {
                    db.DebugEnabled = true;
                    //DBSDbUpdateRecord
                    var list = db.GetDictionaryList(ZWGB_DbUpdateRecordSet.Select(ZWGB_DbUpdateRecordSet.VersionNumber).Where(ZWGB_DbUpdateRecordSet.IsSuccessful.Equal(true)).Top(1).OrderByDESC(ZWGB_DbUpdateRecordSet.VersionNumber));
                    if (list.Count > 0 && !list[0]["VersionNumber"].IsNull())
                    {
                        version = list[0]["VersionNumber"].To<Double>();
                    }
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
            return version;
        }

        /// <summary>
        /// Gets the data database current version string.
        /// </summary>
        /// <returns>System.String.</returns>
        private string getDataDbCurrentVersionStr()
        {
            string version = "";
            using (var db = new Sqlite(dataDbConnectStr))
            {
                try
                {
                    db.DebugEnabled = true;
                    var list = db.GetDictionaryList(ZWGB_DbUpdateRecordSet.Select(ZWGB_DbUpdateRecordSet.VersionStr).Where(ZWGB_DbUpdateRecordSet.IsSuccessful.Equal(true)).Top(1).OrderByDESC(ZWGB_DbUpdateRecordSet.VersionNumber));
                    if (list.Count > 0 && !list[0]["VersionStr"].IsNull())
                    {
                        version = list[0]["VersionStr"].To<string>();
                    }
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
            return version;
        }

        /// <summary>
        /// Gets the configuration database current version.
        /// </summary>
        /// <returns>Double.</returns>
        private Double getConfigDbCurrentVersion()
        {
            Double version = 0;
            using (var db = new Sqlite(sysDbConnectStr))
            {
                try
                {
                    db.DebugEnabled = true;
                    var list = db.GetDictionaryList(ZWGB_DbUpdateRecordSet.Select(ZWGB_DbUpdateRecordSet.VersionNumber).Where(ZWGB_DbUpdateRecordSet.IsSuccessful.Equal(true)).Top(1).OrderByDESC(ZWGB_DbUpdateRecordSet.VersionNumber));
                    if (list.Count > 0 && !list[0]["VersionNumber"].IsNull())
                    {
                        version = list[0]["VersionNumber"].To<Double>();
                    }
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
            return version;
        }

        /// <summary>
        /// Gets the configuration database current version string.
        /// </summary>
        /// <returns>System.String.</returns>
        private string getConfigDbCurrentVersionStr()
        {
            string version = "";
            using (var db = new Sqlite(sysDbConnectStr))
            {
                try
                {
                    db.DebugEnabled = true;
                    var list = db.GetDictionaryList(ZWGB_DbUpdateRecordSet.Select(ZWGB_DbUpdateRecordSet.VersionStr).Where(ZWGB_DbUpdateRecordSet.IsSuccessful.Equal(true)).Top(1).OrderByDESC(ZWGB_DbUpdateRecordSet.VersionNumber));
                    if (list.Count > 0 && !list[0]["VersionStr"].IsNull())
                    {
                        version = list[0]["VersionStr"].To<string>();
                    }
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                    throw ex;
                }
            }
            return version;
        }

        # endregion 基础私有方法

        # region 公开方法

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConfig"/> class.
        /// </summary>
        /// <param name="startPath">The start path.</param>
        public DatabaseConfig(string startPath)
        {
            appStartPath = startPath;
            dataDbConnectStr = "";
            sysDbConnectStr = "";
        }

        /// <summary>
        /// Checks the data database available.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckDataDbAvailable()
        {
            return true;
        }

        /// <summary>
        /// Checks the data database object complete.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckDataDbObjectComplete()
        {
            return true;
        }

        /// <summary>
        /// Connects to sq lite test.
        /// </summary>
        /// <param name="dataDataPath">The data data path.</param>
        /// <param name="password">The password.</param>
        /// <returns>OpenSQLiteResult.</returns>
        public static OpenSQLiteResult ConnectToSQLiteTest(string dataDataPath, string password)
        {
            OpenSQLiteResult result = OpenSQLiteResult.Unknown;
            SQLiteConnectionStringBuilder connStr = new SQLiteConnectionStringBuilder();
            connStr.DataSource = dataDataPath;
            connStr.Password = password;
            using (var db = new Sqlite(connStr.ConnectionString))
            {
                try
                {
                    string sql = "select tbl_name from sqlite_master where rootpage > @";
                    List<Dictionary<string, MObject>> mylist = db.ExecuteSqlToDictionaryList(sql, 1);
                    if (mylist.Count > 0)
                    {
                        result = OpenSQLiteResult.Ok;
                    }
                    else
                    {
                        result = OpenSQLiteResult.NotDbOrNull;
                    }
                    //Db is Null,or Not SQLiter Db
                    db.Connection.Close();
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    if (ex.ErrorCode == 26)
                    {
                        result = OpenSQLiteResult.PassErr;
                    }
                    if (ex.ErrorCode == 14 || ex.ErrorCode == 16)
                    {
                        result = OpenSQLiteResult.NotFind;
                    }
                }
            }
            return result;
        }

        public static void BackupDataDbFile(string fromPathName, string toPathName)
        {
            if (DiskDirFileIo.IsExistFile(fromPathName))
            {
                try
                {
                    string toPath = System.IO.Path.GetDirectoryName(toPathName);
                    if (!DiskDirFileIo.IsExistDirectory(toPath))
                    {
                        DiskDirFileIo.CreateDir(toPath);
                    }
                    DiskDirFileIo.CopyFile(fromPathName, toPathName);
                }
                catch (Exception ex)
                {
                    Moon.Orm.Util.LogUtil.Exception(ex);
                }
            }
        }

        /// <summary>
        /// Backups the data database complete.
        /// </summary>
        /// <param name="toPathName">Name of to path.</param>
        public void BackupDataDbComplete(string toPathName)
        {

        }

        /// <summary>
        /// Backups the data database incremental.
        /// </summary>
        /// <param name="toPathName">Name of to path.</param>
        public void BackupDataDbIncremental(string toPathName)
        { }

        /// <summary>
        /// Backups the data database complete.
        /// </summary>
        /// <param name="toPathName">Name of to path.</param>
        /// <param name="callbackMethod">The callback method.</param>
        public void BackupDataDbComplete(string toPathName, BackupDbCallback callbackMethod)
        { }

        /// <summary>
        /// Backups the data database incremental.
        /// </summary>
        /// <param name="toPathName">Name of to path.</param>
        /// <param name="callbackMethod">The callback method.</param>
        public void BackupDataDbIncremental(string toPathName, BackupDbCallback callbackMethod)
        { }

        # endregion 公开方法
    }

    /// <summary>
    /// Delegate Backup Db Callback
    /// 数据库播放完成回调函数
    /// </summary>
    /// <param name="isSuccessful">if set to <c>true</c> [is successful].</param>
    /// <remarks>SAP_SchoolSystem</remarks>
    public delegate void BackupDbCallback(bool isSuccessful);

    /// <summary>
    /// Enum OpenSQLiteResult
    /// </summary>
    public enum OpenSQLiteResult
    {
        /// <summary>
        /// The unknown
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// The ok
        /// </summary>
        Ok = 1,
        /// <summary>
        /// The not database or null
        /// </summary>
        NotDbOrNull = 2,
        /// <summary>
        /// The not find
        /// </summary>
        NotFind = 3,
        /// <summary>
        /// The locked
        /// </summary>
        Locked = 4,
        /// <summary>
        /// The pass error
        /// </summary>
        PassErr = 5
    }
}