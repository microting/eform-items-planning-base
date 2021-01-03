/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microting.ItemsPlanningBase.Infrastructure.Data;
using Microting.ItemsPlanningBase.Infrastructure.Data.Factories;
using NUnit.Framework;

namespace Microting.ItemsPlanningBase.Tests
{
    [TestFixture]
    public abstract class DbTestFixture
    {
        protected ItemsPlanningPnDbContext DbContext;
        private string _connectionString;


        private void GetContext(string connectionStr)
        {
            ItemsPlanningPnContextFactory contextFactory = new ItemsPlanningPnContextFactory();
            DbContext = contextFactory.CreateDbContext(new[] {connectionStr});

            DbContext.Database.Migrate();
            DbContext.Database.EnsureCreated();
        }

        [SetUp]
        public void Setup()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
              //  _connectionString = @"data source=(LocalDb)\SharedInstance;Initial catalog=items-planning-pn-tests;Integrated Security=true";
                _connectionString = @"Data Source=.\SQLEXPRESS;Database=123_iptest;Integrated Security=True";
            }
            else
            {
                _connectionString =
                    @"Server = localhost; port = 3306; Database = items-planning-pn-tests; user = root; password = secretpassword; Convert Zero Datetime = true;";
            }

            GetContext(_connectionString);


            DbContext.Database.SetCommandTimeout(300);

            try
            {
                ClearDb();
            }
            catch
            {
                DbContext.Database.Migrate();
            }

            DoSetup();
        }

        [TearDown]
        public void TearDown()
        {
            ClearDb();

            ClearFile();

            DbContext.Dispose();
        }

        private void ClearDb()
        {
            List<string> modelNames = new List<string>();
            modelNames.Add("Items");
            modelNames.Add("ItemVersions");
            modelNames.Add("PlanningCases");
            modelNames.Add("PlanningCaseVersions");
            modelNames.Add("Plannings");
            modelNames.Add("PlanningVersions");
            modelNames.Add("UploadedDataVersions");
            modelNames.Add("UploadedDatas");
            modelNames.Add("PlanningCaseSites");
            modelNames.Add("PlanningCaseSiteVersions");
            modelNames.Add("PlaningNameTranslations");
            modelNames.Add("PlaningNameTranslationsVersions");

            foreach (var modelName in modelNames)
            {
                try
                {
                    string sqlCmd;
                    if (DbContext.Database.IsMySql())
                    {
                        sqlCmd = $"SET FOREIGN_KEY_CHECKS = 0;TRUNCATE `items-planning-pn-tests`.`{modelName}`";
                    }
                    else
                    {
                        sqlCmd = $"DELETE FROM [{modelName}]";
                    }

                    DbContext.Database.ExecuteSqlCommand(sqlCmd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string path;

        private void ClearFile()
        {
            path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            path = System.IO.Path.GetDirectoryName(path).Replace(@"file:\", "");

            string picturePath = path + @"\output\dataFolder\picture\Deleted";

            DirectoryInfo diPic = new DirectoryInfo(picturePath);

            try
            {
                foreach (FileInfo file in diPic.GetFiles())
                {
                    file.Delete();
                }
            }
            catch
            {
            }
        }

        protected virtual void DoSetup()
        {
        }
    }
}