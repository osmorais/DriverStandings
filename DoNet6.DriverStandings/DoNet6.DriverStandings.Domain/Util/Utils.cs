﻿using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Domain.Util
{
    public class Utils
    {
        public static List<T> DataTableToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception)
                        { }
                    }
                }
                return objT;
            }).ToList();
        }

        public static List<Lap> DataTableToListLap(DataTable dt)
        {
            var laps = new List<Lap>();
            foreach (DataRow row in dt.Rows)
            {
                Lap lap = new Lap
                {
                    LapId = Convert.ToInt32(row["LapId"]),
                    LapTime = DateTime.Parse(row["LapTime"].ToString()),
                    AverageSpeed = double.Parse(row["AverageSpeed"].ToString()),
                    LapNumber = Convert.ToInt32(row["LapNumber"])
                };

                laps.Add(lap);
            }
            return laps;
        }

        public static List<Driver> DataTableToListDriver(DataTable dt)
        {
            var drivers = new List<Driver>();
            foreach (DataRow row in dt.Rows)
            {
                Driver drive = new Driver
                {
                    DriverId = Convert.ToInt32(row["DriverId"]),
                    DriverCode = row["DriverCode"].ToString(),
                    Name = row["Name"].ToString(),
                    TotalTime = DateTime.Parse(row["TotalTime"].ToString())
                };

                drivers.Add(drive);
            }
            return drivers;
        }

        public static T DataTableToObject<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception)
                        { }
                    }
                }
                return objT;
            }).FirstOrDefault();
        }

        public static DateTime timeFormat(TimeSpan time)
        {
            return DateTime.Parse($"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}.{time.Milliseconds:D3}");
        }

        public static bool hasSpecialCharacters(string text)
        {
            return Regex.IsMatch(text, (@"[^a-zA-Z0-9' '\.]"));
        }

        public static bool hasNumber(string text)
        {
            int hasDigit = 0;
            foreach (char c in text)
            {
                if (Char.IsDigit(c)) { hasDigit++; }
            }

            return hasDigit > 0;
        }
    }
}
