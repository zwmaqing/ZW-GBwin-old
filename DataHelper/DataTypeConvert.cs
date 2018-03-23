using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace DataHelper
{
    public class DataTypeConvert
    {
        /// <summary>
        /// Determines whether [is even this int] [the specified the int].
        /// 偶数判定
        /// </summary>
        /// <param name="theInt">The int.</param>
        /// <returns><c>true</c> if [is even this int] [the specified the int]; otherwise, <c>false</c>.</returns>
        public static bool IsEvenThisInt(int theInt)
        {
            if (theInt % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 时间类型转换

        public static DateTime DateTimeStrToDataTime(string timeStr)
        {
            DateTime theDate = DateTime.Now;
            if (!String.IsNullOrEmpty(timeStr))
            {
                try
                {
                    theDate = DateTime.Parse(timeStr);
                }
                catch
                {
                    theDate = DateTime.Now;
                }
            }
            return theDate;
        }

        /// <summary>
        /// Times the STR to data time.
        /// </summary>
        /// <param name="timeStr">The time STR.</param>
        /// <param name="years">The years.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns>DateTime.</returns>
        public static DateTime TimeStrToDataTime(string timeStr, int years = 2000, int month = 01, int day = 01)
        {
            try
            {
                int hours;
                int minutes;
                int seconds;
                if (timeStr.Length == 7)
                {
                    hours = Convert.ToInt32(timeStr.Substring(0, 1));
                    minutes = Convert.ToInt32(timeStr.Substring(2, 2));
                    seconds = Convert.ToInt32(timeStr.Substring(5, 2));
                }
                else
                {
                    hours = Convert.ToInt32(timeStr.Substring(0, 2));
                    minutes = Convert.ToInt32(timeStr.Substring(3, 2));
                    seconds = Convert.ToInt32(timeStr.Substring(6, 2));
                }
                var dateTimebuff = new DateTime(years, month, day, hours, minutes, seconds);
                return dateTimebuff;
            }
            catch (Exception)
            {
                return new DateTime(years, month, day, 23, 0, 0);
            }
        }

        /// <summary>
        /// Times the string to seconds.
        /// </summary>
        /// <param name="timeStr">The time string.</param>
        /// <returns>System.Int32.</returns>
        public static int TimeStrToSeconds(string timeStr)
        {
            DateTime toDateTime;
            try
            {
                toDateTime = TimeStrToDataTime(timeStr);
            }
            catch (Exception)
            {
                toDateTime = TimeStrToDataTime("0:0:0");
            }
            int secondsInt = toDateTime.Hour * 3600 + toDateTime.Minute * 60 + toDateTime.Second;
            return secondsInt;
        }

        /// <summary>
        /// Dates the time to time STR.
        /// </summary>
        /// <param name="dateTimeIn">The date time in.</param>
        /// <returns>System.String.</returns>
        public static string DateTimeToTimeStr(DateTime dateTimeIn)
        {
            string timeStr = "";
            if (dateTimeIn.Hour < 10)
            {
                timeStr = "0" + dateTimeIn.Hour.ToString() + ":";
            }
            else
            {
                timeStr = dateTimeIn.Hour.ToString() + ":";
            }
            if (dateTimeIn.Minute < 10)
            {
                timeStr = timeStr + "0" + dateTimeIn.Minute.ToString() + ":";
            }
            else
            {
                timeStr = timeStr + dateTimeIn.Minute.ToString() + ":";
            }
            if (dateTimeIn.Second < 10)
            {
                timeStr = timeStr + "0" + dateTimeIn.Second.ToString();
            }
            else
            {
                timeStr = timeStr + dateTimeIn.Second.ToString();
            }
            return timeStr;
        }

        public static string SecondsDoubleToTimeStr(double secondsInput)
        {
            int hours = Convert.ToInt32(Math.Floor(secondsInput / 3600));
            int minutes = Convert.ToInt32(Math.Floor((secondsInput - hours * 3600) / 60));
            int seconds = Convert.ToInt32(Math.Floor((secondsInput - hours * 3600 - minutes * 60)));
            string hoursStr = hours > 10 ? hours.ToString() : "0" + hours.ToString();
            string minutesStr = minutes > 10 ? minutes.ToString() : "0" + minutes.ToString();
            string secondsStr = seconds > 10 ? seconds.ToString() : "0" + seconds.ToString();
            string timeStr = hoursStr + ":" + minutesStr + ":" + secondsStr;
            return timeStr;
        }

        public static string SecondsDoubleToTimeStr(decimal secondsInput)
        {
            int hours = Convert.ToInt32(Math.Floor(secondsInput / 3600));
            int minutes = Convert.ToInt32(Math.Floor((secondsInput - hours * 3600) / 60));
            int seconds = Convert.ToInt32(Math.Floor((secondsInput - hours * 3600 - minutes * 60)));
            string hoursStr = hours > 10 ? hours.ToString() : "0" + hours.ToString();
            string minutesStr = minutes > 10 ? minutes.ToString() : "0" + minutes.ToString();
            string secondsStr = seconds > 10 ? seconds.ToString() : "0" + seconds.ToString();
            string timeStr = hoursStr + ":" + minutesStr + ":" + secondsStr;
            return timeStr;
        }

        public static DateTime MinuteToDateTime(int minute)
        {
            DateTime newDateTime = new DateTime(2000, 1, 1);
            newDateTime = newDateTime.AddMinutes(minute);
            return newDateTime;
        }

        public static Int32 DateTimeToMinuteInt32(DateTime dateTimeIn)
        {
            DateTime startTime = new DateTime(2000, 1, 1);
            DateTime endTime = DateTimeUnityDate(dateTimeIn);

            return Convert.ToInt32((endTime - startTime).TotalMinutes);
        }

        public static DateTime DateTimeUnityDate(DateTime dateTimeIn, int years = 2000, int month = 01, int day = 01)
        {
            DateTime newDateTime = new DateTime(years, month, day);
            newDateTime = newDateTime.AddHours(dateTimeIn.Hour);
            newDateTime = newDateTime.AddMinutes(dateTimeIn.Minute);
            newDateTime = newDateTime.AddSeconds(dateTimeIn.Second);
            return newDateTime;
        }

        public static DateTime DateTimeUnityTime(DateTime dateTimeIn)
        {
            return dateTimeIn.Date;
        }

        public static DateTime TimeIntUnityDateTime(int Hour, int Minute, int Second)
        {
            DateTime newDateTime = new DateTime(2000, 1, 1);
            newDateTime = newDateTime.AddHours(Hour);
            newDateTime = newDateTime.AddMinutes(Minute);
            newDateTime = newDateTime.AddSeconds(Second);
            return newDateTime;
        }

        public static DateTime TimeIntUnityDateTime(double seconds)
        {
            DateTime newDateTime = new DateTime(2000, 1, 1);
            newDateTime = newDateTime.AddSeconds(seconds);
            return newDateTime;
        }

        public static string DateTimeToWeekCNStr(DayOfWeek weekIn)
        {
            switch (weekIn)
            {
                case DayOfWeek.Sunday:
                    {
                        return "星期日";
                    }
                case DayOfWeek.Monday:
                    {
                        return "星期一";
                    }
                case DayOfWeek.Tuesday:
                    {
                        return "星期二";
                    }
                case DayOfWeek.Wednesday:
                    {
                        return "星期三";
                    }
                case DayOfWeek.Thursday:
                    {
                        return "星期四";
                    }
                case DayOfWeek.Friday:
                    {
                        return "星期五";
                    }
                case DayOfWeek.Saturday:
                    {
                        return "星期六";
                    }
                default:
                    {
                        return "日期错误";
                    }
            }
        }

        public static int DateTimeToWeekInt(DayOfWeek weekIn)
        {
            switch (weekIn)
            {
                case DayOfWeek.Sunday:
                    {
                        return 7;
                    }
                case DayOfWeek.Monday:
                    {
                        return 1;
                    }
                case DayOfWeek.Tuesday:
                    {
                        return 2;
                    }
                case DayOfWeek.Wednesday:
                    {
                        return 3;
                    }
                case DayOfWeek.Thursday:
                    {
                        return 4;
                    }
                case DayOfWeek.Friday:
                    {
                        return 5;
                    }
                case DayOfWeek.Saturday:
                    {
                        return 6;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        public static string IntToWeekCNStr(int weekInt)
        {
            switch (weekInt)
            {
                case 7:
                    {
                        return "星期日";
                    }
                case 1:
                    {
                        return "星期一";
                    }
                case 2:
                    {
                        return "星期二";
                    }
                case 3:
                    {
                        return "星期三";
                    }
                case 4:
                    {
                        return "星期四";
                    }
                case 5:
                    {
                        return "星期五";
                    }
                case 6:
                    {
                        return "星期六";
                    }
                default:
                    {
                        return "日期错误";
                    }
            }
        }

        public static DayOfWeek IntToDayOfWeek(int weekInt)
        {
            switch (weekInt)
            {
                case 7:
                    {
                        return DayOfWeek.Sunday;
                    }
                case 1:
                    {
                        return DayOfWeek.Monday;
                    }
                case 2:
                    {
                        return DayOfWeek.Tuesday;
                    }
                case 3:
                    {
                        return DayOfWeek.Wednesday;
                    }
                case 4:
                    {
                        return DayOfWeek.Thursday;
                    }
                case 5:
                    {
                        return DayOfWeek.Friday;
                    }
                case 6:
                    {
                        return DayOfWeek.Saturday;
                    }
                default:
                    {
                      throw(new System.InvalidCastException());
                    }
            }
        }

        public static double GetDateTimeSecondCount(DateTime time)
        {
            double count = 0;
            count += time.Hour * 60 * 60;
            count += time.Minute * 60;
            count += time.Second;
            return count;
        }

        public static UInt32 DateTimeToUInt32(DateTime dateTimeIn)
        {
            DateTime startTime = new DateTime(2000, 1, 1);
            return Convert.ToUInt32((dateTimeIn - startTime).TotalSeconds);
        }

        public static byte[] DateTimeToByte(DateTime dateTimeIn)
        {
            UInt32 intTime = DateTimeToUInt32(dateTimeIn);
            return BitConverter.GetBytes(intTime);
        }

        public static DateTime UInt32ToDateTime(UInt32 timeUInt32)
        {
            DateTime startTime = new DateTime(2000, 1, 1);
            DateTime newTime = startTime.AddSeconds(timeUInt32);
            return newTime;
        }

        public static DateTime ByteToDateTime(byte[] timeByte)
        {
            UInt32 seconds = BitConverter.ToUInt32(timeByte, 0);
            return UInt32ToDateTime(seconds);
        }



        //C# 获取农历日期

        #region 获取农历日期 private

        //ChineseCalendar
        ///<summary>
        /// 实例化一个 ChineseLunisolarCalendar
        ///</summary>
        private static ChineseLunisolarCalendar ChineseCalendar = new ChineseLunisolarCalendar();

        ///<summary>
        /// 十天干
        ///</summary>
        private static string[] tg = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };

        ///<summary>
        /// 十二地支
        ///</summary>
        private static string[] dz = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

        ///<summary>
        /// 十二生肖
        ///</summary>
        private static string[] sx = { "鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };

        ///<summary>
        /// 返回农历天干地支年
        ///</summary>
        ///<param name="year">农历年</param>
        ///<return s></return s>
        public static string GetChineseCalendarYear(int year)
        {
            if (year > 3)
            {
                int tgIndex = (year - 4) % 10;
                int dzIndex = (year - 4) % 12;

                return string.Concat(tg[tgIndex], dz[dzIndex], "[", sx[dzIndex], "]");
            }

            throw new ArgumentOutOfRangeException("无效的年份!");
        }

        ///<summary>
        /// 农历月
        ///</summary>
        ///<return s></return s>
        private static string[] months = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二(腊)" };

        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days1 = { "初", "十", "廿", "三" };
        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

        #endregion 获取农历日期 private

        ///<summary>
        /// 返回农历月
        ///</summary>
        ///<param name="month">月份</param>
        ///<return s></return s>
        public static string GetChineseCalendarMonth(int month)
        {
            if (month < 13 && month > 0)
            {
                return months[month - 1];
            }

            throw new ArgumentOutOfRangeException("无效的月份!");
        }

        ///<summary>
        /// 返回农历日
        ///</summary>
        ///<param name="day">天</param>
        ///<return s></return s>
        public static string GetChineseCalendarDay(int day)
        {
            if (day > 0 && day < 32)
            {
                if (day != 20 && day != 30)
                {
                    return string.Concat(days1[(day - 1) / 10], days[(day - 1) % 10]);
                }
                else
                {
                    return string.Concat(days[(day - 1) / 10], days1[1]);
                }
            }

            throw new ArgumentOutOfRangeException("无效的日!");
        }

        ///<summary>
        /// 根据公历获取农历日期
        ///</summary>
        ///<param name="dateTime">公历日期</param>
        ///<return s></return s>
        public static string GetChineseDateTime(DateTime dateTime)
        {
            int year = ChineseCalendar.GetYear(dateTime);
            int month = ChineseCalendar.GetMonth(dateTime);
            int day = ChineseCalendar.GetDayOfMonth(dateTime);
            //获取闰月， 0 则表示没有闰月
            int leapMonth = ChineseCalendar.GetLeapMonth(year);

            bool isLeap = false;

            if (leapMonth > 0)
            {
                if (leapMonth == month)
                {
                    //闰月
                    isLeap = true;
                    month--;
                }
                else if (month > leapMonth)
                {
                    month--;
                }
            }

            return string.Concat(GetChineseCalendarYear(year), "年", isLeap ? "闰" : string.Empty, GetChineseCalendarMonth(month), "月", GetChineseCalendarDay(day));
        }

        #endregion 时间类型转换

        #region 基础数据类型转换

        /// <summary>
        /// Gets the object int64.
        /// DataTypeConvert.GetTheObjectInt64()
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.Int64.</returns>
        public static long GetTheObjectInt64(Object input)
        {
            try
            {
                return Convert.ToInt64(input);
            }
            catch
            {
                return -1;
            }
        }

        public static int GetTheObjectInt32(Object input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                return -1;
            }
        }

        public static UInt32 GetTheObjectUInt32(Object input)
        {
            try
            {
                return Convert.ToUInt32(input);
            }
            catch
            {
                return 0;
            }
        }

        public static Byte GetIntToByte(int input)
        {
            try
            {
                byte[] by = BitConverter.GetBytes(input);
                return by[0];
            }
            catch
            {
                return 0;
            }
        }

        public static string GetTheObjectString(Object input)
        {
            try
            {
                return Convert.ToString(input);
            }
            catch
            {
                return null;
            }
        }

        public static Boolean GetTheObjectBoolean(Object input)
        {
            try
            {
                return Convert.ToBoolean(input);
            }
            catch
            {
                return false;
            }
        }

        public static Double GetTheObjectDouble(Object input)
        {
            try
            {
                return Convert.ToDouble(input);
            }
            catch
            {
                return 0;
            }
        }


        #endregion 基础数据类型转换

        #region 字符编码转换

        public static byte[] StringToGbkByte(string inString)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(inString);
            return array;
        }
        public static string GbkByteToString(byte[] inGbk)
        {
            string s = System.Text.Encoding.Default.GetString(inGbk, 0, inGbk.Length);
            return s;
        }

        public static Byte[] StringToByte(string inputString)
        {
            string inputStr = inputString.Trim();
            string[] Split = inputStr.Split(new Char[] { ' ', ',', '.', ':', '\t' });
            Byte[] returnByte;
            if (Split.Length > 0)
            {
                returnByte = new Byte[Split.Length];
                int i = 0;
                foreach (string s in Split)
                {
                    returnByte[i] = ConvertStringByte(s);
                    i++;
                }
            }
            else
            {
                returnByte = null;
            }
            return returnByte;
        }
        private static byte ConvertStringByte(string stringVal)
        {
            byte byteVal = 0;

            try
            {
                byteVal = System.Convert.ToByte(stringVal, 16);
            }
            catch (System.OverflowException ex)
            {
                throw ex;
            }
            catch (System.FormatException ex)
            {
                throw ex;
            }
            catch (System.ArgumentNullException ex)
            {
                throw ex;
            }
            return byteVal;
        }

        public static string BytesToHexString(Byte[] inBytes)
        {
            StringBuilder strGuff = new StringBuilder();
            foreach (Byte s in inBytes)
            {
                strGuff.Append(s.ToString("X") + " ");
            }
            return strGuff.ToString();
        }

        /**/
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>        
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /**/
        /// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }


        #endregion 字符编码转换

        #region 系统消息类型转换                  ******************

        /// <summary>
        /// Gets the color of the message notice.
        /// 根据消息等级设置显示颜色
        /// </summary>
        /// <param name="level">The level.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        public static int GetMessageNoticeColor(int level)
        {
            /* 
 * DisplayColor：
 * -65536     Level 0
 * -48574     Level 1
 * -34439     Level 2
 * -32768     Level 3
 * -20382     Level 4
 * -11868     Level 5
 * -256       Level 6
 * -120       Level 7
 * -16776961  Level 8
 * -16711872  Level 9
 * -1         Level 10
 * */
            switch (level)
            {
                case 0:
                    {
                        return -65536;
                    }
                case 1:
                    {
                        return -48574;
                    }
                case 2:
                    {
                        return -34439;
                    }
                case 3:
                    {
                        return -32768;
                    }
                case 4:
                    {
                        return -20382;
                    }
                case 5:
                    {
                        return -11868;
                    }
                case 6:
                    {
                        return -256;
                    }
                case 7:
                    {
                        return -120;
                    }
                case 8:
                    {
                        return -16776961;
                    }
                case 9:
                    {
                        return -16711872;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }

        #endregion 系统消息类型转换               ******************

        #region 金额数字转换为大写

        /// <summary>
        /// 转换人民币大小金额
        /// </summary>
        /// <param name="num">金额</param>
        /// <returns>返回大写形式</returns>
        public static string numbersMoneyToCapital(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字
            string str3 = "";    //从原num值中取出的值
            string str4 = "";    //数字的字符串形式
            string str5 = "";  //人民币大写金额形式
            int i;    //循环变量
            int j;    //num的值乘以100的字符串长度
            string ch1 = "";    //数字的汉语读法
            string ch2 = "";    //数字位的汉字读法
            int nzero = 0;  //用来计算连续的零值是几个
            int temp;            //从原num值中取出的值

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式
            j = str4.Length;      //找出最高位
            if (j > 15)
            {
                return "溢出";
            }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分
            //循环取出每一位需要转换的值
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值
                temp = Convert.ToInt32(str3);      //转换为数字
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;
                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

        /// <summary>
        /// 一个重载，将字符串先转换成数字在调用CmycurD(decimal num)
        /// </summary>
        /// <param name="num">用户输入的金额，字符串形式未转成decimal</param>
        /// <returns></returns>
        public static string stringMoneyToCapital(string numstr)
        {
            try
            {
                decimal num = Convert.ToDecimal(numstr);
                return numbersMoneyToCapital(num);
            }
            catch
            {
                return "非数字形式！";
            }
        }

        #endregion 金额数字转换为大写



    }

    /// <summary>
    /// 汉字转拼音类
    /// </summary>
    public class EcanConvertToCh
    {
        //定义拼音区编码数组
        private static int[] getValue = new int[]
            {
                -20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,
                -20032,-20026,-20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,
                -19756,-19751,-19746,-19741,-19739,-19728,-19725,-19715,-19540,-19531,-19525,-19515,
                -19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,-19261,-19249,
                -19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,
                -19003,-18996,-18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,
                -18731,-18722,-18710,-18697,-18696,-18526,-18518,-18501,-18490,-18478,-18463,-18448,
                -18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183, -18181,-18012,
                -17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,
                -17733,-17730,-17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,
                -17468,-17454,-17433,-17427,-17417,-17202,-17185,-16983,-16970,-16942,-16915,-16733,
                -16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,-16452,-16448,
                -16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,
                -16212,-16205,-16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,
                -15933,-15920,-15915,-15903,-15889,-15878,-15707,-15701,-15681,-15667,-15661,-15659,
                -15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,-15408,-15394,
                -15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,
                -15149,-15144,-15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,
                -14941,-14937,-14933,-14930,-14929,-14928,-14926,-14922,-14921,-14914,-14908,-14902,
                -14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,-14663,-14654,
                -14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,
                -14170,-14159,-14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,
                -14109,-14099,-14097,-14094,-14092,-14090,-14087,-14083,-13917,-13914,-13910,-13907,
                -13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,-13611,-13601,
                -13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,
                -13340,-13329,-13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,
                -13068,-13063,-13060,-12888,-12875,-12871,-12860,-12858,-12852,-12849,-12838,-12831,
                -12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,-12320,-12300,
                -12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,
                -11781,-11604,-11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,
                -11055,-11052,-11045,-11041,-11038,-11024,-11020,-11019,-11018,-11014,-10838,-10832,
                -10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,-10329,-10328,
                -10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254
            };

        //定义拼音数组
        private static string[] getName = new string[]
            {
                "A","Ai","An","Ang","Ao","Ba","Bai","Ban","Bang","Bao","Bei","Ben",
                "Beng","Bi","Bian","Biao","Bie","Bin","Bing","Bo","Bu","Ba","Cai","Can",
                "Cang","Cao","Ce","Ceng","Cha","Chai","Chan","Chang","Chao","Che","Chen","Cheng",
                "Chi","Chong","Chou","Chu","Chuai","Chuan","Chuang","Chui","Chun","Chuo","Ci","Cong",
                "Cou","Cu","Cuan","Cui","Cun","Cuo","Da","Dai","Dan","Dang","Dao","De",
                "Deng","Di","Dian","Diao","Die","Ding","Diu","Dong","Dou","Du","Duan","Dui",
                "Dun","Duo","E","En","Er","Fa","Fan","Fang","Fei","Fen","Feng","Fo",
                "Fou","Fu","Ga","Gai","Gan","Gang","Gao","Ge","Gei","Gen","Geng","Gong",
                "Gou","Gu","Gua","Guai","Guan","Guang","Gui","Gun","Guo","Ha","Hai","Han",
                "Hang","Hao","He","Hei","Hen","Heng","Hong","Hou","Hu","Hua","Huai","Huan",
                "Huang","Hui","Hun","Huo","Ji","Jia","Jian","Jiang","Jiao","Jie","Jin","Jing",
                "Jiong","Jiu","Ju","Juan","Jue","Jun","Ka","Kai","Kan","Kang","Kao","Ke",
                "Ken","Keng","Kong","Kou","Ku","Kua","Kuai","Kuan","Kuang","Kui","Kun","Kuo",
                "La","Lai","Lan","Lang","Lao","Le","Lei","Leng","Li","Lia","Lian","Liang",
                "Liao","Lie","Lin","Ling","Liu","Long","Lou","Lu","Lv","Luan","Lue","Lun",
                "Luo","Ma","Mai","Man","Mang","Mao","Me","Mei","Men","Meng","Mi","Mian",
                "Miao","Mie","Min","Ming","Miu","Mo","Mou","Mu","Na","Nai","Nan","Nang",
                "Nao","Ne","Nei","Nen","Neng","Ni","Nian","Niang","Niao","Nie","Nin","Ning",
                "Niu","Nong","Nu","Nv","Nuan","Nue","Nuo","O","Ou","Pa","Pai","Pan",
                "Pang","Pao","Pei","Pen","Peng","Pi","Pian","Piao","Pie","Pin","Ping","Po",
                "Pu","Qi","Qia","Qian","Qiang","Qiao","Qie","Qin","Qing","Qiong","Qiu","Qu",
                "Quan","Que","Qun","Ran","Rang","Rao","Re","Ren","Reng","Ri","Rong","Rou",
                "Ru","Ruan","Rui","Run","Ruo","Sa","Sai","San","Sang","Sao","Se","Sen",
                "Seng","Sha","Shai","Shan","Shang","Shao","She","Shen","Sheng","Shi","Shou","Shu",
                "Shua","Shuai","Shuan","Shuang","Shui","Shun","Shuo","Si","Song","Sou","Su","Suan",
                "Sui","Sun","Suo","Ta","Tai","Tan","Tang","Tao","Te","Teng","Ti","Tian",
                "Tiao","Tie","Ting","Tong","Tou","Tu","Tuan","Tui","Tun","Tuo","Wa","Wai",
                "Wan","Wang","Wei","Wen","Weng","Wo","Wu","Xi","Xia","Xian","Xiang","Xiao",
                "Xie","Xin","Xing","Xiong","Xiu","Xu","Xuan","Xue","Xun","Ya","Yan","Yang",
                "Yao","Ye","Yi","Yin","Ying","Yo","Yong","You","Yu","Yuan","Yue","Yun",
                "Za", "Zai","Zan","Zang","Zao","Ze","Zei","Zen","Zeng","Zha","Zhai","Zhan",
                "Zhang","Zhao","Zhe","Zhen","Zheng","Zhi","Zhong","Zhou","Zhu","Zhua","Zhuai","Zhuan",
                "Zhuang","Zhui","Zhun","Zhuo","Zi","Zong","Zou","Zu","Zuan","Zui","Zun","Zuo"
           };

        /// <summary>
        /// 汉字转换成全拼的拼音
        /// </summary>
        /// <param name="Chstr">汉字字符串</param>
        /// <returns>转换后的拼音字符串</returns>
        public static string convertCh(string Chstr)
        {
            Regex reg = new Regex("^[\u4e00-\u9fa5]$");//验证是否输入汉字
            byte[] arr = new byte[2];
            string pystr = "";
            int asc = 0, M1 = 0, M2 = 0;
            char[] mChar = Chstr.ToCharArray();//获取汉字对应的字符数组
            for (int j = 0; j < mChar.Length; j++)
            {
                //如果输入的是汉字
                if (reg.IsMatch(mChar[j].ToString()))
                {
                    arr = System.Text.Encoding.Default.GetBytes(mChar[j].ToString());
                    M1 = (short)(arr[0]);
                    M2 = (short)(arr[1]);
                    asc = M1 * 256 + M2 - 65536;
                    if (asc > 0 && asc < 160)
                    {
                        pystr += mChar[j];
                    }
                    else
                    {
                        switch (asc)
                        {
                            case -9254:
                                pystr += "Zhen"; break;
                            case -8985:
                                pystr += "Qian"; break;
                            case -5463:
                                pystr += "Jia"; break;
                            case -8274:
                                pystr += "Ge"; break;
                            case -5448:
                                pystr += "Ga"; break;
                            case -5447:
                                pystr += "La"; break;
                            case -4649:
                                pystr += "Chen"; break;
                            case -5436:
                                pystr += "Mao"; break;
                            case -5213:
                                pystr += "Mao"; break;
                            case -3597:
                                pystr += "Die"; break;
                            case -5659:
                                pystr += "Tian"; break;
                            default:
                                for (int i = (getValue.Length - 1); i >= 0; i--)
                                {
                                    if (getValue[i] <= asc) //判断汉字的拼音区编码是否在指定范围内
                                    {
                                        pystr += getName[i];//如果不超出范围则获取对应的拼音
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                }
                else//如果不是汉字
                {
                    pystr += mChar[j].ToString();//如果不是汉字则返回
                }
            }
            return pystr;//返回获取到的汉字拼音
        }
    }
}
