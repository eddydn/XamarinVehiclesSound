using System;
using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Widget;
using Android.Media;
using Android.Views;
using System.Linq;

namespace XamarinVehiclesSound
{
    [Activity(Label = "XamarinVehiclesSound", MainLauncher = true, Icon = "@drawable/icon",Theme ="@style/AppTheme")]
    public class MainActivity : AppCompatActivity,ViewPager.IOnPageChangeListener
    {
        private string[] vehicles = {
            "aerobatic_aircraft",
            "airplane",
            "air_force_aircraft",
            "bicycle",
            "bulldozer",
            "cruise_ship",
            "custom",
            "drugster",
            "electric_train",
            "excavator",
            "ferrari",
            "fire_truck",
            "forage_harvester",
            "formula_1",
            "general_lee",
            "hang_gliding",
            "helicopter",
            "hovercraft",
            "kitt",
            "lamborghini",
            "lightning_mcqueen",
            "maserati",
            "milk_truck",
            "minimoto",
            "mining_truck",
            "monster_truck",
            "motocross",
            "motogp",
            "motorboat",
            "old_tractor",
            "police_car",
            "porsche",
            "quad",
            "rocket",
            "sail",
            "scooter",
            "seaplane",
            "snowcat",
            "space_shuttle",
            "steam_train",
            "submarine",
            "tractor",
            "tram",
            "truck",
            "truck_mixer",
            "vespa",
            "viper",
            "watercraft"
};

        ViewPagerAdapter adapter;
        ViewPager pager;
        TextView txtName;
        MediaPlayer player;

        int index;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            //Set Toolbar
            Android.Support.V7.Widget.Toolbar myToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolBar);
            SetSupportActionBar(myToolbar);

            //Random array
            Random rd = new Random();
            vehicles = vehicles.OrderBy(Xamarin => rd.Next()).ToArray();

            adapter = new ViewPagerAdapter(this, vehicles);
            pager = FindViewById<ViewPager>(Resource.Id.pager);
            txtName = FindViewById<TextView>(Resource.Id.txtName);
            txtName.Text = vehicles[0];
            pager.Adapter = adapter;
            pager.SetOnPageChangeListener(this);
            pager.SetPageTransformer(false, new ParallaxPageTransformer(Resource.Id.pager));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if(id == Resource.Id.action_sound)
            {
                int soundId = this.Resources.GetIdentifier(vehicles[index], "raw", this.PackageName);
                if(player == null)
                {
                    player = MediaPlayer.Create(this, soundId);
                    player.Looping = false;
                    player.SetVolume(1.0f, 1.0f);
                    player.Start();
                }
                else
                {
                    player.Stop();
                    player.Release();
                    player = null;

                    player = MediaPlayer.Create(this, soundId);
                    player.Looping = false;
                    player.SetVolume(1.0f, 1.0f);
                    player.Start();

                }
            }
            else if(id == Resource.Id.action_voice)
            {
                int soundId = this.Resources.GetIdentifier("voice_"+vehicles[index], "raw", this.PackageName);
                if (player == null)
                {
                    player = MediaPlayer.Create(this, soundId);
                    player.Looping = false;
                    player.SetVolume(1.0f, 1.0f);
                    player.Start();
                }
                else
                {
                    player.Stop();
                    player.Release();
                    player = null;

                    player = MediaPlayer.Create(this, soundId);
                    player.Looping = false;
                    player.SetVolume(1.0f, 1.0f);
                    player.Start();

                }
            }
            return true;
        }


        public void OnPageScrollStateChanged(int state)
        {
           
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            
        }

        public void OnPageSelected(int position)
        {
            txtName.Text = GetNameVehicles(vehicles[position]);
            index = position;
            if(player != null && player.IsPlaying)
            {
                player.Stop();
                player.Release();
                player = null;
            }

        }

        private string GetNameVehicles(string v)
        {
            return v.Replace("_", " ").ToUpper();
        }
    }
}