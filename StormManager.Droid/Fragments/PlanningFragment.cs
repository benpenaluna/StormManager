
using Android.App;
using Android.OS;
using Android.Views;

namespace StormManager.Droid.Fragments
{
    public class PlanningFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static PlanningFragment NewInstance()
        {
            var frag = new PlanningFragment { Arguments = new Bundle() };
            return frag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.planning_layout, null);
        }
    }
}