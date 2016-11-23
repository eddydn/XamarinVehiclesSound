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
using Android.Support.V4.View;
using Java.Lang;

namespace XamarinVehiclesSound
{
    class ViewPagerAdapter : PagerAdapter
    {
        Activity activity;
        string[] vehicles;
        LayoutInflater inflater;



        public ViewPagerAdapter(Activity activity, string[] vehicles)
        {
            this.activity = activity;
            this.vehicles = vehicles;
        }


        public override int Count
        {
            get
            {
                return vehicles.Length;
            }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            inflater = (LayoutInflater)activity.BaseContext.GetSystemService(Context.LayoutInflaterService);
            View itemView = inflater.Inflate(Resource.Layout.viewpager_item, container, false);

            ImageView img = itemView.FindViewById<ImageView>(Resource.Id.imageVehicles);
            int vehiclesId = activity.Resources.GetIdentifier(vehicles[position], "drawable", activity.PackageName);
            img.SetImageResource(vehiclesId);

            container.AddView(itemView);
            return itemView;
        }


        public override void DestroyItem(View container, int position, Java.Lang.Object @object)
        {
            ((ViewGroup)container).RemoveView((View)@object);
        }
    }
}