using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace StormManager.Droid.Fragments
{
    public class OperationsFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static OperationsFragment NewInstance()
        {
            var frag = new OperationsFragment { Arguments = new Bundle() };
            return frag;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.operations_layout, null);
        }
    }
}