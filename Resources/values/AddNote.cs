using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EzNote.Resources.values
{
    [Activity(Label = "AddNote")]
    public class AddNote : Activity
    {
        Button btnAdd;
        EditText txtItemDescription;
        EditText txtItemTitle;

        DatabaseManager objdb = new DatabaseManager();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddItem);

            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            txtItemDescription = FindViewById<EditText>(Resource.Id.txtItemDescription);
            txtItemTitle = FindViewById<EditText>(Resource.Id.txtItemTitle);
            btnAdd.Click += OnBtnAddClick;
        }

        private void OnBtnAddClick(object sender, EventArgs e)
        {
            if (txtItemTitle.Text != "" && txtItemDescription.Text != "")
            {
                objdb.AddNote(txtItemTitle.Text, txtItemDescription.Text);
                Toast.MakeText(this, "Note Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }

        }
    }
}