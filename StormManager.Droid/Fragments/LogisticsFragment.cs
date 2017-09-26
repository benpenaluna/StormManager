
using Android.App;
using Android.OS;
using Android.Views;

namespace StormManager.Droid.Fragments
{
    public class LogisticsFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static LogisticsFragment NewInstance()
        {
            var frag = new LogisticsFragment { Arguments = new Bundle() };
            return frag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.logistics_layout, null);
        }
    }
}