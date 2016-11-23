using Android.Support.V4.View;
using Android.Views;
using System;

namespace XamarinVehiclesSound
{
    internal class ParallaxPageTransformer : ViewPager.IPageTransformer
    {
        private int viewToParallax;

        public ParallaxPageTransformer(int viewToParallax)
        {
            this.viewToParallax = viewToParallax;
        }
        public IntPtr Handle
        {
            get
            {
                return (IntPtr)0;
            }
        }

        public void Dispose()
        {
           
        }

        public void TransformPage(View page, float position)
        {
            int pageWidth = page.Width;
            if (position < -1)
                page.Alpha = 1;
            else if (position <= 1)
                page.FindViewById(viewToParallax).TranslationX = (-position) * (pageWidth / 2);
            else
                page.Alpha = 1;
        }
    }
}