using System;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    2018-01.25
    FlickerKiller app som förhindrar skärmen att skaka.
    FadeInAndOut algoritm funnen på nätet:
    https://stackoverflow.com/questions/12497826/better-algorithm-to-fade-a-winform
*/

namespace FlickerKiller
{
    public partial class FlickerKiller : Form
    {
        public FlickerKiller()
        {
            InitializeComponent();
        }

        private async void FadeOutAndIn(Form o, int interval = 80)
        {
            while (true)
            {
                //Object is fully visible. Fade it out
                do
                {
                    await Task.Delay(interval);
                    o.Opacity -= 0.05;
                } while (o.Opacity > 0.20);
                o.Opacity = 0.20; //make fully invisible  

                //Object is not fully invisible. Fade it in
                do
                {
                    await Task.Delay(interval);
                    o.Opacity += 0.05;
                } while (o.Opacity < 0.50);
                o.Opacity = 0.50; //make fully visible  
            }
        }

        private void FlickerKiller_Load(object sender, EventArgs e)
        {
            FadeOutAndIn(this, 500);
        }
    }
}
