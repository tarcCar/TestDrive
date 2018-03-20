﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using TestDrive.Data;
using TestDrive.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]
namespace TestDrive.Droid
{
    public class SQLite_android : ISQLite
    {
        private const string ArquivoDB = "agendamento.db3";

        public SQLiteConnection PegarConexao()
        {
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, ArquivoDB);
            return new SQLiteConnection(caminhoDB);
        }
    }
}