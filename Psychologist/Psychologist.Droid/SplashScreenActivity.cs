using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;

namespace Psychologist.UI.Droid
{
    [Activity(Theme = "@style/Theme.Splash",   Icon = "@drawable/ic_launcher_foreground", MainLauncher=true, NoHistory = true)]  
    public class SplashScreenActivity:AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);  
            var mainActivityIntent = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivityIntent);
        }
    }
}